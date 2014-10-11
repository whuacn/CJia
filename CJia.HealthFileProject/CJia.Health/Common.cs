using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health
{
    public class Common
    {
        /// <summary>
        /// 判断输入框是否不为为空
        /// </summary>
        /// <param name="ControlName"></param> 
        /// <param name="Name"></param>
        public static bool CheckIsNotNull(DevExpress.XtraEditors.XtraUserControl con, string ControlName, string Name)
        {
            CJia.Controls.CJiaTextBox text = con.Controls.Find(ControlName, true)[0] as CJia.Controls.CJiaTextBox;
            if (text.Text == "")
            {
                MessageBox.Show(Name + "不能为空");
                text.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool CheckLpIsNotNull(DevExpress.XtraEditors.XtraUserControl con, string ControlName, string Name)
        {
            CJia.Controls.CJiaRTLookUp lu = con.Controls.Find(ControlName, true)[0] as Controls.CJiaRTLookUp;
            if (lu.EditValue == "")
            {
                MessageBox.Show(Name + "不能为空");
                lu.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
