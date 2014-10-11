using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 修改批次
    /// </summary>
    public class EditFrequencyToBatchModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatch);
        }

        /// <summary>
        /// 修改频率对应批次
        /// </summary>
        /// <returns></returns>
        public bool UpdataFrequencyBatch(string batchsName,long updateBy,long frequencyBatchId)
        {
            object[] ob = new object[] { batchsName, updateBy, frequencyBatchId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateFrequencyBatch, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 审方修改批次（审方用）
        /// </summary>
        /// <returns></returns>
        public void UpdateCheckBatch(string transID,int detailId, int checkId, string batchsName, long userId, string gropuIndex)
        {
            object[] ob = new object[] { detailId,checkId,batchsName, userId, gropuIndex };
            CJia.DefaultOleDb.Execute(transID,CJia.PIVAS.Models.SqlTools.SqlUpdateBatch, ob);
        }
    }
}