namespace CJia.HIS.App.UI
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ckeRemeUserNo = new DevExpress.XtraEditors.CheckEdit();
            this.lbcSystemName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserAccount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckeRemeUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAccount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ckeRemeUserNo);
            this.panelControl1.Controls.Add(this.lbcSystemName);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtUserPassword);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btnLogin);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtUserAccount);
            this.panelControl1.Location = new System.Drawing.Point(6, 6);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(375, 260);
            this.panelControl1.TabIndex = 0;
            // 
            // ckeRemeUserNo
            // 
            this.ckeRemeUserNo.Location = new System.Drawing.Point(54, 213);
            this.ckeRemeUserNo.Name = "ckeRemeUserNo";
            this.ckeRemeUserNo.Properties.Caption = "记住账号";
            this.ckeRemeUserNo.Size = new System.Drawing.Size(75, 19);
            this.ckeRemeUserNo.TabIndex = 8;
            // 
            // lbcSystemName
            // 
            this.lbcSystemName.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcSystemName.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbcSystemName.Location = new System.Drawing.Point(106, 8);
            this.lbcSystemName.Name = "lbcSystemName";
            this.lbcSystemName.Size = new System.Drawing.Size(163, 35);
            this.lbcSystemName.TabIndex = 7;
            this.lbcSystemName.Text = "医院HIS系统";
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(15, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(365, 14);
            this.labelControl4.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(56, 132);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 23);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "密码：";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.EnterMoveNextControl = true;
            this.txtUserPassword.Location = new System.Drawing.Point(128, 129);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.Properties.Appearance.Options.UseFont = true;
            this.txtUserPassword.Size = new System.Drawing.Size(186, 30);
            this.txtUserPassword.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 178);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(365, 14);
            this.labelControl2.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(232, 207);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 29);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(56, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "账号：";
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.EnterMoveNextControl = true;
            this.txtUserAccount.Location = new System.Drawing.Point(128, 78);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserAccount.Properties.Appearance.Options.UseFont = true;
            this.txtUserAccount.Size = new System.Drawing.Size(186, 30);
            this.txtUserAccount.TabIndex = 0;
            // 
            // LoginView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panelControl1);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(386, 271);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckeRemeUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAccount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserAccount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private DevExpress.XtraEditors.LabelControl lbcSystemName;
        private DevExpress.XtraEditors.CheckEdit ckeRemeUserNo;

    }
}