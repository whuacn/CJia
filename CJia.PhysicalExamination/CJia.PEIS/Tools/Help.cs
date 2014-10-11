using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace CJia.PEIS.Tools
{
    public class Help
    {
        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns>配置文件初始化是否成功</returns>
        public static bool SystemInitConfig()
        {
            try
            {
                CJia.ClientConfig.ServerIP = CJia.PEIS.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.PEIS.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.PEIS.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.PEIS.Tools.ConfigHelper.GetAppStrings("SystemNo");
                if (CJia.DefaultPostgre.QueryScalar("select 1") == "1")
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
        public static void NewBorderForm(string caption,UserControl uc)
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
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms,true);
            return img;
        }
    }
}
