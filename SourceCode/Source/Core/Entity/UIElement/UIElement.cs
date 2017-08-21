using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Sheng.SailingEase.ComponentModel;
using Sheng.SailingEase.Core;
using Sheng.SailingEase.Drawing;
using Sheng.SailingEase.Kernal;
using System.Xml.Linq;

namespace Sheng.SailingEase.Core
{
    /// <summary>
    /// ���д���Ԫ�ص�ʵ�����
    /// ��IDE��SHELL�м̳е���ע��Ϊ EventTypes ���Ը�ֵ
    /// </summary>
    [Serializable]
    public abstract class UIElement : EntityBase, IEventSupport
    {
        #region �ܱ���������

        [NonSerialized]
        private EventTypesAbstract _eventTypesAdapter = Sheng.SailingEase.Core.EventTypes.Instance;
        /// <summary>
        /// �¼�����������
        /// �ڼ̳е��������ô����ԣ���ʹFromXml������ʼ����Ӧ�����ͣ���IDE�г�ʼ��DEV��β�����ͣ�SHELL�г�ʼ��EX��β������
        /// ����ע�⣬IDE�б���ͨ�� OnDeserialized ���Ա�ǵķ����ٴη�����ʵ�����
        /// ��Adapter��β�����Ǳ���� EventTypes ������Ͳ���ȷ����
        /// </summary>
        protected EventTypesAbstract EventTypesAdapter
        {
            get { return this._eventTypesAdapter; }
            set { this._eventTypesAdapter = value; }
        }

        #endregion

        #region ��������

        /// <summary>
        /// �Ƿ�����������ؼ�������Դ
        /// </summary>
        public virtual bool DataSourceUseable
        {
            get { return false; }
        }

       
        [NonSerialized]
        private WindowEntity _hostFormEntity;
        /// <summary>
        /// �˴���Ԫ��ʵ��������FormEntity
        /// </summary>
        public WindowEntity HostFormEntity
        {
            get
            {
                return this._hostFormEntity;
            }
            set
            {
                this._hostFormEntity = value;

                if (this.Events != null)
                {
                    if (this.Events.HostFormEntity == null ||
                        (this.Events.HostFormEntity != null && this.Events.HostFormEntity.Equals(value) == false))
                    {
                        this.Events.HostFormEntity = value;
                    }
                }
            }
        }

        private string _text = String.Empty;
        /// <summary>
        /// ��Ԫ�ع������ı�
        /// </summary>
        [DefaultValue(StringUnity.EmptyString)]
        [CorePropertyRelator("FormElement_Text", "PropertyCatalog_Normal", Description = "FormElement_Text_Description", XmlNodeName = "Text")]
        [PropertyTextBoxEditorAttribute()]
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }

        private string _backColorValue = String.Empty;
        /// <summary>
        /// �洢������ɫ����ֵ
        /// </summary>
        [DefaultValue(StringUnity.EmptyString)]
        [CorePropertyRelator("FormElement_BackColorValue", "PropertyCatalog_Style", Description = "FormElement_BackColorValue_Description", XmlNodeName = "BackColorValue")]
        [PropertyColorChooseEditorAttribute()]
        public string BackColorValue
        {
            get
            {
                return this._backColorValue;
            }
            set
            {
                this._backColorValue = value;
            }
        }

        /// <summary>
        /// ������ɫ����ֵ��ȡ����ɫ
        /// </summary>
        public Color BackColor
        {
            get
            {
                return ColorRepresentationHelper.GetColorByValue(this.BackColorValue);
            }
        }

        private string _foreColorValue = String.Empty;
        /// <summary>
        /// �洢ǰ����ɫ����ֵ
        /// </summary>
        [DefaultValue(StringUnity.EmptyString)]
        [CorePropertyRelator("FormElement_ForeColorValue", "PropertyCatalog_Style", Description = "FormElement_ForeColorValue_Description", XmlNodeName = "ForeColorValue")]
        [PropertyColorChooseEditorAttribute()]
        public string ForeColorValue
        {
            get
            {
                return this._foreColorValue;
            }
            set
            {
                this._foreColorValue = value;
            }
        }

