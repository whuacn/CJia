using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditOrganModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询地区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllArea()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllArea);
        }

        /// <summary>
        /// 根据组织编号查询组织信息
        /// </summary>
        /// <param name="organId"></param>
        /// <returns></returns>
        public DataTable QueryOrganById(string organId)
        {
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryOrganById,sqlParams);
        }

        /// <summary>
        /// 修改时是否存在相同组织编号
        /// </summary>
        /// <param name="organId">所要修改的组织ID</param>
        /// <param name="organNo">新组织编号</param>
        /// <returns></returns>
        public bool QueryExistSameOrganId(string organId,string organNo)
        {
            object[] sqlParams = new object[] { organId,organNo };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameOrganNoWhenUpdate, sqlParams);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据ID修改组织信息
        /// </summary>
        /// <param name="organNo">新组织编号</param>
        /// <param name="organName">新组织名称</param>
        /// <param name="areaId">新所属区域</param>
        /// <param name="updateBy">修改人</param>
        /// <param name="organId">所要修改的组织</param>
        /// <returns></returns>
        public bool UpdateOrganById(string organNo, string organName, string areaId, string updateBy, string organId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(organNo);
            sqlParams.Add(organName);
            sqlParams.Add(areaId);
            sqlParams.Add(updateBy);
            sqlParams.Add(organId);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateOrganById,sqlParams) > 0 ? true : false;
        }
    }
}
