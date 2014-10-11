using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class ExeTaskModel : CJia.HealthInspection.Tools.Model
    {
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
        /// 查询检查结果（静态数据）
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCheckRueult()
        {
            DataTable dtCheckResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckRusult);
            if (dtCheckResult != null && dtCheckResult.Rows != null && dtCheckResult.Rows.Count > 0)
            {
                return dtCheckResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据任务模板ID查询题目
        /// </summary>
        /// <param name="TempId"></param>
        /// <returns></returns>
        public DataTable QueryTaskTitle(long TempId)
        {
            object[] ob = new object[] { TempId };
            DataTable dtTaskTitle = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTaskTitle, ob);
            if (dtTaskTitle != null && dtTaskTitle.Rows != null && dtTaskTitle.Rows.Count > 0)
            {
                return dtTaskTitle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取到同组织机构下的监督人
        /// </summary>
        /// <param name="DeptID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable QueryChecker(long DeptID, long UserID)
        {
            object[] ob = new object[] { DeptID, UserID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryChecker, ob);
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
        /// 获取执行监督的ID
        /// </summary>
        /// <returns></returns>
        public long QueryExeTaskSeq()
        {
            return Convert.ToInt64(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryExeCheckID));
        }

        /// <summary>
        /// 插入此次执行监督的题目
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="CheckId"></param>
        /// <param name="CheckTitleID"></param>
        /// <param name="UserID"></param>
        /// <param name="TitleAnswerID"></param>
        /// <returns></returns>
        public bool InsertExeTaskTitle(string transID, long ExeTaskId, long ExeTaskTitleID, long UserID, long TitleAnswerID, string Result, string Advice)
        {
            object[] ob = new object[] { ExeTaskId, ExeTaskTitleID, UserID, TitleAnswerID, Result, Advice };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertExeTaskTitle, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 插入执行任务记录
        /// </summary>
        /// <param name="UnitId"></param>
        /// <param name="UnitName"></param>
        /// <param name="TaskId"></param>
        /// <param name="TaskName"></param>
        /// <param name="IsLicense"></param>
        /// <param name="IsFiling"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="End_DateTime"></param>
        /// <param name="CheckPoint"></param>
        /// <param name="IsRectification"></param>
        /// <param name="Review"></param>
        /// <param name="IsReview"></param>
        /// <param name="RectificationResult"></param>
        /// <param name="TouchFiled"></param>
        /// <param name="Remark"></param>
        /// <param name="CheckResult"></param>
        /// <param name="CheckOne"></param>
        /// <param name="CheckOneName"></param>
        /// <param name="CheckTwo"></param>
        /// <param name="CheckTwoName"></param>
        /// <param name="CheckNotes"></param>
        /// <param name="CheckOpinion"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool SaveExeTask(string transID,long ExtTaskId, long UnitId, string UnitName, long TaskId, string TaskName, char IsLicense, char IsFiling, DateTime StartDateTime, DateTime End_DateTime, string CheckPoint, char IsRectification, DateTime? Review_Date, char IsReview, char? RectificationResult, string TouchFiled, string Remark, long CheckResult, long CheckOne, string CheckOneName, long CheckTwo, string CheckTwoName, string CheckNotes, string CheckOpinion, long UserId, long OrganId)
        {
            object[] ob = new object[] {ExtTaskId, UnitId, UnitName, TaskId, TaskName, IsLicense, IsFiling, StartDateTime, End_DateTime, CheckPoint, IsRectification, Review_Date, IsReview, RectificationResult, TouchFiled, Remark, CheckResult, CheckOne, CheckOneName, CheckTwo, CheckTwoName, CheckNotes, CheckOpinion, UserId, OrganId };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertExeTask, ob) > 0 ? true : false;
        }
    }
}
