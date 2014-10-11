using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class PublishTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询所有任务类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTaskType()
        {
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllTaskType);
            return dt;
        }

        /// <summary>
        /// 查询任务Seq
        /// </summary>
        /// <returns></returns>
        public string QueryTaskSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryTaskSeq);
        }

        /// <summary>
        /// 插入任务表
        /// </summary>
        /// <param name="sqlParams">插入参数</param>
        /// <returns></returns>
        public bool InsertTask(string transId,List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInsertTask, sqlParams) > 0 ? true : false;
        }

        ///// <summary>
        ///// 查询文件Seq
        ///// </summary>
        ///// <returns></returns>
        //public string QueryFileSeq()
        //{
        //    return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryFileSeq);
        //}

        /// <summary>
        /// 插入信息表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="taskId">任务名称</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertFiles(string transId,string fileName,string filePath,string taskId,string createBy)
        {
            object[] sqlParams = new object[] { fileName,filePath,taskId,createBy };
            return CJia.DefaultOleDb.Execute(transId,SqlTools.SqlInserFiles,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据Id查询任务类型
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public DataTable QueryTaskTypeById(long templateId)
        {
            object[] sqlParams = new object[] { templateId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTaskTypeById, sqlParams);
        }
    }
}
