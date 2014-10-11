using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class AddCheckTitleModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 获得模板大分类类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetBigTemplate()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryBigTemplate);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据模板大分类获得中分类类型
        /// </summary>
        /// <param name="bigTemplate"></param>
        /// <returns></returns>
        public DataTable GetMidTemplateByBig(string bigTemplate)
        {
            object[] sqlParams = new object[] { bigTemplate };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryMiddleTemplate, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据模板中分类获得小分类类型
        /// </summary>
        /// <param name="midTemplate"></param>
        /// <returns></returns>
        public DataTable GetSmallTemplateByMid(string midTemplate)
        {
            object[] sqlParams = new object[] { midTemplate };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQuerySmallTemplate, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得检查题目表SEQ
        /// </summary>
        /// <returns></returns>
        public string GetCheckTitleSeq()
        {
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryCheckTitleSeq);
        }
        /// <summary>
        /// 新增检查题目
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="seq"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="isChoice"></param>
        /// <param name="userName"></param>
        /// <param name="organId"></param>
        /// <returns></returns>
        public bool AddCheckTitle(string transID, string seq, string name, string content, string isChoice, string userName,string organId)
        {
            object[] sqlParams = new object[] { seq, name, content, isChoice, userName,organId};
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddCheckTitle, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 新增检查题目对应的答案
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="answerName"></param>
        /// <param name="titleID"></param>
        /// <param name="userName"></param>
        /// <param name="result"></param>
        /// <param name="advice"></param>
        /// <returns></returns>
        public bool AddCheckTitleAnswer(string transID, string answerName, string titleID, string userName, string result, string advice)
        {
            object[] sqlParams = new object[] { answerName, titleID, userName, result, advice };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddCheckTitleAnswer, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 新增检查题目对应的小分类类型
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="templateID"></param>
        /// <param name="titleID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool AddTitleToTemplate(string transID, string templateID, string titleID, string userName)
        {
            object[] sqlParams = new object[] { templateID, titleID, userName };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddTrTemplatetypeChecktitle, sqlParams) > 0 ? true : false;
        }

        ///// <summary>
        ///// 增加零星题与执行监督的关系
        ///// </summary>
        ///// <param name="transID"></param>
        ///// <param name="CheckID"></param>
        ///// <param name="CheckTitleID"></param>
        ///// <returns></returns>
        //public bool AddSingeCheckTitle(string transID, long CheckID, long CheckTitleID,long UserID)
        //{
        //    object[] ob = new object[] { CheckID, CheckTitleID ,UserID};
        //    return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertSingleTitle, ob) > 0 ? true : false;
        //}
    }
}
