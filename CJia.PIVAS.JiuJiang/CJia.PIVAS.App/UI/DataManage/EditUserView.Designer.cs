namespace CJia.PIVAS.App.UI.DataManage
{
    partial class EditUserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserView));
            this.BtnUsre = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.TxtSurePwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOldPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUsre
            // 
            this.BtnUsre.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUsre.Appearance.Options.UseFont = true;
            this.BtnUsre.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsre.Image")));
            this.BtnUsre.Location = new System.Drawing.Point(66, 163);
            this.BtnUsre.Name = "BtnUsre";
            this.BtnUsre.Size = new System.Drawing.Size(75, 25);
            this.BtnUsre.TabIndex = 5;
            this.BtnUsre.Text = "确  定";
            this.BtnUsre.Click += new System.EventHandler(this.BtnUsre_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnCancle.Appearance.Options.UseFont = true;
            this.BtnCancle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancle.Image")));
            this.BtnCancle.Location = new System.Drawing.Point(185, 163);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 6;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // TxtSurePwd
            // 
            this.TxtSurePwd.Location = new System.Drawing.Point(124, 125);
            this.TxtSurePwd.Name = "TxtSurePwd";
            this.TxtSurePwd.Properties.PasswordChar = '*';
            this.TxtSurePwd.Size = new System.Drawing.Size(155, 20);
            this.TxtSurePwd.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(46, 128);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "确认新密码：";
            // 
            // TxtNewPwd
            // 
            this.TxtNewPwd.Location = new System.Drawing.Point(124, 90);
            this.TxtNewPwd.Name = "TxtNewPwd";
            this.TxtNewPwd.Properties.PasswordChar = '*';
            this.TxtNewPwd.Size = new System.Drawing.Size(155, 20);
            this.TxtNewPwd.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(70, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "新密码：";
            // 
            // TxtOldPwd
            // 
            this.TxtOldPwd.EditValue = "";
            this.TxtOldPwd.Location = new System.Drawing.Point(124, 55);
            this.TxtOldPwd.Name = "TxtOldPwd";
            this.TxtOldPwd.Properties.PasswordChar = '*';
            this.TxtOldPwd.Size = new System.Drawing.Size(155, 20);
            this.TxtOldPwd.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(70, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "旧密码：";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Enabled = false;
            this.TxtUserName.Location = new System.Drawing.Point(124, 20);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(155, 20);
            this.TxtUserName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(70, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "用户名：";
            // 
            // EditUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnUsre);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.TxtSurePwd);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.TxtNewPwd);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtOldPwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.labelControl1);
            this.Name = "EditUserView";
            this.Size = new System.Drawing.Size(326, 206);
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtOldPwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtNewPwd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtSurePwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton BtnUsre;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
    }
}
