using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class ReadCheckModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据Id查询执行监督记录
        /// </summary>
        /// <param name="ExeCheckId"></param>
        /// <returns></returns>
        public DataTable QueryExeCheckById(long ExeCheckId)
        {
            object[] ob = new object[] { ExeCheckId };
            DataTable dtExeCheck = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckById, ob);
            if (dtExeCheck != null && dtExeCheck.Rows != null && dtExeCheck.Rows.Count > 0)
            {
                return dtExeCheck;
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
        public DataTable QueryExeCheckTitleById(long ExeCheckID)
        {
            object[] ob = new object[] { ExeCheckID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExeCheckTitleByID, ob);
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
