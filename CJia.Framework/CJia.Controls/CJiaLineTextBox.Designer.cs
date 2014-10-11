namespace CJia.Controls
{
    partial class CJiaLineTextBox
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
            this.cJiaTextBox1 = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaTextBox1
            // 
            this.cJiaTextBox1.Location = new System.Drawing.Point(0, 2);
            this.cJiaTextBox1.Name = "cJiaTextBox1";
            this.cJiaTextBox1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.cJiaTextBox1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaTextBox1.Properties.Appearance.Options.UseBackColor = true;
            this.cJiaTextBox1.Properties.Appearance.Options.UseFont = true;
            this.cJiaTextBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaTextBox1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaTextBox1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaTextBox1.Size = new System.Drawing.Size(125, 20);
            this.cJiaTextBox1.TabIndex = 5;
            this.cJiaTextBox1.TextChanged += new System.EventHandler(this.cJiaTextBox1_TextChanged);
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.cJiaLabel3.LineVisible = true;
            this.cJiaLabel3.Location = new System.Drawing.Point(0, 18);
            this.cJiaLabel3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.cJiaLabel3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(125, 10);
            this.cJiaLabel3.TabIndex = 6;
            // 
            // CJiaLineTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaTextBox1);
            this.Controls.Add(this.cJiaLabel3);
            this.Name = "CJiaLineTextBox";
            this.Size = new System.Drawing.Size(127, 25);
            this.SizeChanged += new System.EventHandler(this.CJiaLineTextBox_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CJiaTextBox cJiaTextBox1;
        private CJiaLabel cJiaLabel3;
    }
}
