using TwainLib;
namespace CJia.Health.App.UI
{
    partial class ScanForm
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
            this.components = new System.ComponentModel.Container();
            this.txtTimes = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel17 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel16 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.txtID = new CJia.Controls.CJiaTextBox();
            this.btnStart = new CJia.Controls.CJiaButton();
            this.txtFolder = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.txtStartPage = new CJia.Controls.CJiaTextBox();
            this.btnClose = new CJia.Controls.CJiaButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimes
            // 
            this.txtTimes.EditValue = "1";
            this.txtTimes.Location = new System.Drawing.Point(87, 100);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTimes.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTimes.Properties.Appearance.Options.UseBackColor = true;
            this.txtTimes.Properties.Appearance.Options.UseFont = true;
            this.txtTimes.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTimes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTimes.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtTimes.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTimes.Properties.Mask.EditMask = "\\d{2}|\\d{1}";
            this.txtTimes.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTimes.Properties.ReadOnly = true;
            this.txtTimes.Size = new System.Drawing.Size(34, 22);
            this.txtTimes.TabIndex = 173;
            // 
            // cJiaLabel17
            // 
            this.cJiaLabel17.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel17.Location = new System.Drawing.Point(125, 107);
            this.cJiaLabel17.Name = "cJiaLabel17";
            this.cJiaLabel17.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel17.TabIndex = 172;
            this.cJiaLabel17.Text = "次入院";
            // 
            // cJiaLabel16
            // 
            this.cJiaLabel16.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel16.Location = new System.Drawing.Point(62, 106);
            this.cJiaLabel16.Name = "cJiaLabel16";
            this.cJiaLabel16.Size = new System.Drawing.Size(15, 16);
            this.cJiaLabel16.TabIndex = 171;
            this.cJiaLabel16.Text = "第";
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(32, 67);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel2.TabIndex = 170;
            this.cJiaLabel2.Text = "病案号";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(47, 26);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(30, 16);
            this.cJiaLabel1.TabIndex = 168;
            this.cJiaLabel1.Text = "目录";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(87, 60);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtID.Properties.Appearance.Options.UseBackColor = true;
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtID.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtID.Properties.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(259, 22);
            this.txtID.TabIndex = 174;
            // 
            // btnStart
            // 
            this.btnStart.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnStart.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Appearance.Options.UseForeColor = true;
            this.btnStart.CustomText = "开始";
            this.btnStart.Location = new System.Drawing.Point(226, 148);
            this.btnStart.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnStart.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnStart.Name = "btnStart";
            this.btnStart.Selectable = false;
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 175;
            this.btnStart.Text = "开始";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(87, 20);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFolder.Properties.Appearance.Options.UseBackColor = true;
            this.txtFolder.Properties.Appearance.Options.UseFont = true;
            this.txtFolder.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtFolder.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtFolder.Properties.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(259, 22);
            this.txtFolder.TabIndex = 176;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(207, 106);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel3.TabIndex = 177;
            this.cJiaLabel3.Text = "起始页";
            // 
            // txtStartPage
            // 
            this.txtStartPage.EditValue = "1";
            this.txtStartPage.Location = new System.Drawing.Point(262, 100);
            this.txtStartPage.Name = "txtStartPage";
            this.txtStartPage.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtStartPage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartPage.Properties.Appearance.Options.UseBackColor = true;
            this.txtStartPage.Properties.Appearance.Options.UseFont = true;
            this.txtStartPage.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtStartPage.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtStartPage.Properties.Mask.EditMask = "\\d{3}|\\d{2}|\\d{1}";
            this.txtStartPage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtStartPage.Size = new System.Drawing.Size(84, 22);
            this.txtStartPage.TabIndex = 1;
            this.txtStartPage.TextChanged += new System.EventHandler(this.txtStartPage_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.CustomText = "取消";
            this.btnClose.Location = new System.Drawing.Point(87, 148);
            this.btnClose.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Selectable = false;
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 179;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 199);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtStartPage);
            this.Controls.Add(this.cJiaLabel3);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtTimes);
            this.Controls.Add(this.cJiaLabel17);
            this.Controls.Add(this.cJiaLabel16);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.cJiaLabel1);
            this.Name = "ScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描";
            this.Activated += new System.EventHandler(this.ScanForm_Activated);
            this.Leave += new System.EventHandler(this.ScanForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaTextBox txtTimes;
        private Controls.CJiaLabel cJiaLabel17;
        private Controls.CJiaLabel cJiaLabel16;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaTextBox txtID;
        private Controls.CJiaButton btnStart;
        private Controls.CJiaTextBox txtFolder;
        Twain Tw;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.CJiaTextBox txtStartPage;
        private Controls.CJiaButton btnClose;
        private System.Windows.Forms.Timer timer1;
    }
}