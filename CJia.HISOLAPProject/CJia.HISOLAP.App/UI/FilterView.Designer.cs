namespace CJia.HISOLAP.App.UI
{
    partial class FilterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterView));
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.rbMounth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbJD = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDG = new System.Windows.Forms.RadioButton();
            this.rbQJ = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.gbDATE = new System.Windows.Forms.GroupBox();
            this.cbStartJD = new System.Windows.Forms.ComboBox();
            this.cbEndNF = new System.Windows.Forms.ComboBox();
            this.cbEndRQ = new System.Windows.Forms.ComboBox();
            this.cbStartRQ = new System.Windows.Forms.ComboBox();
            this.cbStartYF = new System.Windows.Forms.ComboBox();
            this.cbEndYF = new System.Windows.Forms.ComboBox();
            this.cbEndJD = new System.Windows.Forms.ComboBox();
            this.cbStartNF = new System.Windows.Forms.ComboBox();
            this.btnRefresh2 = new CJia.Controls.BtnRefresh();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.gbDept = new System.Windows.Forms.GroupBox();
            this.btnDX = new System.Windows.Forms.Button();
            this.ctlDept = new CJia.Controls.CJiaTreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnRefresh1 = new CJia.Controls.BtnRefresh();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbDATE.SuspendLayout();
            this.gbDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDept)).BeginInit();
            this.SuspendLayout();
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Checked = true;
            this.rbYear.ForeColor = System.Drawing.Color.Black;
            this.rbYear.Location = new System.Drawing.Point(3, 6);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(37, 18);
            this.rbYear.TabIndex = 1;
            this.rbYear.TabStop = true;
            this.rbYear.Text = "年";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // rbMounth
            // 
            this.rbMounth.AutoSize = true;
            this.rbMounth.Location = new System.Drawing.Point(115, 6);
            this.rbMounth.Name = "rbMounth";
            this.rbMounth.Size = new System.Drawing.Size(37, 18);
            this.rbMounth.TabIndex = 3;
            this.rbMounth.Text = "月";
            this.rbMounth.UseVisualStyleBackColor = true;
            this.rbMounth.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Location = new System.Drawing.Point(171, 6);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(37, 18);
            this.rbDay.TabIndex = 4;
            this.rbDay.Text = "日";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbJD);
            this.panel1.Controls.Add(this.rbYear);
            this.panel1.Controls.Add(this.rbMounth);
            this.panel1.Controls.Add(this.rbDay);
            this.panel1.Location = new System.Drawing.Point(84, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 28);
            this.panel1.TabIndex = 8;
            // 
            // rbJD
            // 
            this.rbJD.AutoSize = true;
            this.rbJD.Location = new System.Drawing.Point(59, 6);
            this.rbJD.Name = "rbJD";
            this.rbJD.Size = new System.Drawing.Size(37, 18);
            this.rbJD.TabIndex = 5;
            this.rbJD.Text = "季";
            this.rbJD.UseVisualStyleBackColor = true;
            this.rbJD.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbDG);
            this.panel2.Controls.Add(this.rbQJ);
            this.panel2.Location = new System.Drawing.Point(84, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 28);
            this.panel2.TabIndex = 9;
            // 
            // rbDG
            // 
            this.rbDG.AutoSize = true;
            this.rbDG.Checked = true;
            this.rbDG.Location = new System.Drawing.Point(3, 6);
            this.rbDG.Name = "rbDG";
            this.rbDG.Size = new System.Drawing.Size(49, 18);
            this.rbDG.TabIndex = 1;
            this.rbDG.TabStop = true;
            this.rbDG.Text = "单个";
            this.rbDG.UseVisualStyleBackColor = true;
            this.rbDG.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // rbQJ
            // 
            this.rbQJ.AutoSize = true;
            this.rbQJ.Location = new System.Drawing.Point(115, 5);
            this.rbQJ.Name = "rbQJ";
            this.rbQJ.Size = new System.Drawing.Size(49, 18);
            this.rbQJ.TabIndex = 3;
            this.rbQJ.Text = "区间";
            this.rbQJ.UseVisualStyleBackColor = true;
            this.rbQJ.CheckedChanged += new System.EventHandler(this.rbRQ_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(7, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "日期类型：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(7, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "年      份：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Location = new System.Drawing.Point(7, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "日期方式：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl6.Location = new System.Drawing.Point(187, 90);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(12, 14);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "至";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl7.Location = new System.Drawing.Point(7, 128);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "季      度：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Location = new System.Drawing.Point(187, 128);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(12, 14);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "至";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Location = new System.Drawing.Point(187, 168);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(12, 14);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "至";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl8.Location = new System.Drawing.Point(7, 168);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 25;
            this.labelControl8.Text = "月      份：";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl9.Location = new System.Drawing.Point(187, 207);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(12, 14);
            this.labelControl9.TabIndex = 31;
            this.labelControl9.Text = "至";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl10.Location = new System.Drawing.Point(7, 207);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 29;
            this.labelControl10.Text = "日      期：";
            // 
            // gbDATE
            // 
            this.gbDATE.BackColor = System.Drawing.Color.White;
            this.gbDATE.Controls.Add(this.cbStartJD);
            this.gbDATE.Controls.Add(this.cbEndNF);
            this.gbDATE.Controls.Add(this.cbEndRQ);
            this.gbDATE.Controls.Add(this.cbStartRQ);
            this.gbDATE.Controls.Add(this.cbStartYF);
            this.gbDATE.Controls.Add(this.cbEndYF);
            this.gbDATE.Controls.Add(this.cbEndJD);
            this.gbDATE.Controls.Add(this.cbStartNF);
            this.gbDATE.Controls.Add(this.labelControl1);
            this.gbDATE.Controls.Add(this.panel1);
            this.gbDATE.Controls.Add(this.panel2);
            this.gbDATE.Controls.Add(this.labelControl9);
            this.gbDATE.Controls.Add(this.labelControl2);
            this.gbDATE.Controls.Add(this.labelControl10);
            this.gbDATE.Controls.Add(this.labelControl3);
            this.gbDATE.Controls.Add(this.labelControl5);
            this.gbDATE.Controls.Add(this.labelControl6);
            this.gbDATE.Controls.Add(this.labelControl8);
            this.gbDATE.Controls.Add(this.labelControl7);
            this.gbDATE.Controls.Add(this.labelControl4);
            this.gbDATE.ForeColor = System.Drawing.Color.Black;
            this.gbDATE.Location = new System.Drawing.Point(8, 8);
            this.gbDATE.Name = "gbDATE";
            this.gbDATE.Size = new System.Drawing.Size(310, 238);
            this.gbDATE.TabIndex = 34;
            this.gbDATE.TabStop = false;
            this.gbDATE.Text = "日期选择";
            // 
            // cbStartJD
            // 
            this.cbStartJD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartJD.FormattingEnabled = true;
            this.cbStartJD.Location = new System.Drawing.Point(84, 125);
            this.cbStartJD.Name = "cbStartJD";
            this.cbStartJD.Size = new System.Drawing.Size(96, 22);
            this.cbStartJD.TabIndex = 39;
            // 
            // cbEndNF
            // 
            this.cbEndNF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndNF.FormattingEnabled = true;
            this.cbEndNF.Location = new System.Drawing.Point(207, 87);
            this.cbEndNF.Name = "cbEndNF";
            this.cbEndNF.Size = new System.Drawing.Size(96, 22);
            this.cbEndNF.TabIndex = 38;
            this.cbEndNF.SelectedValueChanged += new System.EventHandler(this.cbRQ_SelectedValueChanged);
            // 
            // cbEndRQ
            // 
            this.cbEndRQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndRQ.FormattingEnabled = true;
            this.cbEndRQ.Location = new System.Drawing.Point(207, 204);
            this.cbEndRQ.Name = "cbEndRQ";
            this.cbEndRQ.Size = new System.Drawing.Size(96, 22);
            this.cbEndRQ.TabIndex = 37;
            // 
            // cbStartRQ
            // 
            this.cbStartRQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartRQ.FormattingEnabled = true;
            this.cbStartRQ.Location = new System.Drawing.Point(84, 204);
            this.cbStartRQ.Name = "cbStartRQ";
            this.cbStartRQ.Size = new System.Drawing.Size(96, 22);
            this.cbStartRQ.TabIndex = 36;
            // 
            // cbStartYF
            // 
            this.cbStartYF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartYF.FormattingEnabled = true;
            this.cbStartYF.Location = new System.Drawing.Point(84, 165);
            this.cbStartYF.Name = "cbStartYF";
            this.cbStartYF.Size = new System.Drawing.Size(96, 22);
            this.cbStartYF.TabIndex = 35;
            this.cbStartYF.SelectedValueChanged += new System.EventHandler(this.cbRQ_SelectedValueChanged);
            // 
            // cbEndYF
            // 
            this.cbEndYF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndYF.FormattingEnabled = true;
            this.cbEndYF.Location = new System.Drawing.Point(207, 165);
            this.cbEndYF.Name = "cbEndYF";
            this.cbEndYF.Size = new System.Drawing.Size(96, 22);
            this.cbEndYF.TabIndex = 34;
            this.cbEndYF.SelectedValueChanged += new System.EventHandler(this.cbRQ_SelectedValueChanged);
            // 
            // cbEndJD
            // 
            this.cbEndJD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndJD.FormattingEnabled = true;
            this.cbEndJD.Location = new System.Drawing.Point(207, 125);
            this.cbEndJD.Name = "cbEndJD";
            this.cbEndJD.Size = new System.Drawing.Size(96, 22);
            this.cbEndJD.TabIndex = 33;
            // 
            // cbStartNF
            // 
            this.cbStartNF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartNF.FormattingEnabled = true;
            this.cbStartNF.Location = new System.Drawing.Point(84, 87);
            this.cbStartNF.Name = "cbStartNF";
            this.cbStartNF.Size = new System.Drawing.Size(96, 22);
            this.cbStartNF.TabIndex = 32;
            this.cbStartNF.SelectedValueChanged += new System.EventHandler(this.cbRQ_SelectedValueChanged);
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRefresh2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh2.Appearance.Options.UseFont = true;
            this.btnRefresh2.Appearance.Options.UseForeColor = true;
            this.btnRefresh2.CustomText = "查询";
            this.btnRefresh2.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh2.Image")));
            this.btnRefresh2.Location = new System.Drawing.Point(239, 615);
            this.btnRefresh2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRefresh2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Selectable = false;
            this.btnRefresh2.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh2.TabIndex = 37;
            this.btnRefresh2.Text = "查询";
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbDept
            // 
            this.cbDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(6, 21);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(224, 22);
            this.cbDept.TabIndex = 38;
            // 
            // gbDept
            // 
            this.gbDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDept.BackColor = System.Drawing.Color.White;
            this.gbDept.Controls.Add(this.btnDX);
            this.gbDept.Controls.Add(this.cbDept);
            this.gbDept.Controls.Add(this.ctlDept);
            this.gbDept.ForeColor = System.Drawing.Color.Black;
            this.gbDept.Location = new System.Drawing.Point(9, 254);
            this.gbDept.Name = "gbDept";
            this.gbDept.Size = new System.Drawing.Size(310, 355);
            this.gbDept.TabIndex = 39;
            this.gbDept.TabStop = false;
            this.gbDept.Text = "科室选择";
            // 
            // btnDX
            // 
            this.btnDX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDX.Location = new System.Drawing.Point(236, 20);
            this.btnDX.Name = "btnDX";
            this.btnDX.Size = new System.Drawing.Size(67, 23);
            this.btnDX.TabIndex = 39;
            this.btnDX.Text = "多选";
            this.btnDX.UseVisualStyleBackColor = true;
            this.btnDX.Click += new System.EventHandler(this.btnDX_Click);
            // 
            // ctlDept
            // 
            this.ctlDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDept.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.ctlDept.Appearance.Empty.Options.UseBackColor = true;
            this.ctlDept.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.EvenRow.Options.UseBackColor = true;
            this.ctlDept.Appearance.EvenRow.Options.UseBorderColor = true;
            this.ctlDept.Appearance.EvenRow.Options.UseForeColor = true;
            this.ctlDept.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.ctlDept.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.FocusedCell.Options.UseBackColor = true;
            this.ctlDept.Appearance.FocusedCell.Options.UseForeColor = true;
            this.ctlDept.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.ctlDept.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.ctlDept.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.ctlDept.Appearance.FocusedRow.Options.UseBackColor = true;
            this.ctlDept.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.ctlDept.Appearance.FocusedRow.Options.UseForeColor = true;
            this.ctlDept.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.FooterPanel.Options.UseBackColor = true;
            this.ctlDept.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.ctlDept.Appearance.FooterPanel.Options.UseForeColor = true;
            this.ctlDept.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctlDept.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.GroupButton.Options.UseBackColor = true;
            this.ctlDept.Appearance.GroupButton.Options.UseBorderColor = true;
            this.ctlDept.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.ctlDept.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.ctlDept.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.GroupFooter.Options.UseBackColor = true;
            this.ctlDept.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.ctlDept.Appearance.GroupFooter.Options.UseForeColor = true;
            this.ctlDept.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.ctlDept.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ctlDept.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ctlDept.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ctlDept.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.ctlDept.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.ctlDept.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.ctlDept.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.ctlDept.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ctlDept.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.ctlDept.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.ctlDept.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.ctlDept.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.HorzLine.Options.UseBackColor = true;
            this.ctlDept.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.OddRow.BackColor2 = System.Drawing.Color.White;
            this.ctlDept.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.OddRow.Options.UseBackColor = true;
            this.ctlDept.Appearance.OddRow.Options.UseForeColor = true;
            this.ctlDept.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.ctlDept.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ctlDept.Appearance.Preview.Options.UseFont = true;
            this.ctlDept.Appearance.Preview.Options.UseForeColor = true;
            this.ctlDept.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ctlDept.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.ctlDept.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.ctlDept.Appearance.Row.Options.UseBackColor = true;
            this.ctlDept.Appearance.Row.Options.UseForeColor = true;
            this.ctlDept.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.ctlDept.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.ctlDept.Appearance.SelectedRow.Options.UseBackColor = true;
            this.ctlDept.Appearance.SelectedRow.Options.UseForeColor = true;
            this.ctlDept.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.TreeLine.Options.UseBackColor = true;
            this.ctlDept.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ctlDept.Appearance.VertLine.Options.UseBackColor = true;
            this.ctlDept.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.ctlDept.Enabled = false;
            this.ctlDept.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDept.Location = new System.Drawing.Point(6, 49);
            this.ctlDept.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ctlDept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.ctlDept.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ctlDept.Name = "ctlDept";
            this.ctlDept.BeginUnboundLoad();
            this.ctlDept.AppendNode(new object[] {
            null}, -1);
            this.ctlDept.EndUnboundLoad();
            this.ctlDept.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.ctlDept.OptionsBehavior.Editable = false;
            this.ctlDept.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ctlDept.OptionsView.ShowCheckBoxes = true;
            this.ctlDept.OptionsView.ShowColumns = false;
            this.ctlDept.OptionsView.ShowFocusedFrame = false;
            this.ctlDept.OptionsView.ShowHorzLines = false;
            this.ctlDept.OptionsView.ShowIndicator = false;
            this.ctlDept.OptionsView.ShowVertLines = false;
            this.ctlDept.Size = new System.Drawing.Size(298, 300);
            this.ctlDept.TabIndex = 34;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 48;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 107;
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRefresh1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh1.Appearance.Options.UseFont = true;
            this.btnRefresh1.Appearance.Options.UseForeColor = true;
            this.btnRefresh1.CustomText = "查询";
            this.btnRefresh1.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh1.Image")));
            this.btnRefresh1.Location = new System.Drawing.Point(239, 247);
            this.btnRefresh1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRefresh1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Selectable = false;
            this.btnRefresh1.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh1.TabIndex = 40;
            this.btnRefresh1.Text = "查询";
            this.btnRefresh1.Visible = false;
            this.btnRefresh1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FilterView
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh1);
            this.Controls.Add(this.btnRefresh2);
            this.Controls.Add(this.gbDept);
            this.Controls.Add(this.gbDATE);
            this.Name = "FilterView";
            this.Size = new System.Drawing.Size(327, 651);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbDATE.ResumeLayout(false);
            this.gbDATE.PerformLayout();
            this.gbDept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbMounth;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbDG;
        private System.Windows.Forms.RadioButton rbQJ;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.RadioButton rbJD;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.GroupBox gbDATE;
        private System.Windows.Forms.ComboBox cbStartNF;
        private System.Windows.Forms.ComboBox cbStartJD;
        private System.Windows.Forms.ComboBox cbEndNF;
        private System.Windows.Forms.ComboBox cbEndRQ;
        private System.Windows.Forms.ComboBox cbStartRQ;
        private System.Windows.Forms.ComboBox cbStartYF;
        private System.Windows.Forms.ComboBox cbEndYF;
        private System.Windows.Forms.ComboBox cbEndJD;
        private Controls.BtnRefresh btnRefresh2;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.GroupBox gbDept;
        private System.Windows.Forms.Button btnDX;
        private Controls.CJiaTreeList ctlDept;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private Controls.BtnRefresh btnRefresh1;
    }
}
