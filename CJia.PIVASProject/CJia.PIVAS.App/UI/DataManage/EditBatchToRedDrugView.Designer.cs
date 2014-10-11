namespace CJia.PIVAS.App.UI.DataManage
{
    partial class EditBatchToRedDrugView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBatchToRedDrugView));
            this.BtnSure = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ClcRedDrug = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TeBatchTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ClcRedDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeBatchTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(70, 165);
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
            this.BtnCancle.Location = new System.Drawing.Point(188, 165);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(66, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "对应冲药:";
            // 
            // ClcRedDrug
            // 
            this.ClcRedDrug.Location = new System.Drawing.Point(124, 55);
            this.ClcRedDrug.Name = "ClcRedDrug";
            this.ClcRedDrug.Size = new System.Drawing.Size(166, 91);
            this.ClcRedDrug.TabIndex = 13;
            this.ClcRedDrug.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.ClcRedDrug_ItemCheck);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(42, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "批次执行时间:";
            // 
            // TeBatchTime
            // 
            this.TeBatchTime.EditValue = new System.DateTime(2013, 1, 21, 0, 0, 0, 0);
            this.TeBatchTime.Location = new System.Drawing.Point(124, 20);
            this.TeBatchTime.Name = "TeBatchTime";
            this.TeBatchTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TeBatchTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.TeBatchTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeBatchTime.Properties.EditFormat.FormatString = "HH:mm";
            this.TeBatchTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeBatchTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TeBatchTime.Properties.Mask.EditMask = "HH:mm";
            this.TeBatchTime.Size = new System.Drawing.Size(166, 20);
            this.TeBatchTime.TabIndex = 17;
            // 
            // EditBatchToRedDrugView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.TeBatchTime);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ClcRedDrug);
            this.Name = "EditBatchToRedDrugView";
            this.Size = new System.Drawing.Size(333, 208);
            ((System.ComponentModel.ISupportInitialize)(this.ClcRedDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeBatchTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl ClcRedDrug;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeEdit TeBatchTime;
    }
}
