namespace CJia.PIVAS.App.UI.DataManage
{
    partial class AddDeptUsageView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeptUsageView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GlueDept = new DevExpress.XtraEditors.GridLookUpEdit();
            this.GlueViewDept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.GlueUsage = new DevExpress.XtraEditors.GridLookUpEdit();
            this.GlueViewUsage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnCalcle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSure = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GlueDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueViewDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueViewUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(47, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 17);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "病区：";
            // 
            // GlueDept
            // 
            this.GlueDept.Location = new System.Drawing.Point(95, 35);
            this.GlueDept.Name = "GlueDept";
            this.GlueDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GlueDept.Properties.NullText = "";
            this.GlueDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.GlueDept.Properties.View = this.GlueViewDept;
            this.GlueDept.Size = new System.Drawing.Size(166, 20);
            this.GlueDept.TabIndex = 14;
            this.GlueDept.EditValueChanged += new System.EventHandler(this.GlueDept_EditValueChanged);
            // 
            // GlueViewDept
            // 
            this.GlueViewDept.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.GlueViewDept.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GlueViewDept.Name = "GlueViewDept";
            this.GlueViewDept.OptionsBehavior.AutoPopulateColumns = false;
            this.GlueViewDept.OptionsBehavior.Editable = false;
            this.GlueViewDept.OptionsBehavior.ReadOnly = true;
            this.GlueViewDept.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GlueViewDept.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病区";
            this.gridColumn1.FieldName = "DEPT_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(47, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 17);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "用法：";
            // 
            // GlueUsage
            // 
            this.GlueUsage.Location = new System.Drawing.Point(95, 80);
            this.GlueUsage.Name = "GlueUsage";
            this.GlueUsage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GlueUsage.Properties.NullText = "";
            this.GlueUsage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.GlueUsage.Properties.View = this.GlueViewUsage;
            this.GlueUsage.Size = new System.Drawing.Size(166, 20);
            this.GlueUsage.TabIndex = 16;
            // 
            // GlueViewUsage
            // 
            this.GlueViewUsage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.GlueViewUsage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GlueViewUsage.Name = "GlueViewUsage";
            this.GlueViewUsage.OptionsBehavior.AutoPopulateColumns = false;
            this.GlueViewUsage.OptionsBehavior.Editable = false;
            this.GlueViewUsage.OptionsBehavior.ReadOnly = true;
            this.GlueViewUsage.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GlueViewUsage.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用法";
            this.gridColumn2.FieldName = "USAGE_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // BtnCalcle
            // 
            this.BtnCalcle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnCalcle.Appearance.Options.UseFont = true;
            this.BtnCalcle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCalcle.Image")));
            this.BtnCalcle.Location = new System.Drawing.Point(176, 136);
            this.BtnCalcle.Name = "BtnCalcle";
            this.BtnCalcle.Size = new System.Drawing.Size(75, 25);
            this.BtnCalcle.TabIndex = 10;
            this.BtnCalcle.Text = "取  消";
            this.BtnCalcle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(58, 136);
            this.BtnSure.Name = "BtnSure";
            this.BtnSure.Size = new System.Drawing.Size(75, 23);
            this.BtnSure.TabIndex = 9;
            this.BtnSure.Text = "确  定";
            this.BtnSure.Click += new System.EventHandler(this.BtnSure_Click);
            // 
            // AddDeptUsageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCalcle);
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.GlueUsage);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.GlueDept);
            this.Name = "AddDeptUsageView";
            this.Size = new System.Drawing.Size(310, 190);
            this.Load += new System.EventHandler(this.AddDeptUsageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GlueDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueViewDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlueViewUsage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit GlueDept;
        private DevExpress.XtraGrid.Views.Grid.GridView GlueViewDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit GlueUsage;
        private DevExpress.XtraGrid.Views.Grid.GridView GlueViewUsage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCalcle;
    }
}
