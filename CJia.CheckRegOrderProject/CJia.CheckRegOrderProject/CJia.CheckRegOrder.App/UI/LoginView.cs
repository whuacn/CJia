using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class LoginView :CJia.Editors.View, Views.ILoginView
    {// CJia.Editors.View
        public LoginView()
        {
            InitializeComponent();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }
        /// <summary>
        /// 登录成功后关闭窗体事件
        /// </summary>
        public event HandledEventHandler SuccessCloseLoginFormEvent;
        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        public event HandledEventHandler CloseLoginFormEvent;
        /// <summary>
        /// 参数设置
        /// </summary>
        Views.LoginArgs loginArgs = new Views.LoginArgs();
        /// <summary>
        /// 界面校验
        /// </summary>
        /// <returns></returns>
        bool isRightUser()
        {
            if (UserNO.Length == 0)
            {
                MessageBox.Show("工号不能为空");
                txtUserNO.Focus();
                return false;
            }
            if (Password.Length == 0)
            {
                MessageBox.Show("密码不能为空");
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        #region ILogin 成员
        public string UserNO
        {
            get
            {
                return txtUserNO.Text.Trim();
            }
        }
        public string Password
        {
            get
            {
                return txtPassword.Text.Trim();
            }
        }
        public event EventHandler<Views.LoginArgs> OnLogin;
        public void TxtUserNOFocus()
        {
            txtUserNO.Focus();
            txtUserNO.SelectAll();
        }
        public void ExeLogin(DataTable Userdata, DataTable LoginTime)
        {
            User.UserID = int.Parse(Userdata.Rows[0]["user_id"].ToString());  //将用户登录信息保存
            User.UserName = Userdata.Rows[0]["user_name"].ToString();
            User.LoginDateTime = LoginTime.Rows[0][0].ToString();
            if (SuccessCloseLoginFormEvent != null)
            {
                SuccessCloseLoginFormEvent(null, null);
            }
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!isRightUser()) return;
            loginArgs.UserNO = UserNO;
            loginArgs.Password = Password;
            if (OnLogin != null) OnLogin(sender,loginArgs);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseLoginFormEvent(null, null);
        }
        private void txtUserNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(null, null);
            }
        }
        
    }
}
