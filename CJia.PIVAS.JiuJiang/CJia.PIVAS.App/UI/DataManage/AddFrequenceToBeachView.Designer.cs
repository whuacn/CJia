namespace CJia.PIVAS.App.UI.DataManage
{
    partial class AddFrequenceToBeachView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFrequenceToBeachView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BtnSure = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.GlueFrequency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnToLift = new DevExpress.XtraEditors.SimpleButton();
            this.butToRigth = new DevExpress.XtraEditors.SimpleButton();
            this.lbcNoUseBatch = new DevExpress.XtraEditors.ListBoxControl();
            this.lbcUseBatch = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbIllfield = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtIllfield = new System.Windows.Forms.TextBox();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GlueFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcNoUseBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcUseBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIllfield.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "频率:";
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(67, 234);
            this.BtnSure.Name = "BtnSure";
            this.BtnSure.Size = new System.Drawing.Size(75, 25);
            this.BtnSure.TabIndex = 7;
            this.BtnSure.Text = "确  定";
            this.BtnSure.Click += new System.EventHandler(this.BtnSure_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnCancle.Appearance.Options.UseFont = true;
            this.BtnCancle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancle.Image")));
            this.BtnCancle.Location = new System.Drawing.Point(184, 234);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // GlueFrequency
            // 
            this.GlueFrequency.Location = new System.Drawing.Point(101, 55);
            this.GlueFrequency.Name = "GlueFrequency";
            this.GlueFrequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GlueFrequency.Properties.NullText = "";
            this.GlueFrequency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.GlueFrequency.Properties.View = this.gridLookUpEdit1View;
            this.GlueFrequency.Size = new System.Drawing.Size(166, 20);
            this.GlueFrequency.TabIndex = 12;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.gridLookUpEdit1View.OptionsBehavior.ReadOnly = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "简码";
            this.gridColumn2.FieldName = "FILTER";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(67, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "对应批次:";
            // 
            // btnToLift
            // 
            this.btnToLift.Image = ((System.Drawing.Image)(resources.GetObject("btnToLift.Image")));
            this.btnToLift.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnToLift.Location = new System.Drawing.Point(150, 192);
            this.btnToLift.Name = "btnToLift";
            this.btnToLift.Size = new System.Drawing.Size(25, 23);
            this.btnToLift.TabIndex = 28;
            this.btnToLift.Click += new System.EventHandler(this.btnToLift_Click);
            // 
            // butToRigth
            // 
            this.butToRigth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butToRigth.Image = ((System.Drawing.Image)(resources.GetObject("butToRigth.Image")));
            this.butToRigth.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.butToRigth.Location = new System.Drawing.Point(150, 110);
            this.butToRigth.Name = "butToRigth";
            this.butToRigth.Size = new System.Drawing.Size(25, 23);
            this.butToRigth.TabIndex = 27;
            this.butToRigth.Click += new System.EventHandler(this.butToRigth_Click);
            // 
            // lbcNoUseBatch
            // 
            this.lbcNoUseBatch.Location = new System.Drawing.Point(179, 108);
            this.lbcNoUseBatch.Name = "lbcNoUseBatch";
            this.lbcNoUseBatch.Size = new System.Drawing.Size(80, 107);
            this.lbcNoUseBatch.TabIndex = 26;
            this.lbcNoUseBatch.DoubleClick += new System.EventHandler(this.lbcNoUseOrderBy_DoubleClick);
            // 
            // lbcUseBatch
            // 
            this.lbcUseBatch.Location = new System.Drawing.Point(67, 110);
            this.lbcUseBatch.Name = "lbcUseBatch";
            this.lbcUseBatch.Size = new System.Drawing.Size(79, 106);
            this.lbcUseBatch.TabIndex = 25;
            this.lbcUseBatch.DoubleClick += new System.EventHandler(this.lbcUseOrderBy_DoubleClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(67, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "病区:";
            // 
            // cbIllfield
            // 
            this.cbIllfield.Location = new System.Drawing.Point(101, 19);
            this.cbIllfield.Name = "cbIllfield";
            this.cbIllfield.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIllfield.Properties.NullText = "";
            this.cbIllfield.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbIllfield.Properties.View = this.gridView1;
            this.cbIllfield.Size = new System.Drawing.Size(166, 20);
            this.cbIllfield.TabIndex = 31;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtIllfield
            // 
            this.txtIllfield.Location = new System.Drawing.Point(101, 19);
            this.txtIllfield.Name = "txtIllfield";
            this.txtIllfield.Size = new System.Drawing.Size(166, 22);
            this.txtIllfield.TabIndex = 32;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "病区";
            this.gridColumn4.FieldName = "OFFICE_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "FITTER";
            this.gridColumn5.FieldName = "FILTER";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "频率";
            this.gridColumn1.FieldName = "FREQUENCY_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "FITTER";
            this.gridColumn3.FieldName = "FILTER";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // AddFrequenceToBeachView
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtIllfield);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cbIllfield);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnToLift);
            this.Controls.Add(this.butToRigth);
            this.Controls.Add(this.lbcNoUseBatch);
            this.Controls.Add(this.lbcUseBatch);
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.GlueFrequency);
            this.Name = "AddFrequenceToBeachView";
            this.Size = new System.Drawing.Size(319, 283);
            this.Load += new System.EventHandler(this.AddFrequenceToBeachView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GlueFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcNoUseBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcUseBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIllfield.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.GridLookUpEdit GlueFrequency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnToLift;
        private DevExpress.XtraEditors.SimpleButton butToRigth;
        private DevExpress.XtraEditors.ListBoxControl lbcNoUseBatch;
        private DevExpress.XtraEditors.ListBoxControl lbcUseBatch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit cbIllfield;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.TextBox txtIllfield;
    }
}
