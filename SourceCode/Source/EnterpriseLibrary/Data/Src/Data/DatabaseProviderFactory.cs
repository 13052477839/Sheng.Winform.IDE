﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
namespace Microsoft.Practices.EnterpriseLibrary.Data
{
	public class DatabaseProviderFactory : NameTypeFactoryBase<Database>
    {
		protected DatabaseProviderFactory()
			: base()
		{
		}
        public DatabaseProviderFactory(IConfigurationSource configurationSource)
			: base(configurationSource)
        {}
	}
}
