namespace CJia.CheckRegOrder.App
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改用户名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPatientManage = new System.Windows.Forms.ToolStripMenuItem();
            this.排队管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.队列设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.诊室管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加诊室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.诊室管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.用户维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoginDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.登记ToolStripMenuItem,
            this.排队管理ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.诊室管理ToolStripMenuItem,
            this.用户维护ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1223, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改用户名ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.系统ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 修改用户名ToolStripMenuItem
            // 
            this.修改用户名ToolStripMenuItem.Name = "修改用户名ToolStripMenuItem";
            this.修改用户名ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.修改用户名ToolStripMenuItem.Text = "修改用户名";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.退出ToolStripMenuItem.Text = "修改密码";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            // 
            // 登记ToolStripMenuItem
            // 
            this.登记ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegister,
            this.btnPatientManage});
            this.登记ToolStripMenuItem.Name = "登记ToolStripMenuItem";
            this.登记ToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.登记ToolStripMenuItem.Text = "登记管理";
            // 
            // btnRegister
            // 
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(132, 22);
            this.btnRegister.Text = "登记病人";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnPatientManage
            // 
            this.btnPatientManage.Name = "btnPatientManage";
            this.btnPatientManage.Size = new System.Drawing.Size(132, 22);
            this.btnPatientManage.Text = "病人管理";
            this.btnPatientManage.Click += new System.EventHandler(this.btnPatientManage_Click);
            // 
            // 排队管理ToolStripMenuItem
            // 
            this.排队管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQueue,
            this.队列设置ToolStripMenuItem});
            this.排队管理ToolStripMenuItem.Name = "排队管理ToolStripMenuItem";
            this.排队管理ToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.排队管理ToolStripMenuItem.Text = "排队管理";
            // 
            // btnQueue
            // 
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(132, 22);
            this.btnQueue.Text = "队列管理";
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // 队列设置ToolStripMenuItem
            // 
            this.队列设置ToolStripMenuItem.Name = "队列设置ToolStripMenuItem";
            this.队列设置ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.队列设置ToolStripMenuItem.Text = "队列设置";
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportSelect});
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // btnReportSelect
            // 
            this.btnReportSelect.Name = "btnReportSelect";
            this.btnReportSelect.Size = new System.Drawing.Size(132, 22);
            this.btnReportSelect.Text = "查询报告";
            this.btnReportSelect.Click += new System.EventHandler(this.btnReportSelect_Click);
            // 
            // 诊室管理ToolStripMenuItem
            // 
            this.诊室管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加诊室ToolStripMenuItem,
            this.诊室管理ToolStripMenuItem1});
            this.诊室管理ToolStripMenuItem.Name = "诊室管理ToolStripMenuItem";
            this.诊室管理ToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.诊室管理ToolStripMenuItem.Text = "诊室维护";
            // 
            // 增加诊室ToolStripMenuItem
            // 
            this.增加诊室ToolStripMenuItem.Name = "增加诊室ToolStripMenuItem";
            this.增加诊室ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.增加诊室ToolStripMenuItem.Text = "增加诊室";
            // 
            // 诊室管理ToolStripMenuItem1
            // 
            this.诊室管理ToolStripMenuItem1.Name = "诊室管理ToolStripMenuItem1";
            this.诊室管理ToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.诊室管理ToolStripMenuItem1.Text = "诊室管理";
            // 
            // 用户维护ToolStripMenuItem
            // 
            this.用户维护ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddUser,
            this.btnUserManage});
            this.用户维护ToolStripMenuItem.Name = "用户维护ToolStripMenuItem";
            this.用户维护ToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.用户维护ToolStripMenuItem.Text = "用户维护";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(132, 22);
            this.btnAddUser.Text = "增加用户";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(132, 22);
            this.btnUserManage.Text = "用户管理";
            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReg,
            this.toolStripSeparator1,
            this.btnQue,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1223, 59);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReg
            // 
            this.btnReg.ForeColor = System.Drawing.Color.White;
            this.btnReg.Image = ((System.Drawing.Image)(resources.GetObject("btnReg.Image")));
            this.btnReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(45, 56);
            this.btnReg.Text = "登记";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // btnQue
            // 
            this.btnQue.ForeColor = System.Drawing.Color.White;
            this.btnQue.Image = ((System.Drawing.Image)(resources.GetObject("btnQue.Image")));
            this.btnQue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQue.Name = "btnQue";
            this.btnQue.Size = new System.Drawing.Size(45, 56);
            this.btnQue.Text = "队列";
            this.btnQue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQue.Click += new System.EventHandler(this.btnQue_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(45, 56);
            this.btnPrint.Text = "打印";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 59);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUserName,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.lblLoginDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1223, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "用户：";
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(31, 17);
            this.lblUserName.Text = "邓华";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel3.Text = "           ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel4.Image")));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel4.Text = "登录时间:";
            // 
            // lblLoginDateTime
            // 
            this.lblLoginDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoginDateTime.Name = "lblLoginDateTime";
            this.lblLoginDateTime.Size = new System.Drawing.Size(66, 17);
            this.lblLoginDateTime.Text = "2013-1-05";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabMain.Appearance.Options.UseBackColor = true;
            this.tabMain.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(218)))), ((int)(((byte)(246)))));
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 14F);
            this.tabMain.AppearancePage.Header.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tabMain.AppearancePage.Header.Options.UseBackColor = true;
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.Header.Options.UseForeColor = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.Location = new System.Drawing.Point(0, 84);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1223, 566);
            this.tabMain.TabIndex = 9;
            this.tabMain.DoubleClick += new System.EventHandler(this.tabMain_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1223, 668);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "护士站管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改用户名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 登记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRegister;
        private System.Windows.Forms.ToolStripMenuItem btnPatientManage;
        private System.Windows.Forms.ToolStripMenuItem 排队管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnQueue;
        private System.Windows.Forms.ToolStripMenuItem 队列设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnReportSelect;
        private System.Windows.Forms.ToolStripMenuItem 用户维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnUserManage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnReg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblLoginDateTime;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private System.Windows.Forms.ToolStripButton btnQue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 诊室管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加诊室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 诊室管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnAddUser;
    }
}