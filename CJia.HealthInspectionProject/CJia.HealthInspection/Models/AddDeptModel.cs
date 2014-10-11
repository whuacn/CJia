using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class AddDeptModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 插入部门表时查询同一组织是否存在相同部门编号
        /// </summary>
        /// <param name="deptNo">所要插入单位编号</param>
        /// <param name="organId">组织流水号</param>
        /// <returns>true：存在相同编号；false：不存在相同编号</returns>
        public bool IsExistSameDeptNo(string deptNo,string organId)
        {
            object[] sqlParams = new object[] { deptNo,organId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlQueryIsExistSameDeptNoAdd,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 插入部门表
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool InsertDept(List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertDept,sqlParams) > 0 ? true : false;
        }
    }
}
