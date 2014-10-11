using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class ReadExeTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据执行任务ID查询执行任务详细信息
        /// </summary>
        /// <param name="exeTaskId"></param>
        /// <returns></returns>
        public DataTable QueryExeTaskById(long exeTaskId)
        {
            object[] ob = new object[] { exeTaskId };
            DataTable dtExeTask = CJia.DefaultOleDb.Query(SqlTools.SQlQueryExeTaskByID, ob);
            if (dtExeTask != null && dtExeTask.Rows != null && dtExeTask.Rows.Count > 0)
            {
                return dtExeTask;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询涉及条线
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTouchFiled()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTouchFiledTask);
            if (dtResult != null && dtResult.Rows != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据执行监督Id查询监督检查题目
        /// </summary>
        /// <param name="ExeCheckID"></param>
        /// <returns></returns>
        public DataTable QueryExeTaskTitleById(long ExeTaskID)
        {
            object[] ob = new object[] { ExeTaskID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExeTaskTitleByID, ob);
            if (dtResult != null && dtResult.Rows != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据题目ID查询题目答案
        /// </summary>
        /// <param name="TitleId"></param>
        /// <returns></returns>
        public DataTable QueryAnswerByTitleIDForRead(long TitleId)
        {
            object[] ob = new object[] { TitleId };
            DataTable dtAnswer = CJia.DefaultOleDb.Query(SqlTools.SqlQueryAnswerByTitleIDForRead, ob);
            if (dtAnswer != null && dtAnswer.Rows != null && dtAnswer.Rows.Count > 0)
            {
                return dtAnswer;
            }
            else
            {
                return null;
            }
        }
    }
}
