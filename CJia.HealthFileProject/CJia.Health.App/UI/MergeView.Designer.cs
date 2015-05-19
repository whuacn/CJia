using TwainLib;
namespace CJia.Health.App.UI
{
    partial class MergeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeView));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.lblNoBlank = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.btnNoBlamk = new CJia.Controls.CJiaButton();
            this.lblMesg = new CJia.Controls.CJiaLabel();
            this.btnDelete = new CJia.Controls.BtnDelete();
            this.btnRefresh = new CJia.Controls.CJiaButton();
            this.btnMerge = new CJia.Controls.CJiaButton();
            this.pictureGrid = new CJia.Controls.CJiaGrid();
            this.pictureView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LURecordNO = new CJia.Controls.CJiaRTLookUpMoreCol();
            this.txtTimes = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel17 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel16 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.pdfViewer = new CJia.Health.Tools.PDFViewer();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LURecordNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cJiaPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.pdfViewer);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1358, 600);
            this.splitContainerControl1.SplitterPosition = 391;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel1.Controls.Add(this.lblNoBlank);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel1);
            this.cJiaPanel1.Controls.Add(this.btnNoBlamk);
            this.cJiaPanel1.Controls.Add(this.lblMesg);
            this.cJiaPanel1.Controls.Add(this.btnDelete);
            this.cJiaPanel1.Controls.Add(this.btnRefresh);
            this.cJiaPanel1.Controls.Add(this.btnMerge);
            this.cJiaPanel1.Controls.Add(this.pictureGrid);
            this.cJiaPanel1.Controls.Add(this.LURecordNO);
            this.cJiaPanel1.Controls.Add(this.txtTimes);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel17);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel16);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(391, 600);
            this.cJiaPanel1.TabIndex = 0;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.cJiaLabel3.Location = new System.Drawing.Point(7, 154);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(117, 19);
            this.cJiaLabel3.TabIndex = 180;
            this.cJiaLabel3.Text = "自动识别空白页码：";
            // 
            // lblNoBlank
            // 
            this.lblNoBlank.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoBlank.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblNoBlank.Location = new System.Drawing.Point(133, 132);
            this.lblNoBlank.Name = "lblNoBlank";
            this.lblNoBlank.Size = new System.Drawing.Size(51, 19);
            this.lblNoBlank.TabIndex = 179;
            this.lblNoBlank.Text = "001,002";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cJiaLabel1.Location = new System.Drawing.Point(7, 132);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(104, 19);
            this.cJiaLabel1.TabIndex = 178;
            this.cJiaLabel1.Text = "设置非空白页码：";
            // 
            // btnNoBlamk
            // 
            this.btnNoBlamk.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNoBlamk.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnNoBlamk.Appearance.Options.UseFont = true;
            this.btnNoBlamk.Appearance.Options.UseForeColor = true;
            this.btnNoBlamk.CustomText = "非空白页";
            this.btnNoBlamk.Location = new System.Drawing.Point(268, 97);
            this.btnNoBlamk.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNoBlamk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNoBlamk.Name = "btnNoBlamk";
            this.btnNoBlamk.Selectable = false;
            this.btnNoBlamk.Size = new System.Drawing.Size(80, 28);
            this.btnNoBlamk.TabIndex = 177;
            this.btnNoBlamk.Text = "非空白页";
            this.btnNoBlamk.Click += new System.EventHandler(this.btnNoBlamk_Click);
            // 
            // lblMesg
            // 
            this.lblMesg.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMesg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMesg.Location = new System.Drawing.Point(148, 154);
            this.lblMesg.Name = "lblMesg";
            this.lblMesg.Size = new System.Drawing.Size(51, 19);
            this.lblMesg.TabIndex = 176;
            this.lblMesg.Text = "001,002";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "删除(F6)";
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(62, 53);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(80, 28);
            this.btnDelete.TabIndex = 175;
            this.btnDelete.Text = "删除(F6)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.CustomText = "刷新(F5)";
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(165, 53);
            this.btnRefresh.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selectable = false;
            this.btnRefresh.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh.TabIndex = 174;
            this.btnRefresh.Text = "刷新(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnMerge.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnMerge.Appearance.Options.UseFont = true;
            this.btnMerge.Appearance.Options.UseForeColor = true;
            this.btnMerge.CustomText = "合并(F3)";
            this.btnMerge.Image = ((System.Drawing.Image)(resources.GetObject("btnMerge.Image")));
            this.btnMerge.Location = new System.Drawing.Point(268, 53);
            this.btnMerge.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnMerge.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Selectable = false;
            this.btnMerge.Size = new System.Drawing.Size(80, 28);
            this.btnMerge.TabIndex = 173;
            this.btnMerge.Text = "合并(F3)";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // pictureGrid
            // 
            this.pictureGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureGrid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pictureGrid.IndicatorWidth = 30;
            this.pictureGrid.Location = new System.Drawing.Point(3, 176);
            this.pictureGrid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.pictureGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pictureGrid.MainView = this.pictureView;
            this.pictureGrid.Name = "pictureGrid";
            this.pictureGrid.ShowRowNumber = true;
            this.pictureGrid.Size = new System.Drawing.Size(388, 421);
            this.pictureGrid.TabIndex = 169;
            this.pictureGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pictureView});
            // 
            // pictureView
            // 
            this.pictureView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.pictureView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.pictureView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.pictureView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.pictureView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.pictureView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.pictureView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.pictureView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.pictureView.Appearance.Empty.Options.UseBackColor = true;
            this.pictureView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.EvenRow.Options.UseBackColor = true;
            this.pictureView.Appearance.EvenRow.Options.UseBorderColor = true;
            this.pictureView.Appearance.EvenRow.Options.UseForeColor = true;
            this.pictureView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.pictureView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.pictureView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.pictureView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.pictureView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.pictureView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.pictureView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.pictureView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.FixedLine.Options.UseBackColor = true;
            this.pictureView.Appearance.FixedLine.Options.UseBorderColor = true;
            this.pictureView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.pictureView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.pictureView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.pictureView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.pictureView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.pictureView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.pictureView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.pictureView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.pictureView.Appearance.FocusedRow.Options.UseFont = true;
            this.pictureView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.pictureView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.pictureView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.pictureView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.pictureView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.GroupButton.Options.UseBackColor = true;
            this.pictureView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.pictureView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.pictureView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.pictureView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.pictureView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.pictureView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.pictureView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.pictureView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.GroupRow.Options.UseBackColor = true;
            this.pictureView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.pictureView.Appearance.GroupRow.Options.UseForeColor = true;
            this.pictureView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.pictureView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.pictureView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.pictureView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.pictureView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.pictureView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.pictureView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.pictureView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.pictureView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.HorzLine.Options.UseBackColor = true;
            this.pictureView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.OddRow.Options.UseBackColor = true;
            this.pictureView.Appearance.OddRow.Options.UseBorderColor = true;
            this.pictureView.Appearance.OddRow.Options.UseForeColor = true;
            this.pictureView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.pictureView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.pictureView.Appearance.Preview.Options.UseFont = true;
            this.pictureView.Appearance.Preview.Options.UseForeColor = true;
            this.pictureView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.pictureView.Appearance.Row.Options.UseBackColor = true;
            this.pictureView.Appearance.Row.Options.UseForeColor = true;
            this.pictureView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pictureView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.pictureView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.pictureView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.pictureView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.pictureView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.pictureView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.pictureView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.pictureView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.pictureView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.pictureView.Appearance.VertLine.Options.UseBackColor = true;
            this.pictureView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.pictureView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.pictureView.GridControl = this.pictureGrid;
            this.pictureView.IndicatorWidth = 30;
            this.pictureView.Name = "pictureView";
            this.pictureView.OptionsBehavior.Editable = false;
            this.pictureView.OptionsCustomization.AllowFilter = false;
            this.pictureView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.pictureView.OptionsView.EnableAppearanceEvenRow = true;
            this.pictureView.OptionsView.EnableAppearanceOddRow = true;
            this.pictureView.OptionsView.ShowGroupPanel = false;
            this.pictureView.RowHeight = 25;
            this.pictureView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.pictureView_RowCellStyle);
            this.pictureView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.pictureView_FocusedRowChanged);
            this.pictureView.RowCountChanged += new System.EventHandler(this.pictureView_RowCountChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "图片名称";
            this.gridColumn1.FieldName = "Pic_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 82;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "页码";
            this.gridColumn2.FieldName = "Pic_Page";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 45;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "附加码";
            this.gridColumn3.FieldName = "Pic_SubPage";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 45;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "项目名称";
            this.gridColumn4.FieldName = "Pic_ProjectName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 72;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "状态";
            this.gridColumn5.FieldName = "Pic_State";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 49;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "图片路径";
            this.gridColumn6.FieldName = "Pic_Path";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "项目id";
            this.gridColumn7.FieldName = "Pic_ProjectID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "图片扩展名";
            this.gridColumn8.FieldName = "Pic_Extension";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "存储路径";
            this.gridColumn9.FieldName = "STORAGE_PATH";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "逻辑存储路径";
            this.gridColumn10.FieldName = "LOGIC_PATH";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "病人表id";
            this.gridColumn11.FieldName = "HEALTH_ID";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // LURecordNO
            // 
            this.LURecordNO.Caption = "";
            this.LURecordNO.DataSource = null;
            this.LURecordNO.DisplayField = "";
            this.LURecordNO.DisplayText = "";
            this.LURecordNO.DisplayValue = "";
            this.LURecordNO.EditValue = "";
            this.LURecordNO.Fields = null;
            this.LURecordNO.Location = new System.Drawing.Point(62, 14);
            this.LURecordNO.Name = "LURecordNO";
            this.LURecordNO.OpenAfterEnter = false;
            this.LURecordNO.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LURecordNO.Properties.Appearance.Options.UseFont = true;
            this.LURecordNO.Properties.Appearance.Options.UseTextOptions = true;
            this.LURecordNO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LURecordNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.LURecordNO.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LURecordNO.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LURecordNO.Properties.PopupFormMinSize = new System.Drawing.Size(280, 220);
            this.LURecordNO.Properties.PopupFormSize = new System.Drawing.Size(280, 220);
            this.LURecordNO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LURecordNO.ResultRow = null;
            this.LURecordNO.Size = new System.Drawing.Size(209, 20);
            this.LURecordNO.TabIndex = 0;
            this.LURecordNO.UseRowNumDirectSelect = false;
            this.LURecordNO.UseRowNumLocate = false;
            this.LURecordNO.ValueField = "";
            // 
            // txtTimes
            // 
            this.txtTimes.EditValue = "1";
            this.txtTimes.Location = new System.Drawing.Point(296, 15);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTimes.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTimes.Properties.Appearance.Options.UseBackColor = true;
            this.txtTimes.Properties.Appearance.Options.UseFont = true;
            this.txtTimes.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTimes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTimes.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtTimes.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTimes.Properties.Mask.EditMask = "\\d{2}|\\d{1}";
            this.txtTimes.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTimes.Properties.ReadOnly = true;
            this.txtTimes.Size = new System.Drawing.Size(34, 20);
            this.txtTimes.TabIndex = 1;
            this.txtTimes.Leave += new System.EventHandler(this.txtTimes_Leave);
            // 
            // cJiaLabel17
            // 
            this.cJiaLabel17.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel17.Location = new System.Drawing.Point(334, 22);
            this.cJiaLabel17.Name = "cJiaLabel17";
            this.cJiaLabel17.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel17.TabIndex = 142;
            this.cJiaLabel17.Text = "次入院";
            // 
            // cJiaLabel16
            // 
            this.cJiaLabel16.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel16.Location = new System.Drawing.Point(277, 22);
            this.cJiaLabel16.Name = "cJiaLabel16";
            this.cJiaLabel16.Size = new System.Drawing.Size(13, 19);
            this.cJiaLabel16.TabIndex = 141;
            this.cJiaLabel16.Text = "第";
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel2.Location = new System.Drawing.Point(7, 21);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel2.TabIndex = 2;
            this.cJiaLabel2.Text = "病案号";
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.FileName = null;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Password = "";
            this.pdfViewer.Size = new System.Drawing.Size(962, 600);
            this.pdfViewer.StylePDF = CJia.Health.Tools.PDFViewer.PDFStyle.All;
            this.pdfViewer.TabIndex = 0;
            this.pdfViewer.ZoomLevel = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "图片名称";
            this.gridColumn12.FieldName = "PICTURE_NAME";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 82;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "页码";
            this.gridColumn13.FieldName = "PAGE_NO";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 45;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "附加码";
            this.gridColumn14.FieldName = "SUBPAGE";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 45;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "项目名称";
            this.gridColumn15.FieldName = "PRO_NAME";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 72;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn16.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn16.Caption = "状态";
            this.gridColumn16.FieldName = "Pic_State";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            this.gridColumn16.Width = 49;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "图片路径";
            this.gridColumn17.FieldName = "SRC";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "病人表id";
            this.gridColumn22.FieldName = "HEALTH_ID";
            this.gridColumn22.Name = "gridColumn22";
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "项目id";
            this.gridColumn18.FieldName = "PRO_ID";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // MergeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MergeView";
            this.Size = new System.Drawing.Size(1358, 600);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LURecordNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Controls.CJiaPanel cJiaPanel1;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel17;
        private Controls.CJiaLabel cJiaLabel16;
        private Controls.CJiaTextBox txtTimes;
        private Controls.CJiaRTLookUpMoreCol LURecordNO;
        private Controls.CJiaGrid pictureGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView pictureView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        Twain Tw;
        private Controls.CJiaButton btnRefresh;
        private Controls.CJiaButton btnMerge;
        private Controls.BtnDelete btnDelete;
        private Controls.CJiaLabel lblMesg;
        private Controls.CJiaLabel lblNoBlank;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaButton btnNoBlamk;
        private Controls.CJiaLabel cJiaLabel3;
        private Tools.PDFViewer pdfViewer;
    }
}
