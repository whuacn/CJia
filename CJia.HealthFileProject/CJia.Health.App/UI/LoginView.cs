using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class LoginView : CJia.Health.Tools.View, CJia.Health.Views.ILoginView
    {//DevExpress.XtraEditors.XtraUserControl
        public LoginView()
        {
            InitializeComponent();
            Init();
            cJiaLabel6.Text = "Version V" + CJia.Health.Tools.ConfigHelper.GetAppStrings("Version");
        }
        protected override object CreatePresenter()
        {
            return new Presenters.LoginViewPresenter(this);
        }
        /// <summary>
        /// 登录参数设置
        /// </summary>
        Views.LoginEventArgs loginEventArgs = new Views.LoginEventArgs();

        #region ILoginView成员
        //登录事件
        public event EventHandler<Views.LoginEventArgs> OnLogin;
        //用户名输入框获得焦点
        public void TxtUserNOFocus()
        {
            txtUserName.Focus();
            txtUserName.SelectAll();
        }
        #endregion

        #region 界面事件
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            if (!isRightUser()) return;
            loginEventArgs.UserNo = txtUserName.Text;
            loginEventArgs.Password = txtPassword.Text;
            if (ckUser.Checked)
                RememberUserNO();
            if (OnLogin != null) OnLogin(sender, loginEventArgs);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pnlLogin_Click(sender, e);
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraEditors.TextEdit).Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraEditors.TextEdit).Properties.Appearance.BackColor = System.Drawing.Color.White; ;
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            this.closeBtn.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(213)))), ((int)(((byte)(118)))));
            this.closeBtn.Properties.Appearance.Options.UseBackColor = true;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            this.closeBtn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
        }

        private void pnlLogin_MouseEnter(object sender, EventArgs e)
        {
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(71)))));
        }

        private void pnlLogin_MouseLeave(object sender, EventArgs e)
        {
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(60)))));
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 界面校验
        /// </summary>
        /// <returns></returns>
        bool isRightUser()
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
        /// 获得上次记住的用户名
        /// </summary>
        void Init()
        {
            string userNO = CJia.Health.Tools.ConfigHelper.GetAppStrings("UserNO");
            txtUserName.Text = userNO;
        }
        /// <summary>
        /// 记住用户名
        /// </summary>
        void RememberUserNO()
        {
            string userNO = txtUserName.Text;
            CJia.Health.Tools.ConfigHelper.UpdateAppStrings("UserNO", userNO);
        }
        #endregion
    }
}
