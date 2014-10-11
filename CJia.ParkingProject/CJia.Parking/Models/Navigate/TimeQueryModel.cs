using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models.Navigate
{
    public class TimeQueryModel : CJia.Parking.Tools.Model
    {
        public DataTable TimeQuery(List<int> floorList,List<string> timeList,int pageIndex)
        {
            string sql = @"select res.* from 
                            (select row_number() over() rownumber,* 
                                from vt_park 
                                where ";
            List<object> list = new List<object>();
            if (floorList.Count > 0)
            {
                sql = sql + " ( ";
                for (int i = 0; i < floorList.Count; i++)
                {
                    sql = sql + " floor_id=:" + (i + 1).ToString() + " or ";
                    list.Add(floorList[i]);
                }
                sql = sql.Substring(0, sql.Length - 3) + " ) ";
            }
            if (floorList.Count > 0 && timeList.Count > 0)
            {
                sql = sql + " and  ";
            }
            if (timeList.Count > 0)
            {
                sql = sql + " ( ";
                for (int j = 0; j < timeList.Count; j++)
                {
                    sql = sql + " to_char(in_park_date, 'HH24')=:" + (floorList.Count + j + 1).ToString() + " or ";
                    list.Add(timeList[j]);
                }
                sql = sql.Substring(0, sql.Length - 3) + " ) ";
            }
            sql = sql + " ) res where  rownumber BETWEEN :" + (floorList.Count + timeList.Count + 1).ToString() + " and :" + (floorList.Count + timeList.Count + 2).ToString();
            list.Add(pageIndex * 6 - 5);
            list.Add(pageIndex * 6 + 1);
            

            return CJia.DefaultPostgre.Query(sql, list);
        }
    }
}
