using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class TemplateManageModel : Tools.Model
    {
        /// <summary>
        /// 获得所有分类的父子关系
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemplateType()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateType);
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
        /// 根据分类获得模板
        /// </summary>
        /// <param name="organId">组织Id</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetTemplateByOrganIdAndType(string organId,string type)
        {
            object[] sqlParams = new object[] { organId,type, type, type };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateByOrganIdAndType, sqlParams);
            return dtResult;
        }
       
        /// <summary>
        /// 获得所有模板
        /// </summary>
        /// <param name="organId">组织ID</param>
        /// <returns></returns>
        public DataTable QueryTemplateByOrgan(string organId)
        {
            object[] sqlParams = new object[] { organId };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateByOrganId,sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public bool DeleteTemplate(string temID)
        {
            object[] sqlParams = new object[] { temID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteTemplate, sqlParams) > 0 ? true : false;
        }
    }
}
