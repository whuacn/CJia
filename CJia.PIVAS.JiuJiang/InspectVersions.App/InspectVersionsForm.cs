using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace InspectVersions.App
{
    public partial class InspectVersionsForm : Form
    {
        public InspectVersionsForm()
        {
            InitializeComponent();
            this.init();
        }

        string ServerIP
        {
            get
            {
                return InspectVersions.App.ConfigHelper.GetAppStrings("ServerIP");
            }
        }

        bool IsUpdate
        {
            get
            {
                if(InspectVersions.App.ConfigHelper.GetAppStrings("IsUpdate") == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string userAccount = "Administrator";

        private string userPassword = "jjbjy";

        private string directory = "PIVAS";

        private void init()
        {
            if(IsUpdate)
            {
                if(this.Connect(this.ServerIP, userAccount, userPassword))
                {
                    DirectoryInfo serverInfo = new DirectoryInfo(@"\\" + ServerIP + @"\" + directory);
                    FileInfo[] serverFiles = serverInfo.GetFiles("*", SearchOption.AllDirectories);

                    DirectoryInfo clientInfo = new DirectoryInfo(Application.StartupPath);
                    FileInfo[] clientFiles = clientInfo.GetFiles("*", SearchOption.AllDirectories);

                    if(serverFiles.Length > 0)
                    {
                        foreach(FileInfo serverFile in serverFiles)
                        {
                            string clientDirectory = serverFile.DirectoryName.Replace(@"\\" + ServerIP + @"\" + directory, Application.StartupPath);
                            List<FileInfo> selectFile = clientFiles.Where(t => t.FullName.Replace(Application.StartupPath, "") == serverFile.FullName.Replace(@"\\" + ServerIP + @"\" + directory, "")).ToList();
                            if(selectFile == null || selectFile.Count < 1)
                            {
                                if(!Directory.Exists(clientDirectory))
                                {
                                    Directory.CreateDirectory(clientDirectory);
                                }
                                File.Copy(serverFile.FullName, serverFile.FullName.Replace(@"\\" + ServerIP + @"\" + directory, Application.StartupPath), true);
                            }
                            else
                            {
                                if(selectFile[0].LastWriteTime < serverFile.LastWriteTime)
                                {
                                    File.Copy(serverFile.FullName, selectFile[0].FullName, true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("无法连接到版本控制服务器");
                }
            }
            Process.Start(Application.StartupPath + @"\" + "CJia.PIVAS.App.exe");
        }



        /// <summary>
        /// 远程连接
        /// </summary>
        /// <param name="remoteHost">主机IP</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public bool Connect(string remoteHost, string userName, string passWord)
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
                while(proc.HasExited == false)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                if(errormsg != "")
                    Flag = false;
                proc.StandardError.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Flag = false;
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
