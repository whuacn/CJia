using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class LoginScanningView : Tools.View, CJia.PIVAS.Views.ILoginScanningView
    {
        public bool succeed = false;
        public DataTable userData = null;
        public string no;

        public LoginScanningView(string no)
        {
            InitializeComponent();
            this.no = no;
        }

        //重写创建P层的方法
        protected override object CreatePresenter()
        {
            return new Presenters.LoginScanningPresenter(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login();
        }

        private void login()
        {
            Views.LoginScanningEventArgs loginScanningEventArgs = new Views.LoginScanningEventArgs()
            {
                userId = this.txtUserId.Text.Trim().ToUpper(),
                password = CJia.PIVAS.Common.EncryptString(this.txtPassword.Text),
                no = this.no
            };
            this.OnLogin(null, loginScanningEventArgs);
        }

        #region ILoginScanningView 成员

        public event EventHandler<Views.LoginScanningEventArgs> OnLogin;

        public void ExeLogin(bool succeed, string message, DataTable result)
        {
            if(succeed)
            {
                this.succeed = true;
                this.userData = result;
                this.FindForm().Close();
            }
            else
            {
                this.txtUserId.Focus();
                this.txtUserId.SelectAll();
                this.txtPassword.Text = "";
                this.label3.Text = message;
                this.label3.Visible = true;
                this.succeed = false;
                this.userData = null;
            }
        }

        #endregion

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            this.label3.Visible = false;
            if(e.KeyData == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            this.label3.Visible = false;
            if(e.KeyData == Keys.Enter)
            {
                this.login();
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
