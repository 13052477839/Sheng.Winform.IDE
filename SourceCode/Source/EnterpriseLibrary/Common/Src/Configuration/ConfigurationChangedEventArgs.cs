﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    public delegate void ConfigurationChangedEventHandler(object sender, ConfigurationChangedEventArgs e);
    [Serializable]
    public class ConfigurationChangedEventArgs : EventArgs
    {
        private readonly string sectionName;
        public ConfigurationChangedEventArgs(string sectionName)
        {
            this.sectionName = sectionName;
        }
        public string SectionName
        {
            get { return sectionName; }
        }
    }
}
