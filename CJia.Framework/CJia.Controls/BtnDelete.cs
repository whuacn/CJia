using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 删除按钮
    /// </summary>
    public class BtnDelete : CJiaButton
    {
        /// <summary>
        /// BtnDelete构造函数
        /// </summary>
        public BtnDelete()
        {
            baseText = "删除(F6)";
            Image = global::CJia.Controls.Properties.Resources.Delete;
        }
    }
}
