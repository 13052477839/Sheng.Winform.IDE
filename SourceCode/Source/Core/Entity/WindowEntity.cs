using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Sheng.SailingEase.ComponentModel;
using Sheng.SailingEase.Controls;
using Sheng.SailingEase.Core;
using Sheng.SailingEase.Kernal;
using Sheng.SailingEase.Drawing;
using System.Xml.Linq;

namespace Sheng.SailingEase.Core
{
    //FormEntity����Ҫ���л�
    //Ŀǰ����£��������ʱ���쳣˵FormEntity��Ҫ���л�����Ȼ�ǳ���Bug�еط�û�����
    //����Ԫ��ʵ�������Ҫ���л���ԭ����DesignSurface�ڴ����ƣ�ճ��ʱ��Ҫ���л����󣬶�Form�������������
    //[Serializable]
    [DesignerHostEntityAttribute]
    public class WindowEntity : EntityBase, IEventSupport
    {
        public string ControlTypeName
        {
            get
            {
                //TODO:��Դ
                return "����";
            }
        }

        #region �ܱ���������

        [NonSerialized]
        private EventTypesAbstract _eventTypesAdapter = EventTypes.Instance;
        /// <summary>
        /// �¼�����������
        /// �ڼ̳е��������ô����ԣ���ʹFromXml������ʼ����Ӧ�����ͣ���IDE�г�ʼ��DEV��β�����ͣ�SHELL�г�ʼ��EX��β������
        /// ��Adapter��β�����Ǳ���� EventTypes ������Ͳ���ȷ����
        /// </summary>
        protected EventTypesAbstract EventTypesAdapter
        {
            get { return this._eventTypesAdapter; }
            set { this._eventTypesAdapter = value; }
        }

        [NonSerialized]
        private UIElementEntityTypesAbstract _formElementEntityTypesAdapter = UIElementEntityTypes.Instance;
        /// <summary>
        /// ����Ԫ������������
        /// �ڼ̳е��������ô����ԣ���ʹFromXml������ʼ����Ӧ�����ͣ���IDE�г�ʼ��DEV��β�����ͣ�SHELL�г�ʼ��EX��β������
        /// ��Adapter��β�����Ǳ���� EventTypes ������Ͳ���ȷ����
        /// </summary>
        protected UIElementEntityTypesAbstract FormElementEntityTypesAdapter
        {
            get { return this._formElementEntityTypesAdapter; }
            set { this._formElementEntityTypesAdapter = value; }
        }

        #endregion

        #region ��������

        private string _text = String.Empty;
        /// <summary>
        /// ����
        /// </summary>
        [DefaultValue(StringUnity.EmptyString)]
        [CorePropertyRelator("FormEntity_Text", "PropertyCatalog_Normal", Description = "FormEntity_Text_Description", XmlNodeName = "Text")]
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
        [CorePropertyRelator("FormEntity_BackColorValue", "PropertyCatalog_Style", 
            Description = "FormEntity_BackColorValue_Description", XmlNodeName = "BackColorValue")]
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
        [CorePropertyRelator("FormEntity_ForeColorValue", "PropertyCatalog_Style", 
            Description = "FormEntity_ForeColorValue_Description", XmlNodeName = "ForeColorValue")]
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

        private int _width = 300;
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        [DefaultValue(300)]
        [CorePropertyRelator("FormEntity_Width", "PropertyCatalog_Layout", 
            Description = "FormEntity_Width_Description", XmlNodeName = "Width")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Width
        {
            get
            {
                return this._width;
            }
            set
            {
                this._width = value;
            }
        }

        private int _height = 300;
        /// <summary>
        /// ����ĸ߶�
        /// </summary>
        [DefaultValue(300)]
        [CorePropertyRelator("FormEntity_Height", "PropertyCatalog_Layout", 
            Description = "FormEntity_Height_Description", XmlNodeName = "Height")]
        [PropertyTextBoxEditorAttribute(TypeCode = TypeCode.Int32, AllowEmpty = false)]
        public int Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }

        public Size Size
        {
            get
            {
                return new Size(this.Width, this.Height);
            }
            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }

        private int _clientWidth;
        /// <summary>
        /// ������ڲ���ȣ�ȥ�����ұ߿���ȣ�
        /// </summary>
        public int ClientWidth
        {
            get { return _clientWidth; }
            set { _clientWidth = value; }
        }

