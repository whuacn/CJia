using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class CheckSubmitModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 获得评审状态
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckState()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryCheckState, null);
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
        /// <summary>
        /// 获得评审结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckResult()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryCheckResult, null);
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
        /// <summary>
        /// 根据评审状态获得条款
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public DataTable GetCheckData(string stateID)
        {
            using (Adapter ad = new Adapter())
            {
                string sql = "";
                DataTable dtResult;
                if (stateID == "0")//选择全部
                {
                    sql = string.Format(Models.SqlToos.SqlQueryCheckByState, "1=1");
                    dtResult = ad.Query(sql, null);
                }
                else
                {
                    sql = string.Format(Models.SqlToos.SqlQueryCheckByState, "t.check_state = ?");
                    object[] sqlparams = new object[] { stateID };
                    dtResult = ad.Query(sql, sqlparams);
                }
                return dtResult;
            }
        }
        /// <summary>
        /// 修改条款状态
        /// </summary>
        /// <param name="checkID"></param>
        /// <param name="stateID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyCheckState(string checkID, string stateID, string userID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { stateID, userID, checkID };
                bool bl = ad.Execute(SqlToos.SqlModifyCheckState, ob) > 0 ? true : false;
                return bl;
            }
        }
        /// <summary>
        /// 根据id获得条款
        /// </summary>
        /// <param name="checkID"></param>
        /// <returns></returns>
        public DataTable GetCheckDataByID(string checkID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = new object[] { checkID };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryCheckByID, sqlparams);
                return dtResult;
            }
        }
        /// <summary>
        /// 评审
        /// </summary>
        /// <param name="checkID"></param>
        /// <param name="stateID"></param>
        /// <param name="resultID"></param>
        /// <param name="checkAdvice"></param>
        /// <param name="zhenggaiAdvice"></param>
        /// <param name="endDate"></param>
        /// <param name="checkDate"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ModifyCheck(string checkID, string stateID, string resultID, string checkAdvice, string zhenggaiAdvice, string endDate, string checkDate, string userID, string userName)
        {
            using (Adapter ad = new Adapter())
            {
                string sql = "";
                if (stateID != "1204")//退回改进  整改次数+1
                {
                    sql = string.Format(SqlToos.SqlModifyCheck, "");
                }
                else
                {
                    sql = string.Format(SqlToos.SqlModifyCheck, ",times=times+1");
                }
                object[] ob = new object[] { stateID, resultID, checkAdvice, zhenggaiAdvice, endDate, userID, userName, checkDate, userID, checkID };
                return ad.Execute(sql, ob) > 0 ? true : false;
            }
        }
    }
}
