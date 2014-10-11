namespace CJia.PIVAS.App.UI.Label
{
    partial class PrintLabelView
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintLabelView));
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnNoAll = new System.Windows.Forms.RadioButton();
            this.txtStart = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEnd = new DevExpress.XtraEditors.TextEdit();
            this.btnCentel = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnAll
            // 
            this.rbnAll.AutoSize = true;
            this.rbnAll.Checked = true;
            this.rbnAll.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.rbnAll.Location = new System.Drawing.Point(53, 26);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(180, 21);
            this.rbnAll.TabIndex = 0;
            this.rbnAll.TabStop = true;
            this.rbnAll.Text = "显示的所有(1000)张瓶贴";
            this.rbnAll.UseVisualStyleBackColor = true;
            this.rbnAll.CheckedChanged += new System.EventHandler(this.rbnAll_CheckedChanged);
            // 
            // rbnNoAll
            // 
            this.rbnNoAll.AutoSize = true;
            this.rbnNoAll.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.rbnNoAll.Location = new System.Drawing.Point(53, 66);
            this.rbnNoAll.Name = "rbnNoAll";
            this.rbnNoAll.Size = new System.Drawing.Size(124, 21);
            this.rbnNoAll.TabIndex = 1;
            this.rbnNoAll.Text = "显示的瓶贴范围";
            this.rbnNoAll.UseVisualStyleBackColor = true;
            this.rbnNoAll.CheckedChanged += new System.EventHandler(this.rbnNoAll_CheckedChanged);
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(90, 94);
            this.txtStart.Name = "txtStart";
            this.txtStart.Properties.Mask.EditMask = "d";
            this.txtStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtStart.Size = new System.Drawing.Size(71, 20);
            this.txtStart.TabIndex = 2;
            this.txtStart.EditValueChanged += new System.EventHandler(this.txtStart_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(72, 97);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "从";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(169, 97);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "到";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(187, 94);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Properties.Mask.EditMask = "d";
            this.txtEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEnd.Size = new System.Drawing.Size(71, 20);
            this.txtEnd.TabIndex = 5;
            this.txtEnd.EditValueChanged += new System.EventHandler(this.txtEnd_EditValueChanged);
            // 
            // btnCentel
            // 
            this.btnCentel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCentel.Appearance.Options.UseFont = true;
            this.btnCentel.Image = ((System.Drawing.Image)(resources.GetObject("btnCentel.Image")));
            this.btnCentel.Location = new System.Drawing.Point(167, 140);
            this.btnCentel.Name = "btnCentel";
            this.btnCentel.Size = new System.Drawing.Size(75, 25);
            this.btnCentel.TabIndex = 7;
            this.btnCentel.Text = "取消";
            this.btnCentel.Click += new System.EventHandler(this.btnCentel_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.Image")));
            this.btnEnter.Location = new System.Drawing.Point(70, 140);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 25);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "打印";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // PrintLabelView
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCentel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.rbnNoAll);
            this.Controls.Add(this.rbnAll);
            this.Name = "PrintLabelView";
            this.Size = new System.Drawing.Size(310, 190);
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnAll;
        private System.Windows.Forms.RadioButton rbnNoAll;
        private DevExpress.XtraEditors.TextEdit txtStart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEnd;
        private DevExpress.XtraEditors.SimpleButton btnCentel;

    }
}
