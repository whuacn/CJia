using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 登记按钮
    /// </summary>
    public class BtnRegister:CJiaButton
    {
        /// <summary>
        /// BtnRegister构造函数
        /// </summary>
        public BtnRegister()
        {
            baseText = "登记(F8)";
            Image = global::CJia.Controls.Properties.Resources.register;                                    
        }
    }
}
