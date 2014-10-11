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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TeFrequency = new DevExpress.XtraEditors.TextEdit();
            this.btnToLift = new DevExpress.XtraEditors.SimpleButton();
            this.butToRigth = new DevExpress.XtraEditors.SimpleButton();
            this.lbcNoUseBatch = new DevExpress.XtraEditors.ListBoxControl();
            this.lbcUseBatch = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TeFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcNoUseBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcUseBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(78, 197);
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
            this.BtnCancle.Location = new System.Drawing.Point(195, 197);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
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
            // btnToLift
            // 
            this.btnToLift.Image = ((System.Drawing.Image)(resources.GetObject("btnToLift.Image")));
            this.btnToLift.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnToLift.Location = new System.Drawing.Point(161, 157);
            this.btnToLift.Name = "btnToLift";
            this.btnToLift.Size = new System.Drawing.Size(25, 23);
            this.btnToLift.TabIndex = 21;
            this.btnToLift.Click += new System.EventHandler(this.btnToLift_Click);
            // 
            // butToRigth
            // 
            this.butToRigth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butToRigth.Image = ((System.Drawing.Image)(resources.GetObject("butToRigth.Image")));
            this.butToRigth.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.butToRigth.Location = new System.Drawing.Point(161, 75);
            this.butToRigth.Name = "butToRigth";
            this.butToRigth.Size = new System.Drawing.Size(25, 23);
            this.butToRigth.TabIndex = 20;
            this.butToRigth.Click += new System.EventHandler(this.butToRigth_Click);
            // 
            // lbcNoUseBatch
            // 
            this.lbcNoUseBatch.Location = new System.Drawing.Point(190, 73);
            this.lbcNoUseBatch.Name = "lbcNoUseBatch";
            this.lbcNoUseBatch.Size = new System.Drawing.Size(80, 107);
            this.lbcNoUseBatch.TabIndex = 19;
            this.lbcNoUseBatch.DoubleClick += new System.EventHandler(this.lbcNoUseOrderBy_DoubleClick);
            // 
            // lbcUseBatch
            // 
            this.lbcUseBatch.Location = new System.Drawing.Point(78, 75);
            this.lbcUseBatch.Name = "lbcUseBatch";
            this.lbcUseBatch.Size = new System.Drawing.Size(79, 106);
            this.lbcUseBatch.TabIndex = 18;
            this.lbcUseBatch.DoubleClick += new System.EventHandler(this.lbcUseOrderBy_DoubleClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(78, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "对应批次:";
            // 
            // EditFrequencyToBatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnToLift);
            this.Controls.Add(this.butToRigth);
            this.Controls.Add(this.lbcNoUseBatch);
            this.Controls.Add(this.lbcUseBatch);
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.TeFrequency);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.labelControl1);
            this.Name = "EditFrequencyToBatchView";
            this.Size = new System.Drawing.Size(347, 267);
            this.Load += new System.EventHandler(this.EditFrequencyToBatchView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TeFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcNoUseBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcUseBatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TeFrequency;
        private DevExpress.XtraEditors.SimpleButton btnToLift;
        private DevExpress.XtraEditors.SimpleButton butToRigth;
        private DevExpress.XtraEditors.ListBoxControl lbcNoUseBatch;
        private DevExpress.XtraEditors.ListBoxControl lbcUseBatch;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
