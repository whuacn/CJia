using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CJia.PEIS.App
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
            if (CJia.PEIS.Tools.Help.SystemInitConfig())
            {
                UI.LoginView loginView = new UI.LoginView();
                CJia.PEIS.Tools.Help.NewNoBorderForm(loginView);//窗体关闭继续执行
                if (User.IsLoginSuccess)
                {
                    UI.HomePageView home = new UI.HomePageView();
                    CJia.PEIS.Tools.Help.NewNoBorderForm(home);//窗体关闭继续执行
                    MainForm mainForm = new MainForm();
                    Application.Run(mainForm);
                }
            }
            //if (CJia.PEIS.Tools.Help.SystemInitConfig())
            //{
            //    UI.InteAssManView ui = new UI.InteAssManView();
            //    UI.DeptView ui = new UI.DeptView();
            //    CJia.PEIS.Tools.Help.NewNoBorderForm(ui);
            //}
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Message.ShowWarning(e.Exception.Message);
        }
    }
}
