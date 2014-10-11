using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class NewCancelRCPModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }
        /// <summary>
        /// 根据时间范围和病区获得退药信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="illfield"></param>
        /// <param name="state">1为获得已退药品信息,2为获得拒绝退药的信息</param>
        /// <returns></returns>
        public DataTable GetCancelByIffieldAndDate(string dateStyle,DateTime startDate, DateTime endDate, string illfield, int state)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryCancelByIllfieldIDAndDate;
            string illfieldStr = "";
            if (illfield != "0")
            {
                illfieldStr = " and l.illfield_id = '" + illfield + "'  ";
            }
            string dataStyleStr = "";
            if(dateStyle == "Check")
            {
                dataStyleStr = " and lcr.check_time between ? and ?  ";
            }
            else
            {
                dataStyleStr = " and l.create_date between ? and ?  ";
            }
            newSql = string.Format(newSql, illfieldStr, dataStyleStr);
            DateTime start = startDate;
            DateTime end = endDate;
            object[] parms;
            if (state == 1)
            {
                parms = new object[] { "1000303",1, start, end };
            }
            else if(state == 2)
            {
                parms = new object[] { "1000305", 1, start, end };
            }
            else
            {
                parms = new object[] { "1000303", 0 , start, end};
            }

            DataTable dtResult = CJia.DefaultOleDb.Query(newSql, parms);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据时间范围和病区获得退药汇总信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="illfield"></param>
        /// <param name="state">1为获得已退药品汇总,2为获得拒绝退药汇总</param>
        /// <returns></returns>
        public DataTable GetCancelStatByIffieldAndDate(string dateStyle, DateTime startDate, DateTime endDate, string illfield, int state)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryCancelStatByIllfieldIDAndDate;
            string illfieldStr = "";
            if (illfield != "0")
            {
                illfieldStr = " and l.illfield_id = '" + illfield + "'  ";
            }

            string dataStyleStr = "";
            if(dateStyle == "Check")
            {
                dataStyleStr = " and lcr.check_time between ? and ?  ";
            }
            else
            {
                dataStyleStr = " and l.create_date between ? and ?  ";
            }
            newSql = string.Format(newSql, illfieldStr, dataStyleStr);
            DateTime start = startDate;
            DateTime end = endDate;
            object[] parms;
            if(state == 1)
            {
                parms = new object[] { "1000303", 1 , start, end};
            }
            else if(state == 2)
            {
                parms = new object[] { "1000305", 1 , start, end};
            }
            else
            {
                parms = new object[] { "1000303", 0, start, end };
            }
            DataTable dtResult = CJia.DefaultOleDb.Query(newSql, parms);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
    }
}
