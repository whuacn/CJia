using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// 单位输入框
    /// </summary>
    public class CJiaUnitTextBox : DevExpress.XtraEditors.ButtonEdit
    {
        /// <summary>
        /// 单位(cm,kg,mm...)
        /// </summary>
        protected string baseText = string.Empty;
        /// <summary>
        /// CJiaUnitTextBox构造函数
        /// </summary>
        public CJiaUnitTextBox()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject1.Options.UseBackColor = true;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "kg", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.Mask.EditMask = "(-?\\d+)(\\.\\d+)?";
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            Size = new System.Drawing.Size(135, 22);
        }
        /// <summary>
        /// 单位
        /// </summary>
        [Category("CJia属性"), Description("单位")]
        public string UnitText
        {
            get { return baseText; }
            set
            {
                baseText = value;
                this.Properties.Buttons[0].Caption = value;
            }
        }
    }
}
