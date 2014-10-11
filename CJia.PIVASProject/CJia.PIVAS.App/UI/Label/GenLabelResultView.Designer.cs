namespace CJia.PIVAS.App.UI.Label
{
    partial class GenLabelResultView
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
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.grcLabelDetail = new DevExpress.XtraGrid.GridControl();
            this.grvLabelDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdIllfield = new DevExpress.XtraGrid.GridControl();
            this.grvIllfield = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcLabelDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLabelDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIllfield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIllfield)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.AllowTouchScroll = true;
            this.groupControl4.AlwaysScrollActiveControlIntoView = false;
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.Controls.Add(this.grcLabelDetail);
            this.groupControl4.Location = new System.Drawing.Point(3, 3);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(520, 377);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "生成的瓶贴";
            // 
            // grcLabelDetail
            // 
            this.grcLabelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcLabelDetail.Location = new System.Drawing.Point(2, 22);
            this.grcLabelDetail.MainView = this.grvLabelDetail;
            this.grcLabelDetail.Name = "grcLabelDetail";
            this.grcLabelDetail.Size = new System.Drawing.Size(516, 353);
            this.grcLabelDetail.TabIndex = 1;
            this.grcLabelDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLabelDetail});
            // 
            // grvLabelDetail
            // 
            this.grvLabelDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn15,
            this.gridColumn16});
            this.grvLabelDetail.GridControl = this.grcLabelDetail;
            this.grvLabelDetail.GroupCount = 4;
            this.grvLabelDetail.Name = "grvLabelDetail";
            this.grvLabelDetail.OptionsBehavior.Editable = false;
            this.grvLabelDetail.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grvLabelDetail.OptionsView.ShowGroupPanel = false;
            this.grvLabelDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病区";
            this.gridColumn1.FieldName = "ILLFIELD_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "批次";
            this.gridColumn2.FieldName = "BATCH_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "病人";
            this.gridColumn3.FieldName = "PATIENT_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "组号";
            this.gridColumn4.FieldName = "GROUP_INDEX";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 83;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "药品名称";
            this.gridColumn5.FieldName = "PHARM_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 104;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "规格";
            this.gridColumn6.FieldName = "SPEC";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "数量";
            this.gridColumn7.FieldName = "PHARM_AMOUNT";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "单位";
            this.gridColumn15.FieldName = "AMOUNT_UNIT";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "剂量";
            this.gridColumn16.FieldName = "DOSAGE";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.AllowTouchScroll = true;
            this.groupControl1.AlwaysScrollActiveControlIntoView = false;
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.grdIllfield);
            this.groupControl1.Location = new System.Drawing.Point(529, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(168, 377);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "忽略的病区";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 340);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "略以上病区！";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 320);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(156, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "次瓶贴！故此次生成瓶贴时忽";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 300);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "以上病区已成功生成过该";
            // 
            // grdIllfield
            // 
            this.grdIllfield.Location = new System.Drawing.Point(1, 22);
            this.grdIllfield.MainView = this.grvIllfield;
            this.grdIllfield.Name = "grdIllfield";
            this.grdIllfield.Size = new System.Drawing.Size(167, 261);
            this.grdIllfield.TabIndex = 2;
            this.grdIllfield.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIllfield});
            // 
            // grvIllfield
            // 
            this.grvIllfield.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8});
            this.grvIllfield.GridControl = this.grdIllfield;
            this.grvIllfield.Name = "grvIllfield";
            this.grvIllfield.OptionsBehavior.Editable = false;
            this.grvIllfield.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grvIllfield.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "病区";
            this.gridColumn8.FieldName = "OFFICE_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // GenLabelResultView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl4);
            this.Name = "GenLabelResultView";
            this.Size = new System.Drawing.Size(700, 383);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcLabelDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLabelDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIllfield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIllfield)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grcLabelDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLabelDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl grdIllfield;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIllfield;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}
