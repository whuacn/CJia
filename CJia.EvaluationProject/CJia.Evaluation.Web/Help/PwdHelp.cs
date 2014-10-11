using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CJia.Evaluation.Web.Help
{
    public class PwdHelp
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
    }
}