using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class ColumEditModel : CJia.Evaluation.Tools.Model
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
        /// 查询栏目级别
        /// </summary>
        /// <param name="ColumnTreeID"></param>
        /// <returns></returns>
        public int QueryColumnLevel(long ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ColumnID };
                string ColumnLevel = ad.QueryScalar(SqlToos.SqlQueryColumnLevel, ob);
                return ColumnLevel != "" ? Convert.ToInt32(ColumnLevel) : 0;
            }
        }

        /// <summary>
        /// 删除树状节点并把审核表的数据删除
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public bool DeleteColumn(string UpdateBy, long ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] obColumn = new object[] { UpdateBy, ColumnID, ColumnID };
                object[] obCheck = new object[] { UpdateBy, ColumnID };
                bool IsDelete = ad.ExeTransaction(SqlToos.SqlDeleteColumnTree, obColumn, SqlToos.SqlDeleteCheck, obCheck) > 0 ? true : false;
                return IsDelete;
            }
        }
    }
}
