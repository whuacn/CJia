namespace CJia.Health.App.UI
{
    partial class LogoSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoSet));
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.txtContent = new CJia.Controls.CJiaTextBox();
            this.txtDu = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.btnClose = new CJia.Controls.BtnClose();
            this.btnSave = new CJia.Controls.BtnSave();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(26, 29);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel1.TabIndex = 0;
            this.cJiaLabel1.Text = "水印内容：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(107, 26);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtContent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtContent.Properties.Appearance.Options.UseBackColor = true;
            this.txtContent.Properties.Appearance.Options.UseFont = true;
            this.txtContent.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtContent.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtContent.Size = new System.Drawing.Size(258, 22);
            this.txtContent.TabIndex = 1;
            // 
            // txtDu
            // 
            this.txtDu.Location = new System.Drawing.Point(107, 74);
            this.txtDu.Name = "txtDu";
            this.txtDu.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDu.Properties.Appearance.Options.UseBackColor = true;
            this.txtDu.Properties.Appearance.Options.UseFont = true;
            this.txtDu.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtDu.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDu.Size = new System.Drawing.Size(258, 22);
            this.txtDu.TabIndex = 3;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(41, 77);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel2.TabIndex = 2;
            this.cJiaLabel2.Text = "倾斜度：";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.CustomText = "关闭";
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(96, 139);
            this.btnClose.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Selectable = false;
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.CustomText = "保存";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(215, 139);
            this.btnSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Selectable = false;
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LogoSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDu);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.cJiaLabel1);
            this.Name = "LogoSet";
            this.Size = new System.Drawing.Size(390, 205);
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaTextBox txtContent;
        private Controls.CJiaTextBox txtDu;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.BtnClose btnClose;
        private Controls.BtnSave btnSave;
    }
}
