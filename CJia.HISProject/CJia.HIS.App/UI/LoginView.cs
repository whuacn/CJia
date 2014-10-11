using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace CJia.HIS.App.UI
{
    public partial class LoginView : CJia.HIS.View, Views.ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            Init();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.LoginPresenter(this);
        }

        public void Init()
        {
            AdjustSystemName();
        }

        /// <summary>
        /// ����ϵͳ��
        /// </summary>
        public void AdjustSystemName()
        {
            string systemName = ConfigurationSettings.AppSettings["SystemName"];
            this.lbcSystemName.Text = systemName;
            this.lbcSystemName.Location = new Point((this.Width - this.lbcSystemName.Width) / 2, this.lbcSystemName.Location.Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.LoginEven(sender, e);
        }




        #region ILoginView ��Ա

        /// <summary>
        /// �û�������û����
        /// </summary>
        public string UserNo
        {
            get
            {
                return this.txtUserAccount.Text;
            }
        }

        /// <summary>
        /// �û����������
        /// </summary>
        public string UserPwd
        {
            get
            {
                return this.txtUserPassword.Text;
            }
        }

        /// <summary>
        /// ��¼�¼�
        /// </summary>
        public event EventHandler LoginEven;

        /// <summary>
        /// �ر��û��Զ������ڵĴ���
        /// </summary>
        public void CloseForm()
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="mes">������Ϣ����</param>
        public void ShowMessage(string mes)
        {
            MessageBox.Show(mes);
            this.txtUserPassword.SelectAll();
            this.txtUserPassword.Focus();
        }



        #endregion
    }
}
