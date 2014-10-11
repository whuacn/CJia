using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 添加病区对应用法的M层
    /// </summary>
    public class AddDeptUsageModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDept);
        }

        /// <summary>
        /// 查询当前病区未配置的用法
        /// </summary>
        /// <param name="officeId">当前病区ID</param>
        /// <returns></returns>
        public DataTable QueryUsage(string officeId)
        {
            object[] ob = new object[] { officeId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUsage,ob);
        }

        /// <summary>
        /// 插入病区对应用法数据
        /// </summary>
        /// <param name="officeId">病区ID</param>
        /// <param name="officeName">病区名称</param>
        /// <param name="usageId">用法Id</param>
        /// <param name="usageName">用法名称</param>
        /// <param name="createBy">创建人Id</param>
        /// <returns></returns>
        public bool InsertPivas(string officeId, string officeName, long usageId, string usageName, long createBy)
        {
            object[] obInsert = new object[] { officeId, officeName, usageId, usageName, createBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertDeptUsage, obInsert) > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否有重复 如果没有返回true 否则返回false
        /// </summary>
        /// <param name="officeId">病区Id</param>
        /// <param name="usageId">用法ID</param>
        /// <returns></returns>
        public bool QueryIsRepeat(string officeId,long usageId)
        {
            DataTable dt = new DataTable();
            object[] obIsRepeat = new object[] {officeId, usageId };
            dt = CJia.DefaultOleDb.Query(SqlTools.SqlQueryIsRepeat, obIsRepeat);
            if (dt != null&&dt.Rows!=null && dt.Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}