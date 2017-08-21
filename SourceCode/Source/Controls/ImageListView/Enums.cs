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
namespace Sheng.SailingEase.Controls
{
    [Flags]
    public enum ImageListViewItemState
    {
        None = 0,
        Selected = 1,
        Focused = 2,
        Hovered = 4,
    }
    public enum ImageListViewItemVisibility
    {
        NotVisible,
        PartiallyVisible,
        Visible,
    }
}
