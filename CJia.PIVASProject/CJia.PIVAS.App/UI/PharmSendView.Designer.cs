namespace CJia.PIVAS.App.UI
{
    partial class PharmSendView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PharmSendView));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcLable = new DevExpress.XtraGrid.GridControl();
            this.gvLabel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreviewLable = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcLable);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(869, 594);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "瓶贴信息";
            // 
            // gcLable
            // 
            this.gcLable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcLable.Location = new System.Drawing.Point(5, 25);
            this.gcLable.MainView = this.gvLabel;
            this.gcLable.Name = "gcLable";
            this.gcLable.Size = new System.Drawing.Size(859, 564);
            this.gcLable.TabIndex = 0;
            this.gcLable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLabel});
            // 
            // gvLabel
            // 
            this.gvLabel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn7});
            this.gvLabel.GridControl = this.gcLable;
            this.gvLabel.GroupCount = 1;
            this.gvLabel.Name = "gvLabel";
            this.gvLabel.OptionsBehavior.Editable = false;
            this.gvLabel.OptionsView.ShowGroupPanel = false;
            this.gvLabel.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "批次";
            this.gridColumn1.FieldName = "BATCH_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "精神药";
            this.gridColumn2.FieldName = "JSY";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "毒麻药";
            this.gridColumn3.FieldName = "DMY";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "贵重药";
            this.gridColumn4.FieldName = "GCY";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "普通药";
            this.gridColumn5.FieldName = "PTY";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "小计";
            this.gridColumn6.FieldName = "SUBTOTAL";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "病区";
            this.gridColumn7.FieldName = "ILLFIELD_NAME";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnDetail);
            this.groupControl2.Controls.Add(this.btnPreviewLable);
            this.groupControl2.Location = new System.Drawing.Point(878, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(219, 594);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "冲药";
            // 
            // btnDetail
            // 
            this.btnDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnDetail.Appearance.Options.UseFont = true;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(5, 77);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(209, 32);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "查看明细";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnPreviewLable
            // 
            this.btnPreviewLable.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPreviewLable.Appearance.Options.UseFont = true;
            this.btnPreviewLable.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewLable.Image")));
            this.btnPreviewLable.Location = new System.Drawing.Point(5, 25);
            this.btnPreviewLable.Name = "btnPreviewLable";
            this.btnPreviewLable.Size = new System.Drawing.Size(209, 32);
            this.btnPreviewLable.TabIndex = 0;
            this.btnPreviewLable.Text = "预览瓶贴";
            this.btnPreviewLable.Click += new System.EventHandler(this.btnPreviewLable_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "抗生素";
            this.gridColumn8.FieldName = "KSS";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // PharmSendView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "PharmSendView";
            this.Size = new System.Drawing.Size(1100, 600);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcLable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnPreviewLable;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}
