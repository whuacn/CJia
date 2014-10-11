using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.HelperTools
{
    public static class LogHelper
    {
        public static void ExistsFile(string FilePath)
        {
            if(!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Close();
            }
        }

        /// <summary>
        /// 写入一行日志
        /// </summary>
        /// <param name="logStr">写入的信息</param>
        public static void WriteLog(string logStr)
        {
            try
            {
                string path = Application.StartupPath + "\\" + "log.txt";
                ExistsFile(path);//检查文件是否存在
                //读取文件
                StreamWriter sr = new StreamWriter(path);
                sr.WriteLine(logStr);
                sr.Close();
                sr.Dispose();
            }
            catch
            {

            }
        }

    }
}
