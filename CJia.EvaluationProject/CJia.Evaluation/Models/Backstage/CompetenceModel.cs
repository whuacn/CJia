using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class CompetenceModel : CJia.Evaluation.Models.Backstage.ColumEditModel
    {
        /// <summary>
        /// 查询栏目树状
        /// </summary>
        /// <returns></returns>
        public DataTable QueryColumTree()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtColumTree = ad.Query(SqlToos.SqlQueryColum, null);
                return dtColumTree;
            }
        }

        /// <summary>
        /// 查询用户栏目权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable QueryColumnCompetence(string UserID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserID };
                DataTable dtColumnCompetence = ad.Query(SqlToos.SqlQueryColumnCompetence, ob);
                return dtColumnCompetence;
            }
        }

        /// <summary>
        /// 查询菜单树状结构
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMenuTree()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtMenuTree = ad.Query(SqlToos.SqlQueryMenuTree, null);
                return dtMenuTree;
            }
        }

        /// <summary>
        /// 查询已拥有的菜单权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable QueryMenuCompetence(string UserID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserID };
                DataTable dtColumnCompetence = ad.Query(SqlToos.SqlQueryMenuCompetence, ob);
                return dtColumnCompetence;
            }
        }

        /// <summary>
        /// 添加用户权限（事务）
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public bool InsertCompetence(List<object[]> ob)
        {
            using (Adapter ad = new Adapter())
            {
                bool isInsert = ad.ExeTransaction(SqlToos.SqlInsertCompetence, ob) > 0 ? true : false;
                return isInsert;
            }
        }

        /// <summary>
        /// 先删除用户全部权限在添加新权限
        /// </summary>
        /// <param name="ob1"></param>
        /// <param name="ob2"></param>
        /// <returns></returns>
        public bool DeleteInsertCompetence(List<object[]> ob1,List<object[]> ob2)
        {
            using (Adapter ad = new Adapter())
            {
                bool isDeleteInsert = ad.ExeTransaction(SqlToos.SqlDeleteCompetence, ob1, SqlToos.SqlInsertCompetence, ob2) > 0 ? true : false;
                return isDeleteInsert;
            }
        }
    }
}
