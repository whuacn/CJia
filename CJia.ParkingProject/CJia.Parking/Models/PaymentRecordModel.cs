using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class PaymentRecordModel : CJia.Parking.Tools.Model
    {
       /// <summary>
        /// 查询缴费记录
       /// </summary>
       /// <param name="startDate">开始日期</param>
       /// <param name="endDate">结束日期</param>
       /// <param name="memInfo">会员信息</param>
       /// <param name="PlateNo">车牌号</param>
       /// <param name="payDate">缴费日期</param>
       /// <returns></returns>
        public DataTable QueryMemPaymentlog(DateTime startDate,DateTime endDate,string memInfo,string plateNo,DateTime payDate)
        {
            //List<object> sqlParams = new List<object>();
            string sqlPlus = "";
            if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
            {
                sqlPlus = " and start_date<=date_trunc('hour', timestamp'" + startDate + "') and effective_date >=  date_trunc('hour', timestamp'" + endDate+"')";
            }
            if (memInfo != "")
            {
                sqlPlus += " and (gm.mem_no like '%" + memInfo + "%' or gm.mem_name like '%" + memInfo + "%')";
            }
            if (plateNo != "" && plateNo != null)
            {
                sqlPlus += " and plate_no like '%" + plateNo + "%'";
            }
            if (payDate != DateTime.MinValue)
            {
                sqlPlus += " and pay_date= date_trunc('hour', timestamp'" + payDate+"')";
            }
            sqlPlus = string.Format(SqlTools.SqlSelectMemberPaylog,sqlPlus);
            //sqlParams.Add(startDate);
            //sqlParams.Add(endDate);
            //sqlParams.Add(memInfo);
            //sqlParams.Add(plateNo);
            //sqlParams.Add(payDate);
            return CJia.DefaultPostgre.Query(sqlPlus);
        }
    }
}
