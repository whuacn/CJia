using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    public class CJiaCheckedListBox : DevExpress.XtraEditors.CheckedListBoxControl
    {
        /// <summary>
        /// CJiaCheckedListBox构造函数
        /// </summary>
        public CJiaCheckedListBox()
        {
            Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseBorderColor = true;
            Appearance.Options.UseFont = true;
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            HorizontalScrollbar = true;
            HotTrackItems = true;
            ItemHeight = 28;
            LookAndFeel.SkinName = "Office 2010 Blue";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(140, 250);
        }
    }
}
