using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.CheckRegOrder.App
{
    public partial class Login : Form
    {
        /// <summary>
        /// 判断是否成功登录
        /// </summary>
        public bool isSuccessLogin = false;
        public Login()
        {
            InitializeComponent();
            LoadLoginView();
        }
        /// <summary>
        /// 加载LoginView
        /// </summary>
        public void LoadLoginView()
        {
            UI.LoginView loginUC = new UI.LoginView();
            this.Controls.Add(loginUC);
            loginUC.Dock = DockStyle.Fill;
            loginUC.SuccessCloseLoginFormEvent += loginUC_SuccessCloseLoginFormEvent;
            loginUC.CloseLoginFormEvent += loginUC_CloseLoginFormEvent;
        }

        void loginUC_SuccessCloseLoginFormEvent(object sender, HandledEventArgs e)
        {
            isSuccessLogin = true;
            this.Close();
        }
        void loginUC_CloseLoginFormEvent(object sender, HandledEventArgs e)
        {
            this.Close();
        }
       
    }
}
