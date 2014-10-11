using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.HISOLAP.App.Tools
{
    public partial class StringLengthHelper : UserControl
    {
        public StringLengthHelper()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取字符所占用的长度
        /// </summary>
        /// <param name="str">原字符</param>
        /// <returns>字符所占用的长度</returns>
        public float StringLength(string str,Font font)
        {
            this.label.Font = font;
            this.label.Text = str;
            return this.label.Width;
        }
    }
}
