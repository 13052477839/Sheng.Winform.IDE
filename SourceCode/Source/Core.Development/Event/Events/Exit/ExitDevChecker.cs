﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sheng.SailingEase.Core.Development
{
    static class ExitDevChecker
    {
        public static void CheckWarning(ExitDev entity)
        {
            entity.Warning.Clear();
        }
    }
}
