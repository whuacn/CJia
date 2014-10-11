using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 修改批次对应冲药M层
    /// </summary>
    public class EditBatchToRedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatchSet);
        }

        /// <summary>
        /// 修改批次表的时间和对应的冲药  true代表修改成功
        /// </summary>
        /// <param name="batchTime">执行时间</param>
        /// <param name="timeId">对应冲药ID</param>
        /// <param name="updateBy"></param>
        /// <param name="batchId">批次ID</param>
        /// <returns></returns>
        public bool UpdateBatchSet(string batchTime, long timeId, long updateBy, long batchId)
        {
            object[] ob = new object[] { batchTime, timeId, updateBy, batchId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateBatchSet, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 判断修改的批次执行时间是否有重叠
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <param name="batchTime">批次执行时间</param>
        /// <returns>true表示有重叠，false表示没有重叠</returns>
        public bool IsRepeat(long batchId, string batchTime)
        {
            object[] ob = new object[] { batchId, batchTime, batchTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsRepeat, ob) == "1" ? false : true;
        }

    }
}