namespace CJia.Parking.App.UI
{
    partial class TemporaryFeeSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemporaryFeeSet));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new CJia.Controls.BtnSave();
            this.txtFreeHour = new DevExpress.XtraEditors.TextEdit();
            this.txtStartHour = new DevExpress.XtraEditors.TextEdit();
            this.txtEndHour = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtHourSet = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtHourSetFee = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtUpperHour = new DevExpress.XtraEditors.TextEdit();
            this.txtUpperSetFee = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new CJia.Controls.BtnCancel();
            this.btnClear = new CJia.Controls.CJiaButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFreeHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHourSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHourSetFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperSetFee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(136, 94);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "小时之内免费";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl2.Location = new System.Drawing.Point(157, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(168, 25);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "临时停车收费设置";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(199, 140);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "小时按每";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.CustomText = "保存(F8)";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(101, 244);
            this.btnSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Selectable = false;
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存(F8)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFreeHour
            // 
            this.txtFreeHour.Location = new System.Drawing.Point(90, 91);
            this.txtFreeHour.Name = "txtFreeHour";
            this.txtFreeHour.Size = new System.Drawing.Size(40, 20);
            this.txtFreeHour.TabIndex = 1;
            this.txtFreeHour.Leave += new System.EventHandler(this.txtFreeHour_Leave);
            // 
            // txtStartHour
            // 
            this.txtStartHour.Location = new System.Drawing.Point(90, 138);
            this.txtStartHour.Name = "txtStartHour";
            this.txtStartHour.Size = new System.Drawing.Size(40, 20);
            this.txtStartHour.TabIndex = 2;
            this.txtStartHour.Leave += new System.EventHandler(this.txtStartHour_Leave);
            // 
            // txtEndHour
            // 
            this.txtEndHour.Location = new System.Drawing.Point(154, 138);
            this.txtEndHour.Name = "txtEndHour";
            this.txtEndHour.Size = new System.Drawing.Size(40, 20);
            this.txtEndHour.TabIndex = 3;
            this.txtEndHour.Leave += new System.EventHandler(this.txtEndHour_Leave);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(136, 141);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(9, 14);
            this.labelControl6.TabIndex = 60;
            this.labelControl6.Text = "~";
            // 
            // txtHourSet
            // 
            this.txtHourSet.Location = new System.Drawing.Point(253, 138);
            this.txtHourSet.Name = "txtHourSet";
            this.txtHourSet.Size = new System.Drawing.Size(40, 20);
            this.txtHourSet.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(373, 140);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 62;
            this.labelControl7.Text = "元收费";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(297, 140);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(24, 14);
            this.labelControl8.TabIndex = 63;
            this.labelControl8.Text = "小时";
            // 
            // txtHourSetFee
            // 
            this.txtHourSetFee.Location = new System.Drawing.Point(326, 138);
            this.txtHourSetFee.Name = "txtHourSetFee";
            this.txtHourSetFee.Size = new System.Drawing.Size(40, 20);
            this.txtHourSetFee.TabIndex = 5;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(90, 187);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(24, 14);
            this.labelControl9.TabIndex = 65;
            this.labelControl9.Text = "超过";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(165, 187);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 14);
            this.labelControl10.TabIndex = 67;
            this.labelControl10.Text = "小时收费";
            // 
            // txtUpperHour
            // 
            this.txtUpperHour.Location = new System.Drawing.Point(121, 184);
            this.txtUpperHour.Name = "txtUpperHour";
            this.txtUpperHour.Size = new System.Drawing.Size(40, 20);
            this.txtUpperHour.TabIndex = 6;
            this.txtUpperHour.Leave += new System.EventHandler(this.txtUpperHour_Leave);
            // 
            // txtUpperSetFee
            // 
            this.txtUpperSetFee.Location = new System.Drawing.Point(220, 184);
            this.txtUpperSetFee.Name = "txtUpperSetFee";
            this.txtUpperSetFee.Size = new System.Drawing.Size(40, 20);
            this.txtUpperSetFee.TabIndex = 7;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(266, 191);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(12, 14);
            this.labelControl12.TabIndex = 70;
            this.labelControl12.Text = "元";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.CustomText = "取消(F4)";
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(197, 244);
            this.btnCancel.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Selectable = false;
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消(F4)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.CustomText = "清空(F9)";
            this.btnClear.Location = new System.Drawing.Point(293, 244);
            this.btnClear.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClear.Name = "btnClear";
            this.btnClear.Selectable = false;
            this.btnClear.Size = new System.Drawing.Size(80, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空(F9)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // TemporaryFeeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtUpperSetFee);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtUpperHour);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtHourSetFee);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtHourSet);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtEndHour);
            this.Controls.Add(this.txtStartHour);
            this.Controls.Add(this.txtFreeHour);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "TemporaryFeeSet";
            this.Size = new System.Drawing.Size(495, 313);
            ((System.ComponentModel.ISupportInitialize)(this.txtFreeHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHourSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHourSetFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperSetFee.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private Controls.BtnSave btnSave;
        private DevExpress.XtraEditors.TextEdit txtFreeHour;
        private DevExpress.XtraEditors.TextEdit txtStartHour;
        private DevExpress.XtraEditors.TextEdit txtEndHour;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtHourSet;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtHourSetFee;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtUpperHour;
        private DevExpress.XtraEditors.TextEdit txtUpperSetFee;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private Controls.BtnCancel btnCancel;
        private Controls.CJiaButton btnClear;

    }
}
