using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;
using Sheng.SailingEase.Core;
using Sheng.SailingEase.ComponentModel;
using Sheng.SailingEase.Kernal;
using Sheng.SailingEase.Controls;
using System.Diagnostics;
using System.Xml.Linq;

namespace Sheng.SailingEase.Core
{
    /// <summary>
    /// ��ʾ�б�ؼ���ʵ����
    /// </summary>
    [Serializable]
    [NormalUIElementEntityProvideAttribute("FormElementDataListEntity", 0x000066)]
    public class UIElementDataListEntity:UIElement
    {
        #region �ܱ���������

        [NonSerialized]
        private UIElementDataListColumnEntityTypesAbstract _columnEntityTypesAdapter = UIElementDataListColumnEntityTypes.Instance;
        /// <summary>
        /// ����������������
        /// �ڼ̳е��������ô����ԣ���ʹFromXml������ʼ����Ӧ�����ͣ���IDE�г�ʼ��DEV��β�����ͣ�SHELL�г�ʼ��EX��β������
        /// </summary>
        protected UIElementDataListColumnEntityTypesAbstract ColumnEntityTypesAdapter
        {
            get { return this._columnEntityTypesAdapter; }
            set { this._columnEntityTypesAdapter = value; }
        }

        #endregion

        #region ��������

        //private SEPaginationDataGridView.EnumNavigationLocation _navigationLocation =
        //    SEPaginationDataGridView.EnumNavigationLocation.Bottom;
        ///// <summary>
        ///// ��ҳ����λ��
        ///// </summary>
        //[DefaultValue(SEPaginationDataGridView.EnumNavigationLocation.Bottom)]
        //[CorePropertyRelator("FormElementDataListEntity_NavigationLocation", "PropertyCatalog_Pagination", 
        //    Description = "FormElementDataListEntity_NavigationLocation_Description", XmlNodeName = "NavigationLocation")]
        //[PropertyComboBoxEditorAttribute(Enum = typeof(SEPaginationDataGridView.EnumNavigationLocation))]
        //public SEPaginationDataGridView.EnumNavigationLocation NavigationLocation
        //{
        //    get
        //    {
        //        return this._navigationLocation;
        //    }
        //    set
        //    {
        //        this._navigationLocation = value;
        //    }
        //}

        //private bool _pagination = false;
        ///// <summary>
        ///// �Ƿ��ҳ
        ///// </summary>
        //[DefaultValue(false)]
        //[CorePropertyRelator("FormElementDataListEntity_Pagination", "PropertyCatalog_Pagination", 
        //    Description = "FormElementDataListEntity_Pagination_Description", XmlNodeName = "Pagination")]
        //[PropertyBooleanEditorAttribute()]
        //public bool Pagination
        //{
        //    get
        //    {
        //        return this._pagination;
        //    }
        //    set
        //    {
        //        this._pagination = value;
        //    }
        //}

        //private bool _showItemCount = false;
        ///// <summary>
        ///// �Ƿ���ʾ��Ŀ��
        ///// </summary>
        //[DefaultValue(false)]
        //[CorePropertyRelator("FormElementDataListEntity_ShowItemCount", "PropertyCatalog_Pagination", 
        //    Description = "FormElementDataListEntity_ShowItemCount_Description", XmlNodeName = "ShowItemCount")]
        //[PropertyBooleanEditorAttribute()]
        //public bool ShowItemCount
        //{
        //    get
        //    {
        //        return this._showItemCount;
        //    }
        //    set
        //    {
        //        this._showItemCount = value;
        //    }
        //}

        //private bool _showPageCount = false;
        ///// <summary>
        ///// �Ƿ���ʾҳ��
        ///// </summary>
        //[DefaultValue(false)]
        //[CorePropertyRelator("FormElementDataListEntity_ShowPageCount", "PropertyCatalog_Pagination", 
        //    Description = "FormElementDataListEntity_ShowPageCount_Description", XmlNodeName = "ShowPageCount")]
        //[PropertyBooleanEditorAttribute()]
        //public bool ShowPageCount
        //{
        //    get
        //    {
        //        return this._showPageCount;
        //    }
        //    set
        //    {
        //        this._showPageCount = value;
        //    }
        //}

        //private bool _showPageHomeEnd = false;
        ///// <summary>
        ///// �Ƿ���ʾ��ҳβҳ
        ///// </summary>
        //[DefaultValue(false)]
        //[CorePropertyRelator("FormElementDataListEntity_ShowPageHomeEnd", "PropertyCatalog_Pagination", 
        //    Description = "FormElementDataListEntity_ShowPageHomeEnd_Description", XmlNodeName = "ShowPageHomeEnd")]
        //[PropertyBooleanEditorAttribute()]
        //public bool ShowPageHomeEnd
        //{
        //    get
        //    {
        //        return this._showPageHomeEnd;
        //    }
        //    set
        //    {
        //        this._showPageHomeEnd = value;
        //    }
        //}

