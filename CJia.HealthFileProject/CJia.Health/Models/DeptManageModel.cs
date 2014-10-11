using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class DeptManageModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 根据关键字查询科室 如果为空则查询所有科室
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <returns></returns>
        public DataTable QueryDept(string KeyWord)
        {
            if (KeyWord == "" || KeyWord == null)
            {
                return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllDept);
            }
            else
            {
                object[] ob = new object[] { "%" + KeyWord + "%", "%" + KeyWord + "%", "%" + KeyWord + "%" };
                return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDept, ob);
            }
        }

        /// <summary>
        /// 根据科室ID修改科室信息
        /// </summary>
        /// <param name="DeptID">科室ID</param>
        /// <returns></returns>
        public bool UpdateDept(string DeptNo,string DeptName,string DeptPinyin,string UserId, string DeptID)
        {
            object[] ob = new object[] { DeptNo, DeptName, DeptPinyin, UserId, DeptID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateDept, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="DeptNo"></param>
        /// <param name="DeptName"></param>
        /// <param name="DeptPinyin"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool AddDept(string DeptName,string UserId, string DeptNo, string DeptPinyin)
        {
            object[] ob = new object[] { DeptName, UserId, DeptNo, DeptPinyin };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertDept, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        public bool DeleteDept(string UserId, string DeptId)
        {
            object[] ob = new object[] { UserId, DeptId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteDept, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 查询科室表里有几条与当前编号一样的数据
        /// </summary>
        /// <param name="ProNo">项目编号</param>
        /// <returns></returns>
        public int CheckDeptIsRepeat(string DeptNo, string DeptId)
        {
            object[] ob = new object[] { DeptNo, DeptId };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckDeptIsRepeat, ob));
        }
    }
}
