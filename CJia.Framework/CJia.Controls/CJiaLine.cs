using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 横线
    /// </summary>
    public class CJiaLine:DevExpress.XtraEditors.LabelControl
    {
        /// <summary>
        /// CJiaLine构造函数
        /// </summary>
        public CJiaLine()
        {
            AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            LineVisible = true;
            LookAndFeel.SkinName = "Office 2010 Blue";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(250, 14);
            TextChanged += CJiaLine_TextChanged;
        }

        void CJiaLine_TextChanged(object sender, EventArgs e)
        {
            this.Text = "";
        }
    }
}
