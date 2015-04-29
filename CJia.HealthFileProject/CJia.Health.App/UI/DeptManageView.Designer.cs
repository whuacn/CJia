namespace CJia.Health.App.UI
{
    partial class DeptManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptManageView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptGrid = new CJia.Controls.CJiaGrid();
            this.TxtDeptPinyin = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.DeptSearch = new CJia.Controls.CJiaTextSearch();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.TxtDeptName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.TxtDeptNo = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.BtnAddDept = new CJia.Controls.BtnAdd();
            this.BtnDeptDelete = new CJia.Controls.BtnDelete();
            this.BtnUpdateDept = new CJia.Controls.CJiaButton();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.pnlDept = new CJia.Controls.CJiaPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptPinyin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDept)).BeginInit();
            this.pnlDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel1.Location = new System.Drawing.Point(398, 5);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(96, 31);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "科室字典";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "科室名称";
            this.gridColumn2.FieldName = "DEPT_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "科室编号";
            this.gridColumn1.FieldName = "DEPT_NO";
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
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.DeptGrid;
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
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "拼音编码";
            this.gridColumn3.FieldName = "FIRST_PINYIN";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // DeptGrid
            // 
            this.DeptGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeptGrid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeptGrid.IndicatorWidth = 30;
            this.DeptGrid.Location = new System.Drawing.Point(5, 93);
            this.DeptGrid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.DeptGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DeptGrid.MainView = this.gridView1;
            this.DeptGrid.Margin = new System.Windows.Forms.Padding(23);
            this.DeptGrid.Name = "DeptGrid";
            this.DeptGrid.ShowRowNumber = true;
            this.DeptGrid.Size = new System.Drawing.Size(882, 419);
            this.DeptGrid.TabIndex = 4;
            this.DeptGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // TxtDeptPinyin
            // 
            this.TxtDeptPinyin.Location = new System.Drawing.Point(519, 12);
            this.TxtDeptPinyin.Name = "TxtDeptPinyin";
            this.TxtDeptPinyin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDeptPinyin.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtDeptPinyin.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDeptPinyin.Properties.Appearance.Options.UseFont = true;
            this.TxtDeptPinyin.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDeptPinyin.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDeptPinyin.Properties.ReadOnly = true;
            this.TxtDeptPinyin.Size = new System.Drawing.Size(135, 26);
            this.TxtDeptPinyin.TabIndex = 4;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel4.Location = new System.Drawing.Point(453, 16);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel4.TabIndex = 4;
            this.cJiaLabel4.Text = "拼音编码";
            // 
            // DeptSearch
            // 
            this.DeptSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeptSearch.EditValue = "";
            this.DeptSearch.Location = new System.Drawing.Point(67, 523);
            this.DeptSearch.Name = "DeptSearch";
            this.DeptSearch.PointText = "";
            this.DeptSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            this.DeptSearch.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.DeptSearch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.DeptSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.DeptSearch.Properties.Appearance.Options.UseFont = true;
            this.DeptSearch.Properties.Appearance.Options.UseForeColor = true;
            toolTipItem2.Text = "查询";
            superToolTip2.Items.Add(toolTipItem2);
            this.DeptSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("DeptSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
            this.DeptSearch.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.DeptSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DeptSearch.Size = new System.Drawing.Size(300, 32);
            this.DeptSearch.TabIndex = 1;
            this.DeptSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DeptSearch_ButtonClick);
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel5.Location = new System.Drawing.Point(9, 530);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel5.TabIndex = 1;
            this.cJiaLabel5.Text = "关键字";
            // 
            // TxtDeptName
            // 
            this.TxtDeptName.Location = new System.Drawing.Point(295, 13);
            this.TxtDeptName.Name = "TxtDeptName";
            this.TxtDeptName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDeptName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtDeptName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDeptName.Properties.Appearance.Options.UseFont = true;
            this.TxtDeptName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDeptName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDeptName.Size = new System.Drawing.Size(135, 26);
            this.TxtDeptName.TabIndex = 3;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel3.Location = new System.Drawing.Point(229, 15);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "科室名称";
            // 
            // TxtDeptNo
            // 
            this.TxtDeptNo.Location = new System.Drawing.Point(77, 12);
            this.TxtDeptNo.Name = "TxtDeptNo";
            this.TxtDeptNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtDeptNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtDeptNo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtDeptNo.Properties.Appearance.Options.UseFont = true;
            this.TxtDeptNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtDeptNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtDeptNo.Size = new System.Drawing.Size(135, 26);
            this.TxtDeptNo.TabIndex = 2;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel2.Location = new System.Drawing.Point(11, 14);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel2.TabIndex = 0;
            this.cJiaLabel2.Text = "科室编号";
            // 
            // BtnAddDept
            // 
            this.BtnAddDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddDept.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnAddDept.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnAddDept.Appearance.Options.UseFont = true;
            this.BtnAddDept.Appearance.Options.UseForeColor = true;
            this.BtnAddDept.CustomText = "添加(F1)";
            this.BtnAddDept.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddDept.Image")));
            this.BtnAddDept.Location = new System.Drawing.Point(635, 527);
            this.BtnAddDept.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnAddDept.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAddDept.Name = "BtnAddDept";
            this.BtnAddDept.Selectable = false;
            this.BtnAddDept.Size = new System.Drawing.Size(80, 28);
            this.BtnAddDept.TabIndex = 5;
            this.BtnAddDept.Text = "添加(F1)";
            this.BtnAddDept.Click += new System.EventHandler(this.BtnAddDept_Click);
            // 
            // BtnDeptDelete
            // 
            this.BtnDeptDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnDeptDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnDeptDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnDeptDelete.Appearance.Options.UseFont = true;
            this.BtnDeptDelete.Appearance.Options.UseForeColor = true;
            this.BtnDeptDelete.CustomText = "删除(F3)";
            this.BtnDeptDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeptDelete.Image")));
            this.BtnDeptDelete.Location = new System.Drawing.Point(807, 527);
            this.BtnDeptDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnDeptDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDeptDelete.Name = "BtnDeptDelete";
            this.BtnDeptDelete.Selectable = false;
            this.BtnDeptDelete.Size = new System.Drawing.Size(80, 28);
            this.BtnDeptDelete.TabIndex = 7;
            this.BtnDeptDelete.Text = "删除(F3)";
            this.BtnDeptDelete.Click += new System.EventHandler(this.BtnDeptDelete_Click);
            // 
            // BtnUpdateDept
            // 
            this.BtnUpdateDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnUpdateDept.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUpdateDept.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnUpdateDept.Appearance.Options.UseFont = true;
            this.BtnUpdateDept.Appearance.Options.UseForeColor = true;
            this.BtnUpdateDept.CustomText = "修改(F2)";
            this.BtnUpdateDept.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateDept.Image")));
            this.BtnUpdateDept.Location = new System.Drawing.Point(721, 527);
            this.BtnUpdateDept.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnUpdateDept.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnUpdateDept.Name = "BtnUpdateDept";
            this.BtnUpdateDept.Selectable = false;
            this.BtnUpdateDept.Size = new System.Drawing.Size(80, 28);
            this.BtnUpdateDept.TabIndex = 6;
            this.BtnUpdateDept.Text = "修改(F2)";
            this.BtnUpdateDept.Click += new System.EventHandler(this.BtnUpdateDept_Click);
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Controls.Add(this.TxtDeptPinyin);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.TxtDeptName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.TxtDeptNo);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Location = new System.Drawing.Point(5, 43);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(882, 45);
            this.cJiaPanel2.TabIndex = 5;
            // 
            // pnlDept
            // 
            this.pnlDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDept.Controls.Add(this.BtnAddDept);
            this.pnlDept.Controls.Add(this.BtnDeptDelete);
            this.pnlDept.Controls.Add(this.BtnUpdateDept);
            this.pnlDept.Controls.Add(this.cJiaPanel2);
            this.pnlDept.Controls.Add(this.DeptSearch);
            this.pnlDept.Controls.Add(this.DeptGrid);
            this.pnlDept.Controls.Add(this.cJiaLabel5);
            this.pnlDept.Controls.Add(this.cJiaLabel1);
            this.pnlDept.Location = new System.Drawing.Point(250, 12);
            this.pnlDept.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlDept.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDept.Name = "pnlDept";
            this.pnlDept.Size = new System.Drawing.Size(892, 565);
            this.pnlDept.TabIndex = 10;
            // 
            // DeptManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDept);
            this.Name = "DeptManageView";
            this.Size = new System.Drawing.Size(1400, 600);
            this.SizeChanged += new System.EventHandler(this.DeptManageView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptPinyin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDept)).EndInit();
            this.pnlDept.ResumeLayout(false);
            this.pnlDept.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Controls.CJiaGrid DeptGrid;
        private Controls.CJiaTextBox TxtDeptPinyin;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaTextSearch DeptSearch;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaTextBox TxtDeptName;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox TxtDeptNo;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnAdd BtnAddDept;
        private Controls.BtnDelete BtnDeptDelete;
        private Controls.CJiaButton BtnUpdateDept;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaPanel pnlDept;
    }
}
