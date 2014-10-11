using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CJia.Parking.App
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
            if (CJia.Parking.Tools.Help.SystemInitConfig())
            {
                Form frm = new Form();
                frm.Width = 451;
                frm.Height = 273;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.StartPosition = FormStartPosition.CenterScreen;
                UI.LoginView loginView = new UI.LoginView();
                frm.Controls.Add(loginView);
                loginView.Dock = DockStyle.Fill;
                frm.ShowDialog();
                if (CJia.Parking.User.IsLoginSuccess)
                {
                    MainForm mfrm = new MainForm();
                    mfrm.WindowState = FormWindowState.Maximized;
                    mfrm.ShowDialog();
                    mfrm.Dispose();
                    while (mfrm.isLogOff)
                    {
                        mfrm = new MainForm();
                        mfrm.WindowState = FormWindowState.Maximized;
                        mfrm.ShowDialog();
                    }
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Message.ShowWarning(e.Exception.Message);
        }
    }
}
