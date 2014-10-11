namespace CJia.Parking.App.UI
{
    partial class PaymentView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentView));
            this.dropMemType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPayAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.downEdit = new DevExpress.XtraEditors.SpinEdit();
            this.btnReChange = new CJia.Controls.BtnSave();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.gridMemPaylog = new DevExpress.XtraGrid.GridControl();
            this.gvwMemPaylog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridMember = new DevExpress.XtraGrid.GridControl();
            this.gvwMem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.dropMemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemPaylog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMemPaylog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropMemType
            // 
            this.dropMemType.EditValue = "";
            this.dropMemType.Location = new System.Drawing.Point(162, 72);
            this.dropMemType.Name = "dropMemType";
            this.dropMemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropMemType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mem_type", "类型名称")});
            this.dropMemType.Properties.PopupFormMinSize = new System.Drawing.Size(120, 150);
            this.dropMemType.Size = new System.Drawing.Size(117, 20);
            this.dropMemType.TabIndex = 2;
            this.dropMemType.EditValueChanged += new System.EventHandler(this.dropMemType_EditValueChanged);
            this.dropMemType.Enter += new System.EventHandler(this.SetPayAmount);
            this.dropMemType.Leave += new System.EventHandler(this.SetPayAmount);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(36, 140);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 55;
            this.labelControl6.Text = "开始日期：";
            // 
            // txtStartDate
            // 
            this.txtStartDate.EditValue = null;
            this.txtStartDate.EnterMoveNextControl = true;
            this.txtStartDate.Location = new System.Drawing.Point(102, 137);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStartDate.Size = new System.Drawing.Size(177, 20);
            this.txtStartDate.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(36, 109);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 53;
            this.labelControl5.Text = "收费金额：";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(102, 103);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Properties.ReadOnly = true;
            this.txtPayAmount.Size = new System.Drawing.Size(177, 20);
            this.txtPayAmount.TabIndex = 52;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(60, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 50;
            this.labelControl4.Text = "类型：";
            // 
            // downEdit
            // 
            this.downEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.downEdit.Location = new System.Drawing.Point(102, 72);
            this.downEdit.Name = "downEdit";
            this.downEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.downEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.downEdit.Properties.IsFloatValue = false;
            this.downEdit.Properties.Mask.EditMask = "N00";
            this.downEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.downEdit.Size = new System.Drawing.Size(49, 20);
            this.downEdit.TabIndex = 1;
            this.downEdit.ValueChanged += new System.EventHandler(this.SetPayAmount);
            this.downEdit.Enter += new System.EventHandler(this.SetPayAmount);
            this.downEdit.Leave += new System.EventHandler(this.SetPayAmount);
            // 
            // btnReChange
            // 
            this.btnReChange.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnReChange.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnReChange.Appearance.Options.UseFont = true;
            this.btnReChange.Appearance.Options.UseForeColor = true;
            this.btnReChange.CustomText = "充值(F8)";
            this.btnReChange.Image = ((System.Drawing.Image)(resources.GetObject("btnReChange.Image")));
            this.btnReChange.Location = new System.Drawing.Point(350, 130);
            this.btnReChange.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnReChange.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReChange.Name = "btnReChange";
            this.btnReChange.Selectable = false;
            this.btnReChange.Size = new System.Drawing.Size(80, 27);
            this.btnReChange.TabIndex = 4;
            this.btnReChange.Text = "充值(F8)";
            this.btnReChange.Click += new System.EventHandler(this.btnReChange_Click);
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.cJiaLabel2.Location = new System.Drawing.Point(421, 25);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(96, 29);
            this.cJiaLabel2.TabIndex = 57;
            this.cJiaLabel2.Text = "会员缴费";
            // 
            // gridMemPaylog
            // 
            this.gridMemPaylog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMemPaylog.Location = new System.Drawing.Point(5, 25);
            this.gridMemPaylog.MainView = this.gvwMemPaylog;
            this.gridMemPaylog.Name = "gridMemPaylog";
            this.gridMemPaylog.Size = new System.Drawing.Size(895, 382);
            this.gridMemPaylog.TabIndex = 62;
            this.gridMemPaylog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwMemPaylog});
            // 
            // gvwMemPaylog
            // 
            this.gvwMemPaylog.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.Window;
            this.gvwMemPaylog.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwMemPaylog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7});
            this.gvwMemPaylog.GridControl = this.gridMemPaylog;
            this.gvwMemPaylog.Name = "gvwMemPaylog";
            this.gvwMemPaylog.OptionsBehavior.Editable = false;
            this.gvwMemPaylog.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "会员编号";
            this.gridColumn2.FieldName = "mem_no";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "会员姓名";
            this.gridColumn3.FieldName = "mem_name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "车牌号";
            this.gridColumn4.FieldName = "plate_no";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "开始日期";
            this.gridColumn5.FieldName = "start_date";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "截至有效日期";
            this.gridColumn1.FieldName = "effective_date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "缴费金额";
            this.gridColumn6.FieldName = "pay_amount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "缴费时间";
            this.gridColumn7.FieldName = "pay_date";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.gridMember);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(488, 594);
            this.groupControl1.TabIndex = 66;
            this.groupControl1.Text = "会员信息";
            // 
            // gridMember
            // 
            this.gridMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMember.Location = new System.Drawing.Point(5, 25);
            this.gridMember.MainView = this.gvwMem;
            this.gridMember.Name = "gridMember";
            this.gridMember.Size = new System.Drawing.Size(478, 564);
            this.gridMember.TabIndex = 58;
            this.gridMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwMem});
            // 
            // gvwMem
            // 
            this.gvwMem.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.Window;
            this.gvwMem.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwMem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvwMem.GridControl = this.gridMember;
            this.gvwMem.Name = "gvwMem";
            this.gvwMem.OptionsBehavior.Editable = false;
            this.gvwMem.OptionsView.ShowGroupPanel = false;
            this.gvwMem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwMem_FocusedRowChanged);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "会员编号";
            this.gridColumn8.FieldName = "mem_no";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "会员姓名";
            this.gridColumn9.FieldName = "mem_name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "车牌号";
            this.gridColumn10.FieldName = "plate_no";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "办理日期";
            this.gridColumn11.FieldName = "check_date";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridMemPaylog);
            this.groupControl2.Location = new System.Drawing.Point(492, 185);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(905, 412);
            this.groupControl2.TabIndex = 59;
            this.groupControl2.Text = "缴费记录";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.cJiaLabel2);
            this.groupControl3.Controls.Add(this.btnReChange);
            this.groupControl3.Controls.Add(this.txtStartDate);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.txtPayAmount);
            this.groupControl3.Controls.Add(this.downEdit);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.dropMemType);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Location = new System.Drawing.Point(492, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(910, 179);
            this.groupControl3.TabIndex = 61;
            this.groupControl3.Text = "缴费";
            // 
            // PaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "PaymentView";
            this.Size = new System.Drawing.Size(1400, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dropMemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemPaylog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMemPaylog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit dropMemType;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit txtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPayAmount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit downEdit;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnSave btnReChange;
        private DevExpress.XtraGrid.GridControl gridMemPaylog;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwMemPaylog;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridMember;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwMem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}
