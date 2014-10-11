using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Net.Business.MobileMedical
{
    public class Common
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        public static string DateNow
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        /// <summary>
        /// 医嘱变更时间
        /// </summary>
        public static string PadAdviceLastChangeDate = "";

        static object lockObject = new object();
        public static void Log(string Msg)
        {
            lock (lockObject)
            {
                System.IO.File.AppendAllText(@"c:\log.txt", Msg + System.Environment.NewLine);
            }
        }
    }
}
