using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class CancelLabelModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 当天开始时间
        /// </summary>
        private DateTime startdate = DateTime.Parse(PIVASModel.QuerySysdate().ToShortDateString() + " 00:00:00");
        /// <summary>
        /// 当天结束时间
        /// </summary>
        private DateTime enddate = DateTime.Parse(PIVASModel.QuerySysdate().ToShortDateString() + " 23:59:59");
        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }
        /// <summary>
        /// 根据时间，病区，床号查询病人医嘱信息
        /// </summary>
        /// <param name="date"></param>
        /// <param name="illfield"></param>
        /// <param name="bedNO"></param>
        /// <returns></returns>
        public DataTable GetAdviceByIffieldAndBedNO(DateTime date, string illfield, string bedNO, string barCode, string piciID)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryAdviceByIllfieldAndBedNO;
            string illfieldStr = "";
            if (illfield != "0")
            {
                illfieldStr = " and l.illfield_id = '" + illfield + "'  ";
            }
            string pici = "";
            if (piciID != "0")//批次
            {
                pici = " and l.batch_id='" + piciID + "' ";
            }
            string bedNOStr = "";
            if (bedNO != "")
            {
                bedNOStr = " and l.bed_id = '" + bedNO + "' ";
            }
            string barCodeStr = " and gb.LABEL_BAR_ID like '%" + barCode + "%' ";
            newSql = string.Format(newSql, illfieldStr, bedNOStr, barCodeStr, pici);
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
        /// 根据条形码或者医嘱id查询病人医嘱信息
        /// </summary>
        /// <param name="barCodeNO"></param>
        /// <param name="adviceID"></param>
        /// <returns></returns>
        public DataTable GetAdviceByBarCodeNOOrAdviceNO(string barCodeNO, string adviceID)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryAdviceByBarCodeNOOrAdviceID;
            string barCodeNOStr = "";
            if (barCodeNO.Length > 0)
            {
                barCodeNOStr = "   ";
            }
            string adviceIDStr = "";
            if (adviceID.Length > 0)
            {
                adviceIDStr = "";
            }
            newSql = string.Format(newSql, barCodeNOStr, adviceIDStr);
            DataTable dtResult = CJia.DefaultOleDb.Query(newSql);
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
        /// 插入退药申请
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="labelNO"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="deptID"></param>
        /// <param name="deptName"></param>
        /// <param name="reason"></param>
        /// <param name="createrBy"></param>
        /// <returns></returns>
        public bool AddCancelApply(string labelID, string labelBarID, string userID, string userName, string deptID, string deptName, string reason, string createrBy, string isFee)
        {
            object[] sqlParams = new object[] { labelID, userID, userName, deptID, deptName, reason, createrBy, labelBarID, isFee };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlAddCancelApply2, sqlParams) > 0 ? true : false;//by dh SqlAddCancelApply2
        }
        /// <summary>
        /// 根据部门id获得部门名称
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public DataTable GetDeptNameByID(string deptID)
        {
            object[] sqlParams = new object[] { deptID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryDeptNameByID, sqlParams);
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
        /// 根据瓶贴id修改瓶贴状态
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ModifyLabelStatusByID(string labelID, string userID)
        {
            object[] sqlParams = new object[] { "1000302", userID, labelID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateLabelStatusByID, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 根据时间和病区查询出待处理的退药申请
        /// </summary>
        /// <param name="date"></param>
        /// <param name="illfield"></param>
        /// <returns></returns>
        public DataTable GetCancelApplyByIllfiedID(DateTime date, string illfield)
        {
            string newSql = CJia.PIVAS.Models.SqlTools.SqlQueryApplyLabelByIllfield;
            string illfieldStr = "";
            if (illfield != "0")
            {
                illfieldStr = " and l.illfield_id = '" + illfield + "'  ";
            }
            newSql = string.Format(newSql, illfieldStr);
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
        /// 查询所有批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }
    }
}