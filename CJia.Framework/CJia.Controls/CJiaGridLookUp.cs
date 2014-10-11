using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 查询下拉框
    /// </summary>
    public class CJiaGridLookUp : DevExpress.XtraEditors.GridLookUpEdit
    {
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaGridLookUp1View;
        /// <summary>
        /// CJiaGridLookUp构造函数
        /// </summary>
        public CJiaGridLookUp()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            cJiaGridLookUp1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            Properties.ShowFooter = false;
            Size = new System.Drawing.Size(150, 22);
            Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Properties.View.BestFitColumns();
            Properties.ImmediatePopup = true;
            Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.
            Properties.View = cJiaGridLookUp1View;
            //SizeChanged += CJiaGridLookUp_SizeChanged;
            // 
            // cJiaGridLookUp1View
            // 
            cJiaGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            cJiaGridLookUp1View.Name = "cJiaGridLookUp1View";
            cJiaGridLookUp1View.OptionsBehavior.AutoPopulateColumns = false;
            cJiaGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            cJiaGridLookUp1View.OptionsCustomization.AllowFilter = false;
            cJiaGridLookUp1View.OptionsView.ShowGroupPanel = false;
        }

        void CJiaGridLookUp_SizeChanged(object sender, EventArgs e)
        {
            Properties.PopupFormMinSize = new System.Drawing.Size(Size.Width, Size.Width);
            Properties.PopupFormSize = new System.Drawing.Size(Size.Width, Size.Width);
        }

    }
   
}
