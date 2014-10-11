using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 冲药Model层
    /// </summary>
    public class PharmSendModel : Tools.Model
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
        /// 获得冲药次数信息
        /// </summary>
        /// <param name="type">冲药类型编号</param>
        /// <returns>冲药次数信息</returns>
        public DataTable GetPharmSendTime(string type)
        {
            object[] sqlParams = new object[] { type };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTimeSet, sqlParams);
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
        /// 获得开始执行时间和截止时间
        /// </summary>
        /// <param name="timeID"></param>
        /// <returns></returns>
        public DataTable GetStartAndOverTime(int timeID)
        {
            object[] sqlParams = new object[] { timeID };
            DataTable dtResult = CJia.DefaultOleDb.Query(Models.Label.SqlTools.SqlQueryListTime, sqlParams);
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
        /// 获得PharmSendSeq值
        /// </summary>
        /// <returns>PharmSendSeq值</returns>
        public string GetPharmSendSeq()
        {
            string seq = CJia.DefaultOleDb.QueryScalar(SqlTools.SqlQueryPharmSendSeq);
            return seq;
        }
        /// <summary>
        /// 获得当天要冲药的瓶贴统计
        /// </summary>
        /// <returns>当天要冲药的瓶贴统计</returns>
        public DataTable GetTodayLable()
        {
            object[] sqlParams = new object[] { startdate, enddate };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelCollect, sqlParams);
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
        /// 获得当天要冲药的瓶贴详情
        /// </summary>
        /// <returns>当天要冲药的瓶贴详情</returns>
        public DataTable GetTodayLableDetail()
        {
            object[] sqlParams = new object[] { startdate, enddate };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelDetails, sqlParams);
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
        /// 判断当天待冲药中有无待审退的瓶贴
        /// </summary>
        /// <returns>bool</returns>
        public bool isExistApply()
        {
            object[] sqlParams = new object[] { startdate, enddate };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLableApply, sqlParams);
            if (int.Parse(dtResult.Rows[0][0].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得当天配置中心药房库存不足的待冲药
        /// </summary>
        /// <returns>库存不足的药品</returns>
        public DataTable GetTodayNOPharmStore(int timeID)
        {
            object[] sqlParams = new object[] { startdate, enddate, timeID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTodayNoPharmStore, sqlParams);
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
        /// 根据冲药次数修改当天待冲药瓶贴冲药状态
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="userID"></param>
        /// <param name="timeID"></param>
        /// <param name="userName"></param>
        /// <param name="timeID1"></param>
        /// <returns>bool</returns>
        public bool ModifyExeStatusByTimeID(string seq, long userID, int timeID, string userName, int timeID1)
        {
            object[] sqlParams = new object[] { seq, userID, timeID, userName, startdate, enddate, timeID1 };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateTodayLable, sqlParams) > 0 ? true : false;
        }

    }
}
