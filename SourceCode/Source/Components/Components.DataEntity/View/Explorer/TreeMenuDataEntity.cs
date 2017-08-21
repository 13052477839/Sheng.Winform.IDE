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
using Sheng.SailingEase.Controls.Extensions;
using Sheng.SailingEase.Components.DataEntityComponent.Localisation;
using Sheng.SailingEase.Localisation;
using Sheng.SailingEase.ComponentModel;
namespace Sheng.SailingEase.Components.DataEntityComponent.View
{
    class TreeMenuDataEntity : ContextMenuStripCodon
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CreateSqlCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public TreeMenuDataEntity()
            : base("TreeMenuDataEntity")
        {
            this.Items.Add(new ToolStripMenuItemCodon("Add", Language.Current.TreeMenuDataEntity_Add,
                delegate(object sender, ToolStripItemCodonEventArgs args)
                {
                    if (this.AddCommand != null) AddCommand.Excute();
                })
                {
                    IsEnabled = (e) => { if (AddCommand == null) return false; else return AddCommand.CanExcute(); }
                });
            this.Items.Add(new ToolStripMenuItemCodon("Edit", Language.Current.TreeMenuDataEntity_Edit,
                delegate(object sender, ToolStripItemCodonEventArgs args)
                {
                    if (this.EditCommand != null) EditCommand.Excute();
                })
                {
                    IsEnabled = (e) => { if (EditCommand == null) return false; else return EditCommand.CanExcute(); }
                });
            this.Items.Add(new ToolStripMenuItemCodon("Delete", Language.Current.TreeMenuDataEntity_Delete,
                delegate(object sender, ToolStripItemCodonEventArgs args)
                {
                    if (this.DeleteCommand != null) DeleteCommand.Excute();
                })
                {
                    IsEnabled = (e) => { if (DeleteCommand == null) return false; else return DeleteCommand.CanExcute(); }
                });
            this.Items.Add(new ToolStripMenuItemCodon("CreateSql", Language.Current.TreeMenuDataEntity_CreateSql,
                IconsLibrary.Script, delegate(object sender, ToolStripItemCodonEventArgs args)
                {
                    if (this.CreateSqlCommand != null) CreateSqlCommand.Excute();
                })
                {
                    IsEnabled = (e) => { if (CreateSqlCommand == null) return false; else return CreateSqlCommand.CanExcute(); }
                });
            this.Items.Add(new ToolStripSeparatorCodon());
            this.Items.Add(new ToolStripMenuItemCodon("AddItem", Language.Current.TreeMenuDataEntity_AddItem,
                delegate(object sender, ToolStripItemCodonEventArgs args)
                {
                    if (this.AddItemCommand != null) AddItemCommand.Excute();
                })
                {
                    IsEnabled = (e) => { if (AddItemCommand == null) return false; else return AddItemCommand.CanExcute(); }
                });
        }
    }
}
