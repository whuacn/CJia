using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    public class TxtPassword : CJiaTextBox
    {
        /// <summary>
        /// TxtPassword构造函数
        /// </summary>
        public TxtPassword()
        {
            Properties.PasswordChar ='*';
        }
    }
}
