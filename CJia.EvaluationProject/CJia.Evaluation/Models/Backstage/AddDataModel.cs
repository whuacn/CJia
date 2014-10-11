using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class AddDataModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 查询资料类别
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDataType()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDataType = ad.Query(SqlToos.SqlQueryDataType, null);
                return dtDataType;
            }
        }



        /// <summary>
        /// 添加资料
        /// </summary>
        /// <param name="dataTitle"></param>
        /// <param name="dataContent"></param>
        /// <param name="dataType"></param>
        /// <param name="UserID"></param>
        /// <param name="ColumnTreeID"></param>
        /// <returns></returns>
        public bool InsertData(string dataTitle, string dataContent, string dataType, string UserID, string ColumnTreeID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { dataTitle, dataContent, dataType, UserID, ColumnTreeID };
                bool isInsert = ad.Execute(SqlToos.SqlAddData, ob) > 0 ? true : false;
                return isInsert;
            }
        }
    }
}
