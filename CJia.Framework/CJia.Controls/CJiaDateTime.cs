using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Controls
{
    /// <summary>
    /// 日期时间控件
    /// </summary>
    public class CJiaDateTime:DevExpress.XtraEditors.DateEdit
    {
        /// <summary>
        /// CJiaDate构造函数
        /// </summary>
        public CJiaDateTime()
        {
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            Properties.ShowToday = false;
            Properties.ShowClear = false;
            Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Size = new System.Drawing.Size(155, 22);
        }
    }
}
