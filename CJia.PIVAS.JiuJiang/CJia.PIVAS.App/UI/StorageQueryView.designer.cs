namespace CJia.PIVAS.App.UI
{
    partial class StorageQueryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageQueryView));
            this.StorageGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtDrugFirm = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtDrugNo = new DevExpress.XtraEditors.TextEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.TxtDrugName = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSpec = new DevExpress.XtraEditors.TextEdit();
            this.ceFilterZero = new DevExpress.XtraEditors.CheckEdit();
            this.btnPrintStorage = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.StorageGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugFirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StorageGrid
            // 
            this.StorageGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StorageGrid.Location = new System.Drawing.Point(2, 22);
            this.StorageGrid.MainView = this.gridView1;
            this.StorageGrid.Name = "StorageGrid";
            this.StorageGrid.Size = new System.Drawing.Size(1270, 588);
            this.StorageGrid.TabIndex = 24;
            this.StorageGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn2});
            this.gridView1.GridControl = this.StorageGrid;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn9, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "药品名称";
            this.gridColumn7.FieldName = "DRUG_NAME";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "规格";
            this.gridColumn8.FieldName = "DRUG_SPEC";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "厂商";
            this.gridColumn9.FieldName = "FIRM_ID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "批号";
            this.gridColumn10.FieldName = "BATCH_NO";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "有效期";
            this.gridColumn1.FieldName = "EXPIRE_DATE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "数量";
            this.gridColumn11.FieldName = "QUANTITY";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "单位";
            this.gridColumn12.FieldName = "UNITS";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "价格";
            this.gridColumn2.FieldName = "PRICE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(434, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "批号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(659, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "厂商:";
            // 
            // TxtDrugFirm
            // 
            this.TxtDrugFirm.EditValue = "";
            this.TxtDrugFirm.EnterMoveNextControl = true;
            this.TxtDrugFirm.Location = new System.Drawing.Point(703, 37);
            this.TxtDrugFirm.Name = "TxtDrugFirm";
            this.TxtDrugFirm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDrugFirm.Properties.Appearance.Options.UseFont = true;
            this.TxtDrugFirm.Size = new System.Drawing.Size(148, 22);
            this.TxtDrugFirm.TabIndex = 3;
            this.TxtDrugFirm.EditValueChanged += new System.EventHandler(this.TxtDrugName_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "药品名称：";
            // 
            // TxtDrugNo
            // 
            this.TxtDrugNo.EditValue = "";
            this.TxtDrugNo.EnterMoveNextControl = true;
            this.TxtDrugNo.Location = new System.Drawing.Point(483, 37);
            this.TxtDrugNo.Name = "TxtDrugNo";
            this.TxtDrugNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDrugNo.Properties.Appearance.Options.UseFont = true;
            this.TxtDrugNo.Size = new System.Drawing.Size(152, 22);
            this.TxtDrugNo.TabIndex = 2;
            this.TxtDrugNo.EditValueChanged += new System.EventHandler(this.TxtDrugName_EditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnRefresh.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Appearance.Image")));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseImage = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(985, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 31);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TxtDrugName
            // 
            this.TxtDrugName.EditValue = "";
            this.TxtDrugName.EnterMoveNextControl = true;
            this.TxtDrugName.Location = new System.Drawing.Point(76, 37);
            this.TxtDrugName.Name = "TxtDrugName";
            this.TxtDrugName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDrugName.Properties.Appearance.Options.UseFont = true;
            this.TxtDrugName.Size = new System.Drawing.Size(152, 22);
            this.TxtDrugName.TabIndex = 1;
            this.TxtDrugName.EditValueChanged += new System.EventHandler(this.TxtDrugName_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSpec);
            this.groupControl1.Controls.Add(this.ceFilterZero);
            this.groupControl1.Controls.Add(this.btnPrintStorage);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.TxtDrugNo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.TxtDrugName);
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.TxtDrugFirm);
            this.groupControl1.Location = new System.Drawing.Point(6, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1274, 79);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "库存查询";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(242, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "规格：";
            // 
            // txtSpec
            // 
            this.txtSpec.EditValue = "";
            this.txtSpec.EnterMoveNextControl = true;
            this.txtSpec.Location = new System.Drawing.Point(291, 37);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpec.Properties.Appearance.Options.UseFont = true;
            this.txtSpec.Size = new System.Drawing.Size(124, 22);
            this.txtSpec.TabIndex = 10;
            this.txtSpec.EditValueChanged += new System.EventHandler(this.TxtDrugName_EditValueChanged);
            // 
            // ceFilterZero
            // 
            this.ceFilterZero.Location = new System.Drawing.Point(865, 38);
            this.ceFilterZero.Name = "ceFilterZero";
            this.ceFilterZero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceFilterZero.Properties.Appearance.Options.UseFont = true;
            this.ceFilterZero.Properties.Caption = "过滤0数量药品";
            this.ceFilterZero.Size = new System.Drawing.Size(104, 19);
            this.ceFilterZero.TabIndex = 8;
            this.ceFilterZero.CheckedChanged += new System.EventHandler(this.ceFilterZero_CheckedChanged);
            // 
            // btnPrintStorage
            // 
            this.btnPrintStorage.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPrintStorage.Appearance.Options.UseFont = true;
            this.btnPrintStorage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStorage.Image")));
            this.btnPrintStorage.Location = new System.Drawing.Point(1129, 32);
            this.btnPrintStorage.Name = "btnPrintStorage";
            this.btnPrintStorage.Size = new System.Drawing.Size(117, 31);
            this.btnPrintStorage.TabIndex = 7;
            this.btnPrintStorage.Text = "打印(R)";
            this.btnPrintStorage.Click += new System.EventHandler(this.btnPrintStorage_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.StorageGrid);
            this.groupControl2.Location = new System.Drawing.Point(6, 85);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1274, 612);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "药品库存详情";
            // 
            // StorageQueryView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "StorageQueryView";
            this.Size = new System.Drawing.Size(1283, 700);
            ((System.ComponentModel.ISupportInitialize)(this.StorageGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugFirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDrugName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl StorageGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtDrugFirm;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtDrugNo;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.TextEdit TxtDrugName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnPrintStorage;
        private DevExpress.XtraEditors.CheckEdit ceFilterZero;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSpec;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}
