﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Data;
using DevExpress.XtraGrid.Views.Base;

namespace CJia.Parking.Tools
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
                CJia.ClientConfig.ServerIP = CJia.Parking.Tools.ConfigHelper.GetAppStrings("Host");
                CJia.ClientConfig.ServerPort = int.Parse(CJia.Parking.Tools.ConfigHelper.GetAppStrings("Port"));
                CJia.ClientConfig.ClientNo = CJia.Parking.Tools.ConfigHelper.GetAppStrings("ClientNo");
                CJia.ClientConfig.SystemNo = CJia.Parking.Tools.ConfigHelper.GetAppStrings("SystemNo");
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
            //panel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(36))))); // 边框颜色（红色）
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
            fs.Read(imgData, 0, Convert.ToInt32(fs.Length));
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
            Image img = Image.FromStream(ms, true);
            ms.Close();
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

        /// <summary>
        /// 当Grid为空时提示文字
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GridViewDrawEmptyForeground(DevExpress.XtraGrid.Views.Grid.GridView gridView, object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            BindingSource bindingSource = gridView.DataSource as BindingSource;

            if (bindingSource == null || bindingSource.Count == 0)
            {
                string str = "没有查询到你所想要的数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Top + 55, e.Bounds.Left + 35, e.Bounds.Right - 35, e.Bounds.Height - 35);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
        }

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        public static DateTime Sysdate
        {
            get
            {
                return DateTime.Parse(CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
            }
        }
    }
}

#region 【内部用户类，用于加载checkedListBox控件，以及返回对象】
public class InnerUser
{
    private DataRow dr;
    string FieldId;
    string FieldName;
    public InnerUser(DataRow dr, string fieldId, string fieldName)
    {
        this.dr = dr;
        this.FieldId = fieldId;
        this.FieldName = fieldName;
    }
    public override string ToString()//一定要注意重载  
    {
        return dr[FieldName].ToString();
    }
    public string GetFieldName()
    {
        return this.ToString();
    }
    public long GetFieldID()
    {
        return long.Parse(dr[FieldId].ToString());
    }
}
#endregion
