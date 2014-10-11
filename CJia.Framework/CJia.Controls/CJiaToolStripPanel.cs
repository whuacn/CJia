using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// 工具栏色块
    /// </summary>
    public class CJiaToolStripPanel : CJiaWin8Panel
    {
        /// <summary>
        /// CJiaToolStripPanel构造函数
        /// </summary>
        public CJiaToolStripPanel()
        {
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel1.Location = new System.Drawing.Point(40, 26);
            this.cJiaLabel1.Text = customText;

            Size = new System.Drawing.Size(110, 60);
            ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        }

        private string customText = "色块名称";
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("工具栏色块名称")]
        public override string CustomText
        {
            get { return customText; }
            set
            {
                customText = value;
                this.cJiaLabel1.Text = value; 
                if (value.Length == 4)
                {
                    this.cJiaLabel1.Location = new System.Drawing.Point(40, 26);
                }
                if (value.Length == 2)
                {
                    this.cJiaLabel1.Location = new System.Drawing.Point(58, 26);
                }
            }
        }
    }
}
