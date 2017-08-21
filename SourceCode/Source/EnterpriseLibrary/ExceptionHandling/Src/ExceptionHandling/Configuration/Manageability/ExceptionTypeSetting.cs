﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System.Collections.Generic;
using System.Configuration;
using System.Management.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Manageability;
namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.Manageability
{
	[ManagementEntity]
	public class ExceptionTypeSetting : ConfigurationSetting
	{
		private static readonly PublishedInstancesManager<ExceptionTypeSetting, PublishedInstanceKey>
			publishedInstancesManager = new PublishedInstancesManager<ExceptionTypeSetting, PublishedInstanceKey>();
		private string name;
		private string policy;
		private string exceptionTypeName;
		private string postHandlingAction;
		public ExceptionTypeSetting(ConfigurationElement sourceElement,
		                              string name,
		                              string exceptionTypeName,
		                              string postHandlingAction)
			: base(sourceElement)
		{
			this.name = name;
			this.exceptionTypeName = exceptionTypeName;
			this.postHandlingAction = postHandlingAction;
		}
		public override void Publish()
		{
			PublishedInstanceKey key = new PublishedInstanceKey(this.ApplicationName, this.SectionName, this.policy, this.Name);
			publishedInstancesManager.Publish(this, key);
		}
		public override void Revoke()
		{
			PublishedInstanceKey key = new PublishedInstanceKey(this.ApplicationName, this.SectionName, this.policy, this.Name);
			publishedInstancesManager.Revoke(this, key);
		}
		public static void ClearPublishedInstances()
		{
			publishedInstancesManager.ClearPublishedInstances();
		}
		[ManagementKey]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		[ManagementKey]
		[ManagementQualifier("Override", Value = "ApplicationName")]
		public override string ApplicationName
		{
			get { return base.ApplicationName; }
			set { base.ApplicationName = value; }
		}
		[ManagementKey]
		[ManagementQualifier("Override", Value = "SectionName")]
		public override string SectionName
		{
			get { return base.SectionName; }
			set { base.SectionName = value; }
		}
		[ManagementProbe]
		public string ExceptionTypeName
		{
			get { return exceptionTypeName; }
			set { exceptionTypeName = value; }
		}
		[ManagementKey]
		public string Policy
		{
			get { return policy; }
			set { policy = value; }
		}
		[ManagementConfiguration]
		public string PostHandlingAction
		{
			get { return postHandlingAction; }
			set { postHandlingAction = value; }
		}
		[ManagementEnumerator]
		public static IEnumerable<ExceptionTypeSetting> GetInstances()
		{
			return publishedInstancesManager.GetInstances<ExceptionTypeSetting>();
		}
		[ManagementBind]
		public static ExceptionTypeSetting BindInstance(string ApplicationName, string SectionName, string Policy, string Name)
		{
			PublishedInstanceKey key = new PublishedInstanceKey(ApplicationName, SectionName, Policy, Name);
			return publishedInstancesManager.BindInstance<ExceptionTypeSetting>(key);
		}
		protected override bool SaveChanges(ConfigurationElement sourceElement)
		{
			return false; 
		}
		private struct PublishedInstanceKey
		{
			private readonly string applicationName;
			private readonly string sectionName;
			private readonly string policy;
			private readonly string name;
			public PublishedInstanceKey(string applicationName, string sectionName, string policy, string name)
			{
				this.applicationName = applicationName;
				this.sectionName = sectionName;
				this.policy = policy;
				this.name = name;
			}
			public override int GetHashCode()
			{
				return this.name != null ? this.name.GetHashCode() : 0;
			}
			public override bool Equals(object obj)
			{
				if (obj is PublishedInstanceKey)
				{
					PublishedInstanceKey otherKey = (PublishedInstanceKey) obj;
					return this.name == otherKey.name
					       && this.applicationName == otherKey.applicationName
					       && this.sectionName == otherKey.sectionName
					       && this.policy == otherKey.policy;
				}
				return false;
			}
		}
	}
}
