namespace CJia.PIVAS.App.UI.DataManage
{
    partial class NewAddUserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAddUserView));
            this.tbHS = new System.Windows.Forms.RadioButton();
            this.rbPharm = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.BtnUsre = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.TxtSurePwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rbJDPharm = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbHS
            // 
            this.tbHS.AutoSize = true;
            this.tbHS.Location = new System.Drawing.Point(240, 158);
            this.tbHS.Name = "tbHS";
            this.tbHS.Size = new System.Drawing.Size(49, 18);
            this.tbHS.TabIndex = 27;
            this.tbHS.Text = "护士";
            this.tbHS.UseVisualStyleBackColor = true;
            this.tbHS.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbPharm
            // 
            this.rbPharm.AutoSize = true;
            this.rbPharm.Checked = true;
            this.rbPharm.Location = new System.Drawing.Point(112, 158);
            this.rbPharm.Name = "rbPharm";
            this.rbPharm.Size = new System.Drawing.Size(49, 18);
            this.rbPharm.TabIndex = 26;
            this.rbPharm.TabStop = true;
            this.rbPharm.Text = "药师";
            this.rbPharm.UseVisualStyleBackColor = true;
            this.rbPharm.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(71, 160);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "角色：";
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Location = new System.Drawing.Point(116, 127);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(62, 18);
            this.cbAdmin.TabIndex = 23;
            this.cbAdmin.Text = "管理员";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(71, 128);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "权限：";
            // 
            // BtnUsre
            // 
            this.BtnUsre.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnUsre.Appearance.Options.UseFont = true;
            this.BtnUsre.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsre.Image")));
            this.BtnUsre.Location = new System.Drawing.Point(59, 191);
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
            this.BtnCancle.Location = new System.Drawing.Point(200, 191);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // TxtSurePwd
            // 
            this.TxtSurePwd.Location = new System.Drawing.Point(113, 91);
            this.TxtSurePwd.Name = "TxtSurePwd";
            this.TxtSurePwd.Properties.PasswordChar = '*';
            this.TxtSurePwd.Size = new System.Drawing.Size(171, 20);
            this.TxtSurePwd.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "PIVAS密码：";
            // 
            // TxtNewPwd
            // 
            this.TxtNewPwd.Location = new System.Drawing.Point(113, 54);
            this.TxtNewPwd.Name = "TxtNewPwd";
            this.TxtNewPwd.Properties.PasswordChar = '*';
            this.TxtNewPwd.Size = new System.Drawing.Size(171, 20);
            this.TxtNewPwd.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(37, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "PIVAS密码：";
            // 
            // TxtUserNo
            // 
            this.TxtUserNo.Location = new System.Drawing.Point(113, 18);
            this.TxtUserNo.Name = "TxtUserNo";
            this.TxtUserNo.Size = new System.Drawing.Size(171, 20);
            this.TxtUserNo.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(52, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "HIS工号：";
            // 
            // rbJDPharm
            // 
            this.rbJDPharm.AutoSize = true;
            this.rbJDPharm.Location = new System.Drawing.Point(162, 158);
            this.rbJDPharm.Name = "rbJDPharm";
            this.rbJDPharm.Size = new System.Drawing.Size(73, 18);
            this.rbJDPharm.TabIndex = 28;
            this.rbJDPharm.Text = "简单药师";
            this.rbJDPharm.UseVisualStyleBackColor = true;
            // 
            // NewAddUserView
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbJDPharm);
            this.Controls.Add(this.tbHS);
            this.Controls.Add(this.rbPharm);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cbAdmin);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.BtnUsre);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.TxtSurePwd);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.TxtNewPwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtUserNo);
            this.Controls.Add(this.labelControl1);
            this.Name = "NewAddUserView";
            this.Size = new System.Drawing.Size(326, 245);
            ((System.ComponentModel.ISupportInitialize)(this.TxtSurePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtUserNo;
        private DevExpress.XtraEditors.TextEdit TxtNewPwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtSurePwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton BtnUsre;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.CheckBox cbAdmin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.RadioButton rbPharm;
        private System.Windows.Forms.RadioButton tbHS;
        private System.Windows.Forms.RadioButton rbJDPharm;

    }
}
