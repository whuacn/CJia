using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditCheckTitleModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 获取模板大分类
        /// </summary>
        /// <returns></returns>
        public DataTable GetBigTemplate()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryBigTemplate);
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
            if (dtResult != null &&  dtResult.Rows != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据模板小分类查询题目信息
        /// </summary>
        /// <param name="organ"></param>
        /// <param name="smallTypeId"></param>
        /// <returns></returns>
        public DataTable QueryTitleBySmallType(long organ,string BigTypeId, string MiddleTypeId, string smallTypeId)
        {
            object[] ob = new object[] { organ, "%" + BigTypeId + "%", "%" + MiddleTypeId + "%", "%" + smallTypeId + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTitleBySmallType, ob);
            return dtResult;
        }

    }
}
