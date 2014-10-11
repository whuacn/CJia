using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 加载中
    /// </summary>
    public class CJiaLoading:DevExpress.XtraWaitForm.ProgressPanel
    {
        /// <summary>
        /// CJiaLoading构造函数
        /// </summary>
        public CJiaLoading()
        {
            Appearance.BackColor = System.Drawing.Color.Transparent;
            Appearance.Options.UseBackColor = true;
            AppearanceCaption.Options.UseFont = true;
            AppearanceDescription.Options.UseFont = true;
            LookAndFeel.SkinName = "Office 2013";            
            LookAndFeel.UseDefaultLookAndFeel = false;
            ShowCaption = false;
            ShowDescription = false;
            Size = new System.Drawing.Size(40, 40);
        }
    }
}
