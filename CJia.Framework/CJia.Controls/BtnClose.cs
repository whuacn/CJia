using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public class BtnClose:CJiaButton
    {
        /// <summary>
        /// BtnClose构造函数
        /// </summary>
        public BtnClose()
        {
            baseText = "关闭(F4)";
            Image = global::CJia.Controls.Properties.Resources.close;                                 
        }
    }
}
