using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace CJia.HIS.App.Tools
{
    public static class ShowForm
    {
        /// <summary>
        /// 将登陆窗口 ShowDialog 出来
        /// </summary>
        public static void ShowLogin()
        {
            DevExpress.XtraEditors.XtraForm login = new DevExpress.XtraEditors.XtraForm();
            login.AutoSize = true;
            login.FormBorderStyle = FormBorderStyle.FixedDialog;
            login.MaximizeBox = false;
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Text = ConfigurationSettings.AppSettings["SystemName"] + "登录";
            UI.LoginView loginView = new UI.LoginView();
            login.Controls.Add(loginView);
            login.ShowDialog();
        }

        /// <summary>
        /// 将系统选择窗口 ShowDialog 出来
        /// </summary>
        public static void ShowSelectSytem()
        {
            DevExpress.XtraEditors.XtraForm selectSystem = new DevExpress.XtraEditors.XtraForm();
            selectSystem.AutoSize = true;
            selectSystem.FormBorderStyle = FormBorderStyle.FixedDialog;
            selectSystem.MaximizeBox = false;
            selectSystem.Text = "选择子系统";
            UI.SelectSystemView selectSystemView = new UI.SelectSystemView();
            selectSystem.Controls.Add(selectSystemView);
            selectSystem.StartPosition = FormStartPosition.CenterScreen;
            selectSystem.ShowDialog();
        }

        /// <summary>
        /// 初始化系统对应的容器
        /// </summary>
        /// <returns>返回生成的容器</returns>
        public static UserControl CreaterContainer()
        {
            string assemblyName = CJia.HIS.SystemInfo.loginSystem["PAGE_CONTAINER_ASM"].ToString();
            string typeName = CJia.HIS.SystemInfo.loginSystem["PAGE_CONTAINER"].ToString();
            object[] parameters = new object[0];
            DevExpress.XtraEditors.XtraUserControl userControl = CJia.HIS.App.Tools.Reflection.GetInstance(assemblyName, typeName, parameters) as DevExpress.XtraEditors.XtraUserControl;
            userControl.Dock = DockStyle.Fill;
            return userControl;
        }
    }
}
