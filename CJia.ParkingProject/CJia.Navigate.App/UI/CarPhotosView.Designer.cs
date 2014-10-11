namespace CJia.Navigate.App.UI
{
    partial class CarPhotosView
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
            this.LblBeforePage = new System.Windows.Forms.LinkLabel();
            this.LblNextPage = new System.Windows.Forms.LinkLabel();
            this.pan = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.picturebox = new System.Windows.Forms.PictureBox();
            this.picShowView1 = new CJia.Navigate.App.UI.PicShowView();
            this.picShowView3 = new CJia.Navigate.App.UI.PicShowView();
            this.picShowView2 = new CJia.Navigate.App.UI.PicShowView();
            this.picShowView6 = new CJia.Navigate.App.UI.PicShowView();
            this.picShowView5 = new CJia.Navigate.App.UI.PicShowView();
            this.picShowView4 = new CJia.Navigate.App.UI.PicShowView();
            this.pan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // LblBeforePage
            // 
            this.LblBeforePage.ActiveLinkColor = System.Drawing.Color.Black;
            this.LblBeforePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBeforePage.AutoSize = true;
            this.LblBeforePage.BackColor = System.Drawing.Color.Transparent;
            this.LblBeforePage.DisabledLinkColor = System.Drawing.Color.Silver;
            this.LblBeforePage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblBeforePage.ForeColor = System.Drawing.Color.Gray;
            this.LblBeforePage.LinkColor = System.Drawing.Color.Gray;
            this.LblBeforePage.Location = new System.Drawing.Point(830, 569);
            this.LblBeforePage.Name = "LblBeforePage";
            this.LblBeforePage.Size = new System.Drawing.Size(58, 22);
            this.LblBeforePage.TabIndex = 41;
            this.LblBeforePage.TabStop = true;
            this.LblBeforePage.Text = "上一页";
            this.LblBeforePage.VisitedLinkColor = System.Drawing.Color.Gray;
            this.LblBeforePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblBeforePage_LinkClicked);
            // 
            // LblNextPage
            // 
            this.LblNextPage.ActiveLinkColor = System.Drawing.Color.Black;
            this.LblNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNextPage.AutoSize = true;
            this.LblNextPage.BackColor = System.Drawing.Color.Transparent;
            this.LblNextPage.DisabledLinkColor = System.Drawing.Color.Silver;
            this.LblNextPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblNextPage.ForeColor = System.Drawing.Color.Gray;
            this.LblNextPage.LinkColor = System.Drawing.Color.Gray;
            this.LblNextPage.Location = new System.Drawing.Point(933, 569);
            this.LblNextPage.Name = "LblNextPage";
            this.LblNextPage.Size = new System.Drawing.Size(58, 22);
            this.LblNextPage.TabIndex = 42;
            this.LblNextPage.TabStop = true;
            this.LblNextPage.Text = "下一页";
            this.LblNextPage.VisitedLinkColor = System.Drawing.Color.Gray;
            this.LblNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblNextPage_LinkClicked);
            // 
            // pan
            // 
            this.pan.Controls.Add(this.lblMsg);
            this.pan.Controls.Add(this.picturebox);
            this.pan.Location = new System.Drawing.Point(105, 710);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(300, 250);
            this.pan.TabIndex = 48;
            this.pan.Visible = false;
            this.pan.Click += new System.EventHandler(this.pan_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Black;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(57, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(71, 26);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "label1";
            this.lblMsg.Visible = false;
            // 
            // picturebox
            // 
            this.picturebox.Location = new System.Drawing.Point(3, 44);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(300, 250);
            this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox.TabIndex = 0;
            this.picturebox.TabStop = false;
            this.picturebox.Click += new System.EventHandler(this.pan_Click);
            // 
            // picShowView1
            // 
            this.picShowView1.Img = null;
            this.picShowView1.InParkTime = null;
            this.picShowView1.LicenceNo = null;
            this.picShowView1.Location = new System.Drawing.Point(25, 37);
            this.picShowView1.Name = "picShowView1";
            this.picShowView1.ParkNo = null;
            this.picShowView1.Size = new System.Drawing.Size(300, 250);
            this.picShowView1.TabIndex = 51;
            this.picShowView1.Visible = false;
            // 
            // picShowView3
            // 
            this.picShowView3.Img = null;
            this.picShowView3.InParkTime = null;
            this.picShowView3.LicenceNo = null;
            this.picShowView3.Location = new System.Drawing.Point(698, 37);
            this.picShowView3.Name = "picShowView3";
            this.picShowView3.ParkNo = null;
            this.picShowView3.Size = new System.Drawing.Size(300, 250);
            this.picShowView3.TabIndex = 45;
            this.picShowView3.Visible = false;
            // 
            // picShowView2
            // 
            this.picShowView2.Img = null;
            this.picShowView2.InParkTime = null;
            this.picShowView2.LicenceNo = null;
            this.picShowView2.Location = new System.Drawing.Point(362, 37);
            this.picShowView2.Name = "picShowView2";
            this.picShowView2.ParkNo = null;
            this.picShowView2.Size = new System.Drawing.Size(300, 250);
            this.picShowView2.TabIndex = 44;
            this.picShowView2.Visible = false;
            // 
            // picShowView6
            // 
            this.picShowView6.Img = null;
            this.picShowView6.InParkTime = null;
            this.picShowView6.LicenceNo = null;
            this.picShowView6.Location = new System.Drawing.Point(698, 293);
            this.picShowView6.Name = "picShowView6";
            this.picShowView6.ParkNo = null;
            this.picShowView6.Size = new System.Drawing.Size(300, 250);
            this.picShowView6.TabIndex = 50;
            this.picShowView6.Visible = false;
            // 
            // picShowView5
            // 
            this.picShowView5.Img = null;
            this.picShowView5.InParkTime = null;
            this.picShowView5.LicenceNo = null;
            this.picShowView5.Location = new System.Drawing.Point(362, 293);
            this.picShowView5.Name = "picShowView5";
            this.picShowView5.ParkNo = null;
            this.picShowView5.Size = new System.Drawing.Size(300, 250);
            this.picShowView5.TabIndex = 49;
            this.picShowView5.Visible = false;
            // 
            // picShowView4
            // 
            this.picShowView4.Img = null;
            this.picShowView4.InParkTime = null;
            this.picShowView4.LicenceNo = null;
            this.picShowView4.Location = new System.Drawing.Point(25, 293);
            this.picShowView4.Name = "picShowView4";
            this.picShowView4.ParkNo = null;
            this.picShowView4.Size = new System.Drawing.Size(300, 250);
            this.picShowView4.TabIndex = 46;
            this.picShowView4.Visible = false;
            // 
            // CarPhotosView
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picShowView1);
            this.Controls.Add(this.picShowView3);
            this.Controls.Add(this.picShowView2);
            this.Controls.Add(this.picShowView6);
            this.Controls.Add(this.picShowView5);
            this.Controls.Add(this.picShowView4);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.LblNextPage);
            this.Controls.Add(this.LblBeforePage);
            this.Name = "CarPhotosView";
            this.Size = new System.Drawing.Size(1024, 608);
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LblBeforePage;
        private System.Windows.Forms.LinkLabel LblNextPage;
        private PicShowView picShowView2;
        private PicShowView picShowView4;
        private PicShowView picShowView3;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Label lblMsg;
        private PicShowView picShowView5;
        private PicShowView picShowView6;
        private PicShowView picShowView1;

    }
}
