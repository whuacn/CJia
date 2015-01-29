namespace CJia.PIVAS.App.UI
{
    partial class NoPrintLabel
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
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn3,
            this.gridColumn6});
            this.gdvLabelCollect.GridControl = this.gdcLabel;
            this.gdvLabelCollect.GroupCount = 2;
            this.gdvLabelCollect.Name = "gdvLabelCollect";
            this.gdvLabelCollect.OptionsBehavior.Editable = false;
            this.gdvLabelCollect.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gdvLabelCollect.OptionsView.ShowGroupPanel = false;
            this.gdvLabelCollect.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn6, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.gridColumn2.VisibleIndex = 3;
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
            this.gridColumn5.Width = 142;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "瓶贴明细";
            this.gridColumn3.FieldName = "LABEL_DETAIL";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 83;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "瓶贴来源";
            this.gridColumn6.FieldName = "SRC";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // NoPrintLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdcLabel);
            this.Name = "NoPrintLabel";
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;

    }
}
