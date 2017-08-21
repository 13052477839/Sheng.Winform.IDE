﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Sheng.SailingEase.Infrastructure;
using Sheng.SailingEase.Core.Development;
using Sheng.SailingEase.Core;
using Sheng.SailingEase.Windows.Forms.Development.Localisation;
using Sheng.SailingEase.Win32;
namespace Sheng.SailingEase.Windows.Forms.Development
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TextBox))]
    [Description(ConstantLanguage.SETextBoxExDev_Description)]
    [Designer(typeof(SETextBoxExDevDesigner))]
    [RuntimeControlToolboxItem(ConstantLanguage.SETextBoxExDev_Name, ConstantLanguage.SETextBoxExDev_Catalog, typeof(SETextBoxExDev))]
    [RuntimeControlDesignSupportAttribute(typeof(FormElementTextBoxEntityDev),"TextBox")]
    class SETextBoxExDev : TextBox, IShellControlDev
    {
        private EntityBase _entity;
        [NonSerialized]
        private UIElement _formElement;
        public EntityBase Entity
        {
            get
            {
                return this._entity;
            }
            set
            {
                ShellControlHelper.ReplaceControlEntity(_formElement, (UIElement)value);
                this._entity = value;
                this._formElement = (UIElement)value;
                IFormElementEntityDev entityDev = value as IFormElementEntityDev;
                if (entityDev != null)
                {
                    entityDev.Component = this;
                }
            }
        }
        private bool _viewUpdating = false;
        public bool ViewUpdating
        {
            get { return this._viewUpdating; }
            set { this._viewUpdating = value; }
        }
        public void UpdateView()
        {
            this.ViewUpdating = true;
            ShellControlHelper.PropertyDescriptorUpdate(this, this._entity);
            FormElementTextBoxEntityDev entity = (FormElementTextBoxEntityDev)_formElement;
            ShellControlHelper.SetProperty(this, "ReadOnly", entity.ReadOnly);
            ShellControlHelper.SetProperty(this, "Multiline", entity.MultiLine);
            this.ViewUpdating = false;
        }
        public void UpdateEntity()
        {
            ShellControlHelper.UpdateEntity(this._formElement, this);
        }
        public string GetCode()
        {
            return this._entity.Code;
        }
        public string GetName()
        {
            return this._entity.Name;
        }
        public string GetControlTypeName()
        {
            return FormElementEntityDevTypes.Instance.GetName(this._formElement);
        }
        public void ClearEntity()
        {
            this._entity = null;
            this._formElement = null;
        }
        public string GetText()
        {
            return this._formElement.Text;
        }
        public EventCollection GetEvents()
        {
            return this._formElement.Events;
        }
        public void InitializationEntity(EntityBase entity)
        {
        }
        private string waterText = String.Empty;
        public string WaterText
        {
            get { return this.waterText; }
            set
            {
                this.waterText = value;
                this.Invalidate();
            }
        }
        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref   m);
            if (m.Msg == User32.WM_PAINT || m.Msg == User32.WM_ERASEBKGND || m.Msg == User32.WM_NCPAINT)
            {
                if (!this.Focused && this.Text == String.Empty && this.WaterText != String.Empty)
                {
                    Graphics g = Graphics.FromHwnd(this.Handle);
                    g.DrawString(this.WaterText, this.Font, Brushes.Gray, this.ClientRectangle);
                }
            }
        }
    }
    class SETextBoxExDevDesigner : ControlDesigner
    {
        DesignerVerbCollection m_Verbs;
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (m_Verbs == null)
                {
                    m_Verbs = new DesignerVerbCollection();
                    m_Verbs.Add(new DesignerVerb(Language.Current.SETextBoxExDev_Verb_DataRule, new EventHandler(DataRule)));
                }
                return m_Verbs;
            }
        }
        SETextBoxExDevDesigner()
        {
        }
        private void DataRule(object sender, EventArgs args)
        {
            IShellControlDev shellControlDev = this.Control as IShellControlDev;
            using (FormSETextBoxExDevDataRule formSETextBoxExDevDataRule =
                new FormSETextBoxExDevDataRule((FormElementTextBoxEntityDev)shellControlDev.Entity))
            {
                formSETextBoxExDevDataRule.ShowDialog();
            }
        }
    }
}
