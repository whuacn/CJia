using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AddOrganModel : CJia.HealthInspection.Tools.Model
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
        /// 插入时是否存在相同组织编号
        /// </summary>
        /// <param name="organNo">所要添加的组织编号</param>
        /// <returns></returns>
        public bool QueryExistSameOrganId(string organNo)
        {
            object[] sqlParams = new object[] { organNo };
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryExistSameOrganNoWhenAdd,sqlParams);
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
        /// 插入组织表
        /// </summary>
        /// <param name="organNo">组织编号</param>
        /// <param name="organName">组织名称</param>
        /// <param name="createBy">创建人</param>
        /// <param name="areaId">组织所属区域编号</param>
        /// <returns>true：插入成功；false：插入失败</returns>
        public bool InsertOrgan(string organNo,string organName,string createBy,string areaId)
        {
            object[] sqlParams = new object[] { organNo,organName,createBy,areaId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertOrgan,sqlParams) > 0 ? true : false;
        }
    }
}
