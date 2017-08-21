﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
namespace Microsoft.Practices.EnterpriseLibrary.Logging.Database.Configuration.Design.Properties {
    using System;
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Practices.EnterpriseLibrary.Logging.Database.Configuration.Design.Prope" +
                            "rties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        internal static string AddCategoryStoredProcNameDescription {
            get {
                return ResourceManager.GetString("AddCategoryStoredProcNameDescription", resourceCulture);
            }
        }
        internal static string CategoryGeneral {
            get {
                return ResourceManager.GetString("CategoryGeneral", resourceCulture);
            }
        }
        internal static string DatabaseInstanceDescription {
            get {
                return ResourceManager.GetString("DatabaseInstanceDescription", resourceCulture);
            }
        }
        internal static string DatabaseTraceListenerName {
            get {
                return ResourceManager.GetString("DatabaseTraceListenerName", resourceCulture);
            }
        }
        internal static string DatabaseTraceListenerUICommandLongText {
            get {
                return ResourceManager.GetString("DatabaseTraceListenerUICommandLongText", resourceCulture);
            }
        }
        internal static string DatabaseTraceListenerUICommandText {
            get {
                return ResourceManager.GetString("DatabaseTraceListenerUICommandText", resourceCulture);
            }
        }
        internal static string WriteStoredProcNameDescription {
            get {
                return ResourceManager.GetString("WriteStoredProcNameDescription", resourceCulture);
            }
        }
    }
}
