﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Practices.EnterpriseLibrary.Logging.Database.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.Design;
[assembly : ConfigurationDesignManager(typeof(LoggingDatabaseConfigurationDesignManager), typeof(LoggingConfigurationDesignManager))]
[assembly : ConfigurationDesignManager(typeof(LoggingDatabaseConfigurationDesignManager), typeof(ConnectionStringsConfigurationDesignManager))]
[assembly : ReflectionPermission(SecurityAction.RequestMinimum, MemberAccess = true)]
[assembly : SecurityPermission(SecurityAction.RequestMinimum)]
[assembly : ComVisible(false)]
[assembly : AssemblyTitle("Enterprise Library Logging and Instrumentation Database Provider Design")]
[assembly : AssemblyDescription("Enterprise Library Logging and Instrumentation Database Provider Design")]
[assembly : AssemblyVersion("4.1.0.0")]
[assembly : AllowPartiallyTrustedCallers]
[assembly : SecurityTransparent]
