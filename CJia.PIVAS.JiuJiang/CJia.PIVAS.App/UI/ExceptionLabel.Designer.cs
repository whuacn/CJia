namespace CJia.PIVAS.App.UI
{
    partial class ExceptionLabel
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
            this.gdcLabel = new DevExpress.XtraGrid.GridControl();
            this.gdvLabelCollect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gdcLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLabelCollect)).BeginInit();
            this.SuspendLayout();
            // 
            // gdcLabel
            // 
            this.gdcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdcLabel.Location = new System.Drawing.Point(0, 0);
            this.gdcLabel.MainView = this.gdvLabelCollect;
            this.gdcLabel.Name = "gdcLabel";
            this.gdcLabel.Size = new System.Drawing.Size(941, 514);
            this.gdcLabel.TabIndex = 3;
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
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn8,
            this.gridColumn9});
            this.gdvLabelCollect.GridControl = this.gdcLabel;
            this.gdvLabelCollect.GroupCount = 3;
            this.gdvLabelCollect.Name = "gdvLabelCollect";
            this.gdvLabelCollect.OptionsBehavior.Editable = false;
            this.gdvLabelCollect.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gdvLabelCollect.OptionsView.ShowGroupPanel = false;
            this.gdvLabelCollect.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gdvLabelCollect.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gdvLabelCollect_RowStyle);
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
            // gridColumn4
            // 
            this.gridColumn4.Caption = "病人";
            this.gridColumn4.FieldName = "NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "医嘱id";
            this.gridColumn5.FieldName = "GROUP_INDEX";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 142;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "条形码";
            this.gridColumn7.FieldName = "LABEL_BAR_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 85;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "药品名称";
            this.gridColumn6.FieldName = "PHARM_NAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 177;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "药品规格";
            this.gridColumn10.FieldName = "SPEC";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 72;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "药品数量";
            this.gridColumn12.FieldName = "PHARM_AMOUNT";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "药品单位";
            this.gridColumn13.FieldName = "AMOUNT_UNIT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 69;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "打印时间";
            this.gridColumn8.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "GEN_DATE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 184;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "扫描状态";
            this.gridColumn9.FieldName = "LABEL_STATUS_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 119;
            // 
            // ExceptionLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdcLabel);
            this.Name = "ExceptionLabel";
            this.Size = new System.Drawing.Size(941, 514);
            ((System.ComponentModel.ISupportInitialize)(this.gdcLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLabelCollect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdcLabel;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvLabelCollect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;

    }
}
