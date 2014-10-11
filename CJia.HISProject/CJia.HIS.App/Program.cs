using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Configuration;
using System.Configuration;
using System.Reflection;

namespace CJia.HIS.App
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

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //初始化配置文件配置并检查配置是否正确
            if(SystemInitConfig())
            {
                Tools.ShowForm.ShowLogin();
                if(CJia.HIS.SystemInfo.IsLoginSucceed)
                {
                    Tools.ShowForm.ShowSelectSytem();
                    if(CJia.HIS.SystemInfo.loginSystem != null)
                    {
                        HISMainForm hisMainForm = new HISMainForm();
                        Application.Run(hisMainForm);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns>配置文件初始化是否成功</returns>
        private static bool SystemInitConfig()
        {
            try
            {
                string ServerIP = ConfigurationSettings.AppSettings["ServerIP"];
                int ServerPort = int.Parse(ConfigurationSettings.AppSettings["ServerPort"]);
                string ClientNo = ConfigurationSettings.AppSettings["ClientNo"];
                string SystemNo = ConfigurationSettings.AppSettings["SystemNo"];
                CJia.ClientConfig.ServerIP = ServerIP;
                CJia.ClientConfig.ServerPort = ServerPort;
                CJia.ClientConfig.ClientNo = ClientNo;
                CJia.ClientConfig.SystemNo = SystemNo;
                if(CJia.DefaultData.QueryScalar("select 1 from dual") == "1")
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

