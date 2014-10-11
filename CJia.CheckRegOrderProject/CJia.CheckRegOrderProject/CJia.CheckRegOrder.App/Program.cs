using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace CJia.CheckRegOrder.App
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
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);//抛出错误
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            string Host = System.Configuration.ConfigurationManager.AppSettings["Host"];
            string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];
            string ClientNo = System.Configuration.ConfigurationManager.AppSettings["ClientNo"];
            string SystemNo = System.Configuration.ConfigurationManager.AppSettings["SystemNo"];
            CJia.ClientConfig.ClientNo = ClientNo;
            CJia.ClientConfig.SystemNo = SystemNo;
            CJia.ClientConfig.ServerIP = Host;
            CJia.ClientConfig.ServerPort = Convert.ToInt32(Port);
            Login frm = new Login();
            frm.ShowDialog();
            if (frm.isSuccessLogin)
            {
                Application.Run(new MainForm());
            }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);//用messagebox形式抛出错误
        }
    }
}
