﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudioTools.VSTestHost.Internal {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.VisualStudioTools.VSTestHost.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to restart Visual Studio because there is no active test run..
        /// </summary>
        internal static string CannotReconnectNoRunContext {
            get {
                return ResourceManager.GetString("CannotReconnectNoRunContext", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to attach debugger to Visual Studio process..
        /// </summary>
        internal static string FailedToAttach {
            get {
                return ResourceManager.GetString("FailedToAttach", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to connect to Visual Studio instance. Ensure VSTestHost is installed..
        /// </summary>
        internal static string FailedToConnect {
            get {
                return ResourceManager.GetString("FailedToConnect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to resume test run..
        /// </summary>
        internal static string FailedToResume {
            get {
                return ResourceManager.GetString("FailedToResume", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to determine bounds for screen capture..
        /// </summary>
        internal static string InvalidScreenBounds {
            get {
                return ResourceManager.GetString("InvalidScreenBounds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Some required configuration values were missing.
        ///    VSApplication: &apos;{0}&apos;
        ///    VSExecutable: &apos;{1}&apos;
        ///    VSVersion: &apos;{2}&apos;
        ///    VSHive: &apos;{3}&apos;.
        /// </summary>
        internal static string MissingConfigurationValues {
            get {
                return ResourceManager.GetString("MissingConfigurationValues", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Visual Studio is no longer running..
        /// </summary>
        internal static string NoClient {
            get {
                return ResourceManager.GetString("NoClient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no active test run..
        /// </summary>
        internal static string NoRunContext {
            get {
                return ResourceManager.GetString("NoRunContext", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No service provider is available in the current context..
        /// </summary>
        internal static string NoServiceProvider {
            get {
                return ResourceManager.GetString("NoServiceProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to communicate with Visual Studio process during {0}: {1}.
        /// </summary>
        internal static string RemotingError {
            get {
                return ResourceManager.GetString("RemotingError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to communicate with Visual Studio process during {0}: {1}
        ///{2}.
        /// </summary>
        internal static string RemotingErrorDebug {
            get {
                return ResourceManager.GetString("RemotingErrorDebug", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Retrying call into Visual Studio process from {0}..
        /// </summary>
        internal static string RetryRemoteCall {
            get {
                return ResourceManager.GetString("RetryRemoteCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempted to set service provider multiple time..
        /// </summary>
        internal static string ServiceProviderAlreadySet {
            get {
                return ResourceManager.GetString("ServiceProviderAlreadySet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to launch {1} ({0}, {2}{3}).
        /// </summary>
        internal static string VSFailedToLaunch {
            get {
                return ResourceManager.GetString("VSFailedToLaunch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Visual Studio failed to start within {0} seconds..
        /// </summary>
        internal static string VSLaunchTimeout {
            get {
                return ResourceManager.GetString("VSLaunchTimeout", resourceCulture);
            }
        }
    }
}
