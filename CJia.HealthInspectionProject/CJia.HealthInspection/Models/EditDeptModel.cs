using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditDeptModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据部门Id查询部门信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DataTable QueryDeptById(string deptId)
        {
            object[] sqlParams = new object[] { deptId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDeptById,sqlParams);
        }

        /// <summary>
        /// 编辑时查询是否存在相同
        /// </summary>
        /// <param name="deptNo">修改后的部门编号</param>
        /// <param name="deptId">部门流水号</param>
        /// <returns>true：存在相同部门编号；false：不存在相同部门编号</returns>
        public bool QueryIsExistSameDeptNo(string deptNo,string deptId,string organId)
        {
            object[] sqlParams = new object[] { deptNo,deptId ,organId};
            DataTable dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsExistSameDeptNoWhenEdit,sqlParams);
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
        /// 修改部门信息
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool UpdateDept(List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateDeptById,sqlParams) > 0 ? true : false;
        }
    }
}
