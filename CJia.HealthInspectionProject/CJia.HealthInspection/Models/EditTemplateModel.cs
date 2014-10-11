using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class EditTemplateModel : Models.AddTemplateModel
    {
        /// <summary>
        /// 根据模板id，查询模板信息,包括检查题目
        /// </summary>
        /// <param name="tempID"></param>
        /// <returns></returns>
        public DataTable GetTemplateByID(string tempID)
        {
            object[] sqlParams = new object[] { tempID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateByID, sqlParams);
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
        /// 修改模板信息
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="tempName"></param>
        /// <param name="userID"></param>
        /// <param name="tempID"></param>
        /// <returns></returns>
        public bool ModifyTemplate(string transID, string tempName, string userID, string tempID)
        {
            object[] sqlParams = new object[] { tempName, userID, tempID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateTemplate, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 从模板中删除检查题目
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="userID"></param>
        /// <param name="tempID"></param>
        /// <returns></returns>
        public bool DeleteTitleFromTemp(string transID, string userID, string tempID)
        {
            object[] sqlParams = new object[] { userID, tempID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDeleteTitleFromTemp, sqlParams) > 0 ? true : false;
        }
    }
}
