using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class MyBorrowModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 获得我的借阅单
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetMyBorrowList(string userID)
        {
            object[] sqlParams = new object[] { "91", userID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryMyApplyListByUserID, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得借阅单详情
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public DataTable GetMyBorrowDetail(string listID)
        {
            object[] sqlParams = new object[] { listID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryMyApplyDetailByID, sqlParams);
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
