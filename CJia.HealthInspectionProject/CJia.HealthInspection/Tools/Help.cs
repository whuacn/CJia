using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace CJia.HealthInspection.Tools
{
    public static class Help
    {
        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns>配置文件初始化是否成功</returns>
        public static bool SystemInitConfig()
        {
            try
            {
                CJia.ClientConfig.ServerIP = CJia.HealthInspection.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.HealthInspection.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.HealthInspection.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.HealthInspection.Tools.ConfigHelper.GetAppStrings("SystemNo");
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
            catch (Exception ex)
            {
                MessageBox.Show("配置文件配置错误，错误原因:" + ex.Message + "。");
                return false;
            }
        }
        /// <summary>
        /// 新建无边框的窗体
        /// </summary>
        /// <param name="uc"></param>
        public static void NewNoBorderForm(UserControl uc)
        {
            Form frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = uc.Size;
            frm.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            frm.ShowDialog();
        }
        /// <summary>
        /// 根据文件路径名将文件转换为二进制数组
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static byte[] GetBytesByFilePath(string filePath)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] imgData = new byte[fs.Length];
            fs.Read(imgData, 0, (int)fs.Length);
            fs.Close();
            return imgData;
        }
        /// <summary>
        /// 把二进制数组转换成图片
        /// </summary>
        /// <param name="imgData"></param>
        /// <returns></returns>
        public static Image GetImageByBytes(byte[] imgData)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms, true);
            return img;
        }
        /// <summary>
        /// 远程连接
        /// </summary>
        /// <param name="remoteHost">主机IP</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool Connect(string remoteHost, string userName, string passWord)
        {
            bool Flag = true;
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            try
            {
                proc.Start();
                string command = @"net  use  \\" + remoteHost + "  " + passWord + "  " + "  /user:" + userName + ">NUL";
                proc.StandardInput.WriteLine(command);
                command = "exit";
                proc.StandardInput.WriteLine(command);
                while (proc.HasExited == false)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                if (errormsg != "")
                    Flag = false;
                proc.StandardError.Close();
            }
            catch (Exception ex)
            {
                Flag = false;
                Message.Show(ex.Message);
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }
    }
}