        private int _clientHeight;
        /// <summary>
        /// ������ڲ��߶ȣ�ȥ�����������±߿���ȣ�
        /// </summary>
        public int ClientHeight
        {
            get { return _clientHeight; }
            set { _clientHeight = value; }
        }

        private EnumFormWindowState _windowState = EnumFormWindowState.Normal;
        /// <summary>
        /// �����ʱ��״̬
        /// �Ե���ʽ����������
        /// </summary>
        [DefaultValue(EnumFormWindowState.Normal)]
        [CorePropertyRelator("FormEntity_WindowState", "PropertyCatalog_Style", 
            Description = "FormEntity_WindowState_Description", XmlNodeName = "WindowState")]
        [PropertyComboBoxEditorAttribute(Enum = typeof(EnumFormWindowState))]
        public EnumFormWindowState WindowState
        {
            get
            {
                return this._windowState;
            }
            set
            {
                this._windowState = value;
            }
        }

        private UIElementFont _font;
        /// <summary>
        /// ����,û��Ĭ��ֵ,Ϊ����ʹ�Ӵ���ؼ��ܼ̳���������������
        /// </summary>
        [CorePropertyRelator("FormEntity_Font", "PropertyCatalog_Style", 
            Description = "FormEntity_Font_Description", CloneValue = true, XmlNodeName = "Font")]
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

        private string _folderId = String.Empty;
        /// <summary>
        /// �����ļ���Id
        /// </summary>
        public string FolderId
        {
            get
            {
                return this._folderId;
            }
            set
            {
                this._folderId = value;
            }
        }

        private UIElementCollection _elements;
        /// <summary>
        /// ����Ԫ�ؼ���
        /// ����Ԫ�ؼ��ϱ��밴ZOrder�ɴ�С��˳������
        /// </summary>
        public UIElementCollection Elements
        {
            get
            {
                return this._elements;
            }
            set
            {
                this._elements = value;
            }
        }

        #endregion

        #region ����

        public WindowEntity()
        {
            this.XmlRootName = "Window";

            this.Elements = new UIElementCollection(this);
            this.Events = new EventCollection(this, this);
        }

        #endregion

        #region ��������

        /// <summary>
        /// ʹ��ָ��ǰ׺����һ�����ڴ���Ԫ�ص�code
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string CreationElementCode(string prefix)
        {
          

            int value = 0;
            //��ǰ�������
            List<int> codes = new List<int>();
            //������Ҫ��ͬInnerElementһ���ȡ
            foreach (UIElement element in this.GetFormElement(true))
            {
                string name = element.Code;
                if (name.StartsWith(prefix))
                {
                    if (Int32.TryParse(name.Substring(prefix.Length), out value))
                    {
                        codes.Add(value);
                    }
                }
            }

            codes.Sort();

            int lastValue = 0; //��һ��ֵ�������ж��Ƿ��м��п�ȱҪ��

            foreach (int code in codes)
            {
                if (code - lastValue > 1)
                {
                    break;
                }
                else
                {
                    lastValue = code;
                }
            }

            return prefix + (lastValue + 1);
        }

        /// <summary>
        /// ��ȡ���еĴ���Ԫ��
        /// ����Ϊnull
        /// ��һ������Ϊδ������Ԥ����,��ʵ�������ؼ�ʱ,�˷��������������ڲ���Ԫ��,�����������
        /// ֧��InnerElement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UIElement FindFormElementById(string id)
        {
            return this.Elements.GetFormElementById(id);
        }

        /// <summary>
        /// ��ȡ���еĴ���Ԫ��
        /// ����Ϊnull
        /// ��һ������Ϊδ������Ԥ����,��ʵ�������ؼ�ʱ,�˷��������������ڲ���Ԫ��,�����������
        /// ֧��InnerElement
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UIElement FindFormElementByCode(string code)
        {
            return this.Elements.GetFormElementByCode(code);
        }

        #region GetFormElement

        //��һ������Ϊδ������Ԥ����,��ʵ�������ؼ�ʱ,�˷�����ȡ���������пؼ�,�����������
        /// <summary>
        /// ��ȡ����Ԫ�ؼ���
        /// �������� InnerElement
        /// </summary>
        /// <returns></returns>
        public UIElementCollection GetFormElement()
        {
            return GetFormElement(false);
        }

