namespace CJia.PIVAS.App.UI
{
    partial class OneScanningMonitoringView
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.pnMes = new CJia.Controls.CJiaPanel();
            this.lbDate = new DevExpress.XtraEditors.LabelControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.lbName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AllowTouchScroll = true;
            this.groupControl1.AlwaysScrollActiveControlIntoView = false;
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.cJiaPanel1);
            this.groupControl1.Controls.Add(this.pnMes);
            this.groupControl1.Controls.Add(this.lbDate);
            this.groupControl1.Controls.Add(this.btnOut);
            this.groupControl1.Controls.Add(this.lbName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(265, 475);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "一号操作台";
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.btnLogin);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(2, 22);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(261, 451);
            this.cJiaPanel1.TabIndex = 24;
            this.cJiaPanel1.SizeChanged += new System.EventHandler(this.cJiaPanel1_SizeChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(55, 162);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(150, 50);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnMes
            // 
            this.pnMes.AllowTouchScroll = true;
            this.pnMes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMes.Appearance.BackColor = System.Drawing.Color.White;
            this.pnMes.Appearance.BackColor2 = System.Drawing.Color.White;
            this.pnMes.Appearance.Options.UseBackColor = true;
            this.pnMes.FireScrollEventOnMouseWheel = true;
            this.pnMes.Location = new System.Drawing.Point(6, 59);
            this.pnMes.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnMes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnMes.Name = "pnMes";
            this.pnMes.Size = new System.Drawing.Size(252, 376);
            this.pnMes.TabIndex = 6;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.Location = new System.Drawing.Point(134, 34);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(124, 14);
            this.lbDate.TabIndex = 21;
            this.lbDate.Text = "2012/08/23 44:33:33 ";
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.Location = new System.Drawing.Point(171, 442);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(87, 27);
            this.btnOut.TabIndex = 20;
            this.btnOut.Text = "注销";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // lbName
            // 
            this.lbName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbName.Location = new System.Drawing.Point(14, 30);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(34, 19);
            this.lbName.TabIndex = 17;
            this.lbName.Text = "胡杨";
            // 
            // OneScanningMonitoringView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "OneScanningMonitoringView";
            this.Size = new System.Drawing.Size(265, 475);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Controls.CJiaPanel pnMes;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl lbDate;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.LabelControl lbName;
        private Controls.CJiaPanel cJiaPanel1;
    }
}
