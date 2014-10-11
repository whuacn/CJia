namespace CJia.PIVAS.App.UI
{
    partial class PharmFilterView
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PharmFilterView));
            this.ckePharm = new DevExpress.XtraEditors.CheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPharmName = new System.Windows.Forms.TextBox();
            this.gcPatient = new DevExpress.XtraGrid.GridControl();
            this.gvPatient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.isCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ckePharm.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // ckePharm
            // 
            this.ckePharm.EditValue = true;
            this.ckePharm.Location = new System.Drawing.Point(3, 10);
            this.ckePharm.Name = "ckePharm";
            this.ckePharm.Properties.Caption = "全部药品";
            this.ckePharm.Size = new System.Drawing.Size(75, 19);
            this.ckePharm.TabIndex = 888;
            this.ckePharm.CheckedChanged += new System.EventHandler(this.ckeBen_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.txtPharmName);
            this.panel1.Controls.Add(this.gcPatient);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.ckePharm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 418);
            this.panel1.TabIndex = 4;
            // 
            // txtPharmName
            // 
            this.txtPharmName.Location = new System.Drawing.Point(84, 7);
            this.txtPharmName.Name = "txtPharmName";
            this.txtPharmName.Size = new System.Drawing.Size(300, 22);
            this.txtPharmName.TabIndex = 1;
            this.txtPharmName.TextChanged += new System.EventHandler(this.txtPharmName_TextChanged);
            this.txtPharmName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPharmName_KeyDown);
            // 
            // gcPatient
            // 
            this.gcPatient.Location = new System.Drawing.Point(5, 34);
            this.gcPatient.MainView = this.gvPatient;
            this.gcPatient.Name = "gcPatient";
            this.gcPatient.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.isCheck,
            this.repositoryItemCheckEdit1});
            this.gcPatient.Size = new System.Drawing.Size(424, 336);
            this.gcPatient.TabIndex = 29;
            this.gcPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatient});
            // 
            // gvPatient
            // 
            this.gvPatient.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPatient.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPatient.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPatient.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvPatient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn2});
            this.gvPatient.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvPatient.GridControl = this.gcPatient;
            this.gvPatient.Name = "gvPatient";
            this.gvPatient.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPatient.OptionsSelection.MultiSelect = true;
            this.gvPatient.OptionsView.ShowGroupPanel = false;
            this.gvPatient.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "ISCHECK";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 48;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "药品名称";
            this.gridColumn3.FieldName = "PHARM_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 153;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "药品规格";
            this.gridColumn5.FieldName = "PHARM_SPEC";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 83;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "药品厂家";
            this.gridColumn6.FieldName = "PHARM_FACTION";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 138;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "默认选择";
            this.gridColumn2.ColumnEdit = this.isCheck;
            this.gridColumn2.FieldName = "INIT_CHECK";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // isCheck
            // 
            this.isCheck.AutoHeight = false;
            this.isCheck.Name = "isCheck";
            this.isCheck.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.isCheck.ValueGrayed = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.Image")));
            this.btnEnter.Location = new System.Drawing.Point(314, 380);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 27);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "确认";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // PharmFilterView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PharmFilterView";
            this.Size = new System.Drawing.Size(432, 418);
            this.Enter += new System.EventHandler(this.FilterPharmView_Enter);
            this.Leave += new System.EventHandler(this.FilterPharmView_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.ckePharm.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isCheck)).EndInit();
            this.ResumeLayout(false);

        }






        #endregion

        private DevExpress.XtraEditors.CheckEdit ckePharm;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
        private DevExpress.XtraGrid.GridControl gcPatient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatient;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit isCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.TextBox txtPharmName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
