using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// Panel控件
    /// </summary>
    public class CJiaPanel:DevExpress.XtraEditors.PanelControl
    {
        /// <summary>
        /// CJiaPanel构造函数
        /// </summary>
        public CJiaPanel()
        {
            LookAndFeel.SkinName = "Office 2010 Silver";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(300, 220);
        }
    }
}
