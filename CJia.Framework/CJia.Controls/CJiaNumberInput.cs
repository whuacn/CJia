using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// 数字框
    /// </summary>
    public class CJiaNumberInput:DevExpress.XtraEditors.SpinEdit
    {
        /// <summary>
        /// CJiaNumberInput构造函数
        /// </summary>
        public CJiaNumberInput()
        {
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(120, 22);
            this.Validating+=CJiaNumberInput_Validating;
        }

        void CJiaNumberInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.EditValue == null)
            {
                e.Cancel = false;
                return;
            }
            decimal v = 0;
            if (decimal.TryParse(this.EditValue.ToString(), out v))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 数字类型
        /// </summary>
        public enum NumType
        {

            /// <summary>
            /// 任意数值
            /// </summary>
            Decimal,
            /// <summary>
            /// 任意数值2
            /// </summary>
            Decimal2,
            /// <summary>
            /// 仅仅是数值,无小数点（＋－）
            /// </summary>
            OnlyNumber,
            /// <summary>
            /// 仅10个数字
            /// </summary>
            Number10,
            /// <summary>
            /// 2位小数
            /// </summary>
            Radix2,
            /// <summary>
            /// 2位小数（正数）
            /// </summary>
            Radix2_P,
            /// <summary>
            /// 2位小数（负数）
            /// </summary>
            Radix2_N,
            /// <summary>
            /// 4位小数
            /// </summary>
            Radix4,
            /// <summary>
            /// 4位小数（正数）
            /// </summary>
            Radix4_P,
            /// <summary>
            /// 4位小数（负数）
            /// </summary>
            Radix4_N,
            /// <summary>
            /// 正数
            /// </summary>
            OnlyPositive,
            /// <summary>
            /// 正数（不含0）
            /// </summary>
            OnlyPositiveWithout0,
            /// <summary>
            /// 负数
            /// </summary>
            OnlyNegative,
            /// <summary>
            /// 空
            /// </summary>
            None
        }

         private NumType _maskType;

        /// <summary>
        /// 格式类型
        /// </summary>
         [Category("自定义属性"), Description("格式类型")]
         public NumType MaskType
         {
             get
             {
                 return _maskType;
             }
             set
             {
                 _maskType = value;

                 switch (value)
                 {
                     case NumType.Decimal:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[-]?[1-9][0-9]*|[-]?[1-9][0-9]*[.][0-9][1-9]*|[-]?[0][.][0-9][1-9]*|[0]";
                         break;
                     case NumType.Decimal2:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[-]?[1-9][0-9]*|[-]?[1-9][0-9]*[.][0-9]*|[-]?[0][.][0-9]*|[0]";
                         break;
                     case NumType.OnlyNumber:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[1-9][0-9]*|[-][1-9][0-9]*|[0]";
                         break;
                     case NumType.Number10:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[0-9]{1,10}";
                         break;
                     case NumType.Radix2:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f2";
                         break;
                     case NumType.Radix2_P:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f2";
                         break;
                     case NumType.Radix2_N:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f2";
                         break;
                     case NumType.Radix4:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f4";
                         break;
                     case NumType.Radix4_P:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f4";
                         break;
                     case NumType.Radix4_N:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                         this.Properties.Mask.EditMask = "f4";
                         break;
                     case NumType.OnlyPositive:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[1-9][0-9]*|[0]";
                         break;
                     case NumType.OnlyPositiveWithout0:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[1-9][0-9]*";
                         break;
                     case NumType.OnlyNegative:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                         this.Properties.Mask.EditMask = "[-][1-9][0-9]*|[0]";
                         break;
                     case NumType.None:
                         this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                         this.Properties.Mask.EditMask = "";
                         break;
                 }
             }
         }
    }
}
