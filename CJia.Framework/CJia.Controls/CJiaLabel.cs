using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 文本标签
    /// </summary>
    public class CJiaLabel:DevExpress.XtraEditors.LabelControl
    {
        /// <summary>
        /// CJiaLabel构造函数
        /// </summary>
        public CJiaLabel()
        {
            Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Size = new System.Drawing.Size(75, 16);
        }
    }
}
