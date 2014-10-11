namespace CJia.HIS.App.UI
{
    partial class MainContainerView
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
            if(disposing && (components != null))
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
            this.menMain = new System.Windows.Forms.MenuStrip();
            this.menSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menSelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menHelpInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.tolMain = new System.Windows.Forms.ToolStrip();
            this.xtcMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.menMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).BeginInit();
            this.xtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menMain
            // 
            this.menMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menSystem,
            this.menHelp});
            this.menMain.Location = new System.Drawing.Point(0, 0);
            this.menMain.Name = "menMain";
            this.menMain.Size = new System.Drawing.Size(1000, 24);
            this.menMain.TabIndex = 0;
            this.menMain.Text = "menuStrip1";
            // 
            // menSystem
            // 
            this.menSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menSelete,
            this.menLogout,
            this.menExit});
            this.menSystem.Name = "menSystem";
            this.menSystem.Size = new System.Drawing.Size(58, 20);
            this.menSystem.Text = "系统(&S)";
            // 
            // menSelete
            // 
            this.menSelete.Name = "menSelete";
            this.menSelete.Size = new System.Drawing.Size(138, 22);
            this.menSelete.Text = "切换系统(&X)";
            this.menSelete.Click += new System.EventHandler(this.menSelete_Click);
            // 
            // menLogout
            // 
            this.menLogout.Name = "menLogout";
            this.menLogout.Size = new System.Drawing.Size(138, 22);
            this.menLogout.Text = "注销(&Z)";
            this.menLogout.Click += new System.EventHandler(this.menLogout_Click);
            // 
            // menExit
            // 
            this.menExit.Name = "menExit";
            this.menExit.Size = new System.Drawing.Size(138, 22);
            this.menExit.Text = "退出(&E)";
            this.menExit.Click += new System.EventHandler(this.menExit_Click);
            // 
            // menHelp
            // 
            this.menHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menHelpInfo,
            this.menAbout});
            this.menHelp.Name = "menHelp";
            this.menHelp.Size = new System.Drawing.Size(60, 20);
            this.menHelp.Text = "帮助(&H)";
            // 
            // menHelpInfo
            // 
            this.menHelpInfo.Name = "menHelpInfo";
            this.menHelpInfo.Size = new System.Drawing.Size(115, 22);
            this.menHelpInfo.Text = "帮助(&H)";
            this.menHelpInfo.Click += new System.EventHandler(this.menHelpInfo_Click);
            // 
            // menAbout
            // 
            this.menAbout.Name = "menAbout";
            this.menAbout.Size = new System.Drawing.Size(115, 22);
            this.menAbout.Text = "关于(&A)";
            this.menAbout.Click += new System.EventHandler(this.menAbout_Click);
            // 
            // staMain
            // 
            this.staMain.Location = new System.Drawing.Point(0, 578);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(1000, 22);
            this.staMain.TabIndex = 1;
            this.staMain.Text = "statusStrip1";
            // 
            // tolMain
            // 
            this.tolMain.Location = new System.Drawing.Point(0, 24);
            this.tolMain.Name = "tolMain";
            this.tolMain.Size = new System.Drawing.Size(1000, 25);
            this.tolMain.TabIndex = 2;
            this.tolMain.Text = "toolStrip1";
            // 
            // xtcMain
            // 
            this.xtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcMain.Location = new System.Drawing.Point(0, 49);
            this.xtcMain.Name = "xtcMain";
            this.xtcMain.SelectedTabPage = this.xtraTabPage1;
            this.xtcMain.Size = new System.Drawing.Size(1000, 529);
            this.xtcMain.TabIndex = 3;
            this.xtcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(994, 500);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // MainContainerView
            // 
            this.Controls.Add(this.xtcMain);
            this.Controls.Add(this.tolMain);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.menMain);
            this.Name = "MainContainerView";
            this.Size = new System.Drawing.Size(1000, 600);
            this.menMain.ResumeLayout(false);
            this.menMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).EndInit();
            this.xtcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menMain;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.ToolStrip tolMain;
        private DevExpress.XtraTab.XtraTabControl xtcMain;
        private System.Windows.Forms.ToolStripMenuItem menSystem;
        private System.Windows.Forms.ToolStripMenuItem menSelete;
        private System.Windows.Forms.ToolStripMenuItem menLogout;
        private System.Windows.Forms.ToolStripMenuItem menExit;
        private System.Windows.Forms.ToolStripMenuItem menHelp;
        private System.Windows.Forms.ToolStripMenuItem menAbout;
        private System.Windows.Forms.ToolStripMenuItem menHelpInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    }
}