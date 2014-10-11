namespace CJia.PIVAS.App.UI.Label
{
    partial class LabelScanning
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelScanning));
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbScanning = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbBatch = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbIffield = new System.Windows.Forms.ComboBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.dtpQueryTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnScenning = new DevExpress.XtraEditors.SimpleButton();
            this.txbBarCode = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.pbLabelPreview = new System.Windows.Forms.PictureBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gdcLabel = new DevExpress.XtraGrid.GridControl();
            this.gdvLabelCollect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnPrintLabel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdcLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLabelCollect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.AllowTouchScroll = true;
            this.groupControl4.AlwaysScrollActiveControlIntoView = false;
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.Controls.Add(this.rbYes);
            this.groupControl4.Controls.Add(this.rbNo);
            this.groupControl4.Controls.Add(this.rbAll);
            this.groupControl4.Controls.Add(this.labelControl4);
            this.groupControl4.Controls.Add(this.cbScanning);
            this.groupControl4.Controls.Add(this.btnRefresh);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.cbBatch);
            this.groupControl4.Controls.Add(this.labelControl2);
            this.groupControl4.Controls.Add(this.cbIffield);
            this.groupControl4.Controls.Add(this.pictureEdit1);
            this.groupControl4.Controls.Add(this.dtpQueryTime);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Location = new System.Drawing.Point(3, 3);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(994, 82);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "筛选条件";
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.BackColor = System.Drawing.Color.Transparent;
            this.rbYes.Location = new System.Drawing.Point(824, 40);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(61, 18);
            this.rbYes.TabIndex = 4;
            this.rbYes.Text = "已扫描";
            this.rbYes.UseVisualStyleBackColor = false;
            this.rbYes.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.BackColor = System.Drawing.Color.Transparent;
            this.rbNo.Location = new System.Drawing.Point(891, 40);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(61, 18);
            this.rbNo.TabIndex = 5;
            this.rbNo.Text = "未扫描";
            this.rbNo.UseVisualStyleBackColor = false;
            this.rbNo.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.BackColor = System.Drawing.Color.Transparent;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(769, 40);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(49, 18);
            this.rbAll.TabIndex = 3;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(225, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "扫描：";
            // 
            // cbScanning
            // 
            this.cbScanning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScanning.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbScanning.FormattingEnabled = true;
            this.cbScanning.Items.AddRange(new object[] {
            "入仓扫描",
            "出仓扫描"});
            this.cbScanning.Location = new System.Drawing.Point(262, 38);
            this.cbScanning.Name = "cbScanning";
            this.cbScanning.Size = new System.Drawing.Size(79, 22);
            this.cbScanning.TabIndex = 20;
            this.cbScanning.SelectedValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(646, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 31);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(512, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "批次：";
            // 
            // cbBatch
            // 
            this.cbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatch.FormattingEnabled = true;
            this.cbBatch.Location = new System.Drawing.Point(550, 38);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Size = new System.Drawing.Size(84, 22);
            this.cbBatch.TabIndex = 17;
            this.cbBatch.SelectedValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(347, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "病区：";
            // 
            // cbIffield
            // 
            this.cbIffield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIffield.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIffield.FormattingEnabled = true;
            this.cbIffield.Location = new System.Drawing.Point(383, 38);
            this.cbIffield.Name = "cbIffield";
            this.cbIffield.Size = new System.Drawing.Size(120, 22);
            this.cbIffield.TabIndex = 15;
            this.cbIffield.SelectedValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(5, 33);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(37, 37);
            this.pictureEdit1.TabIndex = 14;
            // 
            // dtpQueryTime
            // 
            this.dtpQueryTime.Location = new System.Drawing.Point(78, 39);
            this.dtpQueryTime.Name = "dtpQueryTime";
            this.dtpQueryTime.Size = new System.Drawing.Size(140, 22);
            this.dtpQueryTime.TabIndex = 13;
            this.dtpQueryTime.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "日期：";
            // 
            // groupControl1
            // 
            this.groupControl1.AllowTouchScroll = true;
            this.groupControl1.AlwaysScrollActiveControlIntoView = false;
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.btnPrintLabel);
            this.groupControl1.Controls.Add(this.btnScenning);
            this.groupControl1.Controls.Add(this.txbBarCode);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.pbLabelPreview);
            this.groupControl1.Location = new System.Drawing.Point(1003, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(277, 494);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "瓶贴详情";
            // 
            // btnScenning
            // 
            this.btnScenning.Location = new System.Drawing.Point(196, 38);
            this.btnScenning.Name = "btnScenning";
            this.btnScenning.Size = new System.Drawing.Size(65, 23);
            this.btnScenning.TabIndex = 20;
            this.btnScenning.Text = "扫描";
            this.btnScenning.Click += new System.EventHandler(this.btnScenning_Click);
            // 
            // txbBarCode
            // 
            this.txbBarCode.Location = new System.Drawing.Point(65, 38);
            this.txbBarCode.Name = "txbBarCode";
            this.txbBarCode.Size = new System.Drawing.Size(125, 22);
            this.txbBarCode.TabIndex = 18;
            this.txbBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbBarCode_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "条形码：";
            // 
            // pbLabelPreview
            // 
            this.pbLabelPreview.Location = new System.Drawing.Point(16, 75);
            this.pbLabelPreview.Name = "pbLabelPreview";
            this.pbLabelPreview.Size = new System.Drawing.Size(245, 358);
            this.pbLabelPreview.TabIndex = 0;
            this.pbLabelPreview.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.AllowTouchScroll = true;
            this.groupControl2.AlwaysScrollActiveControlIntoView = false;
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.gdcLabel);
            this.groupControl2.Location = new System.Drawing.Point(3, 91);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(994, 606);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "瓶贴预览";
            // 
            // gdcLabel
            // 
            this.gdcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdcLabel.Location = new System.Drawing.Point(2, 22);
            this.gdcLabel.MainView = this.gdvLabelCollect;
            this.gdcLabel.Name = "gdcLabel";
            this.gdcLabel.Size = new System.Drawing.Size(990, 582);
            this.gdcLabel.TabIndex = 2;
            this.gdcLabel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvLabelCollect});
            // 
            // gdvLabelCollect
            // 
            this.gdvLabelCollect.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gdvLabelCollect.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.gdvLabelCollect.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gdvLabelCollect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gdvLabelCollect.GridControl = this.gdcLabel;
            this.gdvLabelCollect.GroupCount = 2;
            this.gdvLabelCollect.Name = "gdvLabelCollect";
            this.gdvLabelCollect.OptionsBehavior.Editable = false;
            this.gdvLabelCollect.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gdvLabelCollect.OptionsView.ShowGroupPanel = false;
            this.gdvLabelCollect.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gdvLabelCollect.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gdvLabelCollect_RowStyle);
            this.gdvLabelCollect.DoubleClick += new System.EventHandler(this.gdvLabelCollect_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病区";
            this.gridColumn1.FieldName = "ILLFIELD_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "批次";
            this.gridColumn2.FieldName = "BATCH_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "床号";
            this.gridColumn3.FieldName = "BED_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "病人";
            this.gridColumn4.FieldName = "PATIENT_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "医嘱id";
            this.gridColumn5.FieldName = "GROUP_INDEX";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "医嘱类型";
            this.gridColumn6.FieldName = "PHARM_TYPE_NAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "页码";
            this.gridColumn7.FieldName = "PAGE_NO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "打印时间";
            this.gridColumn8.FieldName = "GEN_TIME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "状态";
            this.gridColumn9.FieldName = "LABEL_TYPE";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // groupControl7
            // 
            this.groupControl7.AllowTouchScroll = true;
            this.groupControl7.AlwaysScrollActiveControlIntoView = false;
            this.groupControl7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl7.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl7.Appearance.Options.UseBackColor = true;
            this.groupControl7.Controls.Add(this.lblMessage);
            this.groupControl7.Location = new System.Drawing.Point(1003, 504);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(277, 193);
            this.groupControl7.TabIndex = 6;
            this.groupControl7.Text = "信息提示";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(2, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(273, 169);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPrintLabel.Appearance.Options.UseFont = true;
            this.btnPrintLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintLabel.Image")));
            this.btnPrintLabel.Location = new System.Drawing.Point(149, 447);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(112, 31);
            this.btnPrintLabel.TabIndex = 22;
            this.btnPrintLabel.Text = "重新打印";
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // LabelScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl4);
            this.Name = "LabelScanning";
            this.Size = new System.Drawing.Size(1283, 700);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdcLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLabelCollect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.DateTimePicker dtpQueryTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbIffield;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox cbBatch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gdcLabel;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvLabelCollect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cbScanning;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.PictureBox pbLabelPreview;
        private System.Windows.Forms.TextBox txbBarCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnScenning;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnPrintLabel;
    }
}
