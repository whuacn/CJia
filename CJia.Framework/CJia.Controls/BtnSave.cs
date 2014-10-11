using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 保存按钮
    /// </summary>
    public class BtnSave:CJiaButton
    {
        /// <summary>
        /// BtnSave构造函数
        /// </summary>
        public BtnSave()
        {
            baseText = "保存(F8)";
            Image = global::CJia.Controls.Properties.Resources.Save;            
        }
    }
}
