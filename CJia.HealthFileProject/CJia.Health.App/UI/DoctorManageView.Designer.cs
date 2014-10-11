namespace CJia.Health.App.UI
{
    partial class DoctorManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorManageView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DoctorGrid = new CJia.Controls.CJiaGrid();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.DocSearch = new CJia.Controls.CJiaTextSearch();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.TxtDocName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.TxtDocNo = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.BtnAddDocject = new CJia.Controls.BtnAdd();
            this.BtnDocDelect = new CJia.Controls.BtnDelete();
            this.BtnUpdateDocject = new CJia.Controls.CJiaButton();
            this.checkBox = new CJia.Controls.CJiaCheck();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.LpDept = new CJia.Controls.CJiaRTLookUp();
            this.LpDes = new CJia.Controls.CJiaRTLookUp();
            this.TxtDocPinYin = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel7 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.pnlDoctor = new CJia.Controls.CJiaPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LpDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LpDes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocPinYin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoctor)).BeginInit();
            this.pnlDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.cJiaLabel1.Location = new System.Drawing.Point(361, 10);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(96, 29);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "医生字典";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "医生名称";
            this.gridColumn2.FieldName = "DOCTOR_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "医生编号";
            this.gridColumn1.FieldName = "DOCTOR_NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FixedLine.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.DoctorGrid;
            this.gridView1.IndicatorWidth = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "医生职称";
            this.gridColumn3.FieldName = "NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "医生科室";
            this.gridColumn4.FieldName = "DEPT_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "拼音查询码";
            this.gridColumn5.FieldName = "FIRST_PINYIN";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // DoctorGrid
            // 
            this.DoctorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorGrid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DoctorGrid.IndicatorWidth = 30;
            this.DoctorGrid.Location = new System.Drawing.Point(5, 128);
            this.DoctorGrid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.DoctorGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DoctorGrid.MainView = this.gridView1;
            this.DoctorGrid.Margin = new System.Windows.Forms.Padding(23);
            this.DoctorGrid.Name = "DoctorGrid";
            this.DoctorGrid.ShowRowNumber = true;
            this.DoctorGrid.Size = new System.Drawing.Size(882, 402);
            this.DoctorGrid.TabIndex = 100;
            this.DoctorGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel4.Location = new System.Drawing.Point(12, 45);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel4.TabIndex = 4;
            this.cJiaLabel4.Text = "所属科室";
            // 
            // DocSearch
            // 
            this.DocSearch.EditValue = "";
            this.DocSearch.Location = new System.Drawing.Point(67, 539);
            this.DocSearch.Name = "DocSearch";
            this.DocSearch.PointText = "";
            this.DocSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            this.DocSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.DocSearch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.DocSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.DocSearch.Properties.Appearance.Options.UseFont = true;
            this.DocSearch.Properties.Appearance.Options.UseForeColor = true;
            toolTipItem2.Text = "查询";
            superToolTip2.Items.Add(toolTipItem2);
            this.DocSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("DocSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
            this.DocSearch.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.DocSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DocSearch.Size = new System.Drawing.Size(300, 32);
            this.DocSearch.TabIndex = 1;
            this.DocSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DocSearch_ButtonClick);
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel5.Location = new System.Drawing.Point(7, 549);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel5.TabIndex = 1;
            this.cJiaLabel5.Text = "关键字";
            // 
            // TxtDocName
            // 
            this.TxtDocName.Location = new System.Drawing.Point(328, 12);
            this.TxtDocName.Name = "TxtDocName";
            this.TxtDocName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDocName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtDocName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDocName.Properties.Appearance.Options.UseFont = true;
            this.TxtDocName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDocName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDocName.Size = new System.Drawing.Size(135, 22);
            this.TxtDocName.TabIndex = 3;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(249, 15);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "医生名称";
            // 
            // TxtDocNo
            // 
            this.TxtDocNo.Location = new System.Drawing.Point(90, 12);
            this.TxtDocNo.Name = "TxtDocNo";
            this.TxtDocNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDocNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtDocNo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDocNo.Properties.Appearance.Options.UseFont = true;
            this.TxtDocNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDocNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDocNo.Size = new System.Drawing.Size(135, 22);
            this.TxtDocNo.TabIndex = 2;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(12, 15);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel2.TabIndex = 0;
            this.cJiaLabel2.Text = "医生编号";
            // 
            // BtnAddDocject
            // 
            this.BtnAddDocject.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnAddDocject.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnAddDocject.Appearance.Options.UseFont = true;
            this.BtnAddDocject.Appearance.Options.UseForeColor = true;
            this.BtnAddDocject.CustomText = "添加(F1)";
            this.BtnAddDocject.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddDocject.Image")));
            this.BtnAddDocject.Location = new System.Drawing.Point(635, 541);
            this.BtnAddDocject.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnAddDocject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAddDocject.Name = "BtnAddDocject";
            this.BtnAddDocject.Selectable = false;
            this.BtnAddDocject.Size = new System.Drawing.Size(80, 28);
            this.BtnAddDocject.TabIndex = 7;
            this.BtnAddDocject.Text = "添加(F1)";
            this.BtnAddDocject.Click += new System.EventHandler(this.BtnAddProject_Click);
            // 
            // BtnDocDelect
            // 
            this.BtnDocDelect.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnDocDelect.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnDocDelect.Appearance.Options.UseFont = true;
            this.BtnDocDelect.Appearance.Options.UseForeColor = true;
            this.BtnDocDelect.CustomText = "删除(F3)";
            this.BtnDocDelect.Image = ((System.Drawing.Image)(resources.GetObject("BtnDocDelect.Image")));
            this.BtnDocDelect.Location = new System.Drawing.Point(807, 541);
            this.BtnDocDelect.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnDocDelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDocDelect.Name = "BtnDocDelect";
            this.BtnDocDelect.Selectable = false;
            this.BtnDocDelect.Size = new System.Drawing.Size(80, 28);
            this.BtnDocDelect.TabIndex = 9;
            this.BtnDocDelect.Text = "删除(F3)";
            this.BtnDocDelect.Click += new System.EventHandler(this.BtnProjectDelect_Click);
            // 
            // BtnUpdateDocject
            // 
            this.BtnUpdateDocject.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUpdateDocject.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnUpdateDocject.Appearance.Options.UseFont = true;
            this.BtnUpdateDocject.Appearance.Options.UseForeColor = true;
            this.BtnUpdateDocject.CustomText = "修改(F2)";
            this.BtnUpdateDocject.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateDocject.Image")));
            this.BtnUpdateDocject.Location = new System.Drawing.Point(721, 541);
            this.BtnUpdateDocject.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnUpdateDocject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnUpdateDocject.Name = "BtnUpdateDocject";
            this.BtnUpdateDocject.Selectable = false;
            this.BtnUpdateDocject.Size = new System.Drawing.Size(80, 28);
            this.BtnUpdateDocject.TabIndex = 8;
            this.BtnUpdateDocject.Text = "修改(F2)";
            this.BtnUpdateDocject.Click += new System.EventHandler(this.BtnUpdateProject_Click);
            // 
            // checkBox
            // 
            this.checkBox.EditValue = true;
            this.checkBox.Location = new System.Drawing.Point(529, 547);
            this.checkBox.Name = "checkBox";
            this.checkBox.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.checkBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Properties.Appearance.Options.UseBackColor = true;
            this.checkBox.Properties.Appearance.Options.UseFont = true;
            this.checkBox.Properties.Caption = "同时设为用户";
            this.checkBox.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.checkBox.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkBox.Selectable = true;
            this.checkBox.Size = new System.Drawing.Size(97, 19);
            this.checkBox.TabIndex = 11;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Controls.Add(this.LpDept);
            this.cJiaPanel2.Controls.Add(this.LpDes);
            this.cJiaPanel2.Controls.Add(this.TxtDocPinYin);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel7);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel6);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.TxtDocName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.TxtDocNo);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Location = new System.Drawing.Point(5, 45);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(882, 77);
            this.cJiaPanel2.TabIndex = 5;
            // 
            // LpDept
            // 
            this.LpDept.Caption = "";
            this.LpDept.DataSource = null;
            this.LpDept.DisplayField = "";
            this.LpDept.DisplayText = "";
            this.LpDept.DisplayValue = "";
            this.LpDept.EditValue = "";
            this.LpDept.Location = new System.Drawing.Point(90, 42);
            this.LpDept.Name = "LpDept";
            this.LpDept.OpenAfterEnter = false;
            this.LpDept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.LpDept.Properties.Appearance.Options.UseFont = true;
            this.LpDept.Properties.Appearance.Options.UseTextOptions = true;
            this.LpDept.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LpDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.LpDept.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LpDept.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LpDept.Properties.PopupFormMinSize = new System.Drawing.Size(200, 200);
            this.LpDept.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            this.LpDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LpDept.ResultRow = null;
            this.LpDept.Size = new System.Drawing.Size(135, 22);
            this.LpDept.TabIndex = 11;
            this.LpDept.UseRowNumDirectSelect = false;
            this.LpDept.UseRowNumLocate = false;
            this.LpDept.ValueField = "";
            // 
            // LpDes
            // 
            this.LpDes.Caption = "";
            this.LpDes.DataSource = null;
            this.LpDes.DisplayField = "";
            this.LpDes.DisplayText = "";
            this.LpDes.DisplayValue = "";
            this.LpDes.EditValue = "";
            this.LpDes.Location = new System.Drawing.Point(561, 12);
            this.LpDes.Name = "LpDes";
            this.LpDes.OpenAfterEnter = false;
            this.LpDes.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.LpDes.Properties.Appearance.Options.UseFont = true;
            this.LpDes.Properties.Appearance.Options.UseTextOptions = true;
            this.LpDes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LpDes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.LpDes.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LpDes.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LpDes.Properties.PopupFormMinSize = new System.Drawing.Size(200, 200);
            this.LpDes.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            this.LpDes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LpDes.ResultRow = null;
            this.LpDes.Size = new System.Drawing.Size(142, 22);
            this.LpDes.TabIndex = 10;
            this.LpDes.UseRowNumDirectSelect = false;
            this.LpDes.UseRowNumLocate = false;
            this.LpDes.ValueField = "";
            // 
            // TxtDocPinYin
            // 
            this.TxtDocPinYin.Location = new System.Drawing.Point(328, 42);
            this.TxtDocPinYin.Name = "TxtDocPinYin";
            this.TxtDocPinYin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDocPinYin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtDocPinYin.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDocPinYin.Properties.Appearance.Options.UseFont = true;
            this.TxtDocPinYin.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDocPinYin.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDocPinYin.Size = new System.Drawing.Size(135, 22);
            this.TxtDocPinYin.TabIndex = 6;
            // 
            // cJiaLabel7
            // 
            this.cJiaLabel7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel7.Location = new System.Drawing.Point(249, 45);
            this.cJiaLabel7.Name = "cJiaLabel7";
            this.cJiaLabel7.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel7.TabIndex = 9;
            this.cJiaLabel7.Text = "拼音编码";
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel6.Location = new System.Drawing.Point(495, 15);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel6.TabIndex = 7;
            this.cJiaLabel6.Text = "医生职称";
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.Controls.Add(this.checkBox);
            this.pnlDoctor.Controls.Add(this.BtnAddDocject);
            this.pnlDoctor.Controls.Add(this.cJiaPanel2);
            this.pnlDoctor.Controls.Add(this.BtnDocDelect);
            this.pnlDoctor.Controls.Add(this.BtnUpdateDocject);
            this.pnlDoctor.Controls.Add(this.DoctorGrid);
            this.pnlDoctor.Controls.Add(this.DocSearch);
            this.pnlDoctor.Controls.Add(this.cJiaLabel1);
            this.pnlDoctor.Controls.Add(this.cJiaLabel5);
            this.pnlDoctor.Location = new System.Drawing.Point(271, 14);
            this.pnlDoctor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlDoctor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDoctor.Name = "pnlDoctor";
            this.pnlDoctor.Size = new System.Drawing.Size(892, 580);
            this.pnlDoctor.TabIndex = 10;
            // 
            // DoctorManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlDoctor);
            this.Name = "DoctorManageView";
            this.Size = new System.Drawing.Size(1400, 600);
            this.SizeChanged += new System.EventHandler(this.DoctorManageView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LpDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LpDes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDocPinYin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoctor)).EndInit();
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Controls.CJiaGrid DoctorGrid;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaTextSearch DocSearch;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaTextBox TxtDocName;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox TxtDocNo;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnAdd BtnAddDocject;
        private Controls.BtnDelete BtnDocDelect;
        private Controls.CJiaButton BtnUpdateDocject;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaPanel pnlDoctor;
        private Controls.CJiaTextBox TxtDocPinYin;
        private Controls.CJiaLabel cJiaLabel7;
        private Controls.CJiaLabel cJiaLabel6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Controls.CJiaRTLookUp LpDes;
        private Controls.CJiaCheck checkBox;
        private Controls.CJiaRTLookUp LpDept;
    }
}
