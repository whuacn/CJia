namespace CJia.Parking.App
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
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQueryPaylog = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUSer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArea = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMemType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTemFeeSet = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCheckAdvice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangePwd,
            this.btnCancle,
            this.btnQuit});
            this.文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(124, 22);
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(124, 22);
            this.btnCancle.Text = "注销";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(124, 22);
            this.btnQuit.Text = "退出";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirst,
            this.btnMemManage,
            this.btnPayment,
            this.btnQueryPaylog});
            this.操作ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // btnFirst
            // 
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(152, 22);
            this.btnFirst.Text = "起始页";
            // 
            // btnMemManage
            // 
            this.btnMemManage.Name = "btnMemManage";
            this.btnMemManage.Size = new System.Drawing.Size(152, 22);
            this.btnMemManage.Text = "会员管理";
            this.btnMemManage.Click += new System.EventHandler(this.btnMemManage_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(152, 22);
            this.btnPayment.Text = "会员缴费";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnQueryPaylog
            // 
            this.btnQueryPaylog.Name = "btnQueryPaylog";
            this.btnQueryPaylog.Size = new System.Drawing.Size(152, 22);
            this.btnQueryPaylog.Text = "会员缴费记录";
            this.btnQueryPaylog.Click += new System.EventHandler(this.btnQueryPaylog_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUSer,
            this.btnArea,
            this.btnMemType,
            this.btnTemFeeSet});
            this.设置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // btnUSer
            // 
            this.btnUSer.Name = "btnUSer";
            this.btnUSer.Size = new System.Drawing.Size(172, 22);
            this.btnUSer.Text = "用户维护";
            this.btnUSer.Click += new System.EventHandler(this.btnUSer_Click);
            // 
            // btnArea
            // 
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(172, 22);
            this.btnArea.Text = "区域维护";
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnMemType
            // 
            this.btnMemType.Name = "btnMemType";
            this.btnMemType.Size = new System.Drawing.Size(172, 22);
            this.btnMemType.Text = "会员类型维护";
            this.btnMemType.Click += new System.EventHandler(this.btnMemType_Click);
            // 
            // btnTemFeeSet
            // 
            this.btnTemFeeSet.Name = "btnTemFeeSet";
            this.btnTemFeeSet.Size = new System.Drawing.Size(172, 22);
            this.btnTemFeeSet.Text = "临时车辆收费设置";
            this.btnTemFeeSet.Click += new System.EventHandler(this.btnTemFeeSet_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Location = new System.Drawing.Point(0, 70);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1184, 506);
            this.tabMain.TabIndex = 2;
            this.tabMain.DoubleClick += new System.EventHandler(this.tabMain_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCheckAdvice,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1020, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCheckAdvice
            // 
            this.btnCheckAdvice.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.btnCheckAdvice.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckAdvice.Image")));
            this.btnCheckAdvice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckAdvice.Name = "btnCheckAdvice";
            this.btnCheckAdvice.Size = new System.Drawing.Size(100, 36);
            this.btnCheckAdvice.Text = "会员管理";
            this.btnCheckAdvice.Click += new System.EventHandler(this.btnMemManage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 36);
            this.toolStripButton1.Text = "会员缴费";
            this.toolStripButton1.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(128, 36);
            this.toolStripButton2.Text = "会员缴费记录";
            this.toolStripButton2.Click += new System.EventHandler(this.btnQueryPaylog_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblLogTime,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblUserName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "登录时间：";
            // 
            // lblLogTime
            // 
            this.lblLogTime.Name = "lblLogTime";
            this.lblLogTime.Size = new System.Drawing.Size(130, 17);
            this.lblLogTime.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel2.Text = "        ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "用户：";
            // 
            // lblUserName
            // 
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 17);
            this.lblUserName.Text = "toolStripStatusLabel4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 601);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                    ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnChangePwd;
        private System.Windows.Forms.ToolStripMenuItem btnCancle;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnFirst;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnUSer;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCheckAdvice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnArea;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblLogTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUserName;
        private System.Windows.Forms.ToolStripMenuItem btnMemType;
        private System.Windows.Forms.ToolStripMenuItem btnMemManage;
        private System.Windows.Forms.ToolStripMenuItem btnPayment;
        private System.Windows.Forms.ToolStripMenuItem btnQueryPaylog;
        private System.Windows.Forms.ToolStripMenuItem btnTemFeeSet;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}