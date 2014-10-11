using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 发药统计Model层
    /// </summary>
    public class PharmSendStatSelectModel : Tools.Model
    {
        /// <summary>
        /// 获得病区
        /// </summary>
        /// <returns>病区</returns>
        public DataTable GetOffice()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlSelectOffice);
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
        /// 获得批次
        /// </summary>
        /// <returns>批次</returns>
        public DataTable GetBatch()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(DataManage.SqlTools.SqlQueryBatchSet);
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
        /// 根据条件统计发药单
        /// </summary>
        /// <param name="officeID">病床id</param>
        /// <param name="batchID">批次id</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">截止时间</param>
        /// <returns>发药单明细</returns>
        public DataTable GetPharmSendByCondition(string officeID, int batchID, DateTime start, DateTime end)
        {
            object[] sqlParams = new object[] { start, end };
            string sql = SqlTools.SqlQueryPharmSendByCondition;
            if (officeID != "") { sql = sql + " and spl.illfield_id=" + officeID; }
            if (batchID != 0) { sql = sql + " and spl.batch_id=" + batchID; }
            sql = sql + " group by spld.pharm_name,spld.spec,p.factory_name,spld.amount_unit,p.INHOS_PRICE,p.form_name";
            DataTable dtResult = CJia.DefaultOleDb.Query(sql, sqlParams);
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
