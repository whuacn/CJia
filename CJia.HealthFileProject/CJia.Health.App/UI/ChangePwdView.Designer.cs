namespace CJia.Health.App.UI
{
    partial class ChangePwdView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePwdView));
            this.cJiaLine1 = new CJia.Controls.CJiaLine();
            this.btnSave = new CJia.Controls.BtnSave();
            this.btnCancel = new CJia.Controls.BtnCancel();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.txtRepeatNewPwd = new CJia.Controls.CJiaTextBox();
            this.txtNewPwd = new CJia.Controls.CJiaTextBox();
            this.txtOldPwd = new CJia.Controls.CJiaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaLine1
            // 
            this.cJiaLine1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.cJiaLine1.LineVisible = true;
            this.cJiaLine1.Location = new System.Drawing.Point(14, 154);
            this.cJiaLine1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaLine1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaLine1.Name = "cJiaLine1";
            this.cJiaLine1.Size = new System.Drawing.Size(362, 16);
            this.cJiaLine1.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.CustomText = "保存(F8)";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(123, 179);
            this.btnSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Selectable = false;
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.CustomText = "取消(F4)";
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(244, 179);
            this.btnCancel.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Selectable = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消(F4)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(19, 114);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(90, 16);
            this.cJiaLabel3.TabIndex = 14;
            this.cJiaLabel3.Text = "重复新密码：";
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(49, 71);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel2.TabIndex = 13;
            this.cJiaLabel2.Text = "新密码：";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(49, 27);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(60, 16);
            this.cJiaLabel1.TabIndex = 12;
            this.cJiaLabel1.Text = "原密码：";
            // 
            // txtRepeatNewPwd
            // 
            this.txtRepeatNewPwd.Location = new System.Drawing.Point(123, 111);
            this.txtRepeatNewPwd.Name = "txtRepeatNewPwd";
            this.txtRepeatNewPwd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRepeatNewPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRepeatNewPwd.Properties.Appearance.Options.UseBackColor = true;
            this.txtRepeatNewPwd.Properties.Appearance.Options.UseFont = true;
            this.txtRepeatNewPwd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtRepeatNewPwd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRepeatNewPwd.Properties.PasswordChar = '*';
            this.txtRepeatNewPwd.Size = new System.Drawing.Size(201, 22);
            this.txtRepeatNewPwd.TabIndex = 11;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(123, 65);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNewPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNewPwd.Properties.Appearance.Options.UseBackColor = true;
            this.txtNewPwd.Properties.Appearance.Options.UseFont = true;
            this.txtNewPwd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtNewPwd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNewPwd.Properties.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(201, 22);
            this.txtNewPwd.TabIndex = 10;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(123, 21);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOldPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtOldPwd.Properties.Appearance.Options.UseBackColor = true;
            this.txtOldPwd.Properties.Appearance.Options.UseFont = true;
            this.txtOldPwd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtOldPwd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtOldPwd.Properties.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(201, 22);
            this.txtOldPwd.TabIndex = 9;
            // 
            // ChangePwdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaLine1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cJiaLabel3);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.cJiaLabel1);
            this.Controls.Add(this.txtRepeatNewPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Name = "ChangePwdView";
            this.Size = new System.Drawing.Size(390, 222);
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaLine cJiaLine1;
        private Controls.BtnSave btnSave;
        private Controls.BtnCancel btnCancel;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaTextBox txtRepeatNewPwd;
        private Controls.CJiaTextBox txtNewPwd;
        private Controls.CJiaTextBox txtOldPwd;
    }
}
