﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.Collections.Generic;
using System.Text;
namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder
{
	internal class ReflectionCachePolicy : IReflectionCachePolicy
	{
		private ConfigurationReflectionCache reflectionCache;
		internal ReflectionCachePolicy(ConfigurationReflectionCache reflectionCache)
		{
			this.reflectionCache = reflectionCache;
		}
		public ConfigurationReflectionCache ReflectionCache
		{
			get { return this.reflectionCache; }
		}
	}
}
