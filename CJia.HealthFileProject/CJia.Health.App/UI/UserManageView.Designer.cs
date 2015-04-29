namespace CJia.Health.App.UI
{
    partial class UserManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManageView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridUser = new CJia.Controls.CJiaGrid();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.btnSearch = new CJia.Controls.CJiaTextSearch();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.txtUserName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.txtUserNo = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.btnAdd = new CJia.Controls.BtnAdd();
            this.btnDelete = new CJia.Controls.BtnDelete();
            this.btnUpdate = new CJia.Controls.CJiaButton();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.cboDoctorDescript = new CJia.Controls.CJiaComboBox2();
            this.cJiaComboBox21View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.cklstUserRole = new CJia.Controls.CJiaCheckedListBox();
            this.rtlkDept = new CJia.Controls.CJiaRTLookUp();
            this.pnlUser = new CJia.Controls.CJiaPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctorDescript.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cklstUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtlkDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUser)).BeginInit();
            this.pnlUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel1.Location = new System.Drawing.Point(398, 5);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(96, 31);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "用户维护";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "用户名称";
            this.gridColumn2.FieldName = "USER_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 130;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "用户编号";
            this.gridColumn1.FieldName = "USER_NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
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
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridUser;
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
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "用户科室";
            this.gridColumn4.FieldName = "DEPT_NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "职称";
            this.gridColumn6.FieldName = "DOCTOR_DESCRIPT_NAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "角色名称";
            this.gridColumn3.FieldName = "UNION_ROLE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 409;
            // 
            // gridUser
            // 
            this.gridUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUser.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridUser.IndicatorWidth = 30;
            this.gridUser.Location = new System.Drawing.Point(5, 222);
            this.gridUser.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridUser.MainView = this.gridView1;
            this.gridUser.Margin = new System.Windows.Forms.Padding(23);
            this.gridUser.Name = "gridUser";
            this.gridUser.ShowRowNumber = true;
            this.gridUser.Size = new System.Drawing.Size(882, 303);
            this.gridUser.TabIndex = 6;
            this.gridUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel4.Location = new System.Drawing.Point(477, 25);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel4.TabIndex = 4;
            this.cJiaLabel4.Text = "所属科室";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.EditValue = "";
            this.btnSearch.Location = new System.Drawing.Point(66, 529);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PointText = "";
            this.btnSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            this.btnSearch.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btnSearch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.btnSearch.Properties.Appearance.Options.UseFont = true;
            this.btnSearch.Properties.Appearance.Options.UseForeColor = true;
            toolTipItem1.Text = "查询";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
            this.btnSearch.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Size = new System.Drawing.Size(300, 32);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSearch_ButtonClick);
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel5.Location = new System.Drawing.Point(15, 538);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel5.TabIndex = 1;
            this.cJiaLabel5.Text = "关键字";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(311, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtUserName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtUserName.Size = new System.Drawing.Size(135, 26);
            this.txtUserName.TabIndex = 2;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel3.Location = new System.Drawing.Point(245, 25);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "用户名称";
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(79, 22);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtUserNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserNo.Properties.Appearance.Options.UseFont = true;
            this.txtUserNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtUserNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtUserNo.Size = new System.Drawing.Size(135, 26);
            this.txtUserNo.TabIndex = 1;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel2.Location = new System.Drawing.Point(13, 25);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel2.TabIndex = 0;
            this.cJiaLabel2.Text = "用户编号";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.CustomText = "添加(F1)";
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(609, 533);
            this.btnAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Selectable = false;
            this.btnAdd.Size = new System.Drawing.Size(80, 28);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "添加(F1)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "删除(F3)";
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(806, 533);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(80, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删除(F3)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUpdate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Appearance.Options.UseForeColor = true;
            this.btnUpdate.CustomText = "修改(F2)";
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(708, 533);
            this.btnUpdate.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Selectable = false;
            this.btnUpdate.Size = new System.Drawing.Size(80, 28);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "修改(F2)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel2.Controls.Add(this.cboDoctorDescript);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel6);
            this.cJiaPanel2.Controls.Add(this.cklstUserRole);
            this.cJiaPanel2.Controls.Add(this.rtlkDept);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.txtUserName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.txtUserNo);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Location = new System.Drawing.Point(5, 42);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(882, 174);
            this.cJiaPanel2.TabIndex = 5;
            // 
            // cboDoctorDescript
            // 
            this.cboDoctorDescript.EditValue = "";
            this.cboDoctorDescript.Location = new System.Drawing.Point(740, 22);
            this.cboDoctorDescript.Name = "cboDoctorDescript";
            this.cboDoctorDescript.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboDoctorDescript.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cboDoctorDescript.Properties.Appearance.Options.UseFont = true;
            this.cboDoctorDescript.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboDoctorDescript.Properties.ImmediatePopup = true;
            this.cboDoctorDescript.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cboDoctorDescript.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDoctorDescript.Properties.NullText = "";
            this.cboDoctorDescript.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboDoctorDescript.Properties.PopupFormMinSize = new System.Drawing.Size(250, 250);
            this.cboDoctorDescript.Properties.PopupFormSize = new System.Drawing.Size(250, 250);
            this.cboDoctorDescript.Properties.ShowFooter = false;
            this.cboDoctorDescript.Properties.View = this.cJiaComboBox21View;
            this.cboDoctorDescript.Size = new System.Drawing.Size(135, 26);
            this.cboDoctorDescript.TabIndex = 4;
            // 
            // cJiaComboBox21View
            // 
            this.cJiaComboBox21View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5});
            this.cJiaComboBox21View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cJiaComboBox21View.Name = "cJiaComboBox21View";
            this.cJiaComboBox21View.OptionsBehavior.AutoPopulateColumns = false;
            this.cJiaComboBox21View.OptionsCustomization.AllowFilter = false;
            this.cJiaComboBox21View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cJiaComboBox21View.OptionsView.ShowColumnHeaders = false;
            this.cJiaComboBox21View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "性别";
            this.gridColumn5.FieldName = "NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel6.Location = new System.Drawing.Point(704, 25);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(26, 19);
            this.cJiaLabel6.TabIndex = 12;
            this.cJiaLabel6.Text = "职称";
            // 
            // cklstUserRole
            // 
            this.cklstUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cklstUserRole.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.cklstUserRole.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.cklstUserRole.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cklstUserRole.Appearance.Options.UseBackColor = true;
            this.cklstUserRole.Appearance.Options.UseBorderColor = true;
            this.cklstUserRole.Appearance.Options.UseFont = true;
            this.cklstUserRole.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cklstUserRole.HorizontalScrollbar = true;
            this.cklstUserRole.HotTrackItems = true;
            this.cklstUserRole.ItemHeight = 28;
            this.cklstUserRole.Location = new System.Drawing.Point(5, 61);
            this.cklstUserRole.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cklstUserRole.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cklstUserRole.MultiColumn = true;
            this.cklstUserRole.Name = "cklstUserRole";
            this.cklstUserRole.Size = new System.Drawing.Size(872, 108);
            this.cklstUserRole.TabIndex = 5;
            // 
            // rtlkDept
            // 
            this.rtlkDept.Caption = "";
            this.rtlkDept.DataSource = null;
            this.rtlkDept.DisplayField = "";
            this.rtlkDept.DisplayText = "";
            this.rtlkDept.DisplayValue = "";
            this.rtlkDept.EditValue = "";
            this.rtlkDept.Location = new System.Drawing.Point(543, 22);
            this.rtlkDept.Name = "rtlkDept";
            this.rtlkDept.OpenAfterEnter = false;
            this.rtlkDept.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.rtlkDept.Properties.Appearance.Options.UseFont = true;
            this.rtlkDept.Properties.Appearance.Options.UseTextOptions = true;
            this.rtlkDept.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rtlkDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.rtlkDept.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.rtlkDept.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rtlkDept.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.rtlkDept.Properties.PopupFormMinSize = new System.Drawing.Size(250, 250);
            this.rtlkDept.Properties.PopupFormSize = new System.Drawing.Size(250, 250);
            this.rtlkDept.Properties.ShowPopupCloseButton = false;
            this.rtlkDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rtlkDept.ResultRow = null;
            this.rtlkDept.Size = new System.Drawing.Size(135, 26);
            this.rtlkDept.TabIndex = 3;
            this.rtlkDept.UseRowNumDirectSelect = false;
            this.rtlkDept.UseRowNumLocate = false;
            this.rtlkDept.ValueField = "";
            // 
            // pnlUser
            // 
            this.pnlUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlUser.Controls.Add(this.btnAdd);
            this.pnlUser.Controls.Add(this.cJiaPanel2);
            this.pnlUser.Controls.Add(this.btnSearch);
            this.pnlUser.Controls.Add(this.gridUser);
            this.pnlUser.Controls.Add(this.btnDelete);
            this.pnlUser.Controls.Add(this.btnUpdate);
            this.pnlUser.Controls.Add(this.cJiaLabel1);
            this.pnlUser.Controls.Add(this.cJiaLabel5);
            this.pnlUser.Location = new System.Drawing.Point(260, 9);
            this.pnlUser.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(892, 580);
            this.pnlUser.TabIndex = 10;
            // 
            // UserManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlUser);
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "UserManageView";
            this.Size = new System.Drawing.Size(1400, 600);
            this.SizeChanged += new System.EventHandler(this.UserManageView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctorDescript.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cklstUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtlkDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUser)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Controls.CJiaGrid gridUser;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaTextSearch btnSearch;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaTextBox txtUserName;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox txtUserNo;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnAdd btnAdd;
        private Controls.BtnDelete btnDelete;
        private Controls.CJiaButton btnUpdate;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaPanel pnlUser;
        private Controls.CJiaRTLookUp rtlkDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private Controls.CJiaCheckedListBox cklstUserRole;
        private Controls.CJiaLabel cJiaLabel6;
        private Controls.CJiaComboBox2 cboDoctorDescript;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaComboBox21View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}
