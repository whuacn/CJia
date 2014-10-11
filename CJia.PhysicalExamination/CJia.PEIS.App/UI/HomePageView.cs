using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PEIS.App.UI
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            Init();
        }

        private void cJiaWin8Panel4_DoubleClick(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cJiaWin8Panel16_DoubleClick(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void HomePageView_Scroll(object sender, ScrollEventArgs e)
        {
            pnlTop.Location = new System.Drawing.Point(e.NewValue, 0);
        }

        #region 内部调用方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (User.UserData == null) return;
            if (User.UserData.Rows[0]["user_image"] != DBNull.Value)
                imgUser.Image = CJia.PEIS.Tools.Help.GetImageByBytes((byte[])User.UserData.Rows[0]["user_image"]);
            lblUserName.Text = User.UserData.Rows[0]["user_name"].ToString();
        }
        #endregion
    }
}
