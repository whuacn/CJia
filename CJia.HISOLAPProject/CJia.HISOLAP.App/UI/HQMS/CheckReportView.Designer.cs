namespace CJia.HISOLAP.App.UI.HQMS
{
    partial class CheckReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckReportView));
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.dtStart = new CJia.Controls.CJiaDate();
            this.dtEnd = new CJia.Controls.CJiaDate();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.btnSearch = new CJia.Controls.BtnSearch();
            this.cgPatient = new CJia.Controls.CJiaGrid();
            this.gvPatient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.cbType = new CJia.Controls.CJiaComboBox2();
            this.cJiaComboBox21View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel7 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel8 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel9 = new CJia.Controls.CJiaLabel();
            this.btnCheck = new CJia.Controls.CJiaButton();
            this.btnReport = new CJia.Controls.CJiaButton();
            this.cJiaButton1 = new CJia.Controls.CJiaButton();
            this.gvCheckResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgCheckResult = new CJia.Controls.CJiaGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cgCheckResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(8, 17);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel1.TabIndex = 0;
            this.cJiaLabel1.Text = "开始日期：";
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Location = new System.Drawing.Point(89, 14);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtStart.Properties.Appearance.Options.UseFont = true;
            this.dtStart.Properties.Appearance.Options.UseTextOptions = true;
            this.dtStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.dtStart.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStart.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStart.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.dtStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtStart.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtStart.Properties.ShowToday = false;
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(115, 22);
            this.dtStart.TabIndex = 1;
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.Location = new System.Drawing.Point(291, 14);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtEnd.Properties.Appearance.Options.UseFont = true;
            this.dtEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.dtEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.dtEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEnd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.dtEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtEnd.Properties.ShowToday = false;
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(115, 22);
            this.dtEnd.TabIndex = 3;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(210, 17);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel2.TabIndex = 2;
            this.cJiaLabel2.Text = "截至日期：";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.CustomText = "查询出院人数(F5)";
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(672, 11);
            this.btnSearch.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Selectable = false;
            this.btnSearch.Size = new System.Drawing.Size(140, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询出院人数(F5)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cgPatient
            // 
            this.cgPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cgPatient.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgPatient.IndicatorWidth = 40;
            this.cgPatient.Location = new System.Drawing.Point(0, 48);
            this.cgPatient.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgPatient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgPatient.MainView = this.gvPatient;
            this.cgPatient.Name = "cgPatient";
            this.cgPatient.ShowRowNumber = true;
            this.cgPatient.Size = new System.Drawing.Size(423, 552);
            this.cgPatient.TabIndex = 7;
            this.cgPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPatient});
            // 
            // gvPatient
            // 
            this.gvPatient.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvPatient.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvPatient.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvPatient.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvPatient.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvPatient.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvPatient.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvPatient.Appearance.Empty.Options.UseBackColor = true;
            this.gvPatient.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvPatient.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvPatient.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvPatient.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvPatient.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPatient.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvPatient.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvPatient.Appearance.FixedLine.BackColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvPatient.Appearance.FixedLine.Options.UseBorderColor = true;
            this.gvPatient.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPatient.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPatient.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPatient.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvPatient.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gvPatient.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPatient.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvPatient.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvPatient.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvPatient.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvPatient.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvPatient.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvPatient.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvPatient.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvPatient.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvPatient.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPatient.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvPatient.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvPatient.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvPatient.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPatient.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPatient.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gvPatient.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatient.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gvPatient.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPatient.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvPatient.Appearance.OddRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvPatient.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatient.Appearance.Preview.Options.UseFont = true;
            this.gvPatient.Appearance.Preview.Options.UseForeColor = true;
            this.gvPatient.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvPatient.Appearance.Row.Options.UseBackColor = true;
            this.gvPatient.Appearance.Row.Options.UseForeColor = true;
            this.gvPatient.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvPatient.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvPatient.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvPatient.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvPatient.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvPatient.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvPatient.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvPatient.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvPatient.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPatient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvPatient.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPatient.GridControl = this.cgPatient;
            this.gvPatient.IndicatorWidth = 40;
            this.gvPatient.Name = "gvPatient";
            this.gvPatient.OptionsBehavior.Editable = false;
            this.gvPatient.OptionsCustomization.AllowFilter = false;
            this.gvPatient.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPatient.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPatient.OptionsView.EnableAppearanceOddRow = true;
            this.gvPatient.OptionsView.ShowGroupPanel = false;
            this.gvPatient.RowHeight = 25;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "病案号";
            this.gridColumn2.FieldName = "P3";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 127;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "住院号";
            this.gridColumn3.FieldName = "P3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 109;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "次数";
            this.gridColumn4.FieldName = "P2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 54;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "姓名";
            this.gridColumn5.FieldName = "P4";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 101;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(412, 17);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel3.TabIndex = 8;
            this.cJiaLabel3.Text = "审核类型：";
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(493, 14);
            this.cbType.Name = "cbType";
            this.cbType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbType.Properties.Appearance.Options.UseFont = true;
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cbType.Properties.ImmediatePopup = true;
            this.cbType.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cbType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbType.Properties.NullText = "";
            this.cbType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cbType.Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            this.cbType.Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            this.cbType.Properties.ShowFooter = false;
            this.cbType.Properties.View = this.cJiaComboBox21View;
            this.cbType.Size = new System.Drawing.Size(139, 22);
            this.cbType.TabIndex = 11;
            this.cbType.TextChanged += new System.EventHandler(this.cbType_TextChanged);
            // 
            // cJiaComboBox21View
            // 
            this.cJiaComboBox21View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.cJiaComboBox21View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cJiaComboBox21View.Name = "cJiaComboBox21View";
            this.cJiaComboBox21View.OptionsBehavior.AutoPopulateColumns = false;
            this.cJiaComboBox21View.OptionsCustomization.AllowFilter = false;
            this.cJiaComboBox21View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cJiaComboBox21View.OptionsView.ShowColumnHeaders = false;
            this.cJiaComboBox21View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel4.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.cJiaLabel4.Location = new System.Drawing.Point(434, 157);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(20, 23);
            this.cJiaLabel4.TabIndex = 13;
            this.cJiaLabel4.Text = "审";
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel5.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.cJiaLabel5.Location = new System.Drawing.Point(434, 203);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(20, 23);
            this.cJiaLabel5.TabIndex = 14;
            this.cJiaLabel5.Text = "核";
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel6.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.cJiaLabel6.Location = new System.Drawing.Point(434, 295);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(20, 23);
            this.cJiaLabel6.TabIndex = 16;
            this.cJiaLabel6.Text = "果";
            // 
            // cJiaLabel7
            // 
            this.cJiaLabel7.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel7.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.cJiaLabel7.Location = new System.Drawing.Point(434, 249);
            this.cJiaLabel7.Name = "cJiaLabel7";
            this.cJiaLabel7.Size = new System.Drawing.Size(20, 23);
            this.cJiaLabel7.TabIndex = 15;
            this.cJiaLabel7.Text = "结";
            // 
            // cJiaLabel8
            // 
            this.cJiaLabel8.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel8.Appearance.ForeColor = System.Drawing.Color.Red;
            this.cJiaLabel8.Location = new System.Drawing.Point(428, 128);
            this.cJiaLabel8.Name = "cJiaLabel8";
            this.cJiaLabel8.Size = new System.Drawing.Size(28, 26);
            this.cJiaLabel8.TabIndex = 17;
            this.cJiaLabel8.Text = ">>";
            // 
            // cJiaLabel9
            // 
            this.cJiaLabel9.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel9.Appearance.ForeColor = System.Drawing.Color.Red;
            this.cJiaLabel9.Location = new System.Drawing.Point(428, 324);
            this.cJiaLabel9.Name = "cJiaLabel9";
            this.cJiaLabel9.Size = new System.Drawing.Size(28, 26);
            this.cJiaLabel9.TabIndex = 18;
            this.cJiaLabel9.Text = ">>";
            // 
            // btnCheck
            // 
            this.btnCheck.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCheck.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCheck.Appearance.Options.UseFont = true;
            this.btnCheck.Appearance.Options.UseForeColor = true;
            this.btnCheck.CustomText = "审核数据(F8)";
            this.btnCheck.Location = new System.Drawing.Point(830, 11);
            this.btnCheck.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCheck.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Selectable = false;
            this.btnCheck.Size = new System.Drawing.Size(110, 28);
            this.btnCheck.TabIndex = 19;
            this.btnCheck.Text = "审核数据(F8)";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnReport
            // 
            this.btnReport.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnReport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Appearance.Options.UseForeColor = true;
            this.btnReport.CustomText = "数据上报(F10)";
            this.btnReport.Location = new System.Drawing.Point(958, 11);
            this.btnReport.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReport.Name = "btnReport";
            this.btnReport.Selectable = false;
            this.btnReport.Size = new System.Drawing.Size(110, 28);
            this.btnReport.TabIndex = 20;
            this.btnReport.Text = "数据上报(F10)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cJiaButton1
            // 
            this.cJiaButton1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cJiaButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.cJiaButton1.Appearance.Options.UseFont = true;
            this.cJiaButton1.Appearance.Options.UseForeColor = true;
            this.cJiaButton1.CustomText = "修改(F12)";
            this.cJiaButton1.Location = new System.Drawing.Point(1086, 11);
            this.cJiaButton1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaButton1.Name = "cJiaButton1";
            this.cJiaButton1.Selectable = false;
            this.cJiaButton1.Size = new System.Drawing.Size(80, 28);
            this.cJiaButton1.TabIndex = 21;
            this.cJiaButton1.Text = "修改(F12)";
            this.cJiaButton1.Click += new System.EventHandler(this.cgCheckResult_DoubleClick);
            // 
            // gvCheckResult
            // 
            this.gvCheckResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn7});
            this.gvCheckResult.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvCheckResult.GridControl = this.cgCheckResult;
            this.gvCheckResult.IndicatorWidth = 40;
            this.gvCheckResult.Name = "gvCheckResult";
            this.gvCheckResult.OptionsBehavior.Editable = false;
            this.gvCheckResult.OptionsCustomization.AllowFilter = false;
            this.gvCheckResult.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCheckResult.OptionsView.AllowCellMerge = true;
            this.gvCheckResult.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCheckResult.OptionsView.EnableAppearanceOddRow = true;
            this.gvCheckResult.OptionsView.ShowGroupPanel = false;
            this.gvCheckResult.RowHeight = 25;
            this.gvCheckResult.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvCheckResult_RowCellStyle);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "病案号";
            this.gridColumn6.FieldName = "P3";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 125;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "次数";
            this.gridColumn8.FieldName = "P2";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 66;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "审核类型";
            this.gridColumn9.FieldName = "CHECK_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 86;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "错误提示";
            this.gridColumn10.FieldName = "CS_ERROR";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 322;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "错误归类";
            this.gridColumn7.FieldName = "CHECK_CLASSIFY";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 105;
            // 
            // cgCheckResult
            // 
            this.cgCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cgCheckResult.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgCheckResult.IndicatorWidth = 40;
            this.cgCheckResult.Location = new System.Drawing.Point(464, 48);
            this.cgCheckResult.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgCheckResult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgCheckResult.MainView = this.gvCheckResult;
            this.cgCheckResult.Name = "cgCheckResult";
            this.cgCheckResult.ShowRowNumber = true;
            this.cgCheckResult.Size = new System.Drawing.Size(736, 552);
            this.cgCheckResult.TabIndex = 12;
            this.cgCheckResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheckResult});
            // 
            // CheckReportView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaButton1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.cJiaLabel9);
            this.Controls.Add(this.cJiaLabel8);
            this.Controls.Add(this.cJiaLabel6);
            this.Controls.Add(this.cJiaLabel7);
            this.Controls.Add(this.cJiaLabel5);
            this.Controls.Add(this.cJiaLabel4);
            this.Controls.Add(this.cgCheckResult);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cJiaLabel3);
            this.Controls.Add(this.cgPatient);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.cJiaLabel1);
            this.Name = "CheckReportView";
            this.Size = new System.Drawing.Size(1200, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cgCheckResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaDate dtStart;
        private Controls.CJiaDate dtEnd;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnSearch btnSearch;
        private Controls.CJiaGrid cgPatient;
        private Controls.CJiaLabel cJiaLabel3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatient;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Controls.CJiaComboBox2 cbType;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaComboBox21View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaLabel cJiaLabel6;
        private Controls.CJiaLabel cJiaLabel7;
        private Controls.CJiaLabel cJiaLabel8;
        private Controls.CJiaLabel cJiaLabel9;
        private Controls.CJiaButton btnCheck;
        private Controls.CJiaButton btnReport;
        private Controls.CJiaButton cJiaButton1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCheckResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private Controls.CJiaGrid cgCheckResult;
    }
}
