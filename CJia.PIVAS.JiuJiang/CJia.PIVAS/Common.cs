using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;

namespace CJia.PIVAS
{
    /// <summary>
    /// 公共调用类
    /// </summary>
    public static class Common
    {
        #region 加、解密
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">要解密的字符串</param>
        /// <returns></returns>
        public static string DecryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            }

            byte[] byKey = { 0x13, 0x28, 0x35, 0x4E, 0x59, 0x65, 0x71, 0x8F };
            byte[] IV = { 0xFE, 0xDC, 0xCA, 0xB8, 0xA6, 0x04, 0x92, 0x80 };
            byte[] inputByteArray = new Byte[input.Length];
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns></returns>
        public static string EncryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            }

            byte[] byKey = { 0x13, 0x28, 0x35, 0x4E, 0x59, 0x65, 0x71, 0x8F };
            byte[] IV = { 0xFE, 0xDC, 0xCA, 0xB8, 0xA6, 0x04, 0x92, 0x80 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        #endregion

        #region【批次处理】

        ///// <summary>
        ///// 获取到选中的批次
        ///// </summary>
        ///// <returns></returns>
        //public static string GetBatchsName(CheckedListBoxControl clbc)
        //{
        //    string batchasName = "";
        //    for (int i = 0; i < clbc.Items.Count; i++)
        //    {
        //        if (clbc.Items[i].CheckState == CheckState.Checked)
        //        {
        //            batchasName = batchasName + clbc.Items[i].Value + "-";
        //        }
        //    }
        //    return batchasName;
        //}

        /// <summary>
        /// 获取到选中的批次
        /// </summary>
        /// <returns></returns>
        public static string GetBatchsName(List<string> clbc)
        {
            StringBuilder str = new StringBuilder("");
            if(clbc != null && clbc.Count > 0 )
            {
                foreach(string i in clbc)
                {
                    str.Append(i.ToString() + "-");
                }
            }
            return str.ToString();
            //string batchasName = "";
            //for(int i = 0; i < clbc.Items.Count; i++)
            //{
            //    if(clbc.Items[i].CheckState == CheckState.Checked)
            //    {
            //        batchasName = batchasName + clbc.Items[i].Value + "-";
            //    }
            //}
            //return batchasName;
        }

        /// <summary>
        /// 批次处理 如把1-3转换成1和3的list
        /// </summary>
        /// <param name="Batchs"></param>
        /// <returns></returns>
        public static List<string> BatchHandle(string Batchs)
        {
            List<string> ListBatch = new List<string>();
            string[] StrBatch = Batchs.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < StrBatch.Length; i++)
            {
                ListBatch.Add(StrBatch[i].ToString());
            }
            return ListBatch;
        }

        #endregion

        #region【弹框】

        /// <summary>
        /// 以窗口形式显示
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="UControl"></param>
        public static void ShowAsWindow(string Caption, System.Windows.Forms.UserControl UControl)
        {
            System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
            frmBase.Text = Caption;
            frmBase.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmBase.MaximizeBox = false;
            frmBase.MinimizeBox = false;

            frmBase.Size = new System.Drawing.Size(UControl.Width + 15, UControl.Height + 30);
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //frmBase.AutoSize = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(UControl);
            //UControl.Parent = frmBase;
            UControl.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            frmBase.ShowDialog();
        }

        #endregion

        #region【病区信息】
        static DataTable _dtIllfield = null;
        /// <summary>
        /// 病区信息
        /// </summary>
        public static DataTable GetIllfield()
        {
            if (_dtIllfield == null)
            {
                _dtIllfield = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            }
            return _dtIllfield;
        }
        #endregion

        #region【批次信息】
        static DataTable _dtBatch = null;
        /// <summary>
        /// 批次信息
        /// </summary>
        public static DataTable GetBatch()
        {
            if (_dtBatch == null)
            {
                _dtBatch = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            }
            return _dtBatch;
        }
        #endregion
    }
}
