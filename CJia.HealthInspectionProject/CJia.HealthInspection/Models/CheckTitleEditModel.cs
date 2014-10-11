using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class CheckTitleEditModel : Tools.Model
    {
        /// <summary>
        /// 根据题目id，获得题目详细信息
        /// </summary>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public DataTable GetCheckTitleByID(string titleID)
        {
            object[] sqlParams = new object[] { titleID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryCheckTitleByID, sqlParams);
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
        /// 根据题目id，获得题目类型
        /// </summary>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public DataTable GetCheckTitleTypeByID(string titleID)
        {
            object[] sqlParams = new object[] { titleID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryCheckTitleTypeByID, sqlParams);
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
        /// 新增检查题目对应的答案
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="answerName"></param>
        /// <param name="titleID"></param>
        /// <param name="userName"></param>
        /// <param name="result"></param>
        /// <param name="advice"></param>
        /// <returns></returns>
        public bool AddCheckTitleAnswer(string transID, string answerName, string titleID, string userID, string result, string advice)
        {
            object[] sqlParams = new object[] { answerName, titleID, userID, result, advice };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddCheckTitleAnswer, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据检查题目id,删除其答案
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="titleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteCheckTitleAnswer(string transID, string titleID, string userID)
        {
            object[] sqlParams = new object[] { userID, titleID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDeleteCheckTitleAnswers, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改检查题目信息
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="titleName"></param>
        /// <param name="titleContent"></param>
        /// <param name="isChoice"></param>
        /// <param name="userID"></param>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public bool ModifyCheckTitle(string transID, string titleName, string titleContent, string isChoice, string userID, string titleID)
        {
            object[] sqlParams = new object[] { titleName, titleContent, isChoice, userID, titleID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateCheckTitle, sqlParams) > 0 ? true : false;
        }
    }
}
