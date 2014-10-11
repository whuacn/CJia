using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace CJia.Health.Tools
{
    /// <summary>
    /// Utils
    /// </summary>
    public class Utils
    {
        public Utils()
        {

        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string AESEncrypt(string toEncrypt)
        {
            // 256-AES key
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("(HC)2012122099QWERTYUIOP*&^%$#@!");
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string AESDecrypt(string toDecrypt)
        {
            // 256-AES key    
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("(HC)2012122099QWERTYUIOP*&^%$#@!");
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string CreateZipFile(string zPath, string zFileName)
        {
            try
            {
                string[] filenames = Directory.GetFiles(zPath);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zFileName)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void CreateSysConfigFile(string FileName, string UpdateService, string SystemNo, string SystemName)
        {
            string AppConfig = @"<?xml version=""1.0""?>
<configuration>
    <appSettings>
    <add key=""UpdateService"" value=""{0}""/>
    <add key=""SystemNo"" value=""{1}""/>
    <add key=""SystemName"" value=""{2}""/>
    <add key=""VersionNo"" value=""0.0.0""/>
    </appSettings>
</configuration>";
            AppConfig = String.Format(AppConfig, UpdateService, SystemNo, SystemName);
            File.WriteAllText(FileName, AppConfig, System.Text.Encoding.UTF8);
        }
    }
}
