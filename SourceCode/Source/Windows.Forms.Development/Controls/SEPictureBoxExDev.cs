﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sheng.SailingEase.Infrastructure;
using Sheng.SailingEase.Core.Development;
using Sheng.SailingEase.Core;
namespace Sheng.SailingEase.Windows.Forms.Development
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(PictureBox))]
    [Description(ConstantLanguage.SEPictureBoxExDev_Description)]
    [RuntimeControlToolboxItem(ConstantLanguage.SEPictureBoxExDev_Name, ConstantLanguage.SEPictureBoxExDev_Catalog, typeof(SEPictureBoxExDev))]
    [RuntimeControlDesignSupportAttribute(typeof(FormElementPictureBoxEntityDev), "Image")]
    class SEPictureBoxExDev : PictureBox, IShellControlDev
    {
        private IResourceComponentService _resourceComponentService = ServiceUnity.ResourceService;
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
            FormElementPictureBoxEntityDev entity = (FormElementPictureBoxEntityDev)_formElement;
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(this);
            PropertyDescriptor pds;
            pds = pdc.Find("Image", false);
            if (pds != null)
            {
                if (String.IsNullOrEmpty(entity.Img) == false)
                {
                    ImageResourceInfo imageResource = _resourceComponentService.GetImageResource(entity.Img);
                    if (imageResource != null)
                    {
                        Image image = imageResource.GetImage();
                        pds.SetValue(this, image);
                    }
                }
                else
                {
                    pds.SetValue(this, null);
                }
            }
            ShellControlHelper.SetProperty(this, "SizeMode", entity.SizeMode);
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
    }
}
