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
using System.Xml;
using Sheng.SailingEase.Core;
using Sheng.SailingEase.Core.Development;
using Sheng.SailingEase.Kernal;
namespace Sheng.SailingEase.Core.Development
{
    [Serializable]
    class SaveDataDev : SaveDataEvent, IEventEditorSupport, IWarningable
    {
        [NonSerialized]
        private EventEditorAdapterAbstract _editorAdapater;
        [ObjectCompare(Ignore = true)]
        public EventEditorAdapterAbstract EditorAdapter
        {
            get
            {
                if (_editorAdapater == null)
                    _editorAdapater = new SaveDataDevEditorAdapter(this);
                return _editorAdapater;
            }
        }
        public static EnumEventDataSource AllowDataSourceType
        {
            get
            {
                return (EnumEventDataSource)(EnumEventDataSource.FormElement | EnumEventDataSource.System);
            }
        }
        public static UIElementEntityTypeCollection AllowFormElementControlType
        {
            get
            {
                UIElementEntityTypeCollection collection = new UIElementEntityTypeCollection();
                collection.Add(typeof(UIElementTextBoxEntity));
                collection.Add(typeof(UIElementComboBoxEntity));
                return collection;
            }
        }
        public string WarningSignName
        {
            get { return this.Name; }
        }
        [NonSerialized]
        private WarningSign _warning;
        [ObjectCompare(Ignore = true)]
        public WarningSign Warning
        {
            get
            {
                if (_warning == null)
                    _warning = new WarningSign(this);
                return _warning;
            }
            set { _warning = value; }
        }
        public void CheckWarning()
        {
            SaveDataDevChecker.CheckWarning(this);
        }
    }
}
