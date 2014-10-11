using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    public class DeptUsageModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDeptUsage()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryPivas);
        }

        /// <summary>
        /// 删除病区对应用法  把status改为0
        /// </summary>
        /// <param name="userId">当前登录用户</param>
        /// <param name="pivasSetId">ID</param>
        /// <returns></returns>
        public bool DeleteDeptUsage(long userId, long pivasSetId)
        {
            object[] ob = new object[] { userId, pivasSetId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteDeptUsage, ob) > 0 ? true : false;
        }
    }
}