using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class MyApplyModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 获得申请单
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetMyApplyList(string userID)
        {
            string sql = @"select b.*,c.name borrow_state_name from st_borrow b,gm_code c WHERE b.borrow_state=c.code and b.status='1' and b.borrow_state in ('90','94')
                        and b.applyer_id=? ";
            object[] sqlParams = new object[] {userID };
            DataTable dtResult = CJia.DefaultOleDb.Query(sql, sqlParams);
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
        /// 获得申请单详情
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public DataTable GetMyApplyDetail(string listID)
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
        /// <summary>
        /// 修改申请单状态为撤销状态
        /// </summary>
        /// <param name="listNO"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModfiyBorrowList(string listID, string userID)
        {
            object[] sqlParams = new object[] { userID, listID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateBorrowStatus, sqlParams) > 0 ? true : false;
        }
    }
}
