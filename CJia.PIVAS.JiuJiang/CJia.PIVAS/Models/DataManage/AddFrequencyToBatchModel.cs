using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 添加频率对应批次的M层
    /// </summary>
    public class AddFrequencyToBatchModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 从频率视图中查询未配置批次的频率信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFrequency()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFrequency);
        }

        /// <summary>
        /// 查询批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBatch()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBatch);
        }

        /// <summary>
        /// 插入频率对应批次  true表示插入成功 
        /// </summary>
        /// <param name="frequencyId">频率Id</param>
        /// <param name="frequencyName">频率名称</param>
        /// <param name="frequencyFilter">频率查询码</param>
        /// <param name="batchsName">批次</param>
        /// <param name="updateBy">更新人ID</param>
        /// <returns></returns>
        public bool InsertFrquencyBatch(long frequencyId, string frequencyName, string frequencyFilter, string batchsName, long updateBy, string Illfield, string IllfieldName)
        {
            object[] ob = new object[] { frequencyId, frequencyName, frequencyFilter, batchsName, updateBy, Illfield, IllfieldName };
            return CJia.DefaultOleDb.Execute(SqlTools.sqlInsertFrequencyBatch, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 查询批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIllfield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 是否已经设置了该频率
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool QueryIllfieldFrequency(long frequencyId, string Illfield)
        {
            object[] ob = new object[] { Illfield, frequencyId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.DataManage.SqlTools.SqlQueryIllfieldFrequencyid, ob);
            if(result == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}