        /// <summary>
        /// ��ȡ����Ԫ�ؼ���
        /// findInnerElementָ���Ƿ����InnerElement
        /// </summary>
        /// <param name="findInnerElement">�Ƿ����InnerElement</param>
        /// <returns></returns>
        public UIElementCollection GetFormElement(bool findInnerElement)
        {
            UIElementEntityTypeCollection enumFormElementControlTypeCollection =
                new UIElementEntityTypeCollection();

            return GetFormElement(enumFormElementControlTypeCollection, findInnerElement);
        }

        /// <summary>
        /// ����InnerElement
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public UIElementCollection GetFormElement(UIElementEntityTypeCollection controlType)
        {
            return GetFormElement(controlType, true);
        }

        public UIElementCollection GetFormElement(UIElementEntityTypeCollection controlType, bool findInnerElement)
        {
            UIElementCollection collection = new UIElementCollection(this);

            foreach (UIElement formElement in this.Elements)
            {
                if (controlType.Allowable(formElement))
                {
                    collection.Add(formElement);
                }

                if (findInnerElement)
                {
                    //����InnerElement
                    foreach (UIElement innerElement in formElement.GetInnerElement())
                    {
                        if (controlType.Allowable(innerElement) == false)
                            continue;

                        collection.Add(innerElement);
                    }
                }
            }

            return collection;
        }

        #endregion

        #region ValidateCode

        /// <summary>
        /// ���ָ���Ĵ�����ָ���Ĵ���Ԫ�����Ƿ����
        /// ����InnerElement
        /// ���ѱ�ռ��,��������Ԫ�ر���,����Ч
        /// ���÷���true
        /// </summary>
        /// <param name="code"></param>
        /// <param name="formEntity"></param>
        /// <returns></returns>
        public bool ValidateCode(string code)
        {
            return ValidateCode(code, null);
        }

        public bool ValidateCode(string code, string ignoreId)
        {
            if (ignoreId != null)
            {
                if (this.Id == ignoreId)
                    return true;
            }

            if (this.Code == code)
                return false;

            foreach (UIElement element in this.GetFormElement(true))
            {
                if (ignoreId != null)
                {
                    if (element.Id == ignoreId)
                        continue;
                }

                if (element.Code == code)
                    return false;
            }

            return true;
        }

        #endregion

        #region IXmlable

        /// <summary>
        /// ��XML�������
        /// </summary>
        /// <param name="strXml"></param>
        public override void FromXml(string strXml)
        {
            base.FromXml(strXml);

            SEXElement xmlDoc = SEXElement.Parse(strXml);

            this.Width = xmlDoc.GetInnerObject<int>("/Width", 0);
            this.Height = xmlDoc.GetInnerObject<int>("/Height", 0);
            this.ClientWidth = xmlDoc.GetInnerObject<int>("/ClientWidth", 0);
            this.ClientHeight = xmlDoc.GetInnerObject<int>("/ClientHeight", 0);
            this.WindowState = (EnumFormWindowState)xmlDoc.GetInnerObject<int>("/OpenState", 0);
            this.FolderId = xmlDoc.GetInnerObject("/Folder");

            this.Text = xmlDoc.GetInnerObject("/Text");
            this.BackColorValue = xmlDoc.GetAttributeObject("/BackColorValue/Color", "Value");
            this.ForeColorValue = xmlDoc.GetAttributeObject("/ForeColorValue/Color", "Value");

            if (xmlDoc.SelectSingleNode("/Font").HasElements)
            {
                this.Font = new UIElementFont();
                this.Font.FromXml(xmlDoc.GetOuterXml("/Font"));
            }

            //��Ӷ�������
            EventBase eventBase;
            foreach (XElement eventNode in xmlDoc.SelectNodes("/Events/Event"))
            {
                eventBase = this.EventTypesAdapter.CreateInstance(Convert.ToInt32(eventNode.Attribute("EventCode").Value));
                eventBase.FromXml(eventNode.ToString());
                eventBase.HostFormEntity = this;
                this.Events.Add(eventBase);
            }

            //���Ԫ�ض���
            UIElement formElement;
            foreach (XElement elementNode in xmlDoc.SelectNodes("/Elements/Element"))
            {
                formElement = (UIElement)this.FormElementEntityTypesAdapter.CreateInstance(
                    Convert.ToInt32(elementNode.Element("ControlType").Value));
                Debug.Assert(formElement != null, "���� FormEntity ʱ,FormElement û��������");
                formElement.FromXml(elementNode.ToString());
                formElement.HostFormEntity = this;
                this.Elements.Add(formElement);
            }
        }

