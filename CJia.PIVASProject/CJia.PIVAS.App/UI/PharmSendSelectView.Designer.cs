namespace CJia.PIVAS.App.UI
{
    partial class PharmSendSelectView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PharmSendSelectView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcPharmSendNO = new DevExpress.XtraGrid.GridControl();
            this.gvPharmSendNO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.ckDetail = new DevExpress.XtraEditors.CheckEdit();
            this.datePharmSend = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gcLabel = new DevExpress.XtraGrid.GridControl();
            this.gvlabel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLabelStat = new DevExpress.XtraGrid.GridControl();
            this.gvLabelStat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPharmSendNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPharmSendNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePharmSend.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePharmSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvlabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabelStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabelStat)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.gcPharmSendNO);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(195, 594);
            this.panelControl1.TabIndex = 0;
            // 
            // gcPharmSendNO
            // 
            this.gcPharmSendNO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPharmSendNO.Location = new System.Drawing.Point(2, 2);
            this.gcPharmSendNO.MainView = this.gvPharmSendNO;
            this.gcPharmSendNO.Name = "gcPharmSendNO";
            this.gcPharmSendNO.Size = new System.Drawing.Size(191, 590);
            this.gcPharmSendNO.TabIndex = 0;
            this.gcPharmSendNO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPharmSendNO});
            this.gcPharmSendNO.Click += new System.EventHandler(this.gcPharmSendNO_Click);
            // 
            // gvPharmSendNO
            // 
            this.gvPharmSendNO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn15});
            this.gvPharmSendNO.GridControl = this.gcPharmSendNO;
            this.gvPharmSendNO.GroupCount = 2;
            this.gvPharmSendNO.GroupFormat = "[#image]{1} {2}";
            this.gvPharmSendNO.Name = "gvPharmSendNO";
            this.gvPharmSendNO.OptionsBehavior.Editable = false;
            this.gvPharmSendNO.OptionsView.ShowGroupPanel = false;
            this.gvPharmSendNO.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn15, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "冲药单号";
            this.gridColumn6.FieldName = "PHARM_SEND_NO";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = " ";
            this.gridColumn7.FieldName = "TIME_NAME";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = " ";
            this.gridColumn15.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.FieldName = "PHARM_SEND_DATE";
            this.gridColumn15.GroupFormat.FormatString = "yyyy-MM-dd";
            this.gridColumn15.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Controls.Add(this.ckDetail);
            this.panelControl2.Controls.Add(this.datePharmSend);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(204, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(893, 37);
            this.panelControl2.TabIndex = 1;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(5, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(32, 32);
            this.pictureEdit1.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(689, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 27);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(F6)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(561, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 27);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ckDetail
            // 
            this.ckDetail.Location = new System.Drawing.Point(430, 9);
            this.ckDetail.Name = "ckDetail";
            this.ckDetail.Properties.Caption = "汇总药品显示";
            this.ckDetail.Size = new System.Drawing.Size(100, 19);
            this.ckDetail.TabIndex = 2;
            this.ckDetail.CheckedChanged += new System.EventHandler(this.ckDetail_CheckedChanged);
            // 
            // datePharmSend
            // 
            this.datePharmSend.EditValue = null;
            this.datePharmSend.Location = new System.Drawing.Point(117, 9);
            this.datePharmSend.Name = "datePharmSend";
            this.datePharmSend.Properties.Appearance.Options.UseTextOptions = true;
            this.datePharmSend.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.datePharmSend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePharmSend.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.datePharmSend.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePharmSend.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.datePharmSend.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePharmSend.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.datePharmSend.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datePharmSend.Size = new System.Drawing.Size(307, 20);
            this.datePharmSend.TabIndex = 1;
            this.datePharmSend.EditValueChanged += new System.EventHandler(this.datePharmSend_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(41, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "选择日期：";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.gcLabel);
            this.panelControl3.Controls.Add(this.gcLabelStat);
            this.panelControl3.Location = new System.Drawing.Point(204, 46);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(893, 551);
            this.panelControl3.TabIndex = 2;
            // 
            // gcLabel
            // 
            this.gcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLabel.Location = new System.Drawing.Point(2, 2);
            this.gcLabel.MainView = this.gvlabel;
            this.gcLabel.Name = "gcLabel";
            this.gcLabel.Size = new System.Drawing.Size(889, 547);
            this.gcLabel.TabIndex = 0;
            this.gcLabel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvlabel});
            // 
            // gvlabel
            // 
            this.gvlabel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvlabel.GridControl = this.gcLabel;
            this.gvlabel.GroupCount = 4;
            this.gvlabel.Name = "gvlabel";
            this.gvlabel.OptionsBehavior.Editable = false;
            this.gvlabel.OptionsView.ShowGroupPanel = false;
            this.gvlabel.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn9, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "药品名称";
            this.gridColumn1.FieldName = "PHARM_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 104;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "规格";
            this.gridColumn2.FieldName = "SPEC";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "数量";
            this.gridColumn3.FieldName = "NEWAMOUNT";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "冲药人";
            this.gridColumn4.FieldName = "PHARM_SEND_USER_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "冲药时间";
            this.gridColumn5.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "PHARM_SEND_DATE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "批次";
            this.gridColumn8.FieldName = "BATCH_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "病区";
            this.gridColumn9.FieldName = "ILLFIELD_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "姓名";
            this.gridColumn10.FieldName = "PATIENT_SEND_USER_NAME";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "组号";
            this.gridColumn11.FieldName = "GROUP_NO";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gcLabelStat
            // 
            this.gcLabelStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLabelStat.Location = new System.Drawing.Point(2, 2);
            this.gcLabelStat.MainView = this.gvLabelStat;
            this.gcLabelStat.Name = "gcLabelStat";
            this.gcLabelStat.Size = new System.Drawing.Size(889, 547);
            this.gcLabelStat.TabIndex = 1;
            this.gcLabelStat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLabelStat});
            this.gcLabelStat.Visible = false;
            // 
            // gvLabelStat
            // 
            this.gvLabelStat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn20});
            this.gvLabelStat.GridControl = this.gcLabelStat;
            this.gvLabelStat.GroupCount = 1;
            this.gvLabelStat.Name = "gvLabelStat";
            this.gvLabelStat.OptionsBehavior.Editable = false;
            this.gvLabelStat.OptionsView.ShowGroupPanel = false;
            this.gvLabelStat.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn20, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "药品名称";
            this.gridColumn12.FieldName = "PHARM_NAME";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 104;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "规格";
            this.gridColumn13.FieldName = "SPEC";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "数量";
            this.gridColumn14.FieldName = "PHARM_TOTAL";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "冲药单号";
            this.gridColumn20.FieldName = "PHARM_SEND_NO";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            // 
            // PharmSendSelectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "PharmSendSelectView";
            this.Size = new System.Drawing.Size(1100, 600);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPharmSendNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPharmSendNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePharmSend.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePharmSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvlabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLabelStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabelStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.CheckEdit ckDetail;
        private DevExpress.XtraEditors.DateEdit datePharmSend;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gcLabel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvlabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl gcPharmSendNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPharmSendNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.GridControl gcLabelStat;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLabelStat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
