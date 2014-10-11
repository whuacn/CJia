using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 导出按钮
    /// </summary>
    public class BtnExport:CJiaButton
    {
        /// <summary>
        /// BtnExport构造函数
        /// </summary>
        public BtnExport()
        {
            baseText = "导出(F6)";
            Image = global::CJia.Controls.Properties.Resources.export;
        }
    }
}
