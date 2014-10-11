using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 单选框
    /// </summary>
    public class CJiaRadioBox:DevExpress.XtraEditors.RadioGroup
    {
        /// <summary>
        /// CJiaRadioBox构造函数
        /// </summary>
        public CJiaRadioBox()
        {
            Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseBackColor = true;
            Properties.Appearance.Options.UseFont = true;
            Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(122, 24);
        }
    }
}
