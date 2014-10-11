using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class SelectTemplateModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据组织查询模版
        /// </summary>
        /// <param name="organId">登录用户所输组织ID</param>
        /// <returns></returns>
        public DataTable QueryAllTemplate(long organID)
        {
            object[] ob = new object[] { organID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllTemplateForExeCheck, ob);
            return dtResult;
        }

        /// <summary>
        /// 获得模板大分类类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBigTemplate()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBigTemplate);
        }
        /// <summary>
        /// 根据模板大分类获得中分类类型
        /// </summary>
        /// <param name="bigTemplateId">所选择大分类ID</param>
        /// <returns></returns>
        public DataTable QueryMidTemplateByBig(string bigTemplateId)
        {
            object[] sqlParams = new object[] { bigTemplateId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryMiddleTemplate, sqlParams);
        }
        /// <summary>
        /// 根据模板中分类获得小分类类型
        /// </summary>
        /// <param name="midTemplateId">所选择中分类ID</param>
        /// <returns></returns>
        public DataTable QuerySmallTemplateByMid(string midTemplateId)
        {
            object[] sqlParams = new object[] { midTemplateId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQuerySmallTemplate, sqlParams);
        }

        /// <summary>
        /// 根据分类获得模板
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTemplateByType(string BigTypeId, string MiddleTypeId, string smallTypeId, long organ_id)
        {
            object[] sqlParams = new object[] { organ_id, "%" + BigTypeId + "%", "%" + MiddleTypeId + "%", "%" + smallTypeId + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryTemplateByTypeIdForExeCheck, sqlParams);
            return dtResult;
        }

        /// <summary>
        ///  根据模版ID查询模板名称
        /// </summary>
        /// <param name="templateId">所要查询ID</param>
        /// <returns></returns>
        public string QueryTemplateNameById(long templateId)
        {
            object[] sqlParams = new object[] { templateId };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryTemplateNameById, sqlParams);
        }
    }
}
