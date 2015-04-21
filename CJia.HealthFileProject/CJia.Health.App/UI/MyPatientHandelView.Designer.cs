namespace CJia.Health.App.UI
{
    partial class MyPatientHandelView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPatientHandelView));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCommit = new DevExpress.XtraNavBar.NavBarItem();
            this.btnNoPass = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.cJiaTabControl1 = new CJia.Controls.CJiaTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cJiaPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.cJiaPanel2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1633, 700);
            this.splitContainerControl1.SplitterPosition = 231;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.navBarControl1);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(231, 700);
            this.cJiaPanel1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnCommit,
            this.btnNoPass,
            this.navBarItem1,
            this.navBarItem2});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 227;
            this.navBarControl1.Size = new System.Drawing.Size(227, 696);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "我的病案管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCommit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnNoPass)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnCommit
            // 
            this.btnCommit.Caption = "我的录入";
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCommit.SmallImage")));
            this.btnCommit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCommit_LinkClicked);
            // 
            // btnNoPass
            // 
            this.btnNoPass.Caption = "审核未通过";
            this.btnNoPass.Name = "btnNoPass";
            this.btnNoPass.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnNoPass.SmallImage")));
            this.btnNoPass.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnNoPass_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "病案录入查询";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem1.SmallImage")));
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "已删除的病案";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.SmallImage")));
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Controls.Add(this.cJiaTabControl1);
            this.cJiaPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel2.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(1390, 700);
            this.cJiaPanel2.TabIndex = 0;
            // 
            // cJiaTabControl1
            // 
            this.cJiaTabControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.cJiaTabControl1.Appearance.Options.UseBackColor = true;
            this.cJiaTabControl1.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.cJiaTabControl1.AppearancePage.Header.BorderColor = System.Drawing.Color.Transparent;
            this.cJiaTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaTabControl1.AppearancePage.Header.Options.UseBackColor = true;
            this.cJiaTabControl1.AppearancePage.Header.Options.UseBorderColor = true;
            this.cJiaTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.cJiaTabControl1.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            this.cJiaTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DimGray;
            this.cJiaTabControl1.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.cJiaTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.cJiaTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.White;
            this.cJiaTabControl1.AppearancePage.PageClient.Options.UseBackColor = true;
            this.cJiaTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cJiaTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.cJiaTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaTabControl1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.cJiaTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.cJiaTabControl1.Location = new System.Drawing.Point(2, 2);
            this.cJiaTabControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaTabControl1.Name = "cJiaTabControl1";
            this.cJiaTabControl1.Size = new System.Drawing.Size(1386, 696);
            this.cJiaTabControl1.TabIndex = 0;
            // 
            // MyPatientHandelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MyPatientHandelView";
            this.Size = new System.Drawing.Size(1633, 700);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTabControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Controls.CJiaPanel cJiaPanel1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnCommit;
        private DevExpress.XtraNavBar.NavBarItem btnNoPass;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaTabControl cJiaTabControl1;
    }
}
