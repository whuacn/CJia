namespace CJia.PIVAS.App.UI
{
    partial class PatientView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vgcPatient = new DevExpress.XtraVerticalGrid.VGridControl();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row8 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row9 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row10 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row11 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row12 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row13 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row14 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgcPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vgcPatient);
            this.panelControl1.Location = new System.Drawing.Point(1, -4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(458, 459);
            this.panelControl1.TabIndex = 0;
            // 
            // vgcPatient
            // 
            this.vgcPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgcPatient.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.vgcPatient.Location = new System.Drawing.Point(2, 5);
            this.vgcPatient.Name = "vgcPatient";
            this.vgcPatient.RecordWidth = 387;
            this.vgcPatient.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row,
            this.row6});
            this.vgcPatient.Size = new System.Drawing.Size(454, 454);
            this.vgcPatient.TabIndex = 6;
            // 
            // row
            // 
            this.row.Appearance.BackColor = System.Drawing.Color.White;
            this.row.Appearance.Options.UseBackColor = true;
            this.row.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row1,
            this.row2,
            this.row3,
            this.row4,
            this.row5});
            this.row.Height = 30;
            this.row.Name = "row";
            this.row.Properties.Caption = "基本信息";
            // 
            // row1
            // 
            this.row1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.row1.Appearance.Options.UseForeColor = true;
            this.row1.Height = 28;
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "姓      名";
            this.row1.Properties.FieldName = "PATIENT_NAME";
            // 
            // row2
            // 
            this.row2.Height = 28;
            this.row2.Name = "row2";
            this.row2.Properties.Caption = "性      别";
            this.row2.Properties.FieldName = "GENDER";
            // 
            // row3
            // 
            this.row3.Height = 28;
            this.row3.Name = "row3";
            this.row3.Properties.Caption = "出生日期";
            this.row3.Properties.FieldName = "BIRTHDAY";
            // 
            // row4
            // 
            this.row4.Height = 28;
            this.row4.Name = "row4";
            this.row4.Properties.Caption = "病人类型";
            this.row4.Properties.FieldName = "TYPE_NAME";
            // 
            // row5
            // 
            this.row5.Height = 28;
            this.row5.Name = "row5";
            this.row5.Properties.Caption = "子  类 型";
            this.row5.Properties.FieldName = "SUB_TYPE_NAME";
            // 
            // row6
            // 
            this.row6.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row7,
            this.row8,
            this.row9,
            this.row10,
            this.row11,
            this.row12,
            this.row13,
            this.row14});
            this.row6.Height = 30;
            this.row6.Name = "row6";
            this.row6.Properties.Caption = "住院信息";
            // 
            // row7
            // 
            this.row7.Appearance.Options.UseTextOptions = true;
            this.row7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.row7.Height = 28;
            this.row7.Name = "row7";
            this.row7.Properties.Caption = "病 人 id";
            this.row7.Properties.FieldName = "PATIENT_ID";
            // 
            // row8
            // 
            this.row8.Height = 28;
            this.row8.Name = "row8";
            this.row8.Properties.Caption = "病      区";
            this.row8.Properties.FieldName = "ILLFIELD_NAME";
            // 
            // row9
            // 
            this.row9.Height = 28;
            this.row9.Name = "row9";
            this.row9.Properties.Caption = "科      室";
            this.row9.Properties.FieldName = "OFFICE_NAME";
            // 
            // row10
            // 
            this.row10.Height = 28;
            this.row10.Name = "row10";
            this.row10.Properties.Caption = "床      号";
            this.row10.Properties.FieldName = "BED_NAME";
            // 
            // row11
            // 
            this.row11.Height = 28;
            this.row11.Name = "row11";
            this.row11.Properties.Caption = "护理登级";
            this.row11.Properties.FieldName = "GRADE_NAME";
            // 
            // row12
            // 
            this.row12.Height = 28;
            this.row12.Name = "row12";
            this.row12.Properties.Caption = "病    情";
            this.row12.Properties.FieldName = "ILL_STATUS_NAME";
            // 
            // row13
            // 
            this.row13.Height = 28;
            this.row13.Name = "row13";
            this.row13.Properties.Caption = "入院日期";
            this.row13.Properties.FieldName = "INHOS_DATE";
            // 
            // row14
            // 
            this.row14.Height = 28;
            this.row14.Name = "row14";
            this.row14.Properties.Caption = "诊    断";
            this.row14.Properties.FieldName = "DIAGNOSIS";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(357, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelControl1);
            this.Name = "PatientView";
            this.Size = new System.Drawing.Size(462, 491);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgcPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraVerticalGrid.VGridControl vgcPatient;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row4;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row5;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row6;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row7;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row8;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row9;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row10;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row11;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row12;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row13;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row14;
    }
}