        public override string ToXml()
        {
            SEXElement xmlDoc = SEXElement.Parse(base.ToXml());
            //XmlNode xmlnode;

            xmlDoc.AppendChild(String.Empty, "Folder", this.FolderId);
            xmlDoc.AppendChild(String.Empty, "Width", this.Width);
            xmlDoc.AppendChild(String.Empty, "Height", this.Height);
            xmlDoc.AppendChild(String.Empty, "ClientWidth", this.ClientWidth);
            xmlDoc.AppendChild(String.Empty, "ClientHeight", this.ClientHeight);
            xmlDoc.AppendChild(String.Empty, "OpenState", (int)this.WindowState);
            xmlDoc.AppendChild(String.Empty, "Text", this.Text);
            xmlDoc.AppendChild("BackColorValue");
            xmlDoc.AppendInnerXml("/BackColorValue", new UIElementColor(this.BackColorValue).ToXml());
            xmlDoc.AppendChild("ForeColorValue");
            xmlDoc.AppendInnerXml("/ForeColorValue", new UIElementColor(this.ForeColorValue).ToXml());
            xmlDoc.AppendChild(String.Empty, "Remark", this.Remark);

            if (this.Font != null)
                xmlDoc.AppendInnerXml(this.Font.ToXml());
            else
                xmlDoc.AppendInnerXml("<Font/>");

            xmlDoc.AppendChild("Events");
            xmlDoc.AppendChild("Elements");

            foreach (EventBase eve in this.Events)
            {
                xmlDoc.AppendInnerXml("/Events", eve.ToXml());
            }

            //�Դ���Ԫ�ص�ZOrder��������
            var elements = from c in this.Elements orderby c.ZOrder ascending select c;

            foreach (UIElement formElement in elements)
            {

                xmlDoc.AppendInnerXml("/Elements", formElement.ToXml());
            }

            return xmlDoc.ToString();
        }

        #endregion

        #endregion

        #region IEventSupport ��Ա

        public event OnEventUpdatedHandler EventUpdated;

        private EventCollection events;
        public EventCollection Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }

        public virtual EventTypeCollection EventProvide
        {
            get { throw new NotImplementedException(); }
        }

        private static EventTimes _eventTimes;
        public List<EventTimeAbstract> EventTimeProvide
        {
            get
            {
                if (_eventTimes == null)
                {
                    _eventTimes = new EventTimes();
                }

                return _eventTimes.Times;
            }
        }

        public string GetEventTimeName(int code)
        {
            if (_eventTimes == null)
            {
                _eventTimes = new EventTimes();
            }

            return _eventTimes.GetEventName(code);
        }

        public void EventUpdate(object sender)
        {
            if (this.EventUpdated != null)
                EventUpdated(sender,this);
        }

        #endregion

        #region EventTimes

        public class EventTimes : EventTimesAbstract
        {
            public EventTimes()
            {
                _times = new List<EventTimeAbstract>();
                _times.Add(new Load());
                _times.Add(new Closing());
                _times.Add(new Click());
            }

            public class Load : EventTimeAbstract
            {
                public static int XCode
                {
                    get { return 1; }
                }

                public override int Code
                {
                    get { return XCode; }
                }

                public override string Name
                {
                    get { return "����"; }
                }
            }

            public class Closing : EventTimeAbstract
            {
                public static int XCode
                {
                    get { return 2; }
                }

                public override int Code
                {
                    get { return XCode; }
                }

                public override string Name
                {
                    get { return "�ر�"; }
                }
            }

            public class Click : EventTimeAbstract
            {
                public static int XCode
                {
                    get { return 3; }
                }

                public override int Code
                {
                    get { return XCode; }
                }

                public override string Name
                {
                    get { return "����"; }
                }
            }
        }

        #endregion

        #region ö��

        /// <summary>
        /// ָ�����崰�������ʾ��
        /// ��System.Windows.Forms��FormWindowStateͬ��
        /// </summary>
        public enum EnumFormWindowState
        {
            /// <summary>
            /// Ĭ�ϴ�С�Ĵ���
            /// </summary>
            [LocalizedDescription("EnumFormWindowState_Normal")]
            Normal = 0,
            /// <summary>
            /// ��С���Ĵ���
            /// </summary>
            [LocalizedDescription("EnumFormWindowState_Minimized")]
            Minimized = 1,
            /// <summary>
            ///  ��󻯵Ĵ���
            /// </summary>
            [LocalizedDescription("EnumFormWindowState_Maximized")]
            Maximized = 2
        }

        #endregion
    }
}
