namespace CJia.Health.App.UI
{
    partial class DataQueryView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataQueryView));
            this.cgPatient = new CJia.Controls.CJiaGrid();
            this.gvPatientInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel62 = new CJia.Controls.CJiaLabel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.cdStart = new CJia.Controls.CJiaDate();
            this.cJiaLabel63 = new CJia.Controls.CJiaLabel();
            this.cdEnd = new CJia.Controls.CJiaDate();
            this.txtRecotdNo = new CJia.Controls.CJiaTextBox();
            this.btnSearch = new CJia.Controls.BtnSearch();
            this.cJiaTabControl2 = new CJia.Controls.CJiaTabControl();
            this.txtCard = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.txtPatientId = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.txtPatientName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.selectPanel = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Label();
            this.cJiaLine1 = new CJia.Controls.CJiaLine();
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecotdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).BeginInit();
            this.selectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cgPatient
            // 
            this.cgPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cgPatient.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgPatient.IndicatorWidth = 30;
            this.cgPatient.Location = new System.Drawing.Point(3, 136);
            this.cgPatient.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgPatient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgPatient.MainView = this.gvPatientInfo;
            this.cgPatient.Name = "cgPatient";
            this.cgPatient.ShowRowNumber = true;
            this.cgPatient.Size = new System.Drawing.Size(335, 521);
            this.cgPatient.TabIndex = 5;
            this.cgPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvPatientInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPatientInfo.GridControl = this.cgPatient;
            this.gvPatientInfo.IndicatorWidth = 30;
            this.gvPatientInfo.Name = "gvPatientInfo";
            this.gvPatientInfo.OptionsBehavior.Editable = false;
            this.gvPatientInfo.OptionsCustomization.AllowFilter = false;
            this.gvPatientInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPatientInfo.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPatientInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gvPatientInfo.OptionsView.ShowGroupPanel = false;
            this.gvPatientInfo.RowHeight = 25;
            this.gvPatientInfo.DoubleClick += new System.EventHandler(this.gvPatientInfo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "病人ID";
            this.gridColumn1.FieldName = "PATIENT_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 79;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "入院次数";
            this.gridColumn2.FieldName = "IN_HOSPITAL_TIME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 47;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "病案号";
            this.gridColumn3.FieldName = "RECORDNO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 68;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "姓名";
            this.gridColumn4.FieldName = "PATIENT_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 71;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "性别";
            this.gridColumn5.FieldName = "GENDER_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 38;
            // 
            // cJiaLabel62
            // 
            this.cJiaLabel62.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel62.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel62.Location = new System.Drawing.Point(5, 94);
            this.cJiaLabel62.Name = "cJiaLabel62";
            this.cJiaLabel62.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel62.TabIndex = 6;
            this.cJiaLabel62.Text = "病案号：";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(4, 9);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel1.TabIndex = 16;
            this.cJiaLabel1.Text = "入院日期：";
            // 
            // cdStart
            // 
            this.cdStart.EditValue = null;
            this.cdStart.Location = new System.Drawing.Point(77, 6);
            this.cdStart.Name = "cdStart";
            this.cdStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cdStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cdStart.Properties.Appearance.Options.UseFont = true;
            this.cdStart.Properties.Appearance.Options.UseTextOptions = true;
            this.cdStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cdStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cdStart.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.cdStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cdStart.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.cdStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cdStart.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cdStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cdStart.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.cdStart.Properties.ShowToday = false;
            this.cdStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cdStart.Size = new System.Drawing.Size(118, 22);
            this.cdStart.TabIndex = 18;
            // 
            // cJiaLabel63
            // 
            this.cJiaLabel63.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel63.Location = new System.Drawing.Point(201, 7);
            this.cJiaLabel63.Name = "cJiaLabel63";
            this.cJiaLabel63.Size = new System.Drawing.Size(9, 16);
            this.cJiaLabel63.TabIndex = 19;
            this.cJiaLabel63.Text = "~";
            // 
            // cdEnd
            // 
            this.cdEnd.EditValue = null;
            this.cdEnd.Location = new System.Drawing.Point(214, 6);
            this.cdEnd.Name = "cdEnd";
            this.cdEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cdEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cdEnd.Properties.Appearance.Options.UseFont = true;
            this.cdEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.cdEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cdEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cdEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.cdEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cdEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.cdEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cdEnd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cdEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cdEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.cdEnd.Properties.ShowToday = false;
            this.cdEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cdEnd.Size = new System.Drawing.Size(116, 22);
            this.cdEnd.TabIndex = 20;
            // 
            // txtRecotdNo
            // 
            this.txtRecotdNo.Location = new System.Drawing.Point(62, 91);
            this.txtRecotdNo.Name = "txtRecotdNo";
            this.txtRecotdNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRecotdNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRecotdNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtRecotdNo.Properties.Appearance.Options.UseFont = true;
            this.txtRecotdNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtRecotdNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRecotdNo.Size = new System.Drawing.Size(181, 22);
            this.txtRecotdNo.TabIndex = 23;
            this.txtRecotdNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.CustomText = "查询(F5)";
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(250, 88);
            this.btnSearch.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Selectable = false;
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "查询(F5)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cJiaTabControl2
            // 
            this.cJiaTabControl2.AllowDrop = true;
            this.cJiaTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaTabControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.cJiaTabControl2.Appearance.Options.UseBackColor = true;
            this.cJiaTabControl2.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.cJiaTabControl2.AppearancePage.Header.BorderColor = System.Drawing.Color.Transparent;
            this.cJiaTabControl2.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaTabControl2.AppearancePage.Header.Options.UseBackColor = true;
            this.cJiaTabControl2.AppearancePage.Header.Options.UseBorderColor = true;
            this.cJiaTabControl2.AppearancePage.Header.Options.UseFont = true;
            this.cJiaTabControl2.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            this.cJiaTabControl2.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DimGray;
            this.cJiaTabControl2.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.cJiaTabControl2.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.cJiaTabControl2.AppearancePage.PageClient.BackColor = System.Drawing.Color.White;
            this.cJiaTabControl2.AppearancePage.PageClient.Options.UseBackColor = true;
            this.cJiaTabControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cJiaTabControl2.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.cJiaTabControl2.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.cJiaTabControl2.Location = new System.Drawing.Point(344, 6);
            this.cJiaTabControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaTabControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaTabControl2.Name = "cJiaTabControl2";
            this.cJiaTabControl2.Size = new System.Drawing.Size(1094, 653);
            this.cJiaTabControl2.TabIndex = 25;
            this.cJiaTabControl2.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.cJiaTabControl2_SelectedPageChanged);
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(60, 62);
            this.txtCard.Name = "txtCard";
            this.txtCard.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCard.Properties.Appearance.Options.UseBackColor = true;
            this.txtCard.Properties.Appearance.Options.UseFont = true;
            this.txtCard.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtCard.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCard.Size = new System.Drawing.Size(270, 22);
            this.txtCard.TabIndex = 27;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel2.Location = new System.Drawing.Point(5, 65);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel2.TabIndex = 26;
            this.cJiaLabel2.Text = "证件号：";
            // 
            // txtPatientId
            // 
            this.txtPatientId.Location = new System.Drawing.Point(60, 34);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPatientId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPatientId.Properties.Appearance.Options.UseBackColor = true;
            this.txtPatientId.Properties.Appearance.Options.UseFont = true;
            this.txtPatientId.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtPatientId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPatientId.Size = new System.Drawing.Size(120, 22);
            this.txtPatientId.TabIndex = 29;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel3.Location = new System.Drawing.Point(5, 37);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(57, 16);
            this.cJiaLabel3.TabIndex = 28;
            this.cJiaLabel3.Text = "病人ID：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(228, 34);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPatientName.Properties.Appearance.Options.UseBackColor = true;
            this.txtPatientName.Properties.Appearance.Options.UseFont = true;
            this.txtPatientName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtPatientName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPatientName.Size = new System.Drawing.Size(102, 22);
            this.txtPatientName.TabIndex = 31;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cJiaLabel4.Location = new System.Drawing.Point(187, 37);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel4.TabIndex = 30;
            this.cJiaLabel4.Text = "姓名：";
            // 
            // selectPanel
            // 
            this.selectPanel.Controls.Add(this.cdStart);
            this.selectPanel.Controls.Add(this.btnSearch);
            this.selectPanel.Controls.Add(this.btnAll);
            this.selectPanel.Controls.Add(this.cJiaLine1);
            this.selectPanel.Controls.Add(this.txtRecotdNo);
            this.selectPanel.Controls.Add(this.cJiaLabel1);
            this.selectPanel.Controls.Add(this.txtPatientName);
            this.selectPanel.Controls.Add(this.cJiaLabel62);
            this.selectPanel.Controls.Add(this.cJiaLabel4);
            this.selectPanel.Controls.Add(this.txtPatientId);
            this.selectPanel.Controls.Add(this.cJiaLabel63);
            this.selectPanel.Controls.Add(this.cJiaLabel3);
            this.selectPanel.Controls.Add(this.cdEnd);
            this.selectPanel.Controls.Add(this.txtCard);
            this.selectPanel.Controls.Add(this.cJiaLabel2);
            this.selectPanel.Location = new System.Drawing.Point(0, 3);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Size = new System.Drawing.Size(341, 132);
            this.selectPanel.TabIndex = 32;
            // 
            // btnAll
            // 
            this.btnAll.AutoSize = true;
            this.btnAll.ForeColor = System.Drawing.Color.Blue;
            this.btnAll.Location = new System.Drawing.Point(164, 116);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(19, 14);
            this.btnAll.TabIndex = 32;
            this.btnAll.Text = "︾";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // cJiaLine1
            // 
            this.cJiaLine1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.cJiaLine1.LineVisible = true;
            this.cJiaLine1.Location = new System.Drawing.Point(5, 115);
            this.cJiaLine1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaLine1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaLine1.Name = "cJiaLine1";
            this.cJiaLine1.Size = new System.Drawing.Size(325, 14);
            this.cJiaLine1.TabIndex = 33;
            this.cJiaLine1.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // DataQueryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.selectPanel);
            this.Controls.Add(this.cJiaTabControl2);
            this.Controls.Add(this.cgPatient);
            this.Name = "DataQueryView";
            this.Size = new System.Drawing.Size(1441, 662);
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecotdNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).EndInit();
            this.selectPanel.ResumeLayout(false);
            this.selectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaGrid cgPatient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPatientInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Controls.CJiaLabel cJiaLabel62;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaDate cdStart;
        private Controls.CJiaLabel cJiaLabel63;
        private Controls.CJiaDate cdEnd;
        private Controls.CJiaTextBox txtRecotdNo;
        private Controls.BtnSearch btnSearch;
        private Controls.CJiaTabControl cJiaTabControl2;
        private Controls.CJiaTextBox txtCard;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaTextBox txtPatientId;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox txtPatientName;
        private Controls.CJiaLabel cJiaLabel4;
        private System.Windows.Forms.Panel selectPanel;
        private System.Windows.Forms.Label btnAll;
        private Controls.CJiaLine cJiaLine1;
    }
}
