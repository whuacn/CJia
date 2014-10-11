using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    public class CJiaCheckedComboBox : DevExpress.XtraEditors.CheckedComboBoxEdit
    {
        /// <summary>
        /// CJiaCheckedComboBox构造函数
        /// </summary>
        public CJiaCheckedComboBox()
        {
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            Properties.AppearanceDropDown.Options.UseTextOptions = true;
            Properties.AppearanceDropDown.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            Properties.AppearanceFocused.Options.UseTextOptions = true;
            Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.PopupFormMinSize = new System.Drawing.Size(160, 150);
            Properties.PopupFormSize = new System.Drawing.Size(160, 150);
            Properties.PopupSizeable = false;
            Properties.SelectAllItemCaption = "(全选)";
            Size = new System.Drawing.Size(160, 22);
        }
    }
}
