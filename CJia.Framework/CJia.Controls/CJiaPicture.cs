using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 图片显示控件
    /// </summary>
    public class CJiaPicture:DevExpress.XtraEditors.PictureEdit
    {
        /// <summary>
        /// CJiaPicture构造函数
        /// </summary>
        public CJiaPicture()
        {
           Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
           Properties.Appearance.Options.UseBackColor = true;
           Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
           Size = new System.Drawing.Size(110, 110);
        }
    }
}
