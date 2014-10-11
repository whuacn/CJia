using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 刷新按钮
    /// </summary>
    public class BtnRefresh : CJiaButton
    {
        /// <summary>
        /// BtnRefresh构造函数
        /// </summary>
        public BtnRefresh()
        {
            baseText = "刷新(F5)";
            Image = global::CJia.Controls.Properties.Resources.refresh;
        }
    }
}
