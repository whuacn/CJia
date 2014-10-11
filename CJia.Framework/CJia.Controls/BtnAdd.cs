using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 添加按钮
    /// </summary>
    public class BtnAdd : CJiaButton
    {
        /// <summary>
        /// BtnAdd构造函数
        /// </summary>
        public BtnAdd()
        {
            baseText = "添加(F2)";
            Image = global::CJia.Controls.Properties.Resources.add;
        }
    }
}
