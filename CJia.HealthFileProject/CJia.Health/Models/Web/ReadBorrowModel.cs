using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class ReadBorrowModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 获得我的病案
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetMyBorrow(string userID)
        {
            object[] sqlParams = new object[] { userID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryBorrowByUserID, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
    }
}
