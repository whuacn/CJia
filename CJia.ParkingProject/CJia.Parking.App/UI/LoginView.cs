using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Parking.App.UI
{
    public partial class LoginView : CJia.Parking.Tools.View, CJia.Parking.Views.ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }

        Views.LoginArgs loginArgs = new Views.LoginArgs();

        #region 【界面事件】

        // 界面渐变色绘制
        private void LoginView_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.SkyBlue, System.Drawing.SystemColors.GradientInactiveCaption);
            //e.Graphics.FillRectangle(brush, e.ClipRectangle);
            //e.Graphics.DrawRectangle(Pens.Plum, new Rectangle(50, 50, 350, 200));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.SteelBlue, System.Drawing.SystemColors.GradientActiveCaption);
            e.Graphics.FillRectangle(brush, e.ClipRectangle);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            User.IsLoginSuccess = false;
            this.ParentForm.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!IsNullReturn())
                return;
            loginArgs.UserNo = txtUserName.Text;
            loginArgs.UserPassword = txtPassword.Text;
            if (chkRemUser.Checked)
                RememberUserNO();
            if (OnLogin != null)
            OnLogin(sender,loginArgs);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }


        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 界面校验
        /// </summary>
        /// <returns></returns>
        bool IsNullReturn()
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("用户名不能为空");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("密码不能为空");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 记住用户名
        /// </summary>
        void RememberUserNO()
        {
            string userNO = txtUserName.Text;
            CJia.Parking.Tools.ConfigHelper.UpdateAppStrings("UserNO", userNO);
        }
        #endregion

        #region 【实现接口】

        //用户名输入框获得焦点
        public void TxtUserNOFocus()
        {
            txtUserName.Focus();
            txtUserName.SelectAll();
        }
        #endregion

        #region 【接口层事件】
        /// <summary>
        /// 登录事件
        /// </summary>
        public event EventHandler<Views.LoginArgs> OnLogin;
        #endregion
      
    }
}
