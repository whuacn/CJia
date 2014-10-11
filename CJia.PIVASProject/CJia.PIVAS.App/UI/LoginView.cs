using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 登录的UI层
    /// </summary>
    public partial class LoginView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.ILoginView
    {
        /// <summary>
        /// 登录的构造方法
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            //Init();
        }

        //重写创建P层的方法
        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }

        //登录的单击事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        //密码输入完毕之后按anter直接登录
        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        //用户登录方法
        private void Login()
        {
            CJia.PIVAS.Views.LoginEventArgs loginArgs = new Views.LoginEventArgs();
            loginArgs.UserNo = txtUserAccount.Text;
            UI.DataManage.AddUserView adduser = new DataManage.AddUserView();
            loginArgs.Password = CJia.PIVAS.Common.EncryptString(txtUserPassword.Text);
            this.OnLogin(null, loginArgs);
        }


        //点击取消退出登录
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region 【实现接口】

        /// <summary>
        /// 登录
        /// </summary>
        public event EventHandler<Views.LoginEventArgs> OnLogin;

        /// <summary>
        /// 登录失败
        /// </summary>
        public void ExeLoginFail()
        {
            CJia.PIVAS.Tools.Message.ShowWarning("用户名或密码错误！");
            txtUserAccount.Focus();
            txtUserAccount.SelectAll();
        }

        #endregion
    }
}
