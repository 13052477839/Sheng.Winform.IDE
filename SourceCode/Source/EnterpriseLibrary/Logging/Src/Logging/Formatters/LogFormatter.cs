﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
namespace Microsoft.Practices.EnterpriseLibrary.Logging.Formatters
{
	public abstract class LogFormatter : ILogFormatter
	{
		public abstract string Format(LogEntry log);
	}
}
