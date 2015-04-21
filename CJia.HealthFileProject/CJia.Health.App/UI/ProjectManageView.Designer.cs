namespace CJia.Health.App.UI
{
    partial class ProjectManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectManageView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.pnlProject = new CJia.Controls.CJiaPanel();
            this.BtnAddProject = new CJia.Controls.BtnAdd();
            this.BtnProjectDelect = new CJia.Controls.BtnDelete();
            this.BtnUpdateProject = new CJia.Controls.CJiaButton();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.txtKey = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.ckPrint = new CJia.Controls.CJiaCheck();
            this.TxtProPinyin = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.TxtProName = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.TxtProNo = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.ProjectSearch = new CJia.Controls.CJiaTextSearch();
            this.ProjectGrid = new CJia.Controls.CJiaGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProject)).BeginInit();
            this.pnlProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProPinyin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProject
            // 
            this.pnlProject.Controls.Add(this.BtnAddProject);
            this.pnlProject.Controls.Add(this.BtnProjectDelect);
            this.pnlProject.Controls.Add(this.BtnUpdateProject);
            this.pnlProject.Controls.Add(this.cJiaPanel2);
            this.pnlProject.Controls.Add(this.ProjectSearch);
            this.pnlProject.Controls.Add(this.ProjectGrid);
            this.pnlProject.Controls.Add(this.cJiaLabel5);
            this.pnlProject.Controls.Add(this.cJiaLabel1);
            this.pnlProject.Location = new System.Drawing.Point(291, 12);
            this.pnlProject.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlProject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlProject.Name = "pnlProject";
            this.pnlProject.Size = new System.Drawing.Size(892, 580);
            this.pnlProject.TabIndex = 10;
            // 
            // BtnAddProject
            // 
            this.BtnAddProject.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnAddProject.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnAddProject.Appearance.Options.UseFont = true;
            this.BtnAddProject.Appearance.Options.UseForeColor = true;
            this.BtnAddProject.CustomText = "添加(F1)";
            this.BtnAddProject.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddProject.Image")));
            this.BtnAddProject.Location = new System.Drawing.Point(625, 547);
            this.BtnAddProject.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnAddProject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAddProject.Name = "BtnAddProject";
            this.BtnAddProject.Selectable = false;
            this.BtnAddProject.Size = new System.Drawing.Size(80, 28);
            this.BtnAddProject.TabIndex = 5;
            this.BtnAddProject.Text = "添加(F1)";
            this.BtnAddProject.Click += new System.EventHandler(this.BtnAddProject_Click);
            // 
            // BtnProjectDelect
            // 
            this.BtnProjectDelect.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnProjectDelect.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnProjectDelect.Appearance.Options.UseFont = true;
            this.BtnProjectDelect.Appearance.Options.UseForeColor = true;
            this.BtnProjectDelect.CustomText = "删除(F3)";
            this.BtnProjectDelect.Image = ((System.Drawing.Image)(resources.GetObject("BtnProjectDelect.Image")));
            this.BtnProjectDelect.Location = new System.Drawing.Point(807, 547);
            this.BtnProjectDelect.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnProjectDelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnProjectDelect.Name = "BtnProjectDelect";
            this.BtnProjectDelect.Selectable = false;
            this.BtnProjectDelect.Size = new System.Drawing.Size(80, 28);
            this.BtnProjectDelect.TabIndex = 7;
            this.BtnProjectDelect.Text = "删除(F3)";
            this.BtnProjectDelect.Click += new System.EventHandler(this.BtnProjectDelect_Click);
            // 
            // BtnUpdateProject
            // 
            this.BtnUpdateProject.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUpdateProject.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnUpdateProject.Appearance.Options.UseFont = true;
            this.BtnUpdateProject.Appearance.Options.UseForeColor = true;
            this.BtnUpdateProject.CustomText = "修改(F2)";
            this.BtnUpdateProject.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateProject.Image")));
            this.BtnUpdateProject.Location = new System.Drawing.Point(716, 547);
            this.BtnUpdateProject.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnUpdateProject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnUpdateProject.Name = "BtnUpdateProject";
            this.BtnUpdateProject.Selectable = false;
            this.BtnUpdateProject.Size = new System.Drawing.Size(80, 28);
            this.BtnUpdateProject.TabIndex = 6;
            this.BtnUpdateProject.Text = "修改(F2)";
            this.BtnUpdateProject.Click += new System.EventHandler(this.BtnUpdateProject_Click);
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Controls.Add(this.txtKey);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel6);
            this.cJiaPanel2.Controls.Add(this.ckPrint);
            this.cJiaPanel2.Controls.Add(this.TxtProPinyin);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.TxtProName);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.TxtProNo);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Location = new System.Drawing.Point(5, 44);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(882, 42);
            this.cJiaPanel2.TabIndex = 5;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(500, 9);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtKey.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtKey.Properties.Appearance.Options.UseFont = true;
            this.txtKey.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtKey.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtKey.Size = new System.Drawing.Size(92, 26);
            this.txtKey.TabIndex = 6;
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel6.Location = new System.Drawing.Point(449, 13);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel6.TabIndex = 7;
            this.cJiaLabel6.Text = "快捷键";
            // 
            // ckPrint
            // 
            this.ckPrint.EditValue = true;
            this.ckPrint.Location = new System.Drawing.Point(787, 9);
            this.ckPrint.Name = "ckPrint";
            this.ckPrint.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ckPrint.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckPrint.Properties.Appearance.Options.UseBackColor = true;
            this.ckPrint.Properties.Appearance.Options.UseFont = true;
            this.ckPrint.Properties.Caption = "可以打印";
            this.ckPrint.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ckPrint.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ckPrint.Selectable = true;
            this.ckPrint.Size = new System.Drawing.Size(93, 24);
            this.ckPrint.TabIndex = 5;
            // 
            // TxtProPinyin
            // 
            this.TxtProPinyin.Location = new System.Drawing.Point(675, 8);
            this.TxtProPinyin.Name = "TxtProPinyin";
            this.TxtProPinyin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtProPinyin.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtProPinyin.Properties.Appearance.Options.UseBackColor = true;
            this.TxtProPinyin.Properties.Appearance.Options.UseFont = true;
            this.TxtProPinyin.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtProPinyin.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtProPinyin.Properties.ReadOnly = true;
            this.TxtProPinyin.Size = new System.Drawing.Size(106, 26);
            this.TxtProPinyin.TabIndex = 4;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel4.Location = new System.Drawing.Point(609, 12);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel4.TabIndex = 4;
            this.cJiaLabel4.Text = "拼音编码";
            // 
            // TxtProName
            // 
            this.TxtProName.Location = new System.Drawing.Point(226, 9);
            this.TxtProName.Name = "TxtProName";
            this.TxtProName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtProName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtProName.Properties.Appearance.Options.UseBackColor = true;
            this.TxtProName.Properties.Appearance.Options.UseFont = true;
            this.TxtProName.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtProName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtProName.Size = new System.Drawing.Size(217, 26);
            this.TxtProName.TabIndex = 3;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel3.Location = new System.Drawing.Point(160, 15);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "项目名称";
            // 
            // TxtProNo
            // 
            this.TxtProNo.Location = new System.Drawing.Point(71, 9);
            this.TxtProNo.Name = "TxtProNo";
            this.TxtProNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtProNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtProNo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtProNo.Properties.Appearance.Options.UseFont = true;
            this.TxtProNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtProNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtProNo.Size = new System.Drawing.Size(83, 26);
            this.TxtProNo.TabIndex = 2;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel2.Location = new System.Drawing.Point(5, 15);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel2.TabIndex = 0;
            this.cJiaLabel2.Text = "项目编号";
            // 
            // ProjectSearch
            // 
            this.ProjectSearch.EditValue = "";
            this.ProjectSearch.Location = new System.Drawing.Point(57, 543);
            this.ProjectSearch.Name = "ProjectSearch";
            this.ProjectSearch.PointText = "";
            this.ProjectSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            this.ProjectSearch.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.ProjectSearch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ProjectSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.ProjectSearch.Properties.Appearance.Options.UseFont = true;
            this.ProjectSearch.Properties.Appearance.Options.UseForeColor = true;
            toolTipItem1.Text = "查询";
            superToolTip1.Items.Add(toolTipItem1);
            this.ProjectSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("ProjectSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
            this.ProjectSearch.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ProjectSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ProjectSearch.Size = new System.Drawing.Size(300, 32);
            this.ProjectSearch.TabIndex = 1;
            this.ProjectSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ProjectSearch_ButtonClick);
            // 
            // ProjectGrid
            // 
            this.ProjectGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectGrid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectGrid.IndicatorWidth = 30;
            this.ProjectGrid.Location = new System.Drawing.Point(5, 92);
            this.ProjectGrid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ProjectGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ProjectGrid.MainView = this.gridView1;
            this.ProjectGrid.Margin = new System.Windows.Forms.Padding(20);
            this.ProjectGrid.Name = "ProjectGrid";
            this.ProjectGrid.ShowRowNumber = true;
            this.ProjectGrid.Size = new System.Drawing.Size(882, 445);
            this.ProjectGrid.TabIndex = 4;
            this.ProjectGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.ProjectGrid;
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
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "项目编号";
            this.gridColumn1.FieldName = "PRO_NO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "项目名称";
            this.gridColumn2.FieldName = "PRO_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "快捷键";
            this.gridColumn4.FieldName = "SHORT_KEY";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "拼音编码";
            this.gridColumn3.FieldName = "FIRST_PINYIN";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel5.Location = new System.Drawing.Point(6, 551);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(39, 19);
            this.cJiaLabel5.TabIndex = 1;
            this.cJiaLabel5.Text = "关键字";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cJiaLabel1.Location = new System.Drawing.Point(398, 6);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(96, 31);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "类别字典";
            // 
            // ProjectManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlProject);
            this.Name = "ProjectManageView";
            this.Size = new System.Drawing.Size(1400, 600);
            this.SizeChanged += new System.EventHandler(this.ProjectManageView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pnlProject)).EndInit();
            this.pnlProject.ResumeLayout(false);
            this.pnlProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProPinyin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel pnlProject;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.BtnDelete BtnProjectDelect;
        private Controls.CJiaButton BtnUpdateProject;
        private Controls.CJiaTextSearch ProjectSearch;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaTextBox TxtProPinyin;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaTextBox TxtProName;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox TxtProNo;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaGrid ProjectGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Controls.BtnAdd BtnAddProject;
        private Controls.CJiaCheck ckPrint;
        private Controls.CJiaTextBox txtKey;
        private Controls.CJiaLabel cJiaLabel6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
