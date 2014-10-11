using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models.Web
{
    public class ApplyModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 根据病人信息查询病案
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="patientName"></param>
        /// <returns></returns>
        public DataTable GetRecordByPatientInfo(string patientName)
        {
            object[] sqlParams = new object[] { "%" + patientName + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryRecordByPatientInfo, sqlParams);
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
        /// 插入申请
        /// </summary>
        /// <param name="recordNO"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool AddApplyInfo(string recordNO, string userID, string userName)
        {
            object[] sqlParams = new object[] { userID, userName, recordNO, userID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlAddBorrowDetail, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据病案号和用户id查询申请信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetApply(string userID)
        {
            object[] sqlParams = new object[] {userID };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlQueryApply, sqlParams);
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
