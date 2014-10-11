using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Tools
{
    /// <summary>
    /// 系统帮助类  该类中包含一些公用的方法
    /// </summary>
    public static class Helper
    {
        #region 阿拉伯数字转换成中文数字

        /// <summary>
        /// 将阿拉伯数字转成中文数字
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static string ConvertCh(int i)
        {
            if(i < 10)
            {
                switch(i)
                {
                    case 0:
                        return "零";
                    case 1:
                        return "一";
                    case 2:
                        return "二";
                    case 3:
                        return "三";
                    case 4:
                        return "四";
                    case 5:
                        return "五";
                    case 6:
                        return "六";
                    case 7:
                        return "七";
                    case 8:
                        return "八";
                    case 9:
                        return "九";
                    default:
                        return "";
                }
            }
            else
            {
                throw new Exception("传入的数据不是一位数字");
            }
        }

        /// <summary>
        /// 将小于100的数字装换成中文
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string Convert(int i)
        {
            if(i < 10)
            {
                return ConvertCh(i);
            }
            else if(i == 10)
            {
                return "十";
            }
            else if(i < 20)
            {
                return "十" + ConvertCh(i % 10);
            }
            else if(i < 100)
            {
                if(i % 10 == 0)
                {
                    return ConvertCh(i / 10) + "十";
                }
                else
                {
                    return ConvertCh(i / 10) + "十" + ConvertCh(i % 10);
                }
            }
            else
            {
                throw new Exception("转换的数字带大！");
            }
        }

        #endregion

        #region 获取数据库时间

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

        #endregion


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



    }
}
