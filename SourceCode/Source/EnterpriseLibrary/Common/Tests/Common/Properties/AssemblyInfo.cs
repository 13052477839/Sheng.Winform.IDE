﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System.Management.Instrumentation;
using System.Reflection;
using System.Security;
[assembly: AssemblyTitle("Enterprise Library Shared Library Tests")]
[assembly: AssemblyDescription("Enterprise Library Shared Library Tests")]
[assembly: AssemblyVersion("4.1.0.0")]
[assembly: Instrumented(@"root\EnterpriseLibrary")]
[assembly: WmiConfiguration(@"root\EnterpriseLibrary", HostingModel = ManagementHostingModel.Decoupled, IdentifyLevel = false)]
[assembly: AllowPartiallyTrustedCallers]
