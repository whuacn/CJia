using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 输入框
    /// </summary>
    public class CJiaTextBox:DevExpress.XtraEditors.TextEdit
    {
        /// <summary>
        /// CJiaTextBox构造函数
        /// </summary>
        public CJiaTextBox()
        {
           Properties.Appearance.BackColor = System.Drawing.Color.White;
           Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
           Properties.Appearance.Options.UseBackColor = true;
           Properties.Appearance.Options.UseFont = true;
           Properties.LookAndFeel.SkinName = "Office 2010 Blue";
           Properties.LookAndFeel.UseDefaultLookAndFeel = false;
           Width = 135;
        }
    }
}
