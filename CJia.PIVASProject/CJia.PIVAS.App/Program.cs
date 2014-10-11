using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using CJia.PIVAS.App.UI;
using System.IO;

namespace CJia.PIVAS.App
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CJia.PIVAS.App.UI.Label.PrintLabelReport print = new UI.Label.PrintLabelReport();
            //print.PrintLable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            if(SystemInitConfig())
            {
                Form frm = new Form();
                frm.Width = 410;
                frm.Height = 270;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.StartPosition = FormStartPosition.CenterScreen;
                LoginView loginView = new LoginView();
                frm.Controls.Add(loginView);
                loginView.Dock = DockStyle.Fill;
                frm.ShowDialog();
                if (CJia.PIVAS.User.IsLoginSuccess)
                {
                    MainForm mfrm = new MainForm();
                    mfrm.WindowState = FormWindowState.Maximized;
                    Application.Run(mfrm);
                    mfrm.Dispose();
                    deleteLabelPreview();
                }
                
            }
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
                CJia.ClientConfig.ServerIP = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("SystemNo");
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

        //删除瓶贴预览生成的图片文件
        private static void deleteLabelPreview()
        {
            try
            {
                string directory = Application.StartupPath + "\\LabelPreview\\";
                if(Directory.Exists(directory)) //如果存在这个文件夹删除之
                {
                    foreach(string d in Directory.GetFileSystemEntries(directory))
                    {
                        File.Delete(d); //直接删除其中的文件
                    }
                }
            }
            catch
            {

            }
        }
    }
}
