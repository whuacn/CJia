using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class ExeCheckModel :CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据选择的模板获取到该模板下的题目
        /// </summary>
        /// <param name="TempID"></param>
        /// <returns></returns>
        public DataTable QueryCheckTitleByTempID(long TempID )
        {
            object[] ob = new object[] { TempID };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckTitleByTempID, ob);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
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
        public long QueryCheckSeq()
        {
            return Convert.ToInt64(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlGetCheckSeq));
        }

        /// <summary>
        /// 插入监督记录
        /// </summary>
        /// <returns></returns>
        public bool AddCheck(string transID, long CheckID, long UnitID, string UnitName, long TempID, string TempName, char IsLicence, char IsFiling, DateTime StartDateTime, DateTime End_DateTime, string CheckPoint, char IsRectification, DateTime? Review, char IsReview, char? RectificationResult, string TouchFiled, string Remark, long CheckResult, long CheckOne, string CheckOneName, long CheckTwo, string CheckTwoName, string CheckNotes, string CheckOpinion, long UserId, long OrganId)
        {
            object[] ob = new object[] { CheckID, UnitID, UnitName, TempID, TempName, IsLicence, IsFiling, StartDateTime, End_DateTime, CheckPoint, IsRectification, Review, IsReview, RectificationResult, TouchFiled, Remark, CheckResult, CheckOne, CheckOneName, CheckTwo, CheckTwoName, CheckNotes, CheckOpinion, UserId, OrganId };
            return CJia.DefaultOleDb.Execute(transID,SqlTools.SqlAddCheck, ob) > 0 ? true : false;
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
        public bool InsertCheckTitle(string transID, long CheckId, long CheckTitleID, long UserID, long TitleAnswerID, string Result, string Advice)
        {
            object[] ob = new object[] { CheckId, CheckTitleID, UserID, TitleAnswerID, Result, Advice };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertCheckTitle, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 查询专业条线（静态数据）
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTouchFiled()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTouchFiled);
        }

        /// <summary>
        /// 查询检查结果（静态数据）
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCheckRueult()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckRusult);
        }

        /// <summary>
        /// 获取到同组织机构下的监督人
        /// </summary>
        /// <param name="DeptID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable QueryChecker(long DeptID,long UserID)
        {
            object[] ob = new object[] { DeptID, UserID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryChecker,ob);
            if (dtResult != null && dtResult.Rows != null && dtResult.Rows.Count > 0)
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
