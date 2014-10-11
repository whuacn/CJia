using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class DataInputModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 查询栏目树状
        /// </summary>
        /// <returns></returns>
        public DataTable QueryColumTree(string UserId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserId };
                DataTable dtColumTree = ad.Query(SqlToos.SqlQueryColumnAndCompetence, ob);
                return dtColumTree;
            }
        }

        /// <summary>
        /// 根据栏目Id查询资料
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public DataTable QueryDataByColumnId(string ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ColumnID };
                DataTable dtData = ad.Query(SqlToos.QueryDataByColumnId, ob);
                return dtData;
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
        /// 删除资料
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="DataId"></param>
        /// <returns></returns>
        public bool DeleteData(string UserId, string DataId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserId, DataId };
                bool IsDeleteData = ad.Execute(SqlToos.SqlDeleteData, ob) > 0 ? true : false;
                return IsDeleteData;
            }
        }
    }
}
