namespace CJia.Health.App.UI
{
    partial class ImageInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageInfoView));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labPageNo = new CJia.Controls.CJiaLabel();
            this.labTitle = new CJia.Controls.CJiaLabel();
            this.picDA = new CJia.Controls.CJiaPicture();
            this.imagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDA.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.panel1);
            this.cJiaPanel1.Controls.Add(this.imagePanel);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(847, 493);
            this.cJiaPanel1.TabIndex = 159;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labPageNo);
            this.panel1.Controls.Add(this.labTitle);
            this.panel1.Controls.Add(this.picDA);
            this.panel1.Location = new System.Drawing.Point(173, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 479);
            this.panel1.TabIndex = 160;
            // 
            // labPageNo
            // 
            this.labPageNo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labPageNo.Location = new System.Drawing.Point(40, 13);
            this.labPageNo.Name = "labPageNo";
            this.labPageNo.Size = new System.Drawing.Size(47, 16);
            this.labPageNo.TabIndex = 160;
            this.labPageNo.Text = "001   00";
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTitle.Location = new System.Drawing.Point(3, 3);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(662, 26);
            this.labTitle.TabIndex = 159;
            this.labTitle.Text = "cJiaLabel1";
            // 
            // picDA
            // 
            this.picDA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDA.EditValue = global::CJia.Health.App.Properties.Resources.QQ图片20130626103705;
            this.picDA.Location = new System.Drawing.Point(1, 35);
            this.picDA.Name = "picDA";
            this.picDA.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picDA.Properties.Appearance.Options.UseBackColor = true;
            this.picDA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picDA.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picDA.Size = new System.Drawing.Size(664, 439);
            this.picDA.TabIndex = 158;
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imagePanel.AutoScroll = true;
            this.imagePanel.Location = new System.Drawing.Point(7, 5);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(160, 481);
            this.imagePanel.TabIndex = 6;
            // 
            // ImageInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cJiaPanel1);
            this.Name = "ImageInfoView";
            this.Size = new System.Drawing.Size(847, 493);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDA.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPicture picDA;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Controls.CJiaPanel cJiaPanel1;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel panel1;
        private Controls.CJiaLabel labTitle;
        private Controls.CJiaLabel labPageNo;
    }
}
