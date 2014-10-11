namespace CJia.PIVAS.App.UI.Label
{
    partial class MessageBoxView
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
            if(disposing && (components != null))
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.cbYes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 10F);
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(20, 17);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(332, 73);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "永华你好";
            // 
            // btnNo
            // 
            this.btnNo.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Location = new System.Drawing.Point(153, 106);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(86, 23);
            this.btnNo.TabIndex = 0;
            this.btnNo.Text = "否";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.Enabled = false;
            this.btnYes.Location = new System.Drawing.Point(266, 106);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(86, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "是";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // cbYes
            // 
            this.cbYes.AutoSize = true;
            this.cbYes.Location = new System.Drawing.Point(245, 112);
            this.cbYes.Name = "cbYes";
            this.cbYes.Size = new System.Drawing.Size(15, 14);
            this.cbYes.TabIndex = 1;
            this.cbYes.UseVisualStyleBackColor = true;
            this.cbYes.CheckedChanged += new System.EventHandler(this.cbYes_CheckedChanged);
            // 
            // MessageBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbYes);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblMessage);
            this.Name = "MessageBoxView";
            this.Size = new System.Drawing.Size(376, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnNo;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private System.Windows.Forms.CheckBox cbYes;

    }
}
