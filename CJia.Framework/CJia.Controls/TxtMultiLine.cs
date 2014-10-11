using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    public class TxtMultiLine:DevExpress.XtraEditors.MemoEdit
    {
        /// <summary>
        /// TxtMultiLine构造函数
        /// </summary>
        public TxtMultiLine()
        {
            Properties.Appearance.BackColor = System.Drawing.Color.White;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseBackColor = true;
            Properties.Appearance.Options.UseFont = true;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(135, 102);
        }
    }
}
