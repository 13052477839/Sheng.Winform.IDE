﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
{
	public class ExceptionPolicyRetriever : IConfigurationDataRetriever
	{
		public object GetConfigurationObject(string id, IConfigurationSource configurationSource)
		{
			return new ExceptionHandlingConfigurationView(configurationSource).GetExceptionPolicyData(id);
		}
	}
}
