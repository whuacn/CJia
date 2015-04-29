namespace CJia.Health.App.UI
{
    partial class PrintApplyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintApplyView));
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.txtPatientName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.btnPatientSearch = new CJia.Controls.BtnSearch();
            this.txtRecotdNo = new CJia.Controls.CJiaTextBox();
            this.cboEndDate = new CJia.Controls.CJiaDate();
            this.cJiaLabel63 = new CJia.Controls.CJiaLabel();
            this.cboStartDate = new CJia.Controls.CJiaDate();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel62 = new CJia.Controls.CJiaLabel();
            this.gridPatient = new CJia.Controls.CJiaGrid();
            this.gvPatientInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSearch1 = new CJia.Controls.BtnSearch();
            this.btnPrint = new CJia.Controls.BtnPrint();
            this.cJiaPanel4 = new CJia.Controls.CJiaPanel();
            this.chkAllPicture = new DevExpress.XtraEditors.CheckEdit();
            this.chkPicture = new CJia.Controls.CJiaCheckedListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.pdfViewer = new CJia.Health.Tools.PDFViewer();
            this.axFoxitReaderSDK1 = new AxFoxitReaderSDKProLib.AxFoxitReaderSDK();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecotdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel4)).BeginInit();
            this.cJiaPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllPicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture)).BeginInit();
            this.pnlPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReaderSDK1)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cJiaPanel1.Controls.Add(this.axFoxitReaderSDK1);
            this.cJiaPanel1.Controls.Add(this.txtPatientName);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel1.Controls.Add(this.btnPatientSearch);
            this.cJiaPanel1.Controls.Add(this.txtRecotdNo);
            this.cJiaPanel1.Controls.Add(this.cboEndDate);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel63);
            this.cJiaPanel1.Controls.Add(this.cboStartDate);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel1);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel62);
            this.cJiaPanel1.Controls.Add(this.gridPatient);
            this.cJiaPanel1.Controls.Add(this.btnSearch1);
            this.cJiaPanel1.Location = new System.Drawing.Point(5, 3);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(335, 692);
            this.cJiaPanel1.TabIndex = 2;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(72, 44);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPatientName.Properties.Appearance.Options.UseBackColor = true;
            this.txtPatientName.Properties.Appearance.Options.UseFont = true;
            this.txtPatientName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtPatientName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPatientName.Size = new System.Drawing.Size(259, 26);
            this.txtPatientName.TabIndex = 3;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.cJiaLabel4.Location = new System.Drawing.Point(32, 47);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel4.TabIndex = 160;
            this.cJiaLabel4.Text = "姓名：";
            // 
            // btnPatientSearch
            // 
            this.btnPatientSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPatientSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPatientSearch.Appearance.Options.UseFont = true;
            this.btnPatientSearch.Appearance.Options.UseForeColor = true;
            this.btnPatientSearch.CustomText = "查询(F5)";
            this.btnPatientSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnPatientSearch.Image")));
            this.btnPatientSearch.Location = new System.Drawing.Point(250, 109);
            this.btnPatientSearch.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPatientSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPatientSearch.Name = "btnPatientSearch";
            this.btnPatientSearch.Selectable = false;
            this.btnPatientSearch.Size = new System.Drawing.Size(80, 28);
            this.btnPatientSearch.TabIndex = 6;
            this.btnPatientSearch.Text = "查询(F5)";
            this.btnPatientSearch.Click += new System.EventHandler(this.btnPatientSearch_Click);
            // 
            // txtRecotdNo
            // 
            this.txtRecotdNo.Location = new System.Drawing.Point(72, 80);
            this.txtRecotdNo.Name = "txtRecotdNo";
            this.txtRecotdNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRecotdNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtRecotdNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtRecotdNo.Properties.Appearance.Options.UseFont = true;
            this.txtRecotdNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtRecotdNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRecotdNo.Size = new System.Drawing.Size(259, 26);
            this.txtRecotdNo.TabIndex = 5;
            this.txtRecotdNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecotdNo_KeyDown);
            // 
            // cboEndDate
            // 
            this.cboEndDate.EditValue = null;
            this.cboEndDate.Location = new System.Drawing.Point(213, 9);
            this.cboEndDate.Name = "cboEndDate";
            this.cboEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboEndDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cboEndDate.Properties.Appearance.Options.UseFont = true;
            this.cboEndDate.Properties.Appearance.Options.UseTextOptions = true;
            this.cboEndDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.cboEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.cboEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboEndDate.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cboEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboEndDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.cboEndDate.Properties.ShowToday = false;
            this.cboEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cboEndDate.Size = new System.Drawing.Size(118, 26);
            this.cboEndDate.TabIndex = 2;
            // 
            // cJiaLabel63
            // 
            this.cJiaLabel63.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel63.Location = new System.Drawing.Point(197, 10);
            this.cJiaLabel63.Name = "cJiaLabel63";
            this.cJiaLabel63.Size = new System.Drawing.Size(9, 16);
            this.cJiaLabel63.TabIndex = 152;
            this.cJiaLabel63.Text = "~";
            // 
            // cboStartDate
            // 
            this.cboStartDate.EditValue = null;
            this.cboStartDate.Location = new System.Drawing.Point(72, 9);
            this.cboStartDate.Name = "cboStartDate";
            this.cboStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboStartDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cboStartDate.Properties.Appearance.Options.UseFont = true;
            this.cboStartDate.Properties.Appearance.Options.UseTextOptions = true;
            this.cboStartDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.cboStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.cboStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboStartDate.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cboStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboStartDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.cboStartDate.Properties.ShowToday = false;
            this.cboStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cboStartDate.Size = new System.Drawing.Size(118, 26);
            this.cboStartDate.TabIndex = 1;
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel1.Location = new System.Drawing.Point(2, 12);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(65, 19);
            this.cJiaLabel1.TabIndex = 150;
            this.cJiaLabel1.Text = "入院日期：";
            // 
            // cJiaLabel62
            // 
            this.cJiaLabel62.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel62.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.cJiaLabel62.Location = new System.Drawing.Point(17, 83);
            this.cJiaLabel62.Name = "cJiaLabel62";
            this.cJiaLabel62.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel62.TabIndex = 149;
            this.cJiaLabel62.Text = "病案号：";
            // 
            // gridPatient
            // 
            this.gridPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridPatient.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.gridPatient.IndicatorWidth = 30;
            this.gridPatient.Location = new System.Drawing.Point(3, 144);
            this.gridPatient.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridPatient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridPatient.MainView = this.gvPatientInfo;
            this.gridPatient.Name = "gridPatient";
            this.gridPatient.ShowRowNumber = true;
            this.gridPatient.Size = new System.Drawing.Size(329, 544);
            this.gridPatient.TabIndex = 7;
            this.gridPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatientInfo});
            // 
            // gvPatientInfo
            // 
            this.gvPatientInfo.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.Empty.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FixedLine.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPatientInfo.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPatientInfo.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPatientInfo.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatientInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gvPatientInfo.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatientInfo.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvPatientInfo.Appearance.OddRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvPatientInfo.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatientInfo.Appearance.Preview.Options.UseFont = true;
            this.gvPatientInfo.Appearance.Preview.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvPatientInfo.Appearance.Row.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.Row.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatientInfo.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatientInfo.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvPatientInfo.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvPatientInfo.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvPatientInfo.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatientInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPatientInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5});
            this.gvPatientInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPatientInfo.GridControl = this.gridPatient;
            this.gvPatientInfo.IndicatorWidth = 30;
            this.gvPatientInfo.Name = "gvPatientInfo";
            this.gvPatientInfo.OptionsBehavior.Editable = false;
            this.gvPatientInfo.OptionsCustomization.AllowFilter = false;
            this.gvPatientInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPatientInfo.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPatientInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gvPatientInfo.OptionsView.ShowGroupPanel = false;
            this.gvPatientInfo.RowHeight = 25;
            this.gvPatientInfo.Click += new System.EventHandler(this.gvPatientInfo_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "病案号";
            this.gridColumn3.FieldName = "RECORDNO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 68;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "入院次数";
            this.gridColumn2.FieldName = "IN_HOSPITAL_TIME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 47;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "姓名";
            this.gridColumn4.FieldName = "PATIENT_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 71;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "性别";
            this.gridColumn5.FieldName = "GENDER_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 38;
            // 
            // btnSearch1
            // 
            this.btnSearch1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSearch1.Appearance.Options.UseFont = true;
            this.btnSearch1.Appearance.Options.UseForeColor = true;
            this.btnSearch1.CustomText = "查询(F5)";
            this.btnSearch1.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch1.Image")));
            this.btnSearch1.Location = new System.Drawing.Point(72, 653);
            this.btnSearch1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearch1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Selectable = false;
            this.btnSearch1.Size = new System.Drawing.Size(93, 33);
            this.btnSearch1.TabIndex = 147;
            this.btnSearch1.Text = "查询(F5)";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.CustomText = "打印(F7)";
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(149, 658);
            this.btnPrint.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Selectable = false;
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 181;
            this.btnPrint.Text = "打印(F7)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cJiaPanel4
            // 
            this.cJiaPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cJiaPanel4.Controls.Add(this.chkAllPicture);
            this.cJiaPanel4.Controls.Add(this.chkPicture);
            this.cJiaPanel4.Controls.Add(this.btnPrint);
            this.cJiaPanel4.Location = new System.Drawing.Point(343, 3);
            this.cJiaPanel4.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel4.Name = "cJiaPanel4";
            this.cJiaPanel4.Size = new System.Drawing.Size(234, 692);
            this.cJiaPanel4.TabIndex = 4;
            // 
            // chkAllPicture
            // 
            this.chkAllPicture.Location = new System.Drawing.Point(6, 6);
            this.chkAllPicture.Name = "chkAllPicture";
            this.chkAllPicture.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.chkAllPicture.Properties.Appearance.Options.UseFont = true;
            this.chkAllPicture.Properties.Caption = "全部";
            this.chkAllPicture.Size = new System.Drawing.Size(113, 24);
            this.chkAllPicture.TabIndex = 8;
            this.chkAllPicture.CheckedChanged += new System.EventHandler(this.chkAllPicture_CheckedChanged);
            // 
            // chkPicture
            // 
            this.chkPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPicture.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.chkPicture.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.chkPicture.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.chkPicture.Appearance.Options.UseBackColor = true;
            this.chkPicture.Appearance.Options.UseBorderColor = true;
            this.chkPicture.Appearance.Options.UseFont = true;
            this.chkPicture.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkPicture.HorizontalScrollbar = true;
            this.chkPicture.HotTrackItems = true;
            this.chkPicture.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnHotTrackEx;
            this.chkPicture.ItemHeight = 28;
            this.chkPicture.Location = new System.Drawing.Point(3, 30);
            this.chkPicture.LookAndFeel.SkinName = "Office 2010 Blue";
            this.chkPicture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkPicture.Name = "chkPicture";
            this.chkPicture.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.chkPicture.Size = new System.Drawing.Size(228, 622);
            this.chkPicture.TabIndex = 9;
            this.chkPicture.SelectedValueChanged += new System.EventHandler(this.chkPicture_SelectedValueChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pnlPicture
            // 
            this.pnlPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicture.AutoScroll = true;
            this.pnlPicture.Controls.Add(this.pdfViewer);
            this.pnlPicture.Location = new System.Drawing.Point(582, 3);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(1048, 694);
            this.pnlPicture.TabIndex = 5;
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.FileName = null;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(1048, 694);
            this.pdfViewer.StylePDF = CJia.Health.Tools.PDFViewer.PDFStyle.All;
            this.pdfViewer.TabIndex = 4;
            this.pdfViewer.ZoomLevel = 3;
            // 
            // axFoxitReaderSDK1
            // 
            this.axFoxitReaderSDK1.Enabled = true;
            this.axFoxitReaderSDK1.Location = new System.Drawing.Point(5, 112);
            this.axFoxitReaderSDK1.Name = "axFoxitReaderSDK1";
            this.axFoxitReaderSDK1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFoxitReaderSDK1.OcxState")));
            this.axFoxitReaderSDK1.Size = new System.Drawing.Size(203, 28);
            this.axFoxitReaderSDK1.TabIndex = 161;
            this.axFoxitReaderSDK1.Visible = false;
            // 
            // PrintApplyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPicture);
            this.Controls.Add(this.cJiaPanel4);
            this.Controls.Add(this.cJiaPanel1);
            this.Name = "PrintApplyView";
            this.Size = new System.Drawing.Size(1633, 700);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecotdNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel4)).EndInit();
            this.cJiaPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAllPicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture)).EndInit();
            this.pnlPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReaderSDK1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Controls.CJiaPanel cJiaPanel1;
        private Controls.BtnSearch btnSearch1;
        private Controls.CJiaTextBox txtPatientName;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.BtnSearch btnPatientSearch;
        private Controls.CJiaTextBox txtRecotdNo;
        private Controls.CJiaDate cboEndDate;
        private Controls.CJiaLabel cJiaLabel63;
        private Controls.CJiaDate cboStartDate;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaLabel cJiaLabel62;
        private Controls.CJiaGrid gridPatient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatientInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Controls.BtnPrint btnPrint;
        private Controls.CJiaPanel cJiaPanel4;
        private Controls.CJiaCheckedListBox chkPicture;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel pnlPicture;
        private DevExpress.XtraEditors.CheckEdit chkAllPicture;
        private Tools.PDFViewer pdfViewer;
        private AxFoxitReaderSDKProLib.AxFoxitReaderSDK axFoxitReaderSDK1;
    }
}
