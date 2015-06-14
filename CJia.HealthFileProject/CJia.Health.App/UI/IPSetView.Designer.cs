namespace CJia.Health.App.UI
{
    partial class IPSetView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPSetView));
            this.pnlIp = new CJia.Controls.CJiaPanel();
            this.btnRefresh = new CJia.Controls.BtnRefresh();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckIP = new CJia.Controls.CJiaCheckedListBox();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.txtIP = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.btnAdd = new CJia.Controls.BtnAdd();
            this.btnDelete = new CJia.Controls.BtnDelete();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIp)).BeginInit();
            this.pnlIp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIp
            // 
            this.pnlIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlIp.Controls.Add(this.chkAll);
            this.pnlIp.Controls.Add(this.btnRefresh);
            this.pnlIp.Controls.Add(this.groupBox1);
            this.pnlIp.Controls.Add(this.cJiaPanel1);
            this.pnlIp.Controls.Add(this.btnDelete);
            this.pnlIp.Controls.Add(this.cJiaLabel1);
            this.pnlIp.Location = new System.Drawing.Point(250, 6);
            this.pnlIp.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlIp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlIp.Name = "pnlIp";
            this.pnlIp.Size = new System.Drawing.Size(892, 580);
            this.pnlIp.TabIndex = 12;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.CustomText = "刷新(F5)";
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(804, 537);
            this.btnRefresh.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selectable = false;
            this.btnRefresh.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh.TabIndex = 103;
            this.btnRefresh.Text = "刷新(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckIP);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(5, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 350);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP地址登陆限制";
            // 
            // ckIP
            // 
            this.ckIP.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ckIP.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.ckIP.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.ckIP.Appearance.Options.UseBackColor = true;
            this.ckIP.Appearance.Options.UseBorderColor = true;
            this.ckIP.Appearance.Options.UseFont = true;
            this.ckIP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ckIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckIP.HorizontalScrollbar = true;
            this.ckIP.HotTrackItems = true;
            this.ckIP.ItemHeight = 28;
            this.ckIP.Location = new System.Drawing.Point(3, 19);
            this.ckIP.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ckIP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ckIP.MultiColumn = true;
            this.ckIP.Name = "ckIP";
            this.ckIP.Size = new System.Drawing.Size(876, 328);
            this.ckIP.TabIndex = 13;
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.cJiaLabel6);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel5);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel1.Controls.Add(this.txtIP);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel1.Controls.Add(this.btnAdd);
            this.cJiaPanel1.Location = new System.Drawing.Point(5, 49);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(882, 120);
            this.cJiaPanel1.TabIndex = 101;
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel6.Location = new System.Drawing.Point(89, 91);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(168, 19);
            this.cJiaLabel6.TabIndex = 11;
            this.cJiaLabel6.Text = "192.168.0.1-192.168.0.254";
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel5.Location = new System.Drawing.Point(89, 66);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(71, 19);
            this.cJiaLabel5.TabIndex = 10;
            this.cJiaLabel5.Text = "192.168.0.*";
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel4.Location = new System.Drawing.Point(89, 41);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(73, 19);
            this.cJiaLabel4.TabIndex = 9;
            this.cJiaLabel4.Text = "192.168.0.1";
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel2.Location = new System.Drawing.Point(6, 41);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(77, 19);
            this.cJiaLabel2.TabIndex = 8;
            this.cJiaLabel2.Text = "IP地址格式：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(63, 9);
            this.txtIP.Name = "txtIP";
            this.txtIP.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtIP.Properties.Appearance.Options.UseFont = true;
            this.txtIP.Size = new System.Drawing.Size(266, 26);
            this.txtIP.TabIndex = 4;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cJiaLabel3.Location = new System.Drawing.Point(6, 12);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(51, 19);
            this.cJiaLabel3.TabIndex = 2;
            this.cJiaLabel3.Text = "IP地址：";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.CustomText = "添加IP限制";
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(356, 7);
            this.btnAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Selectable = false;
            this.btnAdd.Size = new System.Drawing.Size(95, 28);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加IP限制";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "删除IP限制";
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(692, 537);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(95, 28);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除IP限制";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cJiaLabel1.Location = new System.Drawing.Point(398, 7);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(118, 31);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "IP地址限制";
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.Location = new System.Drawing.Point(9, 535);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.chkAll.Properties.Appearance.Options.UseFont = true;
            this.chkAll.Properties.Caption = "全选";
            this.chkAll.Size = new System.Drawing.Size(64, 24);
            this.chkAll.TabIndex = 104;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // IPSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlIp);
            this.Name = "IPSetView";
            this.Size = new System.Drawing.Size(1400, 600);
            this.SizeChanged += new System.EventHandler(this.IPSetView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIp)).EndInit();
            this.pnlIp.ResumeLayout(false);
            this.pnlIp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel pnlIp;
        private Controls.BtnAdd btnAdd;
        private Controls.BtnDelete btnDelete;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaPanel cJiaPanel1;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.CJiaCheckedListBox ckIP;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel6;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.BtnRefresh btnRefresh;
        private DevExpress.XtraEditors.CheckEdit chkAll;

    }
}
