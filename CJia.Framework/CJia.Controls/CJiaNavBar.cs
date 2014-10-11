using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 树形导航栏
    /// </summary>
    public class CJiaNavBar : DevExpress.XtraNavBar.NavBarControl
    {
        /// <summary>
        /// CJiaNavBar构造函数
        /// </summary>
        public CJiaNavBar()
        {
            Appearance.GroupHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            Appearance.GroupHeader.Options.UseFont = true;
            Appearance.Item.Font = new System.Drawing.Font("Tahoma", 10F);
            Appearance.Item.Options.UseFont = true;
            OptionsNavPane.ExpandedWidth = 140;
            Size = new System.Drawing.Size(140, 300);
        }
    }
}
