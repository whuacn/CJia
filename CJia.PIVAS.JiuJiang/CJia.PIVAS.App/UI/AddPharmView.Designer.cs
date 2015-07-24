namespace CJia.PIVAS.App.UI
{
    partial class AddPharmView
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
            if(disposing && (components != null))
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
            this.gcPharm = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnFilterPharm = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddPharm = new DevExpress.XtraEditors.SimpleButton();
            this.cbFilterZero = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcPharm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPharm
            // 
            this.gcPharm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPharm.Location = new System.Drawing.Point(3, 52);
            this.gcPharm.MainView = this.gridView1;
            this.gcPharm.Name = "gcPharm";
            this.gcPharm.Size = new System.Drawing.Size(673, 426);
            this.gcPharm.TabIndex = 3;
            this.gcPharm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Desktop;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.SystemColors.Desktop;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Desktop;
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.SystemColors.Desktop;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn1,
            this.gridColumn18,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gcPharm;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "药品名称";
            this.gridColumn14.FieldName = "PHARM_NAME";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 159;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "规格";
            this.gridColumn15.FieldName = "PHARM_SPEC";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 84;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "厂商";
            this.gridColumn16.FieldName = "PHARM_FACTORY";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 76;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "差量";
            this.gridColumn17.FieldName = "ALL_ECONOMIZE_PHARM_AMOUNT";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 54;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "入库量";
            this.gridColumn1.FieldName = "ADD_PHARM_COUNT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "单位";
            this.gridColumn18.FieldName = "PHARM_UNIT";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            this.gridColumn18.Width = 60;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "最近节约时间";
            this.gridColumn2.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "LAST_ECONOMIZE_TIME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            // 
            // btnFilterPharm
            // 
            this.btnFilterPharm.Location = new System.Drawing.Point(175, 12);
            this.btnFilterPharm.Name = "btnFilterPharm";
            this.btnFilterPharm.Size = new System.Drawing.Size(140, 29);
            this.btnFilterPharm.TabIndex = 48;
            this.btnFilterPharm.Text = "增加药品";
            this.btnFilterPharm.Click += new System.EventHandler(this.btnFilterPharm_Click);
            // 
            // btnAddPharm
            // 
            this.btnAddPharm.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnAddPharm.Appearance.Options.UseFont = true;
            this.btnAddPharm.Image = global::CJia.PIVAS.App.Properties.Resources.uu;
            this.btnAddPharm.Location = new System.Drawing.Point(521, 12);
            this.btnAddPharm.Name = "btnAddPharm";
            this.btnAddPharm.Size = new System.Drawing.Size(123, 28);
            this.btnAddPharm.TabIndex = 54;
            this.btnAddPharm.Text = "确认入库";
            this.btnAddPharm.Click += new System.EventHandler(this.btnAddPharm_Click);
            // 
            // cbFilterZero
            // 
            this.cbFilterZero.AutoSize = true;
            this.cbFilterZero.Checked = true;
            this.cbFilterZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilterZero.Location = new System.Drawing.Point(326, 19);
            this.cbFilterZero.Name = "cbFilterZero";
            this.cbFilterZero.Size = new System.Drawing.Size(78, 16);
            this.cbFilterZero.TabIndex = 55;
            this.cbFilterZero.Text = "过滤0节约";
            this.cbFilterZero.UseVisualStyleBackColor = true;
            this.cbFilterZero.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 21);
            this.txtSearch.TabIndex = 56;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // AddPharmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterZero);
            this.Controls.Add(this.btnAddPharm);
            this.Controls.Add(this.btnFilterPharm);
            this.Controls.Add(this.gcPharm);
            this.Name = "AddPharmView";
            this.Size = new System.Drawing.Size(679, 480);
            ((System.ComponentModel.ISupportInitialize)(this.gcPharm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPharm;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.SimpleButton btnFilterPharm;
        private DevExpress.XtraEditors.SimpleButton btnAddPharm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.CheckBox cbFilterZero;
        private System.Windows.Forms.TextBox txtSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
