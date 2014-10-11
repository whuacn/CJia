namespace CJia.PEIS.App.UI
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.pnlLogin = new CJia.Controls.CJiaPanel();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.closeBtn = new CJia.Controls.CJiaPicture();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.cJiaPicture1 = new CJia.Controls.CJiaPicture();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.ckUser = new CJia.Controls.CJiaCheck();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).BeginInit();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPicture1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(60)))));
            this.cJiaPanel1.Appearance.BackColor2 = System.Drawing.Color.LightGreen;
            this.cJiaPanel1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(60)))));
            this.cJiaPanel1.Appearance.Options.UseBackColor = true;
            this.cJiaPanel1.Appearance.Options.UseBorderColor = true;
            this.cJiaPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cJiaPanel1.Controls.Add(this.cJiaLabel6);
            this.cJiaPanel1.Controls.Add(this.txtPassword);
            this.cJiaPanel1.Controls.Add(this.txtUserName);
            this.cJiaPanel1.Controls.Add(this.pnlLogin);
            this.cJiaPanel1.Controls.Add(this.closeBtn);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel4);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel3);
            this.cJiaPanel1.Controls.Add(this.cJiaPicture1);
            this.cJiaPanel1.Controls.Add(this.cJiaPanel2);
            this.cJiaPanel1.Controls.Add(this.ckUser);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel2);
            this.cJiaPanel1.Controls.Add(this.cJiaLabel1);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(664, 377);
            this.cJiaPanel1.TabIndex = 0;
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel6.Location = new System.Drawing.Point(148, 245);
            this.cJiaLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(81, 14);
            this.cJiaLabel6.TabIndex = 10;
            this.cJiaLabel6.Text = "Version V2.0.0";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(345, 177);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(282, 28);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtUserName_Leave);
            this.txtPassword.MouseEnter += new System.EventHandler(this.txtUserName_Enter);
            this.txtPassword.MouseLeave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(345, 99);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtUserName.Size = new System.Drawing.Size(282, 28);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            this.txtUserName.MouseEnter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.MouseLeave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLogin.Controls.Add(this.cJiaLabel5);
            this.pnlLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLogin.Location = new System.Drawing.Point(345, 259);
            this.pnlLogin.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlLogin.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(282, 32);
            this.pnlLogin.TabIndex = 4;
            this.pnlLogin.TabStop = true;
            this.pnlLogin.Click += new System.EventHandler(this.pnlLogin_Click);
            this.pnlLogin.MouseEnter += new System.EventHandler(this.pnlLogin_MouseEnter);
            this.pnlLogin.MouseLeave += new System.EventHandler(this.pnlLogin_MouseLeave);
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel5.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel5.Location = new System.Drawing.Point(119, 4);
            this.cJiaLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(48, 24);
            this.cJiaLabel5.TabIndex = 12;
            this.cJiaLabel5.Text = "登 录";
            this.cJiaLabel5.MouseEnter += new System.EventHandler(this.pnlLogin_MouseEnter);
            this.cJiaLabel5.MouseLeave += new System.EventHandler(this.pnlLogin_MouseLeave);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.EditValue = ((object)(resources.GetObject("closeBtn.EditValue")));
            this.closeBtn.Location = new System.Drawing.Point(621, 2);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Properties.Appearance.Options.UseBackColor = true;
            this.closeBtn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.closeBtn.Size = new System.Drawing.Size(41, 41);
            this.closeBtn.TabIndex = 20;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel4.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel4.Location = new System.Drawing.Point(100, 217);
            this.cJiaLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(176, 25);
            this.cJiaLabel4.TabIndex = 8;
            this.cJiaLabel4.Text = "医院健康体检系统";
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel3.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel3.Location = new System.Drawing.Point(154, 178);
            this.cJiaLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(68, 19);
            this.cJiaLabel3.TabIndex = 7;
            this.cJiaLabel3.Text = "华东医院";
            // 
            // cJiaPicture1
            // 
            this.cJiaPicture1.EditValue = ((object)(resources.GetObject("cJiaPicture1.EditValue")));
            this.cJiaPicture1.Location = new System.Drawing.Point(109, 74);
            this.cJiaPicture1.Name = "cJiaPicture1";
            this.cJiaPicture1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cJiaPicture1.Properties.Appearance.Options.UseBackColor = true;
            this.cJiaPicture1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaPicture1.Size = new System.Drawing.Size(152, 111);
            this.cJiaPicture1.TabIndex = 6;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Appearance.BackColor = System.Drawing.Color.White;
            this.cJiaPanel2.Appearance.Options.UseBackColor = true;
            this.cJiaPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaPanel2.Location = new System.Drawing.Point(295, 62);
            this.cJiaPanel2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(2, 245);
            this.cJiaPanel2.TabIndex = 6;
            // 
            // ckUser
            // 
            this.ckUser.EnterMoveNextControl = true;
            this.ckUser.Location = new System.Drawing.Point(343, 215);
            this.ckUser.Margin = new System.Windows.Forms.Padding(0);
            this.ckUser.Name = "ckUser";
            this.ckUser.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ckUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.ckUser.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.ckUser.Properties.Appearance.Options.UseBackColor = true;
            this.ckUser.Properties.Appearance.Options.UseFont = true;
            this.ckUser.Properties.Appearance.Options.UseForeColor = true;
            this.ckUser.Properties.Caption = "记住用户名";
            this.ckUser.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ckUser.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ckUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckUser.Selectable = true;
            this.ckUser.Size = new System.Drawing.Size(138, 24);
            this.ckUser.TabIndex = 3;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel2.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel2.Location = new System.Drawing.Point(345, 147);
            this.cJiaLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(78, 23);
            this.cJiaLabel2.TabIndex = 11;
            this.cJiaLabel2.Text = "密   码：";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel1.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel1.Location = new System.Drawing.Point(345, 69);
            this.cJiaLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(80, 23);
            this.cJiaLabel1.TabIndex = 10;
            this.cJiaLabel1.Text = "用户名：";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaPanel1);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(664, 377);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPicture1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel cJiaPanel1;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaPicture cJiaPicture1;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.CJiaCheck ckUser;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaPicture closeBtn;
        private Controls.CJiaPanel pnlLogin;
        private Controls.CJiaLabel cJiaLabel5;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private Controls.CJiaLabel cJiaLabel6;
    }
}
