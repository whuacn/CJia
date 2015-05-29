namespace CJia.Health.App.UI
{
    partial class LookSetView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookSetView));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cgPicture = new CJia.Controls.CJiaGrid();
            this.gvPicture = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LURecordNO = new CJia.Controls.CJiaRTLookUpMoreCol();
            this.cJiaLabel62 = new CJia.Controls.CJiaLabel();
            this.lblprojectName = new CJia.Controls.CJiaLabel();
            this.pdfViewer = new CJia.Health.Tools.PDFViewer();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.btnExport = new CJia.Controls.CJiaButton();
            this.btnPrint = new CJia.Controls.CJiaButton();
            this.btnAllExport = new CJia.Controls.CJiaButton();
            this.btnAllPrint = new CJia.Controls.CJiaButton();
            this.btnAllYes = new CJia.Controls.CJiaButton();
            this.btnAllNO = new CJia.Controls.CJiaButton();
            this.btnDownPage = new CJia.Controls.CJiaButton();
            this.btnNo = new CJia.Controls.BtnDelete();
            this.btnUpPage = new CJia.Controls.CJiaButton();
            this.btnYes = new CJia.Controls.BtnSave();
            this.btnLock = new CJia.Controls.CJiaButton();
            this.btnUnLock = new CJia.Controls.CJiaButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LURecordNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cJiaPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.lblprojectName);
            this.splitContainerControl1.Panel2.Controls.Add(this.pdfViewer);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1118, 621);
            this.splitContainerControl1.SplitterPosition = 350;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.cgPicture);
            this.cJiaPanel1.Controls.Add(this.LURecordNO);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel62);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(350, 621);
            this.cJiaPanel1.TabIndex = 0;
            // 
            // cgPicture
            // 
            this.cgPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cgPicture.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgPicture.IndicatorWidth = 30;
            this.cgPicture.Location = new System.Drawing.Point(4, 56);
            this.cgPicture.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgPicture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgPicture.MainView = this.gvPicture;
            this.cgPicture.Name = "cgPicture";
            this.cgPicture.ShowRowNumber = true;
            this.cgPicture.Size = new System.Drawing.Size(342, 562);
            this.cgPicture.TabIndex = 173;
            this.cgPicture.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPicture});
            this.cgPicture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cgPicture_KeyDown);
            // 
            // gvPicture
            // 
            this.gvPicture.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvPicture.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvPicture.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvPicture.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvPicture.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvPicture.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvPicture.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvPicture.Appearance.Empty.Options.UseBackColor = true;
            this.gvPicture.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvPicture.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvPicture.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvPicture.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvPicture.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPicture.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvPicture.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvPicture.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvPicture.Appearance.FixedLine.Options.UseBorderColor = true;
            this.gvPicture.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPicture.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPicture.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPicture.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPicture.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gvPicture.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPicture.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvPicture.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvPicture.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvPicture.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvPicture.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvPicture.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvPicture.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvPicture.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvPicture.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPicture.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPicture.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvPicture.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvPicture.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPicture.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPicture.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPicture.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gvPicture.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPicture.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gvPicture.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPicture.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvPicture.Appearance.OddRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvPicture.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPicture.Appearance.Preview.Options.UseFont = true;
            this.gvPicture.Appearance.Preview.Options.UseForeColor = true;
            this.gvPicture.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvPicture.Appearance.Row.Options.UseBackColor = true;
            this.gvPicture.Appearance.Row.Options.UseForeColor = true;
            this.gvPicture.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPicture.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvPicture.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvPicture.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPicture.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvPicture.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvPicture.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvPicture.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPicture.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPicture.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4});
            this.gvPicture.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPicture.GridControl = this.cgPicture;
            this.gvPicture.IndicatorWidth = 30;
            this.gvPicture.Name = "gvPicture";
            this.gvPicture.OptionsBehavior.Editable = false;
            this.gvPicture.OptionsCustomization.AllowFilter = false;
            this.gvPicture.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPicture.OptionsView.AllowCellMerge = true;
            this.gvPicture.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPicture.OptionsView.EnableAppearanceOddRow = true;
            this.gvPicture.OptionsView.ShowGroupPanel = false;
            this.gvPicture.RowHeight = 25;
            this.gvPicture.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvBigPicture_RowCellStyle);
            this.gvPicture.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPicture_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "页码";
            this.gridColumn1.FieldName = "PAGE_NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 49;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "附加码";
            this.gridColumn3.FieldName = "SUBPAGE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "项目名称";
            this.gridColumn2.FieldName = "PRO_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 130;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "访问权限";
            this.gridColumn4.FieldName = "IS_LOOK_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 81;
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
            this.LURecordNO.Location = new System.Drawing.Point(65, 14);
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
            this.LURecordNO.Properties.PopupFormMinSize = new System.Drawing.Size(270, 220);
            this.LURecordNO.Properties.PopupFormSize = new System.Drawing.Size(270, 220);
            this.LURecordNO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LURecordNO.ResultRow = null;
            this.LURecordNO.Size = new System.Drawing.Size(278, 20);
            this.LURecordNO.TabIndex = 174;
            this.LURecordNO.UseRowNumDirectSelect = false;
            this.LURecordNO.UseRowNumLocate = false;
            this.LURecordNO.ValueField = "";
            this.LURecordNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LURecordNO_KeyDown);
            // 
            // cJiaLabel62
            // 
            this.cJiaLabel62.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel62.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel62.Location = new System.Drawing.Point(7, 15);
            this.cJiaLabel62.Name = "cJiaLabel62";
            this.cJiaLabel62.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel62.TabIndex = 171;
            this.cJiaLabel62.Text = "病案号：";
            // 
            // lblprojectName
            // 
            this.lblprojectName.Appearance.BackColor = System.Drawing.Color.White;
            this.lblprojectName.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lblprojectName.Appearance.Font = new System.Drawing.Font("Tahoma", 22F);
            this.lblprojectName.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblprojectName.Location = new System.Drawing.Point(29, 48);
            this.lblprojectName.Name = "lblprojectName";
            this.lblprojectName.Size = new System.Drawing.Size(116, 35);
            this.lblprojectName.TabIndex = 5;
            this.lblprojectName.Text = "病案首页";
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.FileName = null;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Password = "";
            this.pdfViewer.Size = new System.Drawing.Size(763, 621);
            this.pdfViewer.StylePDF = CJia.Health.Tools.PDFViewer.PDFStyle.All;
            this.pdfViewer.TabIndex = 2;
            this.pdfViewer.ZoomLevel = 3;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel2.Controls.Add(this.btnUnLock);
            this.cJiaPanel2.Controls.Add(this.btnLock);
            this.cJiaPanel2.Controls.Add(this.btnExport);
            this.cJiaPanel2.Controls.Add(this.btnPrint);
            this.cJiaPanel2.Controls.Add(this.btnAllExport);
            this.cJiaPanel2.Controls.Add(this.btnAllPrint);
            this.cJiaPanel2.Controls.Add(this.btnAllYes);
            this.cJiaPanel2.Controls.Add(this.btnAllNO);
            this.cJiaPanel2.Controls.Add(this.btnDownPage);
            this.cJiaPanel2.Controls.Add(this.btnNo);
            this.cJiaPanel2.Controls.Add(this.btnUpPage);
            this.cJiaPanel2.Controls.Add(this.btnYes);
            this.cJiaPanel2.Location = new System.Drawing.Point(1122, 1);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(176, 619);
            this.cJiaPanel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.CustomText = "可以导出(F8)";
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(15, 430);
            this.btnExport.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Selectable = false;
            this.btnExport.Size = new System.Drawing.Size(146, 28);
            this.btnExport.TabIndex = 187;
            this.btnExport.Text = "可以导出(F8)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.CustomText = "可以打印(F7)";
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(15, 388);
            this.btnPrint.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Selectable = false;
            this.btnPrint.Size = new System.Drawing.Size(146, 28);
            this.btnPrint.TabIndex = 186;
            this.btnPrint.Text = "可以打印(F7)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAllExport
            // 
            this.btnAllExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllExport.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAllExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAllExport.Appearance.Options.UseFont = true;
            this.btnAllExport.Appearance.Options.UseForeColor = true;
            this.btnAllExport.CustomText = "全部可以导出";
            this.btnAllExport.Location = new System.Drawing.Point(15, 576);
            this.btnAllExport.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAllExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAllExport.Name = "btnAllExport";
            this.btnAllExport.Selectable = false;
            this.btnAllExport.Size = new System.Drawing.Size(146, 28);
            this.btnAllExport.TabIndex = 185;
            this.btnAllExport.Text = "全部可以导出";
            this.btnAllExport.Click += new System.EventHandler(this.btnAllExport_Click);
            // 
            // btnAllPrint
            // 
            this.btnAllPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAllPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAllPrint.Appearance.Options.UseFont = true;
            this.btnAllPrint.Appearance.Options.UseForeColor = true;
            this.btnAllPrint.CustomText = "全部可以打印";
            this.btnAllPrint.Location = new System.Drawing.Point(15, 534);
            this.btnAllPrint.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAllPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAllPrint.Name = "btnAllPrint";
            this.btnAllPrint.Selectable = false;
            this.btnAllPrint.Size = new System.Drawing.Size(146, 28);
            this.btnAllPrint.TabIndex = 184;
            this.btnAllPrint.Text = "全部可以打印";
            this.btnAllPrint.Click += new System.EventHandler(this.btnAllPrint_Click);
            // 
            // btnAllYes
            // 
            this.btnAllYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllYes.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAllYes.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAllYes.Appearance.Options.UseFont = true;
            this.btnAllYes.Appearance.Options.UseForeColor = true;
            this.btnAllYes.CustomText = "全部可以浏览";
            this.btnAllYes.Location = new System.Drawing.Point(15, 492);
            this.btnAllYes.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAllYes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAllYes.Name = "btnAllYes";
            this.btnAllYes.Selectable = false;
            this.btnAllYes.Size = new System.Drawing.Size(146, 28);
            this.btnAllYes.TabIndex = 183;
            this.btnAllYes.Text = "全部可以浏览";
            this.btnAllYes.Click += new System.EventHandler(this.btnAllYes_Click);
            // 
            // btnAllNO
            // 
            this.btnAllNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllNO.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAllNO.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAllNO.Appearance.Options.UseFont = true;
            this.btnAllNO.Appearance.Options.UseForeColor = true;
            this.btnAllNO.CustomText = "全部不能浏览";
            this.btnAllNO.Location = new System.Drawing.Point(15, 123);
            this.btnAllNO.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAllNO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAllNO.Name = "btnAllNO";
            this.btnAllNO.Selectable = false;
            this.btnAllNO.Size = new System.Drawing.Size(146, 28);
            this.btnAllNO.TabIndex = 182;
            this.btnAllNO.Text = "全部不能浏览";
            this.btnAllNO.Click += new System.EventHandler(this.btnAllNO_Click);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownPage.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDownPage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDownPage.Appearance.Options.UseFont = true;
            this.btnDownPage.Appearance.Options.UseForeColor = true;
            this.btnDownPage.CustomText = "下一页(F4)";
            this.btnDownPage.Image = ((System.Drawing.Image)(resources.GetObject("btnDownPage.Image")));
            this.btnDownPage.Location = new System.Drawing.Point(15, 238);
            this.btnDownPage.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDownPage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDownPage.Name = "btnDownPage";
            this.btnDownPage.Selectable = false;
            this.btnDownPage.Size = new System.Drawing.Size(146, 28);
            this.btnDownPage.TabIndex = 170;
            this.btnDownPage.Text = "下一页(F4)";
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Appearance.Options.UseForeColor = true;
            this.btnNo.CustomText = "不能浏览(F5)";
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Location = new System.Drawing.Point(15, 304);
            this.btnNo.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNo.Name = "btnNo";
            this.btnNo.Selectable = false;
            this.btnNo.Size = new System.Drawing.Size(146, 28);
            this.btnNo.TabIndex = 32;
            this.btnNo.Text = "不能浏览(F5)";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpPage.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUpPage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUpPage.Appearance.Options.UseFont = true;
            this.btnUpPage.Appearance.Options.UseForeColor = true;
            this.btnUpPage.CustomText = "上一页(F1)";
            this.btnUpPage.Image = ((System.Drawing.Image)(resources.GetObject("btnUpPage.Image")));
            this.btnUpPage.Location = new System.Drawing.Point(15, 196);
            this.btnUpPage.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUpPage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Selectable = false;
            this.btnUpPage.Size = new System.Drawing.Size(146, 28);
            this.btnUpPage.TabIndex = 169;
            this.btnUpPage.Text = "上一页(F1)";
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnYes.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.Appearance.Options.UseForeColor = true;
            this.btnYes.CustomText = "可以浏览(F6)";
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.Location = new System.Drawing.Point(15, 346);
            this.btnYes.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnYes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnYes.Name = "btnYes";
            this.btnYes.Selectable = false;
            this.btnYes.Size = new System.Drawing.Size(146, 28);
            this.btnYes.TabIndex = 31;
            this.btnYes.Text = "可以浏览(F6)";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLock.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnLock.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnLock.Appearance.Options.UseFont = true;
            this.btnLock.Appearance.Options.UseForeColor = true;
            this.btnLock.CustomText = "病案锁定";
            this.btnLock.Location = new System.Drawing.Point(15, 82);
            this.btnLock.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnLock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLock.Name = "btnLock";
            this.btnLock.Selectable = false;
            this.btnLock.Size = new System.Drawing.Size(146, 28);
            this.btnLock.TabIndex = 188;
            this.btnLock.Text = "病案锁定";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnLock
            // 
            this.btnUnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnLock.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUnLock.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btnUnLock.Appearance.Options.UseFont = true;
            this.btnUnLock.Appearance.Options.UseForeColor = true;
            this.btnUnLock.CustomText = "病案解锁";
            this.btnUnLock.Location = new System.Drawing.Point(15, 41);
            this.btnUnLock.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUnLock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Selectable = false;
            this.btnUnLock.Size = new System.Drawing.Size(146, 28);
            this.btnUnLock.TabIndex = 189;
            this.btnUnLock.Text = "病案解锁";
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // LookSetView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.cJiaPanel2);
            this.Name = "LookSetView";
            this.Size = new System.Drawing.Size(1300, 621);
            this.Enter += new System.EventHandler(this.ImageCheckView_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cgPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LURecordNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Controls.CJiaPanel cJiaPanel1;
        private Controls.CJiaGrid cgPicture;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPicture;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private Controls.CJiaRTLookUpMoreCol LURecordNO;
        private Controls.CJiaLabel cJiaLabel62;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaButton btnDownPage;
        private Controls.CJiaButton btnUpPage;
        private Controls.BtnDelete btnNo;
        private Controls.BtnSave btnYes;
        private Controls.CJiaButton btnAllNO;
        private Tools.PDFViewer pdfViewer;
        private Controls.CJiaLabel lblprojectName;
        private Controls.CJiaButton btnAllYes;
        private Controls.CJiaButton btnAllPrint;
        private Controls.CJiaButton btnExport;
        private Controls.CJiaButton btnPrint;
        private Controls.CJiaButton btnAllExport;
        private Controls.CJiaButton btnUnLock;
        private Controls.CJiaButton btnLock;

    }
}
