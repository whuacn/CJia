namespace CJia.Navigate.App.UI
{
    partial class QueryView
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnFastQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnStallQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnDateQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnLicenceQuery = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.HomePage = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHome = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.HomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnFastQuery);
            this.panelControl1.Controls.Add(this.btnStallQuery);
            this.panelControl1.Controls.Add(this.btnDateQuery);
            this.panelControl1.Controls.Add(this.btnLicenceQuery);
            this.panelControl1.Location = new System.Drawing.Point(3, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(217, 699);
            this.panelControl1.TabIndex = 0;
            // 
            // btnFastQuery
            // 
            this.btnFastQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFastQuery.Appearance.Options.UseFont = true;
            this.btnFastQuery.Location = new System.Drawing.Point(9, 151);
            this.btnFastQuery.Name = "btnFastQuery";
            this.btnFastQuery.Size = new System.Drawing.Size(198, 54);
            this.btnFastQuery.TabIndex = 2;
            this.btnFastQuery.Text = "快速查询";
            this.btnFastQuery.Click += new System.EventHandler(this.btnFastQuery_Click);
            // 
            // btnStallQuery
            // 
            this.btnStallQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStallQuery.Appearance.Options.UseFont = true;
            this.btnStallQuery.Location = new System.Drawing.Point(10, 383);
            this.btnStallQuery.Name = "btnStallQuery";
            this.btnStallQuery.Size = new System.Drawing.Size(198, 54);
            this.btnStallQuery.TabIndex = 5;
            this.btnStallQuery.Text = "车位查询";
            this.btnStallQuery.Click += new System.EventHandler(this.btnStallQuery_Click);
            // 
            // btnDateQuery
            // 
            this.btnDateQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateQuery.Appearance.Options.UseFont = true;
            this.btnDateQuery.Location = new System.Drawing.Point(10, 306);
            this.btnDateQuery.Name = "btnDateQuery";
            this.btnDateQuery.Size = new System.Drawing.Size(198, 54);
            this.btnDateQuery.TabIndex = 4;
            this.btnDateQuery.Text = "时间查询";
            this.btnDateQuery.Click += new System.EventHandler(this.btnDateQueyr_Click);
            // 
            // btnLicenceQuery
            // 
            this.btnLicenceQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenceQuery.Appearance.Options.UseFont = true;
            this.btnLicenceQuery.Location = new System.Drawing.Point(10, 230);
            this.btnLicenceQuery.Name = "btnLicenceQuery";
            this.btnLicenceQuery.Size = new System.Drawing.Size(198, 54);
            this.btnLicenceQuery.TabIndex = 3;
            this.btnLicenceQuery.Text = "全车牌查询";
            this.btnLicenceQuery.Click += new System.EventHandler(this.btnLicenceQUuery_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Appearance.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.Appearance.Options.UseBorderColor = true;
            this.xtraTabControl1.AppearancePage.Header.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.AppearancePage.Header.Options.UseBorderColor = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseBorderColor = true;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseBorderColor = true;
            this.xtraTabControl1.AppearancePage.PageClient.BorderColor = System.Drawing.Color.White;
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Location = new System.Drawing.Point(217, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.HomePage;
            this.xtraTabControl1.Size = new System.Drawing.Size(794, 709);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.HomePage});
            // 
            // HomePage
            // 
            this.HomePage.Controls.Add(this.panelControl2);
            this.HomePage.Name = "HomePage";
            this.HomePage.Size = new System.Drawing.Size(788, 680);
            this.HomePage.Text = "xtraTabPage1";
            this.HomePage.SizeChanged += new System.EventHandler(this.HomePage_SizeChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(788, 680);
            this.panelControl2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.lblHome);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(191, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 188);
            this.panel1.TabIndex = 4;
            // 
            // lblHome
            // 
            this.lblHome.Appearance.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHome.Location = new System.Drawing.Point(11, 9);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(384, 41);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "欢迎来到车位引导管理系统";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(211, 97);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 27);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "找车不愁";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(115, 97);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 27);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "停车无忧";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(234, 163);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(168, 20);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "上海创佳信息技术有限公司";
            // 
            // QueryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "QueryView";
            this.Size = new System.Drawing.Size(1010, 699);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.HomePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.SimpleButton btnStallQuery;
        private DevExpress.XtraEditors.SimpleButton btnDateQuery;
        private DevExpress.XtraEditors.SimpleButton btnLicenceQuery;
        private DevExpress.XtraEditors.SimpleButton btnFastQuery;
        private DevExpress.XtraTab.XtraTabPage HomePage;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblHome;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;

    }
}
