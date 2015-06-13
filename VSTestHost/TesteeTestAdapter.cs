﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.Common;
using Microsoft.VisualStudio.TestTools.Execution;
using Microsoft.VisualStudio.TestTools.TestAdapter;

namespace Microsoft.VisualStudioTools.VSTestHost.Internal {
    /// <summary>
    /// Acts as a communication proxy between VS instances.
    /// 
    /// This class is instantiated in the client VS.
    /// </summary>
    class TesteeTestAdapter : MarshalByRefObject, ITestAdapter, IDisposable {
        private IRunContext _runContext;
        private readonly Dictionary<string, ITestAdapter> _adapters = new Dictionary<string, ITestAdapter>();

        public const string Url = "vstest";

        public TesteeTestAdapter() { }

        public void Dispose() {
            Dispose(true);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                RemotingServices.Disconnect(this);
            }
        }

        public bool IsInitialized {
            get {
                return _runContext != null;
            }
        }

        private IEnumerable<ITestAdapter> GetAdapters() {
            lock (_adapters) {
                return _adapters.Values.ToList();
            }
        }

        private ITestAdapter GetAdapter(string adapterName) {
            ITestAdapter adapter;
            lock (_adapters) {
                if (_adapters.TryGetValue(adapterName, out adapter)) {
                    return adapter;
                }
            }

            adapter = (ITestAdapter)Activator.CreateInstance(Type.GetType(adapterName));
            if (_runContext != null) {
                adapter.Initialize(_runContext);
            }

            lock (_adapters) {
                try {
                    _adapters.Add(adapterName, adapter);
                } catch (ArgumentException) {
                    adapter.Cleanup();
                    adapter = _adapters[adapterName];
                }
            }
            return adapter;
        }


        public void Initialize(IRunContext runContext) {
            _runContext = runContext;
            foreach (var adapter in GetAdapters()) {
                adapter.Initialize(runContext);
            }
        }

        public void PreTestRunFinished(IRunContext runContext) {
            foreach (var adapter in GetAdapters()) {
                adapter.PreTestRunFinished(runContext);
            }
        }

        public void ReceiveMessage(object message) {
            foreach (var adapter in GetAdapters()) {
                adapter.ReceiveMessage(message);
            }
        }

        public void AbortTestRun() {
            foreach (var adapter in GetAdapters()) {
                adapter.AbortTestRun();
            }
        }

        public void Cleanup() {
            _runContext = null;
            foreach (var adapter in GetAdapters()) {
                adapter.Cleanup();
            }
            _adapters.Clear();
        }

        public void PauseTestRun() {
            foreach (var adapter in GetAdapters()) {
                adapter.PauseTestRun();
            }
        }

        public void ResumeTestRun() {
            foreach (var adapter in GetAdapters()) {
                adapter.ResumeTestRun();
            }
        }

        private bool TryGetProperty(
            ITestElement testElement,
            IRunContext runContext,
            string propertyName,
            out string value
        ) {
            value = null;

            var runProps = runContext.RunConfig.TestRun.RunConfiguration.TestSettingsProperties;

            if (testElement.Properties.ContainsKey(propertyName)) {
                value = testElement.Properties[propertyName] as string;
                return value != null;
            }
            return runProps.TryGetValue(propertyName, out value);
        }

        public void Run(ITestElement testElement, ITestContext testContext) {
            var testAdapter = GetAdapter(testElement.Adapter);

            using (var screenRecorder = StartSceenRecorder(testElement, _runContext)) {
                try {
                    testAdapter.Run(testElement, testContext);
                } catch (Exception ex) {
                    var message = new TextTestResultMessage(
                        _runContext.RunConfig.TestRun.Id,
                        testElement,
                        ex.ToString()
                    );
                    testContext.ResultSink.AddResult(message);
                }

                if (screenRecorder != null && !string.IsNullOrEmpty(screenRecorder.Failure)) {
                    System.Windows.Forms.MessageBox.Show(screenRecorder.Failure);
                    var message = new TextTestResultMessage(
                        _runContext.RunConfig.TestRun.Id,
                        testElement,
                        screenRecorder.Failure
                    );
                    testContext.ResultSink.AddResult(message);
                }
            }
        }

        private ScreenRecorder StartSceenRecorder(ITestElement testElement, IRunContext runContext) {
            string screenCapture;

            if (!TryGetProperty(testElement, _runContext, VSTestProperties.ScreenCapture.Key, out screenCapture) ||
                string.IsNullOrEmpty(screenCapture)) {
                return null;
            }
            try {
                if (!Path.IsPathRooted(screenCapture)) {
                    screenCapture = Path.Combine(
                        _runContext.RunConfig.TestRun.RunConfiguration.RunDeploymentOutDirectory,
                        screenCapture
                    );
                }
            } catch (ArgumentException) {
                return null;
            }

            screenCapture = screenCapture.Replace("$id$", testElement.HumanReadableId);
            screenCapture = screenCapture.Replace("$date$", DateTime.Today.ToShortDateString());
            var screenRecorder = new ScreenRecorder(screenCapture);

            string intervalString;
            int interval;
            if (TryGetProperty(testElement, runContext, VSTestProperties.ScreenCapture.IntervalKey, out intervalString) &&
                int.TryParse(intervalString, out interval)) {
                screenRecorder.Interval = TimeSpan.FromMilliseconds(interval);
            } else {
                screenRecorder.Interval = TimeSpan.FromSeconds(1);
            }

            return screenRecorder;
        }

        public void StopTestRun() {
            foreach (var adapter in GetAdapters()) {
                adapter.StopTestRun();
            }
        }
    }
}
