namespace CJia.Health.App.UI
{
    partial class DataCheckView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCheckView));
            this.cgPatient = new CJia.Controls.CJiaGrid();
            this.gvPatientInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel62 = new CJia.Controls.CJiaLabel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnPass = new CJia.Controls.BtnSave();
            this.btnNoPass = new CJia.Controls.BtnDelete();
            this.btnLock = new CJia.Controls.CJiaButton();
            this.btnOpenLock = new CJia.Controls.CJiaButton();
            this.btnDelete = new CJia.Controls.BtnCancel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.cdStart = new CJia.Controls.CJiaDate();
            this.cJiaLabel63 = new CJia.Controls.CJiaLabel();
            this.cdEnd = new CJia.Controls.CJiaDate();
            this.crbLock = new CJia.Controls.CJiaRadioBox();
            this.crdCheck = new CJia.Controls.CJiaRadioBox();
            this.txtKey = new CJia.Controls.CJiaTextBox();
            this.btnSearch = new CJia.Controls.BtnSearch();
            this.cJiaTabControl2 = new CJia.Controls.CJiaTabControl();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crbLock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crdCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // cgPatient
            // 
            this.cgPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cgPatient.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgPatient.IndicatorWidth = 30;
            this.cgPatient.Location = new System.Drawing.Point(3, 114);
            this.cgPatient.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgPatient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgPatient.MainView = this.gvPatientInfo;
            this.cgPatient.Name = "cgPatient";
            this.cgPatient.ShowRowNumber = true;
            this.cgPatient.Size = new System.Drawing.Size(335, 545);
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
            this.cJiaLabel62.Location = new System.Drawing.Point(6, 39);
            this.cJiaLabel62.Name = "cJiaLabel62";
            this.cJiaLabel62.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel62.TabIndex = 6;
            this.cJiaLabel62.Text = "关键字：";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPass.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPass.Appearance.Options.UseFont = true;
            this.btnPass.Appearance.Options.UseForeColor = true;
            this.btnPass.CustomText = "审核通过(F5)";
            this.btnPass.Enabled = false;
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.Location = new System.Drawing.Point(995, 622);
            this.btnPass.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPass.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPass.Name = "btnPass";
            this.btnPass.Selectable = false;
            this.btnPass.Size = new System.Drawing.Size(108, 28);
            this.btnPass.TabIndex = 11;
            this.btnPass.Text = "审核通过(F5)";
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnNoPass
            // 
            this.btnNoPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoPass.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnNoPass.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnNoPass.Appearance.Options.UseFont = true;
            this.btnNoPass.Appearance.Options.UseForeColor = true;
            this.btnNoPass.CustomText = "审核不通过(F6)";
            this.btnNoPass.Enabled = false;
            this.btnNoPass.Image = ((System.Drawing.Image)(resources.GetObject("btnNoPass.Image")));
            this.btnNoPass.Location = new System.Drawing.Point(1130, 622);
            this.btnNoPass.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnNoPass.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNoPass.Name = "btnNoPass";
            this.btnNoPass.Selectable = false;
            this.btnNoPass.Size = new System.Drawing.Size(122, 28);
            this.btnNoPass.TabIndex = 12;
            this.btnNoPass.Text = "审核不通过(F6)";
            this.btnNoPass.Click += new System.EventHandler(this.btnNoPass_Click);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLock.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnLock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnLock.Appearance.Options.UseFont = true;
            this.btnLock.Appearance.Options.UseForeColor = true;
            this.btnLock.CustomText = "锁定(F11)";
            this.btnLock.Enabled = false;
            this.btnLock.Image = global::CJia.Health.App.Properties.Resources._200962;
            this.btnLock.Location = new System.Drawing.Point(362, 622);
            this.btnLock.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnLock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLock.Name = "btnLock";
            this.btnLock.Selectable = false;
            this.btnLock.Size = new System.Drawing.Size(98, 28);
            this.btnLock.TabIndex = 13;
            this.btnLock.Text = "锁定(F11)";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnOpenLock
            // 
            this.btnOpenLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenLock.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOpenLock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnOpenLock.Appearance.Options.UseFont = true;
            this.btnOpenLock.Appearance.Options.UseForeColor = true;
            this.btnOpenLock.CustomText = "解锁(F12)";
            this.btnOpenLock.Enabled = false;
            this.btnOpenLock.Image = global::CJia.Health.App.Properties.Resources._1213;
            this.btnOpenLock.Location = new System.Drawing.Point(483, 622);
            this.btnOpenLock.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnOpenLock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOpenLock.Name = "btnOpenLock";
            this.btnOpenLock.Selectable = false;
            this.btnOpenLock.Size = new System.Drawing.Size(97, 28);
            this.btnOpenLock.TabIndex = 14;
            this.btnOpenLock.Text = "解锁(F12)";
            this.btnOpenLock.Click += new System.EventHandler(this.btnOpenLock_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "撤销审核(F8)";
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(1279, 622);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(113, 28);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "撤销审核(F8)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(5, 8);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel1.TabIndex = 16;
            this.cJiaLabel1.Text = "建档：";
            // 
            // cdStart
            // 
            this.cdStart.EditValue = null;
            this.cdStart.Location = new System.Drawing.Point(45, 5);
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
            this.cdStart.Size = new System.Drawing.Size(136, 22);
            this.cdStart.TabIndex = 18;
            // 
            // cJiaLabel63
            // 
            this.cJiaLabel63.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel63.Location = new System.Drawing.Point(187, 6);
            this.cJiaLabel63.Name = "cJiaLabel63";
            this.cJiaLabel63.Size = new System.Drawing.Size(9, 16);
            this.cJiaLabel63.TabIndex = 19;
            this.cJiaLabel63.Text = "~";
            // 
            // cdEnd
            // 
            this.cdEnd.EditValue = null;
            this.cdEnd.Location = new System.Drawing.Point(202, 5);
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
            this.cdEnd.Size = new System.Drawing.Size(136, 22);
            this.cdEnd.TabIndex = 20;
            // 
            // crbLock
            // 
            this.crbLock.EditValue = ((short)(0));
            this.crbLock.Location = new System.Drawing.Point(5, 68);
            this.crbLock.Name = "crbLock";
            this.crbLock.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.crbLock.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.crbLock.Properties.Appearance.Options.UseBackColor = true;
            this.crbLock.Properties.Appearance.Options.UseFont = true;
            this.crbLock.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.crbLock.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "锁定"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "未锁")});
            this.crbLock.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.crbLock.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.crbLock.Size = new System.Drawing.Size(333, 24);
            this.crbLock.TabIndex = 21;
            this.crbLock.SelectedIndexChanged += new System.EventHandler(this.crbLock_SelectedIndexChanged);
            // 
            // crdCheck
            // 
            this.crdCheck.EditValue = ((short)(0));
            this.crdCheck.Location = new System.Drawing.Point(5, 89);
            this.crdCheck.Name = "crdCheck";
            this.crdCheck.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.crdCheck.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.crdCheck.Properties.Appearance.Options.UseBackColor = true;
            this.crdCheck.Properties.Appearance.Options.UseFont = true;
            this.crdCheck.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.crdCheck.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "通过"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "拒绝"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "未审")});
            this.crdCheck.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.crdCheck.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.crdCheck.Size = new System.Drawing.Size(332, 24);
            this.crdCheck.TabIndex = 22;
            this.crdCheck.SelectedIndexChanged += new System.EventHandler(this.crbLock_SelectedIndexChanged);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(61, 36);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtKey.Properties.Appearance.Options.UseFont = true;
            this.txtKey.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtKey.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtKey.Size = new System.Drawing.Size(191, 22);
            this.txtKey.TabIndex = 23;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.CustomText = "查询(F5)";
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(258, 33);
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
            this.cJiaTabControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(213)))), ((int)(((byte)(238)))));
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
            this.cJiaTabControl2.Size = new System.Drawing.Size(1094, 601);
            this.cJiaTabControl2.TabIndex = 25;
            this.cJiaTabControl2.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.cJiaTabControl2_SelectedPageChanged);
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(607, 628);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(0, 16);
            this.cJiaLabel2.TabIndex = 26;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(882, 628);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(0, 16);
            this.cJiaLabel3.TabIndex = 27;
            // 
            // DataCheckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.cJiaLabel3);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.cJiaTabControl2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.crdCheck);
            this.Controls.Add(this.crbLock);
            this.Controls.Add(this.cdEnd);
            this.Controls.Add(this.cJiaLabel63);
            this.Controls.Add(this.cdStart);
            this.Controls.Add(this.cJiaLabel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpenLock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnNoPass);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.cJiaLabel62);
            this.Controls.Add(this.cgPatient);
            this.Name = "DataCheckView";
            this.Size = new System.Drawing.Size(1441, 662);
            ((System.ComponentModel.ISupportInitialize)(this.cgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPatientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crbLock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crdCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Controls.BtnSave btnPass;
        private Controls.BtnDelete btnNoPass;
        private Controls.CJiaButton btnLock;
        private Controls.CJiaButton btnOpenLock;
        private Controls.BtnCancel btnDelete;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaDate cdStart;
        private Controls.CJiaLabel cJiaLabel63;
        private Controls.CJiaDate cdEnd;
        private Controls.CJiaRadioBox crbLock;
        private Controls.CJiaRadioBox crdCheck;
        private Controls.CJiaTextBox txtKey;
        private Controls.BtnSearch btnSearch;
        private Controls.CJiaTabControl cJiaTabControl2;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel3;
    }
}
