﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace Sheng.SIMBE.SEControl.Docking
{
	[Flags]
	[Serializable]
	[Editor(typeof(DockAreasEditor), typeof(System.Drawing.Design.UITypeEditor))]
	public enum DockAreas
	{
		Float = 1,
		DockLeft = 2,
		DockRight = 4,
		DockTop = 8,
		DockBottom = 16,
		Document = 32
	}
	public enum DockState
	{
		Unknown = 0,
		Float = 1,
		DockTopAutoHide = 2,
		DockLeftAutoHide = 3,
		DockBottomAutoHide = 4,
		DockRightAutoHide = 5,
		Document = 6,
		DockTop = 7,
		DockLeft = 8,
		DockBottom = 9,
		DockRight = 10,
		Hidden = 11
	}
	public enum DockAlignment
	{
		Left,
		Right,
		Top,
		Bottom
	}
	public enum DocumentStyle
	{
		DockingMdi,
		DockingWindow,
		DockingSdi,
		SystemMdi,
	}
    public enum TabAlign
    {
        Top,
        Bottom
    }
}
