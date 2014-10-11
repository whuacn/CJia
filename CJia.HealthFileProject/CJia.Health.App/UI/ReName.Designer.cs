namespace CJia.Health.App.UI
{
    partial class ReName
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.btnClose = new CJia.Controls.CJiaButton();
            this.btnStart = new CJia.Controls.CJiaButton();
            this.txtStartPage = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.cJiaLabel3.Location = new System.Drawing.Point(58, 51);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(72, 29);
            this.cJiaLabel3.TabIndex = 179;
            this.cJiaLabel3.Text = "新页码";
            this.cJiaLabel3.Click += new System.EventHandler(this.cJiaLabel3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.CustomText = "取消";
            this.btnClose.Location = new System.Drawing.Point(75, 133);
            this.btnClose.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Selectable = false;
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 181;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStart
            // 
            this.btnStart.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnStart.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Appearance.Options.UseForeColor = true;
            this.btnStart.CustomText = "确定";
            this.btnStart.Location = new System.Drawing.Point(214, 133);
            this.btnStart.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnStart.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnStart.Name = "btnStart";
            this.btnStart.Selectable = false;
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 180;
            this.btnStart.Text = "确定";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtStartPage
            // 
            this.txtStartPage.Location = new System.Drawing.Point(150, 39);
            this.txtStartPage.Name = "txtStartPage";
            this.txtStartPage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtStartPage.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtStartPage.Properties.Appearance.Options.UseFont = true;
            this.txtStartPage.Properties.Appearance.Options.UseForeColor = true;
            this.txtStartPage.Properties.Mask.EditMask = "\\d{3}|\\d{2}|\\d{1}";
            this.txtStartPage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtStartPage.Size = new System.Drawing.Size(144, 54);
            this.txtStartPage.TabIndex = 182;
            // 
            // ReName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 193);
            this.Controls.Add(this.txtStartPage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cJiaLabel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReName";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重命名";
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaButton btnClose;
        private Controls.CJiaButton btnStart;
        private DevExpress.XtraEditors.TextEdit txtStartPage;
    }
}