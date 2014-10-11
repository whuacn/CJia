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
        /// 调增系统名
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




        #region ILoginView 成员

        /// <summary>
        /// 用户输入的用户编号
        /// </summary>
        public string UserNo
        {
            get
            {
                return this.txtUserAccount.Text;
            }
        }

        /// <summary>
        /// 用户输入的密码
        /// </summary>
        public string UserPwd
        {
            get
            {
                return this.txtUserPassword.Text;
            }
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        public event EventHandler LoginEven;

        /// <summary>
        /// 关闭用户自定义所在的窗体
        /// </summary>
        public void CloseForm()
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="mes">返回信息内容</param>
        public void ShowMessage(string mes)
        {
            MessageBox.Show(mes);
            this.txtUserPassword.SelectAll();
            this.txtUserPassword.Focus();
        }



        #endregion
    }
}
