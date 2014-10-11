using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class EditDataModel : CJia.Evaluation.Tools.Model
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
        /// 根据资料Id查询资料信息
        /// </summary>
        /// <param name="DataId"></param>
        /// <returns></returns>
        public DataTable QueryDataByID(string DataId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DataId };
                DataTable dtData = ad.Query(SqlToos.SqlQueryDataById, ob);
                return dtData;
            }
        }

        /// <summary>
        /// 修改资料
        /// </summary>
        /// <param name="DataTitle"></param>
        /// <param name="DataContent"></param>
        /// <param name="DataType"></param>
        /// <param name="UserID"></param>
        /// <param name="DataId"></param>
        /// <returns></returns>
        public bool UpdateData(string DataTitle, string DataContent, string DataType,string UserID, string DataId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DataTitle, DataContent, DataType, UserID, DataId };
                bool IsUpdateData = ad.Execute(SqlToos.SqlUpdateData, ob) > 0 ? true : false;
                return IsUpdateData;
            }
        }

        
    }
}
