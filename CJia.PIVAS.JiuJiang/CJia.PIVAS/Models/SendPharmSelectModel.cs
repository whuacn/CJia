using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class SendPharmSelectModel : Tools.Model
    {
        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }

        /// <summary>
        /// 查询瓶贴
        /// </summary>
        /// <param name="startData"></param>
        /// <param name="endData"></param>
        /// <param name="illfield"></param>
        /// <returns></returns>
        public DataTable QueryLabel(bool isPrintDate, DateTime startData, DateTime endData, bool isListDate, DateTime listDate, bool isZXDate, DateTime zxDate, string illfields, string batchs, string pharmId, string group, string longTemporary, string allGrDr, string usageIds)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlSendALLQueryLable;
            string sql = "";
            List<object> parms = new List<object>();
            if (isPrintDate)
            {
                sql += " and gb.gen_date between ? and ?   ";
                sql += " and nspl.create_date between ?  and  ?  ";
                parms.Add(startData);
                parms.Add(endData);
                parms.Add(startData.AddDays(-2));
                parms.Add(endData.AddDays(2));
            }

            if (isZXDate)
            {
                sql += " and  nspl.pharm_time between trunc(?) and trunc(? +1) ";
                parms.Add(zxDate);
                parms.Add(zxDate);
            }
            if (isListDate)
            {
                sql += " and  nspl.list_doctor_date between trunc(?) and trunc(? +1) ";
                parms.Add(listDate);
                parms.Add(listDate);
            }
            if (allGrDr == "ALL")
            {
                sql += " and  1 = 1 ";
            }
            if (allGrDr == "GR")
            {
                sql += " and  trunc(nspl.list_doctor_date) != trunc(nspl.pharm_time)  ";
            }
            if (allGrDr == "DR")
            {
                sql += " and  trunc(nspl.list_doctor_date) = trunc(nspl.pharm_time)  ";
            }
            if (!isPrintDate && !isZXDate && !isListDate)
            {
                sql = " and 1 = 0  ";
            }



            string illfieldStr = " nspl.illfield_id in (" + illfields + ") ";
            string usageStr = " nspl.usage_id in (" + usageIds + ") ";
            string batchStr = " nspl.batch_id in (" + batchs + ") ";

            if (longTemporary == "TEMPORARY")
            {
                batchStr = " 1 = 1 ";
            }
            //newSql = string.Format(newSql, groupStr, longTemporaryStr, illfieldStr, batchStr);
            newSql = string.Format(newSql, sql, illfieldStr, batchStr, usageStr);
            DataTable result = CJia.DefaultOleDb.Query(newSql, parms);
            return result;
        }

        /// <summary>
        /// 查询瓶贴汇总信息
        /// </summary>
        /// <param name="startData"></param>
        /// <param name="endData"></param>
        /// <param name="illfield"></param>
        /// <returns></returns>
        public DataTable QueryLabelSum(bool isPrintDate, DateTime startData, DateTime endData, bool isListDate, DateTime listDate, bool isZXDate, DateTime zxDate, string illfields, string batchs, string pharmId, string group, string longTemporary, string allGrDr, string usageIds)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlSendALLQueryLableSum;
            string sql = "";
            List<object> parms = new List<object>();
            if (group == "YES")
            {
                sql += " AND FN_IS_GROUP(GROUP_INDEX) = '1'   ";
            }
            if (group == "NO")
            {
                sql += " AND FN_IS_GROUP(GROUP_INDEX) = '0'   ";
            }
            if (group == "ALL")
            {
                sql += " AND 1=1  ";
            }

            if (isPrintDate)
            {
                sql += "  and gb.gen_date between ? and ?    ";
                parms.Add(startData);
                parms.Add(endData);
            }
            if (isZXDate)
            {
                sql += " and  nspl.pharm_time between trunc(?) and trunc(? +1) ";
                parms.Add(zxDate);
                parms.Add(zxDate);
            }
            if (isListDate)
            {
                sql += " and  nspl.list_doctor_date between trunc(?) and trunc(? +1) ";
                parms.Add(listDate);
                parms.Add(listDate);
            }
            if (allGrDr == "ALL")
            {
                sql += " and  1 = 1 ";
            }
            if (allGrDr == "GR")
            {
                sql += " and  trunc(nspl.list_doctor_date) != trunc(nspl.pharm_time)  ";
            }
            if (allGrDr == "DR")
            {
                sql += " and  trunc(nspl.list_doctor_date) = trunc(nspl.pharm_time)  ";
            }
            if (!isPrintDate && !isZXDate && !isListDate)
            {
                sql = " and 1 = 0  ";
            }

            string illfieldStr = " nspl.illfield_id in (" + illfields + ") ";
            string usageStr = " nspl.usage_id in (" + usageIds + ") ";
            string batchStr = " nspl.batch_id in (" + batchs + ") ";


            if (longTemporary == "TEMPORARY")
            {
                batchStr = " 1 = 1 ";
            }
            //newSql = string.Format(newSql, groupStr, longTemporaryStr, illfieldStr, batchStr);
            newSql = string.Format(newSql, sql, illfieldStr, batchStr, usageStr);
            DataTable result = CJia.DefaultOleDb.Query(newSql, parms);
            return result;
        }

        /// <summary>
        /// 查询药品汇总信息
        /// </summary>
        /// <param name="startData"></param>
        /// <param name="endData"></param>
        /// <param name="illfield"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public DataTable QueryPharmColloct(DateTime startData, DateTime endData, string illfield, string batch, string group)
        {
            string newSql = "";
            object[] parms;
            if (group == "ALL")
            {
                newSql = CJia.PIVAS.Models.SqlTools.SqlSendAllPharmColloct;
                string illfieldStr1 = "";
                if (illfield != "0")
                {
                    illfieldStr1 = " and sspv.illfield_id = '" + illfield + "'  ";
                }
                string illfieldStr2 = "";
                if (illfield != "0")
                {
                    illfieldStr2 = " and spl.illfield_id = '" + illfield + "'  ";
                }
                newSql = string.Format(newSql, illfieldStr1, illfieldStr2);
                parms = new object[] { startData, endData, startData, endData };
            }
            else if (group == "YES")
            {
                newSql = CJia.PIVAS.Models.SqlTools.SqlSendYesPharmColloct;
                string illfieldStr1 = "";
                if (illfield != "0")
                {
                    illfieldStr1 = " and spl.illfield_id = '" + illfield + "'  ";
                }
                string batchStr = "";
                if (batch != "0")
                {
                    batchStr = " and  spl.batch_id = " + batch;
                }
                newSql = string.Format(newSql, illfieldStr1, batchStr);
                parms = new object[] { startData, endData };
            }
            else
            {
                newSql = CJia.PIVAS.Models.SqlTools.SqlSendNoPharmColloct;
                string illfieldStr1 = "";
                if (illfield != "0")
                {
                    illfieldStr1 = " and sspv.illfield_id = '" + illfield + "'  ";
                }
                newSql = string.Format(newSql, illfieldStr1);
                parms = new object[] { startData, endData };
            }
            DataTable result = CJia.DefaultOleDb.Query(newSql, parms);
            return result;
        }

        /// <summary>
        /// 查询药品
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable QueryPharm(string key)
        {
            string likeKe = "'%" + key.ToUpper() + "%'";
            string newSql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectPharm, likeKe, likeKe);
            DataTable result = CJia.DefaultOleDb.Query(newSql);
            return result;
        }

    }
}
