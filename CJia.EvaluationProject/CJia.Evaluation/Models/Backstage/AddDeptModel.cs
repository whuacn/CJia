using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class AddDeptModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 查询科室
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllDept()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDept = ad.Query(SqlToos.SqlQueryAllDept, null);
                return dtDept;
            }
        }

        /// <summary>
        /// 添加科室
        /// </summary>
        /// <param name="DeptName"></param>
        /// <param name="ParentId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool InsertDept(string DeptName, string ParentId, string UserId)
        { 
            using(Adapter ad=new Adapter())
            {
                object[] ob = new object[] { DeptName, ParentId, UserId };
                bool IsInsert = ad.Execute(SqlToos.SqlInsertDept, ob) > 0 ? true : false;
                return IsInsert;
            }
        }
    }
}
