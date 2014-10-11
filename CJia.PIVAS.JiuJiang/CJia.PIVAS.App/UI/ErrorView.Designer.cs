namespace CJia.PIVAS.App.UI
{
    partial class ErrorView
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
            this.gcAdvice = new DevExpress.XtraGrid.GridControl();
            this.gvAdvice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsInPivas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcAdvice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAdvice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gcAdvice
            // 
            this.gcAdvice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAdvice.Location = new System.Drawing.Point(0, 0);
            this.gcAdvice.MainView = this.gvAdvice;
            this.gcAdvice.Name = "gcAdvice";
            this.gcAdvice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gcAdvice.Size = new System.Drawing.Size(1517, 933);
            this.gcAdvice.TabIndex = 1;
            this.gcAdvice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAdvice});
            // 
            // gvAdvice
            // 
            this.gvAdvice.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvAdvice.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvAdvice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn2,
            this.gridColumn11,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.colIsInPivas,
            this.gridColumn1,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24});
            this.gvAdvice.GridControl = this.gcAdvice;
            this.gvAdvice.GroupCount = 3;
            this.gvAdvice.Name = "gvAdvice";
            this.gvAdvice.OptionsView.ShowGroupPanel = false;
            this.gvAdvice.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "病区";
            this.gridColumn10.FieldName = "PATIENT_ILLFILED_NAME";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "病人";
            this.gridColumn2.FieldName = "PATIENT";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "医嘱";
            this.gridColumn3.FieldName = "ADVICE_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 211;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "规格与厂商";
            this.gridColumn4.FieldName = "ITEM_SPEC";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 104;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "剂量";
            this.gridColumn5.FieldName = "DOSAGE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 77;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "单位";
            this.gridColumn6.FieldName = "DOSAGE_UNIT";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 36;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "数量";
            this.gridColumn26.FieldName = "ACCOUNT";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            this.gridColumn26.Width = 32;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "单位";
            this.gridColumn27.FieldName = "ACCOUNT_UNIT";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 5;
            this.gridColumn27.Width = 34;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "用法";
            this.gridColumn7.FieldName = "USAGE_NAME";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 63;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "频率";
            this.gridColumn8.FieldName = "FREQUENCY_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 46;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "开单医生";
            this.gridColumn9.FieldName = "LIST_DOCTOR_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 60;
            // 
            // colIsInPivas
            // 
            this.colIsInPivas.Caption = "药品是否存在";
            this.colIsInPivas.FieldName = "IS_IN_PIVAS";
            this.colIsInPivas.Name = "colIsInPivas";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "开单时间";
            this.gridColumn1.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "LIST_DATE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 134;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "医嘱类型";
            this.gridColumn22.FieldName = "LONG_TIME_NAME";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 10;
            this.gridColumn22.Width = 60;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "审核人";
            this.gridColumn23.FieldName = "CHECK_USER";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.Width = 43;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "审核时间";
            this.gridColumn24.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn24.FieldName = "CHECK_DATE";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Width = 126;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PATIENT", "病人信息"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BED_CODE", "床号")});
            this.repositoryItemLookUpEdit2.DataSource = this.gcAdvice.DataSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "PATIENT";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.ValueMember = "ILLFILED_BED_PATIENT_CODE";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "组号";
            this.gridColumn11.FieldName = "GROUP_INDEX";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // ErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcAdvice);
            this.Name = "ErrorView";
            this.Size = new System.Drawing.Size(1517, 933);
            ((System.ComponentModel.ISupportInitialize)(this.gcAdvice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAdvice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAdvice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAdvice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colIsInPivas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}
