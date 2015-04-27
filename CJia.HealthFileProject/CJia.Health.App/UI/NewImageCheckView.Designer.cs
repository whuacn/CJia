namespace CJia.Health.App.UI
{
    partial class NewImageCheckView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewImageCheckView));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cgPicture = new CJia.Controls.CJiaGrid();
            this.gvPicture = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LURecordNO = new CJia.Controls.CJiaRTLookUpMoreCol();
            this.btnSearch = new CJia.Controls.BtnSearch();
            this.cJiaLabel62 = new CJia.Controls.CJiaLabel();
            this.crdCheck = new CJia.Controls.CJiaRadioBox();
            this.lblprojectName = new CJia.Controls.CJiaLabel();
            this.pdfViewer = new CJia.Health.Tools.PDFViewer();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.btnAllCheck = new CJia.Controls.CJiaButton();
            this.txtCheckStatusName = new CJia.Controls.CJiaLabel();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.txtProName = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.txtSubPage = new CJia.Controls.CJiaLabel();
            this.txtPageNo = new CJia.Controls.CJiaLabel();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.btnDelete = new CJia.Controls.BtnCancel();
            this.btnDownPage = new CJia.Controls.CJiaButton();
            this.btnNoPass = new CJia.Controls.BtnDelete();
            this.btnUpPage = new CJia.Controls.CJiaButton();
            this.btnPass = new CJia.Controls.BtnSave();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LURecordNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crdCheck.Properties)).BeginInit();
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
            this.cJiaPanel1.Controls.Add(this.btnSearch);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel62);
            this.cJiaPanel1.Controls.Add(this.crdCheck);
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
            this.cgPicture.Location = new System.Drawing.Point(4, 77);
            this.cgPicture.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgPicture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgPicture.MainView = this.gvPicture;
            this.cgPicture.Name = "cgPicture";
            this.cgPicture.ShowRowNumber = true;
            this.cgPicture.Size = new System.Drawing.Size(342, 541);
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
            this.gvPicture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPicture_KeyDown);
            this.gvPicture.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvPicture_KeyUp);
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
            this.gridColumn4.Caption = "状态";
            this.gridColumn4.FieldName = "CHECK_STATUS_NAME";
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
            this.LURecordNO.Location = new System.Drawing.Point(65, 12);
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
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.CustomText = "查询(F12)";
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(250, 6);
            this.btnSearch.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Selectable = false;
            this.btnSearch.Size = new System.Drawing.Size(93, 28);
            this.btnSearch.TabIndex = 172;
            this.btnSearch.Text = "查询(F12)";
            this.btnSearch.Visible = false;
            // 
            // cJiaLabel62
            // 
            this.cJiaLabel62.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel62.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel62.Location = new System.Drawing.Point(7, 17);
            this.cJiaLabel62.Name = "cJiaLabel62";
            this.cJiaLabel62.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel62.TabIndex = 171;
            this.cJiaLabel62.Text = "病案号：";
            // 
            // crdCheck
            // 
            this.crdCheck.EditValue = ((short)(0));
            this.crdCheck.Location = new System.Drawing.Point(4, 45);
            this.crdCheck.Name = "crdCheck";
            this.crdCheck.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.crdCheck.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.crdCheck.Properties.Appearance.Options.UseBackColor = true;
            this.crdCheck.Properties.Appearance.Options.UseFont = true;
            this.crdCheck.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.crdCheck.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "通过"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "拒绝"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "提交")});
            this.crdCheck.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.crdCheck.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.crdCheck.Size = new System.Drawing.Size(339, 28);
            this.crdCheck.TabIndex = 170;
            this.crdCheck.SelectedIndexChanged += new System.EventHandler(this.crdCheck_SelectedIndexChanged);
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
            this.pdfViewer.Size = new System.Drawing.Size(756, 621);
            this.pdfViewer.StylePDF = CJia.Health.Tools.PDFViewer.PDFStyle.All;
            this.pdfViewer.TabIndex = 2;
            this.pdfViewer.ZoomLevel = 3;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel2.Controls.Add(this.btnAllCheck);
            this.cJiaPanel2.Controls.Add(this.txtCheckStatusName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.txtProName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Controls.Add(this.txtSubPage);
            this.cJiaPanel2.Controls.Add(this.txtPageNo);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel1);
            this.cJiaPanel2.Controls.Add(this.btnDelete);
            this.cJiaPanel2.Controls.Add(this.btnDownPage);
            this.cJiaPanel2.Controls.Add(this.btnNoPass);
            this.cJiaPanel2.Controls.Add(this.btnUpPage);
            this.cJiaPanel2.Controls.Add(this.btnPass);
            this.cJiaPanel2.Location = new System.Drawing.Point(1122, 1);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(176, 619);
            this.cJiaPanel2.TabIndex = 1;
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllCheck.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAllCheck.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAllCheck.Appearance.Options.UseFont = true;
            this.btnAllCheck.Appearance.Options.UseForeColor = true;
            this.btnAllCheck.CustomText = "全部审核";
            this.btnAllCheck.Enabled = false;
            this.btnAllCheck.Location = new System.Drawing.Point(15, 324);
            this.btnAllCheck.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAllCheck.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Selectable = false;
            this.btnAllCheck.Size = new System.Drawing.Size(146, 28);
            this.btnAllCheck.TabIndex = 182;
            this.btnAllCheck.Text = "全部审核";
            this.btnAllCheck.Visible = false;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // txtCheckStatusName
            // 
            this.txtCheckStatusName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckStatusName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCheckStatusName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtCheckStatusName.Location = new System.Drawing.Point(87, 159);
            this.txtCheckStatusName.Name = "txtCheckStatusName";
            this.txtCheckStatusName.Size = new System.Drawing.Size(0, 19);
            this.txtCheckStatusName.TabIndex = 181;
            this.txtCheckStatusName.Visible = false;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(36, 162);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel3.TabIndex = 180;
            this.cJiaLabel3.Text = "状态：";
            this.cJiaLabel3.Visible = false;
            // 
            // txtProName
            // 
            this.txtProName.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.txtProName.Location = new System.Drawing.Point(117, 103);
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(0, 24);
            this.txtProName.TabIndex = 179;
            this.txtProName.Visible = false;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(36, 109);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel2.TabIndex = 178;
            this.cJiaLabel2.Text = "项目名称：";
            this.cJiaLabel2.Visible = false;
            // 
            // txtSubPage
            // 
            this.txtSubPage.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSubPage.Location = new System.Drawing.Point(145, 55);
            this.txtSubPage.Name = "txtSubPage";
            this.txtSubPage.Size = new System.Drawing.Size(0, 16);
            this.txtSubPage.TabIndex = 177;
            this.txtSubPage.Visible = false;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPageNo.Location = new System.Drawing.Point(66, 57);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(0, 16);
            this.txtPageNo.TabIndex = 176;
            this.txtPageNo.Visible = false;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel4.Location = new System.Drawing.Point(103, 57);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel4.TabIndex = 175;
            this.cJiaLabel4.Text = "子码：";
            this.cJiaLabel4.Visible = false;
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(15, 57);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel1.TabIndex = 174;
            this.cJiaLabel1.Text = "页码：";
            this.cJiaLabel1.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "撤销审核(F7)";
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(15, 574);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(146, 28);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "撤销审核(F7)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnDownPage.Location = new System.Drawing.Point(15, 424);
            this.btnDownPage.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDownPage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDownPage.Name = "btnDownPage";
            this.btnDownPage.Selectable = false;
            this.btnDownPage.Size = new System.Drawing.Size(146, 28);
            this.btnDownPage.TabIndex = 170;
            this.btnDownPage.Text = "下一页(F4)";
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnNoPass
            // 
            this.btnNoPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoPass.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNoPass.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnNoPass.Appearance.Options.UseFont = true;
            this.btnNoPass.Appearance.Options.UseForeColor = true;
            this.btnNoPass.CustomText = "审核拒绝(F6)";
            this.btnNoPass.Image = ((System.Drawing.Image)(resources.GetObject("btnNoPass.Image")));
            this.btnNoPass.Location = new System.Drawing.Point(15, 524);
            this.btnNoPass.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNoPass.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNoPass.Name = "btnNoPass";
            this.btnNoPass.Selectable = false;
            this.btnNoPass.Size = new System.Drawing.Size(146, 28);
            this.btnNoPass.TabIndex = 32;
            this.btnNoPass.Text = "审核拒绝(F6)";
            this.btnNoPass.Click += new System.EventHandler(this.btnNoPass_Click);
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
            this.btnUpPage.Location = new System.Drawing.Point(15, 374);
            this.btnUpPage.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUpPage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Selectable = false;
            this.btnUpPage.Size = new System.Drawing.Size(146, 28);
            this.btnUpPage.TabIndex = 169;
            this.btnUpPage.Text = "上一页(F1)";
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPass.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPass.Appearance.Options.UseFont = true;
            this.btnPass.Appearance.Options.UseForeColor = true;
            this.btnPass.CustomText = "审核通过(F5)";
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.Location = new System.Drawing.Point(15, 474);
            this.btnPass.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPass.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPass.Name = "btnPass";
            this.btnPass.Selectable = false;
            this.btnPass.Size = new System.Drawing.Size(146, 28);
            this.btnPass.TabIndex = 31;
            this.btnPass.Text = "审核通过(F5)";
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // NewImageCheckView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.cJiaPanel2);
            this.Name = "NewImageCheckView";
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
            ((System.ComponentModel.ISupportInitialize)(this.crdCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
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
        private Controls.BtnSearch btnSearch;
        private Controls.CJiaLabel cJiaLabel62;
        private Controls.CJiaRadioBox crdCheck;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaButton btnDownPage;
        private Controls.CJiaButton btnUpPage;
        private Controls.BtnCancel btnDelete;
        private Controls.BtnDelete btnNoPass;
        private Controls.BtnSave btnPass;
        private Controls.CJiaLabel txtSubPage;
        private Controls.CJiaLabel txtPageNo;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaLabel txtProName;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel txtCheckStatusName;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaButton btnAllCheck;
        private Tools.PDFViewer pdfViewer;
        private Controls.CJiaLabel lblprojectName;

    }
}
