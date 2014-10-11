using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// 搜索框
    /// </summary>
    public class CJiaTextSearch:DevExpress.XtraEditors.ButtonEdit
    {
        /// <summary>
        /// CJiaTextSearch构造函数
        /// </summary>
        public CJiaTextSearch()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();            
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            Properties.Appearance.ForeColor = System.Drawing.Color.LightGray;
            Properties.Appearance.Options.UseBorderColor = true;
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseForeColor = true;
            toolTipItem1.Text = "查询";
            superToolTip1.Items.Add(toolTipItem1);
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CJia.Controls.Properties.Resources.Bigsearch ,new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(300, 32);
            Enter += CJiaTextSearch_Enter;
            Leave += CJiaTextSearch_Leave;
        }
        void CJiaTextSearch_Leave(object sender, EventArgs e)
        {
            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            string searchValue = this.Text.ToString().Trim();
            if (searchValue.Length == 0)
            {
                this.Text = PointText;
            }
        }

        void CJiaTextSearch_Enter(object sender, EventArgs e)
        {
            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            string searchValue = this.Text.ToString().Trim();
            if (searchValue.Length > 0 && searchValue == PointText)
            {
                this.Text = "";
            }
        }

        private string pointText = string.Empty;
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("输入框提示文本")]
        public string PointText
        {
            get { return pointText; }
            set
            {
                pointText = value;
                this.Text = value;
            }
        }
    }
}
