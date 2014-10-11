namespace CJia.PIVAS.App.UI.DataManage
{
    partial class EditFrequencyToBatchView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFrequencyToBatchView));
            this.BtnSure = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ClbcBatch = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TeFrequency = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ClbcBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeFrequency.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(70, 163);
            this.BtnSure.Name = "BtnSure";
            this.BtnSure.Size = new System.Drawing.Size(75, 25);
            this.BtnSure.TabIndex = 7;
            this.BtnSure.Text = "确  定";
            this.BtnSure.Click += new System.EventHandler(this.BtnSure_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnCancle.Appearance.Options.UseFont = true;
            this.BtnCancle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancle.Image")));
            this.BtnCancle.Location = new System.Drawing.Point(187, 163);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "对应批次:";
            // 
            // ClbcBatch
            // 
            this.ClbcBatch.Location = new System.Drawing.Point(112, 51);
            this.ClbcBatch.Name = "ClbcBatch";
            this.ClbcBatch.Size = new System.Drawing.Size(166, 91);
            this.ClbcBatch.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "频率:";
            // 
            // TeFrequency
            // 
            this.TeFrequency.EditValue = "";
            this.TeFrequency.Enabled = false;
            this.TeFrequency.Location = new System.Drawing.Point(112, 18);
            this.TeFrequency.Name = "TeFrequency";
            this.TeFrequency.Properties.ReadOnly = true;
            this.TeFrequency.Size = new System.Drawing.Size(166, 20);
            this.TeFrequency.TabIndex = 17;
            // 
            // EditFrequencyToBatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.TeFrequency);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ClbcBatch);
            this.Controls.Add(this.labelControl1);
            this.Name = "EditFrequencyToBatchView";
            this.Size = new System.Drawing.Size(333, 208);
            this.Load += new System.EventHandler(this.EditFrequencyToBatchView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClbcBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeFrequency.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl ClbcBatch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TeFrequency;
    }
}
