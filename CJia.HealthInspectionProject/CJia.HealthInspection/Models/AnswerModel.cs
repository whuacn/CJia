using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AnswerModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据题目ID查询题目答案
        /// </summary>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public DataTable QuyerAnswerByTitleID(long titleID)
        {
            object[] ob = new object[] { titleID };
            DataTable dtAnser = CJia.DefaultOleDb.Query(SqlTools.SqlQueryAnswerByTitleID, ob);
            if (dtAnser != null && dtAnser.Rows != null && dtAnser.Rows.Count > 0)
            {
                return dtAnser;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据答案ID查询笔录和建议
        /// </summary>
        /// <param name="AnswerID"></param>
        /// <returns></returns>
        public DataTable QueryAnswerRusultByID(long AnswerID)
        {
            object[] ob = new object[] { AnswerID };
            DataTable dtRusult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryAnswerResultById, ob);
            if (dtRusult != null && dtRusult.Rows != null && dtRusult.Rows.Count > 0)
            {
                return dtRusult;
            }
            else
            {
                return null;
            }
        }
    }
}
