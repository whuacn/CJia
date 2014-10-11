using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class EditDeptModel : CJia.Evaluation.Tools.Model
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
        /// 修改科室
        /// </summary>
        /// <param name="DeptName"></param>
        /// <param name="ParentID"></param>
        /// <param name="UserId"></param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public bool UpdateDept(string DeptName, string ParentID, string UserId, string DeptID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DeptName, ParentID, UserId, DeptID };
                bool bl = ad.Execute(SqlToos.SqlUpdateDept, ob) > 0 ? true : false;
                return bl;
            }
        }

        /// <summary>
        /// 根据科室ID查询科室信息 
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public DataTable QueryDeptByID(string DeptID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DeptID };
                DataTable dtDept = ad.Query(SqlToos.SqlQueryDeptByID, ob);
                return dtDept;
            }
        }
    }
}
