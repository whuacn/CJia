namespace CJia.Health.App.UI
{
    partial class BorrowTimeLenthView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowTimeLenthView));
            this.pnlBorrpwTime = new CJia.Controls.CJiaPanel();
            this.BtnAddBorrowTime = new CJia.Controls.BtnAdd();
            this.BtnDeleteBorrowTime = new CJia.Controls.BtnDelete();
            this.BtnUpdateBorrowTime = new CJia.Controls.CJiaButton();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.cbDocDes = new CJia.Controls.CJiaComboBox2();
            this.cJiaComboBox21View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.txtBorrowTime = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.gcBorrowTime = new CJia.Controls.CJiaGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBorrpwTime)).BeginInit();
            this.pnlBorrpwTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDocDes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorrowTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBorrpwTime
            // 
            this.pnlBorrpwTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlBorrpwTime.Controls.Add(this.BtnAddBorrowTime);
            this.pnlBorrpwTime.Controls.Add(this.BtnDeleteBorrowTime);
            this.pnlBorrpwTime.Controls.Add(this.BtnUpdateBorrowTime);
            this.pnlBorrpwTime.Controls.Add(this.cJiaPanel2);
            this.pnlBorrpwTime.Controls.Add(this.gcBorrowTime);
            this.pnlBorrpwTime.Controls.Add(this.cJiaLabel1);
            this.pnlBorrpwTime.Location = new System.Drawing.Point(256, 14);
            this.pnlBorrpwTime.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlBorrpwTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBorrpwTime.Name = "pnlBorrpwTime";
            this.pnlBorrpwTime.Size = new System.Drawing.Size(892, 565);
            this.pnlBorrpwTime.TabIndex = 11;
            // 
            // BtnAddBorrowTime
            // 
            this.BtnAddBorrowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddBorrowTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnAddBorrowTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnAddBorrowTime.Appearance.Options.UseFont = true;
            this.BtnAddBorrowTime.Appearance.Options.UseForeColor = true;
            this.BtnAddBorrowTime.CustomText = "添加(F1)";
            this.BtnAddBorrowTime.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddBorrowTime.Image")));
            this.BtnAddBorrowTime.Location = new System.Drawing.Point(635, 516);
            this.BtnAddBorrowTime.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnAddBorrowTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAddBorrowTime.Name = "BtnAddBorrowTime";
            this.BtnAddBorrowTime.Selectable = false;
            this.BtnAddBorrowTime.Size = new System.Drawing.Size(80, 28);
            this.BtnAddBorrowTime.TabIndex = 5;
            this.BtnAddBorrowTime.Text = "添加(F1)";
            this.BtnAddBorrowTime.Click += new System.EventHandler(this.BtnAddBorrowTime_Click);
            // 
            // BtnDeleteBorrowTime
            // 
            this.BtnDeleteBorrowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnDeleteBorrowTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnDeleteBorrowTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnDeleteBorrowTime.Appearance.Options.UseFont = true;
            this.BtnDeleteBorrowTime.Appearance.Options.UseForeColor = true;
            this.BtnDeleteBorrowTime.CustomText = "删除(F3)";
            this.BtnDeleteBorrowTime.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeleteBorrowTime.Image")));
            this.BtnDeleteBorrowTime.Location = new System.Drawing.Point(807, 516);
            this.BtnDeleteBorrowTime.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnDeleteBorrowTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDeleteBorrowTime.Name = "BtnDeleteBorrowTime";
            this.BtnDeleteBorrowTime.Selectable = false;
            this.BtnDeleteBorrowTime.Size = new System.Drawing.Size(80, 28);
            this.BtnDeleteBorrowTime.TabIndex = 7;
            this.BtnDeleteBorrowTime.Text = "删除(F3)";
            this.BtnDeleteBorrowTime.Click += new System.EventHandler(this.BtnDeleteBorrowTime_Click);
            // 
            // BtnUpdateBorrowTime
            // 
            this.BtnUpdateBorrowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnUpdateBorrowTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUpdateBorrowTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.BtnUpdateBorrowTime.Appearance.Options.UseFont = true;
            this.BtnUpdateBorrowTime.Appearance.Options.UseForeColor = true;
            this.BtnUpdateBorrowTime.CustomText = "修改(F2)";
            this.BtnUpdateBorrowTime.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateBorrowTime.Image")));
            this.BtnUpdateBorrowTime.Location = new System.Drawing.Point(721, 516);
            this.BtnUpdateBorrowTime.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnUpdateBorrowTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnUpdateBorrowTime.Name = "BtnUpdateBorrowTime";
            this.BtnUpdateBorrowTime.Selectable = false;
            this.BtnUpdateBorrowTime.Size = new System.Drawing.Size(80, 28);
            this.BtnUpdateBorrowTime.TabIndex = 6;
            this.BtnUpdateBorrowTime.Text = "修改(F2)";
            this.BtnUpdateBorrowTime.Click += new System.EventHandler(this.BtnUpdateBorrowTime_Click);
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cJiaPanel2.Controls.Add(this.cbDocDes);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel2.Controls.Add(this.txtBorrowTime);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel2.Location = new System.Drawing.Point(5, 45);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(882, 46);
            this.cJiaPanel2.TabIndex = 5;
            // 
            // cbDocDes
            // 
            this.cbDocDes.Location = new System.Drawing.Point(50, 11);
            this.cbDocDes.Name = "cbDocDes";
            this.cbDocDes.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbDocDes.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cbDocDes.Properties.Appearance.Options.UseFont = true;
            this.cbDocDes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cbDocDes.Properties.ImmediatePopup = true;
            this.cbDocDes.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cbDocDes.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbDocDes.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cbDocDes.Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            this.cbDocDes.Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            this.cbDocDes.Properties.ShowFooter = false;
            this.cbDocDes.Properties.View = this.cJiaComboBox21View;
            this.cbDocDes.Size = new System.Drawing.Size(150, 26);
            this.cbDocDes.TabIndex = 9;
            // 
            // cJiaComboBox21View
            // 
            this.cJiaComboBox21View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13});
            this.cJiaComboBox21View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cJiaComboBox21View.Name = "cJiaComboBox21View";
            this.cJiaComboBox21View.OptionsBehavior.AutoPopulateColumns = false;
            this.cJiaComboBox21View.OptionsCustomization.AllowFilter = false;
            this.cJiaComboBox21View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cJiaComboBox21View.OptionsView.ShowColumnHeaders = false;
            this.cJiaComboBox21View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "借阅状态";
            this.gridColumn13.FieldName = "NAME";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel4.Location = new System.Drawing.Point(371, 14);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(21, 19);
            this.cJiaLabel4.TabIndex = 5;
            this.cJiaLabel4.Text = "(天)";
            // 
            // txtBorrowTime
            // 
            this.txtBorrowTime.Location = new System.Drawing.Point(297, 10);
            this.txtBorrowTime.Name = "txtBorrowTime";
            this.txtBorrowTime.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtBorrowTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtBorrowTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtBorrowTime.Properties.Appearance.Options.UseFont = true;
            this.txtBorrowTime.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtBorrowTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBorrowTime.Size = new System.Drawing.Size(68, 26);
            this.txtBorrowTime.TabIndex = 3;
            this.txtBorrowTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBorrowTime_KeyPress);
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel3.Location = new System.Drawing.Point(218, 15);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(52, 19);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "借阅时间";
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel2.Location = new System.Drawing.Point(4, 15);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(26, 19);
            this.cJiaLabel2.TabIndex = 0;
            this.cJiaLabel2.Text = "职称";
            // 
            // gcBorrowTime
            // 
            this.gcBorrowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBorrowTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcBorrowTime.IndicatorWidth = 30;
            this.gcBorrowTime.Location = new System.Drawing.Point(5, 96);
            this.gcBorrowTime.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gcBorrowTime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcBorrowTime.MainView = this.gridView1;
            this.gcBorrowTime.Margin = new System.Windows.Forms.Padding(23);
            this.gcBorrowTime.Name = "gcBorrowTime";
            this.gcBorrowTime.ShowRowNumber = true;
            this.gcBorrowTime.Size = new System.Drawing.Size(882, 410);
            this.gcBorrowTime.TabIndex = 4;
            this.gcBorrowTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gcBorrowTime;
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
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "职称";
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "借阅时间";
            this.gridColumn2.FieldName = "TIME_LENTH";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cJiaLabel1.Location = new System.Drawing.Point(398, 5);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(96, 31);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "借阅时间";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "医生职称";
            this.gridColumn3.FieldName = "NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // BorrowTimeLenthView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBorrpwTime);
            this.Name = "BorrowTimeLenthView";
            this.Size = new System.Drawing.Size(1400, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBorrpwTime)).EndInit();
            this.pnlBorrpwTime.ResumeLayout(false);
            this.pnlBorrpwTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDocDes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorrowTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel pnlBorrpwTime;
        private Controls.BtnAdd BtnAddBorrowTime;
        private Controls.BtnDelete BtnDeleteBorrowTime;
        private Controls.CJiaButton BtnUpdateBorrowTime;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaTextBox txtBorrowTime;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaGrid gcBorrowTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaLabel cJiaLabel4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Controls.CJiaComboBox2 cbDocDes;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaComboBox21View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}
