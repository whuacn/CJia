namespace CJia.PIVAS.App.UI
{
    partial class StorageLabel
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
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gdcLabel.Size = new System.Drawing.Size(694, 364);
            this.gdcLabel.TabIndex = 3;
            this.gdcLabel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvLabelCollect});
            // 
            // gdvLabelCollect
            // 
            this.gdvLabelCollect.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gdvLabelCollect.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.gdvLabelCollect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn12,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn2});
            this.gdvLabelCollect.GridControl = this.gdcLabel;
            this.gdvLabelCollect.Name = "gdvLabelCollect";
            this.gdvLabelCollect.OptionsBehavior.Editable = false;
            this.gdvLabelCollect.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gdvLabelCollect.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "药品名称";
            this.gridColumn6.FieldName = "PHARM_NAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 205;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "药品规格";
            this.gridColumn10.FieldName = "SPEC";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 96;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "药品厂商";
            this.gridColumn1.FieldName = "FIRM_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "需求数量";
            this.gridColumn12.FieldName = "ALL_COUNT";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 74;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "库存数量";
            this.gridColumn8.FieldName = "QUANTITY";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 71;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "缺少数量";
            this.gridColumn13.FieldName = "DIFF_COUNT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 68;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "药品单位";
            this.gridColumn2.FieldName = "AMOUNT_UNIT";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 68;
            // 
            // StorageLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdcLabel);
            this.Name = "StorageLabel";
            this.Size = new System.Drawing.Size(694, 364);
            ((System.ComponentModel.ISupportInitialize)(this.gdcLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLabelCollect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdcLabel;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvLabelCollect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}
