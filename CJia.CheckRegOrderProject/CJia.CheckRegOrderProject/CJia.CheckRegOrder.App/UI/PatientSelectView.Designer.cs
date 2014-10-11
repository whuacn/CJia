namespace CJia.CheckRegOrder.App.UI
{
    partial class PatientSelectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientSelectView));
            this.panelControl21 = new DevExpress.XtraEditors.PanelControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.txtPatientName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.gcPatient = new DevExpress.XtraGrid.GridControl();
            this.gvPatient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn68 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtPatientNO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).BeginInit();
            this.panelControl21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientNO.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl21
            // 
            this.panelControl21.Controls.Add(this.btnSelect);
            this.panelControl21.Controls.Add(this.txtPatientName);
            this.panelControl21.Controls.Add(this.labelControl33);
            this.panelControl21.Controls.Add(this.gcPatient);
            this.panelControl21.Controls.Add(this.txtPatientNO);
            this.panelControl21.Controls.Add(this.labelControl23);
            this.panelControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl21.Location = new System.Drawing.Point(0, 0);
            this.panelControl21.Name = "panelControl21";
            this.panelControl21.Size = new System.Drawing.Size(919, 531);
            this.panelControl21.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(438, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 29);
            this.btnSelect.TabIndex = 33;
            this.btnSelect.Text = "查询(&Q)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(280, 13);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(128, 20);
            this.txtPatientName.TabIndex = 32;
            this.txtPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientName_KeyDown);
            // 
            // labelControl33
            // 
            this.labelControl33.Location = new System.Drawing.Point(213, 15);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(60, 14);
            this.labelControl33.TabIndex = 31;
            this.labelControl33.Text = "病人姓名：";
            // 
            // gcPatient
            // 
            this.gcPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPatient.Location = new System.Drawing.Point(0, 43);
            this.gcPatient.MainView = this.gvPatient;
            this.gcPatient.Name = "gcPatient";
            this.gcPatient.Size = new System.Drawing.Size(919, 487);
            this.gcPatient.TabIndex = 4;
            this.gcPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatient,
            this.gridView15});
            // 
            // gvPatient
            // 
            this.gvPatient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gvPatient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn35,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56,
            this.gridColumn57,
            this.gridColumn68,
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvPatient.GridControl = this.gcPatient;
            this.gvPatient.Name = "gvPatient";
            this.gvPatient.OptionsBehavior.Editable = false;
            this.gvPatient.OptionsView.ColumnAutoWidth = false;
            this.gvPatient.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病人卡号";
            this.gridColumn1.FieldName = "patient_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "队列编号";
            this.gridColumn35.FieldName = "queue_no";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 1;
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
            // gridColumn59
            // 
            this.gridColumn59.Caption = "就诊科室";
            this.gridColumn59.FieldName = "clinic_name";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 10;
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
            this.gridView15.GridControl = this.gcPatient;
            this.gridView15.Name = "gridView15";
            // 
            // txtPatientNO
            // 
            this.txtPatientNO.Location = new System.Drawing.Point(79, 13);
            this.txtPatientNO.Name = "txtPatientNO";
            this.txtPatientNO.Size = new System.Drawing.Size(128, 20);
            this.txtPatientNO.TabIndex = 3;
            this.txtPatientNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientNO_KeyDown);
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(12, 15);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(60, 14);
            this.labelControl23.TabIndex = 2;
            this.labelControl23.Text = "病人卡号：";
            // 
            // PatientSelectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl21);
            this.Name = "PatientSelectView";
            this.Size = new System.Drawing.Size(919, 531);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).EndInit();
            this.panelControl21.ResumeLayout(false);
            this.panelControl21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientNO.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl21;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.TextEdit txtPatientName;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraGrid.GridControl gcPatient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatient;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn55;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn68;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn59;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private DevExpress.XtraEditors.TextEdit txtPatientNO;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
