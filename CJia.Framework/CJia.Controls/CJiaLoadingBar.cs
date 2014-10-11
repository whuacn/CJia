using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 加载条
    /// </summary>
    public class CJiaLoadingBar:DevExpress.XtraEditors.ProgressBarControl
    {
        /// <summary>
        /// CJiaLoadingBar构造函数
        /// </summary>
        public CJiaLoadingBar()
        {
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(350, 25);
        }

    }
}
