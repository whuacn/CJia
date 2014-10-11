using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 退出按钮
    /// </summary>
    public class BtnExit:CJiaButton
    {
        /// <summary>
        /// BtnExit构造函数
        /// </summary>
        public BtnExit()
        {
            baseText = "退出(F4)";
            Image = global::CJia.Controls.Properties.Resources.Exit; 
        }
    }
}
