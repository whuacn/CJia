using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 减少按钮
    /// </summary>
    public class BtnRemove:CJiaButton
    {
        /// <summary>
        /// BtnRemove构造函数
        /// </summary>
        public BtnRemove()
        {
            baseText = "减少(F6)";
            Image = global::CJia.Controls.Properties.Resources.remove;            
        }
    }
}
