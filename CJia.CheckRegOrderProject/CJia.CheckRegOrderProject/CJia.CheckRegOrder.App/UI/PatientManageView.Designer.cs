namespace CJia.CheckRegOrder.App.UI
{
    partial class PatientManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientManageView));
            this.panelControl18 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl8 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl19 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSelectPatient = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnHistory = new DevExpress.XtraNavBar.NavBarItem();
            this.s = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnRegNoCheck = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl20 = new DevExpress.XtraEditors.PanelControl();
            this.tabSecond = new System.Windows.Forms.TabControl();
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
            this.panelControl18.TabIndex = 1;
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
            this.navBarGroup2,
            this.s});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnSelectPatient,
            this.btnRegNoCheck,
            this.btnHistory});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 227;
            this.navBarControl1.Size = new System.Drawing.Size(227, 555);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "病人查询";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSelectPatient)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Caption = "查询病人";
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSelectPatient.SmallImage")));
            this.btnSelectPatient.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnSelectPatient_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "病史管理";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnHistory)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnHistory
            // 
            this.btnHistory.Caption = "病史管理";
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnHistory.SmallImage")));
            this.btnHistory.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnHistory_LinkClicked);
            // 
            // s
            // 
            this.s.Caption = "未就诊病人统计";
            this.s.Expanded = true;
            this.s.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRegNoCheck)});
            this.s.Name = "s";
            // 
            // btnRegNoCheck
            // 
            this.btnRegNoCheck.Caption = "登记未就诊病人";
            this.btnRegNoCheck.Name = "btnRegNoCheck";
            this.btnRegNoCheck.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRegNoCheck.SmallImage")));
            this.btnRegNoCheck.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnRegNoCheck_LinkClicked);
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
            // PatientManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl18);
            this.Name = "PatientManageView";
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
        private DevExpress.XtraNavBar.NavBarItem btnSelectPatient;
        private DevExpress.XtraNavBar.NavBarGroup s;
        private DevExpress.XtraNavBar.NavBarItem btnRegNoCheck;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnHistory;
        private DevExpress.XtraEditors.PanelControl panelControl20;
        private System.Windows.Forms.TabControl tabSecond;
    }
}
