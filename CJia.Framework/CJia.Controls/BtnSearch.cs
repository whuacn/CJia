using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 查询按钮
    /// </summary>
    public class BtnSearch:CJiaButton
    {
        /// <summary>
        /// BtnSearch构造函数
        /// </summary>
        public BtnSearch()
        {
            baseText = "查询(F5)";
            Image = global::CJia.Controls.Properties.Resources.search;                        
        }
    }
}
