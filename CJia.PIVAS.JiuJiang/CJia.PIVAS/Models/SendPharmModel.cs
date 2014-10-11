using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class SendPharmModel : Tools.Model
    {
        /// <summary>
        /// 获得系统时间
        /// </summary>
        public DateTime SystemDate = DateTime.Parse(Models.PIVASModel.QuerySysdate().ToString());
        /// <summary>
        /// 当天开始时间
        /// </summary>
        private DateTime startdate = DateTime.Parse(Models.PIVASModel.QuerySysdate().ToShortDateString() + " 00:00:00");
        /// <summary>
        /// 当天结束时间
        /// </summary>
        private DateTime enddate = DateTime.Parse(Models.PIVASModel.QuerySysdate().ToShortDateString() + " 23:59:59");

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
        /// <param name="illfield"></param>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public DataTable QueryLabler(string illfield,string batchId)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryLable;
            string illfieldStr = "";
            if(illfield != "0")
            {
                illfieldStr = " and spl.illfield_id = '" + illfield + "'  ";
            }
            string batchStr = "";
            if(batchId != "0")
            {
                batchStr = " and  spl.batch_id = " + batchId;
            }
            newSql = string.Format(newSql, illfieldStr, batchStr);
            DataTable result = CJia.DefaultOleDb.Query(newSql);
            return result;
        }
        /// <summary>
        /// 获得当天要冲的非成组的药
        /// </summary>
        /// <param name="illfield"></param>
        /// <returns></returns>
        public DataTable QueryTodayPharmSend(string illfield)
        {
            string newSql = this.GetAddFilter(CJia.PIVAS.Models.SqlTools.SqlQueryTodayPharmSend, illfield);
            DataTable result = CJia.DefaultOleDb.Query(newSql);
            return result;
        }
        /// <summary>
        /// 查询药品汇总信息
        /// </summary>
        /// <param name="genDate"></param>
        /// <param name="illfield"></param>
        /// <param name="batchId"></param>
        /// <param name="printStatus"></param>
        /// <param name="sendStatus"></param>
        /// <returns></returns>
        public DataTable QueryPharmColloct(DateTime date, string illfield)
        {
            string newSql = this.GetAddFilter(CJia.PIVAS.Models.SqlTools.SqlQueryPharmColloct, illfield);
            object[] sqlParams = new object[] { date, date.AddDays(1), date };
            DataTable result = CJia.DefaultOleDb.Query(newSql, sqlParams);
            return result;
        }

        /// <summary>
        /// 获得当天配置中心药房库存不足的待冲药
        /// </summary>
        /// <returns>库存不足的药品</returns>
        public DataTable GetTodayNOPharmStore(string illfieldID)
        {
            string newSql = this.GetAddFilter(CJia.PIVAS.Models.SqlTools.SqlQueryTodayNoPharmStore, illfieldID);
            DataTable dtResult = CJia.DefaultOleDb.Query(newSql);
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
        /// 向sql中增加筛选条件
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="genDate"></param>
        /// <param name="illfield"></param>
        /// <param name="batchId"></param>
        /// <param name="printStatus"></param>
        /// <param name="sendStatus"></param>
        /// <returns></returns>
        private string GetAddFilter(string sql, string illfield)
        {
            string strIllfield = "";
            if (illfield != "0")
            {
                strIllfield = " and nog.illfield_id = '" + illfield + "'  ";
            }
            return string.Format(sql, strIllfield);
        }
    }
}
