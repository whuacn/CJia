using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据任务ID查询任务
        /// </summary>
        /// <param name="taskId">所要查询ID</param>
        /// <returns></returns>
        public DataTable QueryTaskById(string taskId)
        {
            object[] sqlParams = new object[] { taskId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTaskById,sqlParams);
        }

        /// <summary>
        /// 查询所有任务类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTaskType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllTaskType);
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

        /// <summary>
        /// 根据任务ID查询所属文件
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public DataTable QueryFilesByTaskId(string taskId)
        {
            object[] sqlParams = new object[] { taskId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFilesByTaskId, sqlParams);
        }

        /// <summary>
        /// 修改任务表
        /// </summary>
        /// <param name="sqlParams">插入参数</param>
        /// <returns></returns>
        public bool UpdateTask(string transId,List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlUpdateTaskById, sqlParams) > 0 ? true : false;
       
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
        /// 根据文件ID删除文件
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="fileId">文件ID</param>
        /// <param name="updateBy">修改人</param>
        /// <returns></returns>
        public bool DeleteFileById(string transId, string fileId, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, fileId };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlDeleteFilesByFileId, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 插入信息表
        /// </summary>
        /// <param name="transId">事物ID</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="taskId">任务名称</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool InsertFiles(string transId, string fileName, string filePath, string taskId, string createBy)
        {
            object[] sqlParams = new object[] { fileName, filePath, taskId, createBy };
            return CJia.DefaultOleDb.Execute(transId, SqlTools.SqlInserFiles, sqlParams) > 0 ? true : false;
        }
    }
}
