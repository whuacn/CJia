using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 日期控件
    /// </summary>
    public class CJiaDate:DevExpress.XtraEditors.DateEdit
    {
        /// <summary>
        /// CJiaDate构造函数
        /// </summary>
        public CJiaDate()
        {
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.EditFormat.FormatString = "yyyy-MM-dd";
            Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.Mask.EditMask = "yyyy-MM-dd";
            Properties.ShowToday = false;
            Properties.ShowClear = false;
            Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Size = new System.Drawing.Size(115, 22);
        }
    }
}
