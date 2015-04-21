using CJia.Health.App.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CJia.Health.App
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Init();
            string isDev = CJia.Health.Tools.ConfigHelper.GetAppStrings("isDev");
            if (isDev == "0")
            {
                LoginWaitFrm frm = new LoginWaitFrm();
                frm.Show();
                Application.DoEvents();
                UI.LoginView login = new UI.LoginView();
                frm.Close();
                CJia.Health.Tools.Help.NewNoBorderForm(login);
            }
            else
            {
                LoginFrom log = new LoginFrom();
                log.ShowDialog();
            }
            if (User.IsLoginSuccess)
            {
                Application.Run(new NewMainForm());
            }
            //Application.Run(new Form1());
        }

        static void Init()
        {
            CJia.ClientConfig.ServerIP = CJia.Health.Tools.ConfigHelper.GetAppStrings("Host");
            CJia.ClientConfig.ServerPort = int.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("Port"));
            CJia.ClientConfig.ClientNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("ClientNo");
            CJia.ClientConfig.SystemNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("SystemNo");
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Message.ShowWarning(e.Exception.Message);
        }

    }
}