        /// <summary>
        /// ������ɫ����ֵ��ȡǰ��ɫ
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return ColorRepresentationHelper.GetColorByValue(this.ForeColorValue);
            }
        }

        private bool _enabled = true;
        /// <summary>
        /// ����
        /// </summary>
        [DefaultValue(true)]
        [CorePropertyRelator("FormElement_Enabled", "PropertyCatalog_Normal", Description = "FormElement_Enabled_Description", XmlNodeName = "Enabled")]
        [PropertyBooleanEditorAttribute()]
        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        private bool _visible = true;
        /// <summary>
        /// �ɼ�
        /// </summary>
        [DefaultValue(true)]
        [CorePropertyRelator("FormElement_Visible", "PropertyCatalog_Normal", Description = "FormElement_Visible_Description", XmlNodeName = "Visible")]
        [PropertyBooleanEditorAttribute()]
        public bool Visible
        {
            get
            {
                return this._visible;
            }
            set
            {
                this._visible = value;
                
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        [DefaultValue(100)]
        [CorePropertyRelator("FormElement_Width", "PropertyCatalog_Layout", Description = "FormElement_Width_Description", XmlNodeName = "Width")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Width
        {
            get
            {
                return this.Size.Width;
            }
            set
            {
                this.Size = new Size(value, this.Size.Height);
            }
        }

        /// <summary>
        /// �߶�
        /// </summary>
        [DefaultValue(21)]
        [CorePropertyRelator("FormElement_Height", "PropertyCatalog_Layout", Description = "FormElement_Height_Description", XmlNodeName = "Height")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Height
        {
            get
            {
                return this.Size.Height;
            }
            set
            {
                this.Size = new Size(this.Size.Width,value);
            }
        }

        private Size _size = new Size(100,21);
        /// <summary>
        /// ��С
        /// </summary>
        public Size Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }

        private UIElementAnchor _anchor = new UIElementAnchor();
        /// <summary>
        /// ��Եê��
        /// </summary>
        //��ΪԪ�����е�ֵ�����ǳ��������Բ�����new ElementAnchor()��const ElementAnchor anchor = new ElementAnchor(); Ҳ����
        //�������͵ĳ��������� new object() ����ʼ��
        //���Ҫ��ElementAnchor����ʵ�� IConvertible �ӿڣ��Թ�  Convert.ChangeType �ܰ�ElementAnchorת���ַ����Ժ�DefaultValue�Ա�
        //����ʾ���� ElementAnchor.Equals ����ΪElementAnchor.Equals�Ѿ���д��
        [DefaultValue("Top,Left")]  
        [CorePropertyRelator("FormElement_Anchor", "PropertyCatalog_Layout", Description = "FormElement_Anchor_Description", XmlNodeName = "Anchor")]
        [PropertyAnchorEditorAttribute()]
        public UIElementAnchor Anchor
        {
            get
            {
                return this._anchor;
            }
            set
            {
                this._anchor = value;
            }
        }

        [DefaultValue(0)]
        [CorePropertyRelator("FormElement_Top", "PropertyCatalog_Layout", Description = "FormElement_Top_Description", XmlNodeName = "Top")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Top
        {
            get
            {
                return this.Location.Y;
            }
            set
            {
                this.Location = new Point(this.Location.X, value);
            }
        }

        [DefaultValue(0)]
        [CorePropertyRelator("FormElement_Left", "PropertyCatalog_Layout", Description = "FormElement_Left_Description", XmlNodeName = "Left")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Left
        {
            get
            {
                return this.Location.X;
            }
            set
            {
                this.Location = new Point(value, this.Location.Y);
            }
        }

        private UIElementFont _font ;
        /// <summary>
        /// ����,
        /// ע��! Ĭ��ֵΪnull,Ϊ����ʹ�Ӵ���ؼ��ܼ̳�����������������
        /// </summary>
        [CorePropertyRelator("FormElement_Font", "PropertyCatalog_Style", Description = "FormElement_Font_Description", CloneValue = true, XmlNodeName = "Font")]
        [PropertyFontEditorAttribute()]
        public UIElementFont Font
        {
            get { return this._font; }
            set
            {
                if (value != null)
                    this._font = value;
                else
                    this._font = null;
            }
        }

        private Point _location = new Point();
        /// <summary>
        /// λ��
        /// </summary>
        public Point Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }

        /// <summary>
        /// ��ȡԪ�صĴ���ȫ·��
        /// ��Ҫ���������б��е�������
        /// ���Ի�ȡ,�����б�code.������code
        /// һ��Ԫ�صȼ���Code����
        /// ��Ҫע���һ�㣬�����пؼ�����windows������ֱ��continer�ǳ������ģ��������ҵ�datagrid����ͨ��cells����ȥ��
        /// ����Ҫ�õ������еĵط���������fullcode������dataGridview��code
        /// ��������еĵط�����fullcode�������ԱȽϺã���Ϊһ��Ԫ��,fullcode��ͬ��code
        /// </summary>
        public virtual string FullCode
        {
            get
            {
                return this.Code;
            }
        }

        /// <summary>
        /// ��ȡԪ�ص�����ȫ·��
        /// </summary>
        public virtual string FullName
        {
            get
            {
                return this.Name;
            }
        }

        private int _tabIndex = 0;
        public int TabIndex
        {
            get { return this._tabIndex; }
            set { this._tabIndex = value; }
        }

        private int _zOrder = 0;
        public int ZOrder
        {
            get { return this._zOrder; }
            set { this._zOrder = value; }
        }

        //���Ҫ����ճ������ԭ��Ԫ���ϵ����
        private string _parentId;
        /// <summary>
        /// �˴���Ԫ�صĸ�Ԫ��Id
        /// </summary>
        public string ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
            }
        }

        #endregion

        #region ����

        public UIElement()
        {
            this.XmlRootName = "Element";
        }

        #endregion

        #region �������л��뷴���л�

        [OnDeserialized]
        void AfterDeserialized(StreamingContext ctx)
        {
            this.EventTypesAdapter = Sheng.SailingEase.Core.EventTypes.Instance;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ����xml�ִ�����Ԫ�ض���
        /// ������ɹ��в��֣������ɼ̳е������ʵ��
        /// </summary>
        /// <param name="strXml"></param>
        public override void FromXml(string strXml)
        {
            base.FromXml(strXml);

            SEXElement xmlDoc = SEXElement.Parse(strXml);

            //���ò���
            this.Enabled = xmlDoc.GetInnerObject<bool>("/Enabled", true);
            this.Visible = xmlDoc.GetInnerObject<bool>("/Visible", true);
            this.Size = new Size(xmlDoc.GetInnerObject<int>("/Width", 0), xmlDoc.GetInnerObject<int>("/Height", 0));

            //FormXml��ʱ����ҪControlType����Ϊ�ڵ���FormXml��ʱ�򣬶����Ȼ�Ѿ���ʵ����������������֪��
            //this.ControlType = FormElementEntityTypes.GetProvideAttribute(xmlDoc.GetInnerObject<int>(XmlRootName + "/ControlType", -0));
            this.Text = xmlDoc.GetInnerObject("/Text");

            this.BackColorValue = xmlDoc.GetAttributeObject("/BackColorValue/Color","Value");
            this.ForeColorValue = xmlDoc.GetAttributeObject("/ForeColorValue/Color", "Value");

            this.TabIndex = xmlDoc.GetInnerObject<int>("/TabIndex", 0);
            this.ZOrder = xmlDoc.GetInnerObject<int>("/ZOrder", 0);

            //��Щ����Ԫ��û���������,���繤������Ŀ,����Ĭ��
            this.Location = new Point(xmlDoc.GetInnerObject<int>("/Left", 0), xmlDoc.GetInnerObject<int>("/Top", 0));

            //����ê������
            //��Щ����Ԫ��û���������,���繤������Ŀ,����Ĭ��
            this.Anchor.Top = xmlDoc.GetInnerObject<bool>("/Anchor/Top", true);
            this.Anchor.Bottom = xmlDoc.GetInnerObject<bool>("/Anchor/Bottom", false);
            this.Anchor.Left = xmlDoc.GetInnerObject<bool>("/Anchor/Left", true);
            this.Anchor.Right = xmlDoc.GetInnerObject<bool>("/Anchor/Right", false);

            if (xmlDoc.SelectSingleNode("/Font").HasElements)
            {
                this.Font = new UIElementFont();
                this.Font.FromXml(xmlDoc.GetOuterXml("/Font"));
            }

           

            //����¼�����
            EventBase eventBase;
            foreach (XElement eventNode in xmlDoc.SelectNodes("/Events/Event"))
            {
                eventBase = this.EventTypesAdapter.CreateInstance(Convert.ToInt32(eventNode.Attribute("EventCode").Value));
                eventBase.FromXml(eventNode.ToString());
                this.Events.Add(eventBase);
            }
        }

        /// <summary>
        /// ��ȡ���ص�����xml��ʽ
        /// ������ɹ��в��֣������ɼ̳е������ʵ��
        /// </summary>
        /// <returns></returns>
        public override string ToXml()
        {
            SEXElement xmlDoc = SEXElement.Parse(base.ToXml());

            xmlDoc.AppendChild(String.Empty, "ControlType", UIElementEntityTypes.Instance.GetProvideAttribute(this).Code);
            xmlDoc.AppendChild(String.Empty, "Text", this.Text);
            xmlDoc.AppendChild("BackColorValue");
            xmlDoc.AppendInnerXml("/BackColorValue", new UIElementColor(this.BackColorValue).ToXml());
            xmlDoc.AppendChild("ForeColorValue");
            xmlDoc.AppendInnerXml("/ForeColorValue", new UIElementColor(this.ForeColorValue).ToXml());
            xmlDoc.AppendChild(String.Empty, "Enabled", this.Enabled);
            xmlDoc.AppendChild(String.Empty, "Visible", this.Visible);
            xmlDoc.AppendChild(String.Empty, "Top", this.Location.Y);
            xmlDoc.AppendChild(String.Empty, "Left", this.Location.X);
            xmlDoc.AppendChild(String.Empty, "Width", this.Width);
            xmlDoc.AppendChild(String.Empty, "Height", this.Height);
            xmlDoc.AppendChild(String.Empty, "TabIndex", this.TabIndex);
            xmlDoc.AppendChild(String.Empty, "ZOrder", this.ZOrder);
            xmlDoc.AppendChild("Anchor");
            xmlDoc.AppendInnerXml("/Anchor", this.Anchor.GetXml());

            //����
            if (this.Font != null)
                xmlDoc.AppendInnerXml(this.Font.ToXml());
            else
                xmlDoc.AppendInnerXml("<Font/>");

            //�¼�
            xmlDoc.AppendChild("Events");

            foreach (EventBase even in this.Events)
            {
                xmlDoc.AppendInnerXml("/Events", even.ToXml());
            }

            return xmlDoc.ToString() ;
        }

        /// <summary>
        /// ��ȡ���ɷָ����ڲ�Ԫ�ؼ���
        /// ע���ⲻ��������ȡ����panel���������ؼ����ӿؼ���
        /// �����������б������İ������ɷָ��������е�Ԫ��
        /// ���������б�,�˷����ͷ��������ж��󼯺�
        /// InnerElement���ܶ�������,���������������������Ԫ��
        /// ����������������ɷָ����ڲ�Ԫ�ؼ��ϣ��ͷ���һ���յ�FormElementCollection
        /// </summary>
        /// <returns></returns>
        public virtual UIElementCollection GetInnerElement()
        {
            return new UIElementCollection(this.HostFormEntity);
        }

        #endregion

        #region IEventSupport ��Ա

        [field: NonSerialized]
        public event OnEventUpdatedHandler EventUpdated;

        private EventCollection _events;
        public EventCollection Events
        {
            get
            {

                if (this._events == null)
                {
                    this._events = new EventCollection(this.HostFormEntity, this);
                }

                //��Ϊ�����л���ᶪʧHostEntity������������һ���ж�����֤HostEntity
                //FormEntity���ﱣ֤���ˣ����ﱾ��Ҳ��֪��FormEntity
                //����FormEntityͨ��ʵ����IShellControlDev�ӿڵ�Entity��������֤
                if (this._events.HostEntity == null || this._events.HostEntity.Equals(this) == false)
                {
                    this._events.HostEntity = this;
                }

                return this._events;
            }
            set
            {
                this._events = value;
            }
        }

        //�⼸���鷽��Ҫ�ṩһ��Ĭ��ʵ��
        //��Ϊ��һ��ÿ���������̳еĹ��������󶼻���д�⼸�����Ի��߷���

        public virtual EventTypeCollection EventProvide
        {
            get { return new EventTypeCollection(); }
        }

        public virtual List<EventTimeAbstract> EventTimeProvide
        {
            get { return new List<EventTimeAbstract>(); }
        }

        public virtual string GetEventTimeName(int code)
        {
            return String.Empty;
        }

        public void EventUpdate(object sender)
        {
            if (this.EventUpdated != null)
                EventUpdated(sender, this);
        }

        #endregion
    }
}
