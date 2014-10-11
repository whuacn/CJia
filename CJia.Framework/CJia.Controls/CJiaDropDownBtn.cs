using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 下拉框按钮
    /// </summary>
    public class CJiaDropDownBtn:DevExpress.XtraEditors.DropDownButton
    {
        /// <summary>
        /// CJiaDropDownBtn构造函数
        /// </summary>
        public CJiaDropDownBtn()
        {
            Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Appearance.Options.UseFont = true;
            DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            LookAndFeel.SkinName = "Office 2010 Blue";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(135, 23);
        }
    }
}
