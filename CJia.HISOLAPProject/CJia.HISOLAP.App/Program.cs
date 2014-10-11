using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CJia.HISOLAP.App
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
            if (SystemInitConfig())
                Application.Run(new frmMain());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Message.ShowWarning(e.Exception.Message);
        }


        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns>配置文件初始化是否成功</returns>
        private static bool SystemInitConfig()
        {
            try
            {
                CJia.ClientConfig.ServerIP = ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = ConfigHelper.GetAppStrings("HQMSClientNo");
                CJia.ClientConfig.SystemNo = ConfigHelper.GetAppStrings("HQMSSystemNo");
                if (CJia.DefaultOleDb.QueryScalar("select 1 from dual") == "1")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("配置文件配置错误，数据库访问异常。");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
