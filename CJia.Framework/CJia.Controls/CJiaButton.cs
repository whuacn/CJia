using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CJia.Controls
{
    /// <summary>
    /// 按钮
    /// </summary>
    public class CJiaButton : DevExpress.XtraEditors.SimpleButton
    {
        /// <summary>
        /// 自定义文本
        /// F1:帮助 F2:增加 F3:修改 F4:取消 F5:查询/刷新 F6:删除/减少 F7:打印
        /// F8:保存/确定 F9:打印/重打印 F10，F11，F12为自定义按钮快捷键
        /// </summary>
        protected string baseText = string.Empty;
        /// <summary>
        /// 是否显示缺省文本
        /// </summary>
        protected bool isShowDefaultText = true;
        /// <summary>
        /// CJiaBtn构造函数
        /// </summary>
        public CJiaButton()
        {
            TextChanged += new EventHandler(CJiaButton_TextChanged);
            Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            Appearance.Options.UseFont = true;
            Appearance.Options.UseForeColor = true;
            LookAndFeel.SkinName = "Office 2010 Blue";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(80, 28);
        }
        /// <summary>
        ///按钮文本改变事件
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        public void CJiaButton_TextChanged(object sender, EventArgs e)
        {
            if (isShowDefaultText)
            {
                //确保控件的Text为初始值，但又能修改Text属性；
                (sender as CJiaButton).Text = this.baseText;
            }
        }
        /// <summary>  
        /// 添加按钮上鼠标 移入、移出、按下、弹起 事件  
        /// </summary>  
        /// <param name="btn">操作的按钮</param>  
        public void AddBtnEvent(Button btn)
        {
            btn.MouseEnter += delegate(object sender, EventArgs e)
            {
                ((Button)sender).BackgroundImage = Properties.Resources.backgroundOn;
            };
            btn.MouseLeave += delegate(object sender, EventArgs e)
            {
                ((Button)sender).BackgroundImage = Properties.Resources.backgroundNormal;
            };
            btn.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                ((Button)sender).BackgroundImage = Properties.Resources.backgroundClick;
            };
            btn.MouseUp += delegate(object sender, MouseEventArgs e)
            {
                ((Button)sender).BackgroundImage = Properties.Resources.backgroundNormal;
            };
        }
        /// <summary>
        /// 设置是否捕获焦点（false为不捕获）
        /// </summary>
        public bool Selectable
        {
            get { return this.GetStyle(System.Windows.Forms.ControlStyles.FixedHeight); }
            set { this.SetStyle(System.Windows.Forms.ControlStyles.Selectable, value); }
        }
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("自定义文本")]
        public string CustomText
        {
            get { return baseText; }
            set
            {
                baseText = value;
                this.Text = value;
            }
        }
    }
}
