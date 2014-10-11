using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class NewCancelApplyModel : Tools.Model
    {
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime Sysdate()
        {
            return DateTime.Parse(CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
        }
        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }
        /// <summary>
        /// 根据时间和病区查询退药申请的医嘱
        /// </summary>
        /// <param name="date"></param>
        /// <param name="illfield"></param>
        /// <returns></returns>
        public DataTable GetApplyLabelByIffieldAndDate(DateTime date, List<string> illfield)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlNewQueryApplyLabelByIllfield;
            newSql = string.Format(newSql, GetIllfieldIdsStr(illfield).ToString());
            DateTime date1 = DateTime.Parse(date.ToShortDateString() + " 00:00:00");
            DateTime date2 = DateTime.Parse(date.ToShortDateString() + " 23:59:59");
            object[] parms = new object[] { date1, date2 };
            DataTable dtResult = CJia.DefaultOleDb.Query(newSql, parms);
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
        /// 根据瓶贴id修改瓶贴状态为拒绝申退
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyLabelStatusByID(string transID, string labelID, string userID)
        {
            object[] sqlParams = new object[] { "1000305", userID, labelID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateLabelStatusByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据瓶贴id修改瓶贴状态为已退
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyLabelStatusByID2(string transID, string labelID, string userID)
        {
            object[] sqlParams = new object[] { "1000303", userID, labelID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateLabelStatusByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据瓶贴id修改条形码状态为瓶贴作废
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyBarCodeStatusByID(string transID, string labelID, string userID)
        {
            object[] sqlParams = new object[] { userID, labelID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateBarCodeStatusByID, sqlParams) > 0 ? true : false;
        }


        /// <summary>
        /// 查询瓶贴的扣费次数
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public string QueryLabelTimes(string labelId)
        {
            object[] paramers = new object[] { labelId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlLabelTimes, paramers);
            if (string.IsNullOrEmpty(result))
            {
                result = "0";
            }
            return result;
        }

        /// <summary>
        /// 取得退药表下一个id
        /// </summary>
        /// <returns>退药表Sequence</returns>
        public long GetNextCancelRCPId()
        {
            return long.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlSelectNextCancelRCPId));
        }
        /// <summary>
        /// 修改瓶贴申请表中的退药单号
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="cancelRCPID"></param>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <param name="isFee"></param>
        /// <param name="lableStatus"></param>
        /// <returns></returns>
        public bool ModifyCancelRCPID(string transID, long cancelRCPID, string labelID, string userID, string isFee, string lableStatus)
        {
            object[] sqlParams = new object[] { lableStatus, cancelRCPID, userID, isFee, labelID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateApplyLabel, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 往退药单表中插入退药信息
        /// </summary>
        /// <param name="cancelRCPID"></param>
        /// <param name="checkUserID"></param>
        /// <param name="checkUserName"></param>
        /// <param name="checkDeptID"></param>
        /// <param name="checkDeptName"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public bool AddCancelApplyRCP(string transID, long cancelRCPID, string checkUserID, string checkUserName, string checkDeptID, string checkDeptName, string createBy)
        {
            object[] sqlParams = new object[] { cancelRCPID, checkUserID, checkUserName, checkDeptID, checkDeptName, createBy };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddCancelApplyRCP, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据条形码查询瓶贴信息
        /// </summary>
        /// <param name="barCodeID"></param>
        /// <returns></returns>
        public DataTable GetLabelByBarCodeList(List<string> barCodeID)
        {
            StringBuilder str = new StringBuilder("");
            foreach (string barCode in barCodeID)
            {
                str.Append(barCode);
                str.Append(",");
            }
            if (str.Length > 0)
            {
                str.Remove(str.Length - 1, 1);
            }
            string sql = string.Format(SqlTools.SqlQueryLabelByBarCodeList, str.ToString(), str.ToString());
            DataTable dtResult = CJia.DefaultOleDb.Query(sql);
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
        /// 根据条形码查询瓶贴信息
        /// </summary>
        /// <param name="barCodeID"></param>
        /// <returns></returns>
        public DataTable GetLabelByBarCodeID(string barCodeID)
        {
            object[] param = new object[] { barCodeID, barCodeID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelByBarCodeID, param);
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
        /// 插入退药表
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="deptID"></param>
        /// <param name="deptName"></param>
        /// <param name="reason"></param>
        /// <param name="createrBy"></param>
        /// <returns></returns>
        public bool AddCancelApply(string transID, string labelID, string labelBarCode, string userID, string userName, string deptID, string deptName, string reason, string createrBy, string isFee)
        {
            object[] sqlParams = new object[] { labelID, userID, userName, deptID, deptName, reason, createrBy, labelBarCode, isFee };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlAddCancelApply2, sqlParams) > 0 ? true : false;
        }

        #region 内部调用方法
        /// <summary>
        /// 获得病区id
        /// </summary>
        /// <param name="illfieldIds"></param>
        /// <returns></returns>
        private StringBuilder GetIllfieldIdsStr(List<string> illfieldIds)
        {
            StringBuilder Ids = new StringBuilder(" and l.illfield_id in (");
            if (illfieldIds != null && illfieldIds.Count > 0)
            {
                foreach (string id in illfieldIds.ToArray())
                {
                    Ids.Append(id.ToString() + ",");
                }
                Ids.Remove(Ids.Length - 1, 1);
                Ids.Append(") ");
            }
            else
            {
                Ids = new StringBuilder(" and 0 = 1 ");
            }
            return Ids;
        }

        /// <summary>
        /// 删除瓶贴id对应的退药申请
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="labelID"></param>
        public void DelectCancelApply(string transID, string labelID)
        {
            object[] sqlParams = new object[] { labelID };
            CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDelectCancelApply, sqlParams);
        }
        #endregion


    }
}
