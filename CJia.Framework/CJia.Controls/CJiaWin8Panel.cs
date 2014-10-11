using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// win8色块
    /// </summary>
    public class CJiaWin8Panel : DevExpress.XtraEditors.PanelControl
    {
        private System.Drawing.Point parentPoint;
        private System.Drawing.Size parentSize;
        private System.Drawing.Point SonPoint;
        /// <summary>
        /// 显示色块名称label
        /// </summary>
        public CJia.Controls.CJiaLabel cJiaLabel1;
        /// <summary>
        /// CJiaWin8Panel构造函数
        /// </summary>
        public CJiaWin8Panel()
        {
            cJiaLabel1 = new CJiaLabel();
            //this.cJiaLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.cJiaLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel1.Appearance.ForeColor = System.Drawing.Color.White;
            this.cJiaLabel1.Location = new System.Drawing.Point(3, 94);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Text = customText;

            Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            Appearance.Options.UseBackColor = true;
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            Cursor = System.Windows.Forms.Cursors.Hand;
            LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            LookAndFeel.UseDefaultLookAndFeel = false;
            Controls.Add(cJiaLabel1);
            Size = new System.Drawing.Size(180, 120);
            MouseEnter += CJiaWin8Panel_MouseEnter;
            MouseLeave += CJiaWin8Panel_MouseLeave;
        }

        void CJiaWin8Panel_MouseLeave(object sender, EventArgs e)
        {
            this.Location = parentPoint;
            this.Size = parentSize;
            this.Controls["cJiaLabel1"].Location = SonPoint;
        }

        void CJiaWin8Panel_MouseEnter(object sender, EventArgs e)
        {
            parentPoint = this.Location;
            parentSize = this.Size;
            SonPoint = this.Controls["cJiaLabel1"].Location;
            this.Location = new System.Drawing.Point(parentPoint.X - 2, parentPoint.Y - 2);
            this.Size = new System.Drawing.Size(parentSize.Width + 4, parentSize.Height + 4);
            this.Controls["cJiaLabel1"].Location = new System.Drawing.Point(SonPoint.X + 2, SonPoint.Y + 2);
        }

        private string customText = "cJiaWin8Panel";
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("win8色块名称")]
        public virtual string CustomText
        {
            get { return customText; }
            set
            {
                customText = value;
                this.cJiaLabel1.Text = value;
            }
        }

    }
}
