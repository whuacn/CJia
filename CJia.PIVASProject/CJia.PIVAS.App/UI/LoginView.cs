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
    /// ��¼��UI��
    /// </summary>
    public partial class LoginView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.ILoginView
    {
        /// <summary>
        /// ��¼�Ĺ��췽��
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            //Init();
        }

        //��д����P��ķ���
        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }

        //��¼�ĵ����¼�
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        //�����������֮��anterֱ�ӵ�¼
        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        //�û���¼����
        private void Login()
        {
            CJia.PIVAS.Views.LoginEventArgs loginArgs = new Views.LoginEventArgs();
            loginArgs.UserNo = txtUserAccount.Text;
            UI.DataManage.AddUserView adduser = new DataManage.AddUserView();
            loginArgs.Password = CJia.PIVAS.Common.EncryptString(txtUserPassword.Text);
            this.OnLogin(null, loginArgs);
        }


        //���ȡ���˳���¼
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region ��ʵ�ֽӿڡ�

        /// <summary>
        /// ��¼
        /// </summary>
        public event EventHandler<Views.LoginEventArgs> OnLogin;

        /// <summary>
        /// ��¼ʧ��
        /// </summary>
        public void ExeLoginFail()
        {
            CJia.PIVAS.Tools.Message.ShowWarning("�û������������");
            txtUserAccount.Focus();
            txtUserAccount.SelectAll();
        }

        #endregion
    }
}
