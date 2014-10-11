using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 多列CheckedListBox
    /// </summary>
    public class CJiaMCCheckedListBox : CJiaCheckedListBox
    {
        /// <summary>
        /// CJiaMCCheckedListBox构造函数
        /// </summary>
        public CJiaMCCheckedListBox()
        {
            this.MultiColumn = true;
            Size = new System.Drawing.Size(300, 80);
        }
    }
}
