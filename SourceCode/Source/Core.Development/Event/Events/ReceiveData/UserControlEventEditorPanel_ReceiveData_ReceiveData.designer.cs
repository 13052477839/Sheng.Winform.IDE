﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
namespace Sheng.SailingEase.Core.Development
{
    partial class UserControlEventEditorPanel_ReceiveData_ReceiveData
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new Sheng.SailingEase.Controls.SEButton();
            this.btnAdd = new Sheng.SailingEase.Controls.SEButton();
            this.dataGridViewReceiveData = new System.Windows.Forms.DataGridView();
            this.ColumnDataCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceiveToName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceiveData)).BeginInit();
            this.SuspendLayout();
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(40, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 274);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.dataGridViewReceiveData.AllowUserToAddRows = false;
            this.dataGridViewReceiveData.AllowUserToDeleteRows = false;
            this.dataGridViewReceiveData.AllowUserToResizeRows = false;
            this.dataGridViewReceiveData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReceiveData.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReceiveData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewReceiveData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewReceiveData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReceiveData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewReceiveData.ColumnHeadersHeight = 21;
            this.dataGridViewReceiveData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewReceiveData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDataCode,
            this.ColumnReceiveToName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewReceiveData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewReceiveData.Location = new System.Drawing.Point(3, 35);
            this.dataGridViewReceiveData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dataGridViewReceiveData.MultiSelect = false;
            this.dataGridViewReceiveData.Name = "dataGridViewReceiveData";
            this.dataGridViewReceiveData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReceiveData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewReceiveData.RowHeadersVisible = false;
            this.dataGridViewReceiveData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewReceiveData.RowTemplate.Height = 21;
            this.dataGridViewReceiveData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReceiveData.Size = new System.Drawing.Size(454, 233);
            this.dataGridViewReceiveData.StandardTab = true;
            this.dataGridViewReceiveData.TabIndex = 0;
            this.dataGridViewReceiveData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewReceiveData_DataBindingComplete);
            this.ColumnDataCode.DataPropertyName = "DataCode";
            this.ColumnDataCode.HeaderText = "${UserControlEventEditorPanel_ReceiveData_ReceiveData_ColumnDataCode}";
            this.ColumnDataCode.Name = "ColumnDataCode";
            this.ColumnDataCode.ReadOnly = true;
            this.ColumnDataCode.Width = 140;
            this.ColumnReceiveToName.DataPropertyName = "ReceiveToName";
            this.ColumnReceiveToName.HeaderText = "${UserControlEventEditorPanel_ReceiveData_ReceiveData_ColumnReceiveToName}";
            this.ColumnReceiveToName.Name = "ColumnReceiveToName";
            this.ColumnReceiveToName.ReadOnly = true;
            this.ColumnReceiveToName.Width = 260;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewReceiveData);
            this.Name = "UserControlEventEditorPanel_ReceiveData_ReceiveData";
            this.Controls.SetChildIndex(this.dataGridViewReceiveData, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceiveData)).EndInit();
            this.ResumeLayout(false);
        }
        private Sheng.SailingEase.Controls.SEButton btnDelete;
        private Sheng.SailingEase.Controls.SEButton btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewReceiveData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceiveToName;
    }
}
