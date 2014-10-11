namespace CJia.PIVAS.App.UI.DataManage
{
    partial class DeptUsageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptUsageView));
            this.GcDeptUsage = new DevExpress.XtraGrid.GridControl();
            this.GridViewDeptUsage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAddDeptUsage = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GcDeptUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDeptUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GcDeptUsage
            // 
            this.GcDeptUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GcDeptUsage.Location = new System.Drawing.Point(2, 2);
            this.GcDeptUsage.MainView = this.GridViewDeptUsage;
            this.GcDeptUsage.Name = "GcDeptUsage";
            this.GcDeptUsage.Size = new System.Drawing.Size(1090, 534);
            this.GcDeptUsage.TabIndex = 0;
            this.GcDeptUsage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewDeptUsage});
            this.GcDeptUsage.Load += new System.EventHandler(this.GcDeptUsage_Load);
            this.GcDeptUsage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GcDeptUsage_KeyDown);
            // 
            // GridViewDeptUsage
            // 
            this.GridViewDeptUsage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.GridViewDeptUsage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridViewDeptUsage.GridControl = this.GcDeptUsage;
            this.GridViewDeptUsage.Name = "GridViewDeptUsage";
            this.GridViewDeptUsage.OptionsBehavior.Editable = false;
            this.GridViewDeptUsage.OptionsBehavior.ReadOnly = true;
            this.GridViewDeptUsage.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewDeptUsage.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病区";
            this.gridColumn1.FieldName = "OFFICE_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用法";
            this.gridColumn2.FieldName = "USAGE_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.GcDeptUsage);
            this.panelControl1.Location = new System.Drawing.Point(3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1094, 538);
            this.panelControl1.TabIndex = 13;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.Location = new System.Drawing.Point(870, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(100, 27);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "删  除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddDeptUsage
            // 
            this.BtnAddDeptUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddDeptUsage.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.BtnAddDeptUsage.Appearance.Options.UseFont = true;
            this.BtnAddDeptUsage.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddDeptUsage.Image")));
            this.BtnAddDeptUsage.Location = new System.Drawing.Point(764, 12);
            this.BtnAddDeptUsage.Name = "BtnAddDeptUsage";
            this.BtnAddDeptUsage.Size = new System.Drawing.Size(100, 27);
            this.BtnAddDeptUsage.TabIndex = 1;
            this.BtnAddDeptUsage.Text = "添  加";
            this.BtnAddDeptUsage.Click += new System.EventHandler(this.BtnAddDeptUsage_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.BtnRefresh.Appearance.Options.UseFont = true;
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.Location = new System.Drawing.Point(976, 12);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(100, 27);
            this.BtnRefresh.TabIndex = 4;
            this.BtnRefresh.Text = "刷  新";
            this.BtnRefresh.Click += new System.EventHandler(this.GcDeptUsage_Load);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.BtnRefresh);
            this.panelControl2.Controls.Add(this.BtnAddDeptUsage);
            this.panelControl2.Controls.Add(this.BtnDelete);
            this.panelControl2.Location = new System.Drawing.Point(3, 546);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1094, 51);
            this.panelControl2.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(75, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 17);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "按\"F5\"刷新数据";
            // 
            // DeptUsageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "DeptUsageView";
            this.Size = new System.Drawing.Size(1100, 600);
            ((System.ComponentModel.ISupportInitialize)(this.GcDeptUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDeptUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GcDeptUsage;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewDeptUsage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton BtnAddDeptUsage;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
