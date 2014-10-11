using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 批次对应冲药的M层
    /// </summary>
    public class BatchToRedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询批次对应冲药
        /// </summary>
        /// <returns></returns>
        public  DataTable QueryBatchSet()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatchSet);
        }
    }
}