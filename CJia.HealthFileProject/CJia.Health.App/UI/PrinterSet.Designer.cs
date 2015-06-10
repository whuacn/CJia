namespace CJia.Health.App.UI
{
    partial class PrinterSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterSet));
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.btnSave = new CJia.Controls.BtnSave();
            this.btnClose = new CJia.Controls.BtnClose();
            this.cbPrintName = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPrintName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cJiaLabel1.Location = new System.Drawing.Point(31, 57);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(48, 17);
            this.cJiaLabel1.TabIndex = 0;
            this.cJiaLabel1.Text = "打印机：";
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
            // cbPrintName
            // 
            this.cbPrintName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPrintName.Location = new System.Drawing.Point(85, 54);
            this.cbPrintName.Name = "cbPrintName";
            this.cbPrintName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPrintName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPrintName.Size = new System.Drawing.Size(275, 20);
            this.cbPrintName.TabIndex = 15;
            // 
            // PrinterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPrintName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cJiaLabel1);
            this.Name = "PrinterSet";
            this.Size = new System.Drawing.Size(390, 205);
            ((System.ComponentModel.ISupportInitialize)(this.cbPrintName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CJiaLabel cJiaLabel1;
        private Controls.BtnClose btnClose;
        private Controls.BtnSave btnSave;
        private DevExpress.XtraEditors.ComboBoxEdit cbPrintName;
    }
}
