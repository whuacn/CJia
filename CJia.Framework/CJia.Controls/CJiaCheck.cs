using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 单选框
    /// </summary>
    public class CJiaCheck:DevExpress.XtraEditors.CheckEdit
    {
        /// <summary>
        /// CJiaCheck构造函数
        /// </summary>
        public CJiaCheck()
        {
            Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseBackColor = true;
            Properties.Appearance.Options.UseFont = true;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(75, 21);
            Selectable = false;
        }
        /// <summary>
        /// 设置是否捕获焦点（false为不捕获）
        /// </summary>
        public bool Selectable
        {
            get { return this.GetStyle(System.Windows.Forms.ControlStyles.FixedHeight); }
            set { this.SetStyle(System.Windows.Forms.ControlStyles.Selectable, value); }
        }
    }
}
