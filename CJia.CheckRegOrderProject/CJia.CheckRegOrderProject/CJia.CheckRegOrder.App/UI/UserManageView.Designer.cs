namespace CJia.CheckRegOrder.App.UI
{
    partial class UserManageView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManageView));
            this.panelControl18 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl8 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl19 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSelectUser = new DevExpress.XtraNavBar.NavBarItem();
            this.btnAddUser = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnWork = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl20 = new DevExpress.XtraEditors.PanelControl();
            this.tabSecond = new System.Windows.Forms.TabControl();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).BeginInit();
            this.panelControl18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl8)).BeginInit();
            this.splitContainerControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).BeginInit();
            this.panelControl19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).BeginInit();
            this.panelControl20.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl18
            // 
            this.panelControl18.Controls.Add(this.splitContainerControl8);
            this.panelControl18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl18.Location = new System.Drawing.Point(0, 0);
            this.panelControl18.Name = "panelControl18";
            this.panelControl18.Size = new System.Drawing.Size(1112, 566);
            this.panelControl18.TabIndex = 2;
            // 
            // splitContainerControl8
            // 
            this.splitContainerControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl8.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl8.Name = "splitContainerControl8";
            this.splitContainerControl8.Panel1.Controls.Add(this.panelControl19);
            this.splitContainerControl8.Panel1.Text = "Panel1";
            this.splitContainerControl8.Panel2.Controls.Add(this.panelControl20);
            this.splitContainerControl8.Panel2.Text = "Panel2";
            this.splitContainerControl8.Size = new System.Drawing.Size(1108, 562);
            this.splitContainerControl8.SplitterPosition = 235;
            this.splitContainerControl8.TabIndex = 3;
            this.splitContainerControl8.Text = "splitContainerControl8";
            // 
            // panelControl19
            // 
            this.panelControl19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl19.Controls.Add(this.navBarControl1);
            this.panelControl19.Location = new System.Drawing.Point(2, 1);
            this.panelControl19.Name = "panelControl19";
            this.panelControl19.Size = new System.Drawing.Size(231, 559);
            this.panelControl19.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnSelectUser,
            this.btnWork,
            this.btnAddUser});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 227;
            this.navBarControl1.Size = new System.Drawing.Size(227, 555);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "用户信息管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSelectUser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnAddUser)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Caption = "查询用户";
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSelectUser.SmallImage")));
            this.btnSelectUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnSelectUser_LinkClicked);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Caption = "添加用户";
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddUser.SmallImage")));
            this.btnAddUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnAddUser_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "用户工作量统计";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnWork)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnWork
            // 
            this.btnWork.Caption = "统计工作量";
            this.btnWork.Name = "btnWork";
            this.btnWork.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnWork.SmallImage")));
            // 
            // panelControl20
            // 
            this.panelControl20.Controls.Add(this.tabSecond);
            this.panelControl20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl20.Location = new System.Drawing.Point(0, 0);
            this.panelControl20.Name = "panelControl20";
            this.panelControl20.Size = new System.Drawing.Size(868, 562);
            this.panelControl20.TabIndex = 0;
            // 
            // tabSecond
            // 
            this.tabSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSecond.Location = new System.Drawing.Point(2, 2);
            this.tabSecond.Name = "tabSecond";
            this.tabSecond.SelectedIndex = 0;
            this.tabSecond.Size = new System.Drawing.Size(864, 558);
            this.tabSecond.TabIndex = 0;
            this.tabSecond.DoubleClick += new System.EventHandler(this.tabSecond_DoubleClick);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "添加用户";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem1.SmallImage")));
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "添加用户";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.SmallImage")));
            // 
            // UserManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl18);
            this.Name = "UserManageView";
            this.Size = new System.Drawing.Size(1112, 566);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).EndInit();
            this.panelControl18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl8)).EndInit();
            this.splitContainerControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).EndInit();
            this.panelControl19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).EndInit();
            this.panelControl20.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl18;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl8;
        private DevExpress.XtraEditors.PanelControl panelControl19;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnSelectUser;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnWork;
        private DevExpress.XtraEditors.PanelControl panelControl20;
        private System.Windows.Forms.TabControl tabSecond;
        private DevExpress.XtraNavBar.NavBarItem btnAddUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
    }
}
