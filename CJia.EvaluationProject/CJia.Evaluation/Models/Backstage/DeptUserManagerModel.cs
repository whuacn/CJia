using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class DeptUserManagerModel : CJia.Evaluation.Tools.Model
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
        /// 根据科室Id查询用户
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        public DataTable QueryUserByDeptId(string DeptId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DeptId };
                DataTable dt = ad.Query(SqlToos.SqlQueryUserByDeptId, ob);
                return dt;
            }
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public bool DeleteDept(string DeptID, string UserID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserID, DeptID, DeptID };
                bool isDelete = ad.Execute(SqlToos.SqlDeleteDept, ob) > 0 ? true : false;
                return isDelete;
            }
        }


        /// <summary>
        /// 判断当期那科室是否有子科室
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool IsHaveChildDept(string parentId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { parentId };
                DataTable dt = ad.Query(SqlToos.SqlIsHaveChild, ob);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UpdateBy"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteUser(string UpdateBy, string UserId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UpdateBy, UserId };
                bool isDelete = ad.Execute(SqlToos.SqlDeleteUser, ob) > 0 ? true : false;
                return isDelete;
            }
        }
    }
}
