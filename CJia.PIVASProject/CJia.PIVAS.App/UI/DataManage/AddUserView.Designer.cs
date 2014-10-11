namespace CJia.PIVAS.App.UI.DataManage
{
    partial class AddUserView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.TxtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSurePwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BtnUsre = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(59, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "工   号：";
            // 
            // TxtUserNo
            // 
            this.TxtUserNo.Location = new System.Drawing.Point(125, 18);
            this.TxtUserNo.Name = "TxtUserNo";
            this.TxtUserNo.Size = new System.Drawing.Size(155, 20);
            this.TxtUserNo.TabIndex = 1;
            // 
            // TxtNewPwd
            // 
            this.TxtNewPwd.Location = new System.Drawing.Point(125, 94);
            this.TxtNewPwd.Name = "TxtNewPwd";
            this.TxtNewPwd.Properties.PasswordChar = '*';
            this.TxtNewPwd.Size = new System.Drawing.Size(155, 20);
            this.TxtNewPwd.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 97);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "密   码：";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(125, 58);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(155, 20);
            this.TxtName.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "姓   名：";
            // 
            // TxtSurePwd
            // 
            this.TxtSurePwd.Location = new System.Drawing.Point(125, 131);
            this.TxtSurePwd.Name = "TxtSurePwd";
            this.TxtSurePwd.Properties.PasswordChar = '*';
            this.TxtSurePwd.Size = new System.Drawing.Size(155, 20);
            this.TxtSurePwd.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(47, 134);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "确认密码：";
            // 
            // BtnUsre
            // 
            this.BtnUsre.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUsre.Appearance.Options.UseFont = true;
            this.BtnUsre.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsre.Image")));
            this.BtnUsre.Location = new System.Drawing.Point(71, 167);
            this.BtnUsre.Name = "BtnUsre";
            this.BtnUsre.Size = new System.Drawing.Size(75, 25);
            this.BtnUsre.TabIndex = 7;
            this.BtnUsre.Text = "确  定";
            this.BtnUsre.Click += new System.EventHandler(this.BtnUsre_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnCancle.Appearance.Options.UseFont = true;
            this.BtnCancle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancle.Image")));
            this.BtnCancle.Location = new System.Drawing.Point(180, 167);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // AddUserView
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnUsre);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.TxtSurePwd);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtNewPwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtUserNo);
            this.Controls.Add(this.labelControl1);
            this.Name = "AddUserView";
            this.Size = new System.Drawing.Size(326, 206);
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtUserNo;
        private DevExpress.XtraEditors.TextEdit TxtNewPwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtSurePwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton BtnUsre;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;

    }
}
