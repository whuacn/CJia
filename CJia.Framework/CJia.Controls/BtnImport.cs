using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 导入按钮
    /// </summary>
    public class BtnImport : CJiaButton
    {
        /// <summary>
        /// BtnImport构造函数
        /// </summary>
        public BtnImport()
        {
            baseText = "导入(F2)";
            Image = global::CJia.Controls.Properties.Resources.import;
        }
    }
}
