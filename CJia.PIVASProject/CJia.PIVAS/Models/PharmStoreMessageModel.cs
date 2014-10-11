using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class PharmStoreMessageModel : Tools.Model
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
        /// 库存不足时,继续冲药(不包含库存不足的药品瓶贴)
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="userID"></param>
        /// <param name="timeID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ModifyExeStatusByTimeID(string seq, long userID, int timeID, string userName)
        {
            object[] sqlParams = new object[] { seq, userID, timeID, userName, startdate, enddate,startdate, enddate,timeID, timeID, };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlNotUpdateTodayNoStoreLabel, sqlParams) > 0 ? true : false;
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
    }
}
