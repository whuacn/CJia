namespace CJia.CheckRegOrder.App.UI
{
    partial class RegNoCheckView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegNoCheckView));
            this.panelControl21 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.gcRegNoCheckPatient = new DevExpress.XtraGrid.GridControl();
            this.gvRegNoCheckPatient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn68 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).BeginInit();
            this.panelControl21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRegNoCheckPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegNoCheckPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl21
            // 
            this.panelControl21.Controls.Add(this.btnDelete);
            this.panelControl21.Controls.Add(this.gcRegNoCheckPatient);
            this.panelControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl21.Location = new System.Drawing.Point(0, 0);
            this.panelControl21.Name = "panelControl21";
            this.panelControl21.Size = new System.Drawing.Size(919, 531);
            this.panelControl21.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(810, 495);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 29);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gcRegNoCheckPatient
            // 
            this.gcRegNoCheckPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcRegNoCheckPatient.Location = new System.Drawing.Point(0, 0);
            this.gcRegNoCheckPatient.MainView = this.gvRegNoCheckPatient;
            this.gcRegNoCheckPatient.Name = "gcRegNoCheckPatient";
            this.gcRegNoCheckPatient.Size = new System.Drawing.Size(919, 485);
            this.gcRegNoCheckPatient.TabIndex = 4;
            this.gcRegNoCheckPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRegNoCheckPatient,
            this.gridView15});
            // 
            // gvRegNoCheckPatient
            // 
            this.gvRegNoCheckPatient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gvRegNoCheckPatient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56,
            this.gridColumn57,
            this.gridColumn68,
            this.gridColumn58,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvRegNoCheckPatient.GridControl = this.gcRegNoCheckPatient;
            this.gvRegNoCheckPatient.Name = "gvRegNoCheckPatient";
            this.gvRegNoCheckPatient.OptionsBehavior.Editable = false;
            this.gvRegNoCheckPatient.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病人卡号";
            this.gridColumn1.FieldName = "patient_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "姓名";
            this.gridColumn37.FieldName = "patient_name";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 2;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "性别";
            this.gridColumn38.FieldName = "gender";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 3;
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "出生年月";
            this.gridColumn54.FieldName = "birthday";
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 4;
            // 
            // gridColumn55
            // 
            this.gridColumn55.Caption = "家庭住址";
            this.gridColumn55.FieldName = "address";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 5;
            this.gridColumn55.Width = 120;
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "联系电话";
            this.gridColumn56.FieldName = "telephone";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 6;
            this.gridColumn56.Width = 96;
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "病人类型";
            this.gridColumn57.FieldName = "patient_type";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 7;
            // 
            // gridColumn68
            // 
            this.gridColumn68.Caption = "登记人";
            this.gridColumn68.FieldName = "user_name";
            this.gridColumn68.Name = "gridColumn68";
            this.gridColumn68.Visible = true;
            this.gridColumn68.VisibleIndex = 8;
            // 
            // gridColumn58
            // 
            this.gridColumn58.Caption = "登记时间";
            this.gridColumn58.FieldName = "register_date";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 9;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "就诊类型";
            this.gridColumn2.FieldName = "admissions_type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "发票编号";
            this.gridColumn3.FieldName = "invoice_no";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 12;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "开票时间";
            this.gridColumn4.FieldName = "invoice_date";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 13;
            // 
            // gridView15
            // 
            this.gridView15.GridControl = this.gcRegNoCheckPatient;
            this.gridView15.Name = "gridView15";
            // 
            // RegNoCheckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl21);
            this.Name = "RegNoCheckView";
            this.Size = new System.Drawing.Size(919, 531);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).EndInit();
            this.panelControl21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRegNoCheckPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegNoCheckPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl21;
        private DevExpress.XtraGrid.GridControl gcRegNoCheckPatient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRegNoCheckPatient;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn55;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn68;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
