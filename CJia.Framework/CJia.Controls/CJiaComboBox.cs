using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 不能绑数据源的下拉框
    /// </summary>
    public class CJiaComboBox:DevExpress.XtraEditors.ComboBoxEdit
    {
        /// <summary>
        /// CJiaComboBox构造函数
        /// </summary>
        public CJiaComboBox()
        {
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            Size = new System.Drawing.Size(135, 22);
        }
    }
}
