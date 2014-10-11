using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 可绑数据源的下拉框
    /// </summary>
    public class CJiaComboBox2:CJiaGridLookUp
    {
        /// <summary>
        /// CJiaComboBox2构造函数
        /// </summary>
        public CJiaComboBox2()
        {
            Properties.Appearance.Options.UseTextOptions = false;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            Properties.View.OptionsView.ShowColumnHeaders = false;
        }
    }
}
