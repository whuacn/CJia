using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 频率对应批次的M层
    /// </summary>
    public class FrequencyToBatchModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询频率对应批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequencyToBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequencyBatch);
        }

        /// <summary>
        ///  从频率视图中查询未配置批次的频率信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequency()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequency);
        }

        /// <summary>
        /// 删除FrequencyBatch
        /// </summary>
        /// <param name="userId">修改人Id</param>
        /// <param name="frequencyBatchId">频率对应批次Id</param>
        /// <returns></returns>
        public bool DeleteFrequencyBatch(long userId, long frequencyBatchId)
        {
            object[] ob = new object[] { userId, frequencyBatchId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteFrequencyBatch, ob) > 0 ? true : false;
        }
    }
}