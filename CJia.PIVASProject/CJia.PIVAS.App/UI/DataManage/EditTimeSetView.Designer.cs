namespace CJia.PIVAS.App.UI.DataManage
{
    partial class EditTimeSetView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTimeSetView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TeName = new DevExpress.XtraEditors.TextEdit();
            this.TeStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.BtnSure = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.TeOverTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeOverTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(53, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "名      称:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "开始时间:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(53, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "截止时间:";
            // 
            // TeName
            // 
            this.TeName.EditValue = "";
            this.TeName.Location = new System.Drawing.Point(124, 24);
            this.TeName.Name = "TeName";
            this.TeName.Size = new System.Drawing.Size(156, 20);
            this.TeName.TabIndex = 3;
            // 
            // TeStartTime
            // 
            this.TeStartTime.EditValue = new System.DateTime(2013, 1, 21, 0, 0, 0, 0);
            this.TeStartTime.Location = new System.Drawing.Point(124, 66);
            this.TeStartTime.Name = "TeStartTime";
            this.TeStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TeStartTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.TeStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeStartTime.Properties.EditFormat.FormatString = "HH:mm";
            this.TeStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeStartTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TeStartTime.Properties.Mask.EditMask = "HH:mm";
            this.TeStartTime.Size = new System.Drawing.Size(156, 20);
            this.TeStartTime.TabIndex = 4;
            // 
            // BtnSure
            // 
            this.BtnSure.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BtnSure.Appearance.Options.UseFont = true;
            this.BtnSure.Image = ((System.Drawing.Image)(resources.GetObject("BtnSure.Image")));
            this.BtnSure.Location = new System.Drawing.Point(73, 157);
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
            this.BtnCancle.Location = new System.Drawing.Point(184, 157);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 25);
            this.BtnCancle.TabIndex = 8;
            this.BtnCancle.Text = "取  消";
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // TeOverTime
            // 
            this.TeOverTime.EditValue = new System.DateTime(2013, 1, 21, 0, 0, 0, 0);
            this.TeOverTime.Location = new System.Drawing.Point(124, 108);
            this.TeOverTime.Name = "TeOverTime";
            this.TeOverTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TeOverTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.TeOverTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeOverTime.Properties.EditFormat.FormatString = "HH:mm";
            this.TeOverTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TeOverTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TeOverTime.Properties.Mask.EditMask = "HH:mm";
            this.TeOverTime.Size = new System.Drawing.Size(156, 20);
            this.TeOverTime.TabIndex = 12;
            // 
            // EditTimeSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.TeOverTime);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.TeName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.TeStartTime);
            this.Name = "EditTimeSetView";
            this.Size = new System.Drawing.Size(333, 208);
            ((System.ComponentModel.ISupportInitialize)(this.TeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeOverTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TeName;
        private DevExpress.XtraEditors.TimeEdit TeStartTime;
        private DevExpress.XtraEditors.SimpleButton BtnSure;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private DevExpress.XtraEditors.TimeEdit TeOverTime;
    }
}
