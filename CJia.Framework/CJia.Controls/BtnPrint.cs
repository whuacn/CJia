using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 打印按钮
    /// </summary>
    public class BtnPrint:CJiaButton
    {
        /// <summary>
        /// BtnPrint构造函数
        /// </summary>
        public BtnPrint()
        {
            baseText = "打印(F7)";
            Image = global::CJia.Controls.Properties.Resources.Print;                
        }
    }
}
