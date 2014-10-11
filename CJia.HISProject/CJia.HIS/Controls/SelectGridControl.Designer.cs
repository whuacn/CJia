namespace CJia.HIS.Controls
{
    partial class SelectGridControl
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
            this.gctResult = new DevExpress.XtraGrid.GridControl();
            this.gvwResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gctResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwResult)).BeginInit();
            this.SuspendLayout();
            // 
            // gctResult
            // 
            this.gctResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctResult.Location = new System.Drawing.Point(0, 0);
            this.gctResult.MainView = this.gvwResult;
            this.gctResult.Name = "gctResult";
            this.gctResult.Size = new System.Drawing.Size(214, 248);
            this.gctResult.TabIndex = 100000;
            this.gctResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwResult});
            this.gctResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gctResult_KeyDown);
            // 
            // gvwResult
            // 
            this.gvwResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvwResult.GridControl = this.gctResult;
            this.gvwResult.Name = "gvwResult";
            this.gvwResult.OptionsBehavior.Editable = false;
            this.gvwResult.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvwResult.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwResult.OptionsView.EnableAppearanceOddRow = true;
            this.gvwResult.OptionsView.ShowGroupPanel = false;
            this.gvwResult.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvwResult_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "TEXT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // SelectGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gctResult);
            this.Name = "SelectGridControl";
            this.Size = new System.Drawing.Size(214, 248);
            ((System.ComponentModel.ISupportInitialize)(this.gctResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gctResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