        private string _dataEntityId;
        /// <summary>
        /// ����������ʵ���Id
        /// </summary>
        [CorePropertyRelator("FormElementDataListEntity_DataEntityId", "PropertyCatalog_Normal", 
            Description = "FormElementDataListEntity_DataEntityId_Description", XmlNodeName = "DataEntityId")]
        [PropertyDataItemChooseEditorAttribute(ShowDataItem = false)]
        public string DataEntityId
        {
            get
            {
                return this._dataEntityId;
            }
            set
            {
                this._dataEntityId = value;
            }
        }

        private UIElementDataListColumnEntityCollection _dataColumns;
        /// <summary>
        /// ��������
        /// </summary>
        public UIElementDataListColumnEntityCollection DataColumns
        {
            get
            {
                return this._dataColumns;
            }
            set
            {
                this._dataColumns = value;
            }
        }

       

        #endregion

        #region ����

        public UIElementDataListEntity()
            : base()
        {
            this.DataColumns = new UIElementDataListColumnEntityCollection(this);
        }

        #endregion

        #region ��������

        public override string ToXml()
        {
            SEXElement xmlDoc = SEXElement.Parse(base.ToXml());

            xmlDoc.AppendChild(String.Empty, "DataEntity", this.DataEntityId);
            //xmlDoc.AppendChild(XmlRootName, "NavigationLocation", (int)this.NavigationLocation);
            //xmlDoc.AppendChild(String.Empty, "Pagination", this.Pagination);
            //xmlDoc.AppendChild(String.Empty, "ShowItemCount", this.ShowItemCount);
            //xmlDoc.AppendChild(String.Empty, "ShowPageCount", this.ShowPageCount);
            //xmlDoc.AppendChild(String.Empty, "ShowPageHomeEnd", this.ShowPageHomeEnd);

            xmlDoc.AppendChild("Columns");
            
            foreach (UIElementDataListColumnEntityAbstract column in this.DataColumns)
            {
                xmlDoc.AppendInnerXml("/Columns", column.ToXml());
            }

            return xmlDoc.ToString();
        }

        public override void FromXml(string strXml)
        {
            base.FromXml(strXml);

            SEXElement xmlDoc = SEXElement.Parse(strXml);

            this.DataEntityId = xmlDoc.GetInnerObject("/DataEntity");
            //this.NavigationLocation = 
            //    (SEPaginationDataGridView.EnumNavigationLocation)xmlDoc.GetInnerObject<int>(XmlRootName + "/NavigationLocation",0);
            //this.Pagination = xmlDoc.GetInnerObject<bool>("/Pagination", false);
            //this.ShowItemCount = xmlDoc.GetInnerObject<bool>("/ShowItemCount", false);
            //this.ShowPageCount = xmlDoc.GetInnerObject<bool>("/ShowPageCount", false);
            //this.ShowPageHomeEnd = xmlDoc.GetInnerObject<bool>("/ShowPageHomeEnd", false);

            //����ж���
            foreach (XElement node in xmlDoc.SelectNodes("/Columns/Column"))
            {
                UIElementDataListColumnEntityAbstract formElementDataColumnEntity =
                    ColumnEntityTypesAdapter.CreateInstance(Convert.ToInt32(node.Attribute("ColumnType").Value));
                formElementDataColumnEntity.FromXml(node.ToString());
                this.DataColumns.Add(formElementDataColumnEntity);
            }

        }

        /// <summary>
        /// ��ȡ���е���ʵ�����
        /// ����Ϊnull
        /// 
        /// ԭDev��β�����е� GetDataColumnDev
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UIElementDataListColumnEntityAbstract GetDataColumn(string id)
        {
            return this.DataColumns.GetEntityById(id);
        }

        //TODO:���������Ǹ�BUG��ת�����ܣ�������ȷ��
        public override UIElementCollection GetInnerElement()
        {
            return (UIElementCollection)this.DataColumns;
        }

        /// <summary>
        /// ����shell����д���Է���Ex��β����
        /// </summary>
        /// <returns></returns>
        public virtual UIElementDataListRowEntity NewRow()
        {
            UIElementDataListRowEntity row = new UIElementDataListRowEntity(this);
            return row;
        }

        #endregion

        #region IEventSupport ��Ա

        private static UIElementDataListEventTimes _eventTimes;
        public override List<EventTimeAbstract> EventTimeProvide
        {
            get
            {
                if (_eventTimes == null)
                {
                    _eventTimes = new UIElementDataListEventTimes();
                }

                return _eventTimes.Times;
            }
        }

        public override string GetEventTimeName(int code)
        {
            if (_eventTimes == null)
            {
                _eventTimes = new UIElementDataListEventTimes();
            }

            return _eventTimes.GetEventName(code);
        }

        #endregion
    }
}
