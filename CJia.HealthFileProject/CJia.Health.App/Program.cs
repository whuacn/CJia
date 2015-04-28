using CJia._3LevelReview.App;
using CJia.Health.App.UI;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            if (AppRunAlready("WSLPrinter.App"))
            {
                MessageBox.Show("程序已启动！");
                return;
            }
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
                SplashScreenManager.ShowForm(typeof(SplashScreenMain));
                Application.Run(new NewMainForm());
            }
            //Application.Run(new Form1());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Message.ShowWarning((e.ExceptionObject as Exception).Message);
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            NlogMonitor.LogMonitor.Info("错误日志：" + str);
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
            string str = GetExceptionMsg(e.Exception, e.ToString());
            NlogMonitor.LogMonitor.Info("错误日志：" + str);
        }
        ///<summary>   
        /// 验证是否已经运行
        /// </summary>
        public static bool AppRunAlready(string appName)
        {
            Process[] app = Process.GetProcessesByName(appName);
            return app.Length > 1;
        }
        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
