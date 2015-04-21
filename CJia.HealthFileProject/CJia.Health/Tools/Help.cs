using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Net;

namespace CJia.Health.Tools
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
                CJia.ClientConfig.ServerIP = CJia.Health.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.Health.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.Health.Tools.ConfigHelper.GetAppStrings("SystemNo");
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
        /// 使用show()方法显示窗体，用于提示（loading...)
        /// </summary>
        /// <param name="uc"></param>
        public static void NewRedBorderFrom(UserControl uc)
        {
            Form frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = uc.Size;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            DevExpress.XtraEditors.PanelControl panel = new DevExpress.XtraEditors.PanelControl();
            panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            panel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            panel.Appearance.Options.UseBackColor = true;
            panel.Appearance.Options.UseBorderColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            panel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            panel.LookAndFeel.UseDefaultLookAndFeel = false;
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(panel);
            frm.ShowInTaskbar = false;
            frm.TopMost = true;
            frm.Show();
            frm.Refresh();
        }
        /// <summary>
        /// 新建有边框颜色的窗体
        /// </summary>
        /// <param name="uc"></param>
        public static void NewBorderForm(UserControl uc)
        {
            Form frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = uc.Size;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Size = new System.Drawing.Size(uc.Width + 15, uc.Height + 30);
            frm.AutoSize = true;
            DevExpress.XtraEditors.PanelControl panel = new DevExpress.XtraEditors.PanelControl();
            panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            panel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            panel.Appearance.Options.UseBackColor = true;
            panel.Appearance.Options.UseBorderColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            panel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            panel.LookAndFeel.UseDefaultLookAndFeel = false;
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(panel);
            frm.ShowDialog();
        }
        /// <summary>
        /// 新建有边框颜色的窗体(带标题)
        /// </summary>
        /// <param name="uc"></param>
        public static void NewBorderForm(string caption, UserControl uc)
        {
            System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
            frmBase.Text = caption;
            frmBase.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmBase.MaximizeBox = false;
            frmBase.MinimizeBox = false;

            frmBase.Size = new System.Drawing.Size(uc.Width + 5, uc.Height + 5);
            frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(uc);
            //UControl.Parent = frmBase;
            uc.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            frmBase.ShowDialog();
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
        /// 将uri资源转换为图片
        /// </summary>
        /// <param name="uri">uri</param>
        /// <param name="userName">用户名 凭证(可以为空)</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static Image GetImageByUri(string uri,string userName,string password)
        {
            try
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.Credentials = new NetworkCredential(userName, password);
                byte[] bytes = myWebClient.DownloadData(uri);
                Image image = GetImageByBytes(bytes);
                return image;
            }
            catch
            {
                return null;
            }
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

        #region datatable 操作
        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static DataTable GetDataSource(DataRow[] rows)
        {
            if(rows != null && rows.Length != 0)
            {
                DataTable result = rows[0].Table.Clone();
                for(int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// DATA 加 row
        /// </summary>
        /// <param name="nowCount"></param>
        /// <returns></returns>
        public static void DataAddRow(DataTable tabel, DataRow[] rows)
        {
            if(rows != null && rows.Length != 0)
            {
                foreach(DataRow row in rows)
                {
                    DataRow nowRow = tabel.NewRow();
                    nowRow.ItemArray = row.ItemArray;
                    tabel.Rows.Add(nowRow);
                }
            }
        }

        /// <summary>
        /// 判断该datatable中是否有数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsNull(this DataTable dt)
        {
            if(dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 图片操作
        /// <summary>
        /// 实际尺寸 合适尺寸
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="bol">true表示实际尺寸</param>
        public static void InFactSize(CJia.Controls.CJiaPicture pic, bool bol)
        {
            if (pic.Image != null)
            {
                Image img = pic.Image;
                if (bol)
                {
                    pic.Width = img.Width;
                    pic.Height = img.Height;
                }
                else
                {
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                }
            }
        }
        /// <summary>
        /// 左 右 旋转
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="bol">true表示左旋转</param>
        public static void XuanZhuang(CJia.Controls.CJiaPicture pic, bool bol)
        {
            if (pic.Image != null)
            {
                Image img = pic.Image;
                if (bol)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                    pic.Image = img;
                }
                else
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    int panel_W = pic.Parent.Width;
                    float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                    pic.Width = panel_W - 20;
                    float height = i * (panel_W - 20);
                    pic.Height = Convert.ToInt32(height);
                    pic.Image = img;
                }
            }
        }
        /// <summary>
        /// 放大 缩小
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="bol">true 放大</param>
        public static void FangDa(CJia.Controls.CJiaPicture pic, bool bol)
        {
            if (pic.Image != null)
            {
                int panel_W = pic.Width;
                Image img = pic.Image;
                float i = float.Parse(img.Height.ToString()) / float.Parse(img.Width.ToString());
                if (bol)
                {
                    if (panel_W + 100 < img.Width)
                    {
                        pic.Width = panel_W + 100;
                        float height = i * (panel_W + 100);
                        pic.Height = Convert.ToInt32(height);
                    }
                }
                else
                {
                    if (panel_W - 100 > 100)
                    {
                        pic.Width = panel_W - 100;
                        float height = i * (panel_W - 100);
                        pic.Height = Convert.ToInt32(height);
                    }
                }
            }
        }
        
        #endregion
    }
}
