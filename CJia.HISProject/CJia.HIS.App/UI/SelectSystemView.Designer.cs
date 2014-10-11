namespace CJia.HIS.App.UI
{
    partial class SelectSystemView
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.btnCentel = new DevExpress.XtraEditors.SimpleButton();
            this.gctSelectSys = new DevExpress.XtraGrid.GridControl();
            this.gvwSelectSys = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctSelectSys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSelectSys)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnEnter);
            this.panelControl1.Controls.Add(this.btnCentel);
            this.panelControl1.Controls.Add(this.gctSelectSys);
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(324, 395);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl1.Location = new System.Drawing.Point(112, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 23);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "子系统选择";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(213, 367);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "确定";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCentel
            // 
            this.btnCentel.Location = new System.Drawing.Point(36, 367);
            this.btnCentel.Name = "btnCentel";
            this.btnCentel.Size = new System.Drawing.Size(75, 23);
            this.btnCentel.TabIndex = 1;
            this.btnCentel.Text = "取消";
            this.btnCentel.Click += new System.EventHandler(this.btnCentel_Click);
            // 
            // gctSelectSys
            // 
            this.gctSelectSys.Location = new System.Drawing.Point(5, 35);
            this.gctSelectSys.MainView = this.gvwSelectSys;
            this.gctSelectSys.Name = "gctSelectSys";
            this.gctSelectSys.Size = new System.Drawing.Size(314, 321);
            this.gctSelectSys.TabIndex = 0;
            this.gctSelectSys.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwSelectSys});
            this.gctSelectSys.DoubleClick += new System.EventHandler(this.btnEnter_Click);
            // 
            // gvwSelectSys
            // 
            this.gvwSelectSys.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvwSelectSys.GridControl = this.gctSelectSys;
            this.gvwSelectSys.Name = "gvwSelectSys";
            this.gvwSelectSys.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "子系统名";
            this.gridColumn1.FieldName = "SYSTEM_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(),
            new DevExpress.XtraGrid.GridColumnSummaryItem(),
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // SelectSystemView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panelControl1);
            this.Name = "SelectSystemView";
            this.Size = new System.Drawing.Size(334, 405);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctSelectSys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSelectSys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gctSelectSys;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwSelectSys;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
        private DevExpress.XtraEditors.SimpleButton btnCentel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}