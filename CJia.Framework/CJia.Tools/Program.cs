using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace CJia.Tools
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
            SystemInitConfig();

            Application.Run(new MainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns>配置文件初始化是否成功</returns>
        private static bool SystemInitConfig()
        {
            try
            {
                CJia.ClientConfig.ServerIP = ConfigurationSettings.AppSettings["Host"];
                CJia.ClientConfig.ServerPort = int.Parse(ConfigurationSettings.AppSettings["Port"]);
                CJia.ClientConfig.ClientNo = ConfigurationSettings.AppSettings["ClientNo"];
                CJia.ClientConfig.SystemNo = ConfigurationSettings.AppSettings["SystemNo"];
                if(CJia.DefaultOleDb.QueryScalar("select 1 from dual") == "1")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("配置文件配置错误，数据库访问异常。");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("配置文件配置错误，错误原因:" + ex.Message + "。");
                return false;
            }
        }
    }
}
