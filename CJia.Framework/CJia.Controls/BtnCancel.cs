using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 取消按钮
    /// </summary>
    public class BtnCancel:CJiaButton
    {
        /// <summary>
        /// BtnCancel构造函数
        /// </summary>
        public BtnCancel()
        {
            baseText = "取消(F4)";
            Image = global::CJia.Controls.Properties.Resources.cancel;                        
        }
    }
}
