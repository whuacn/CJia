using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Models
{
    public class PaymentModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMember()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMember);
        }

        /// <summary>
        /// 查询会员类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMemType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMemType);
        }

        /// <summary>
        /// 查询所选会员所有未过期缴费记录
        /// </summary>
        /// <param name="memId"></param>
        /// <returns></returns>
        public DataTable QueryMemPaylog(long memId)
        {
            object[] sqlParams = new object[] { memId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMemPaylogByMemId,sqlParams);
        }

        /// <summary>
        /// 查询是否存在相同时间段
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="memId"></param>
        /// <returns></returns>
        public DataTable QueryIsExistSameTime(DateTime startDate,long memId)
        {
            object[] sqlParams = new object[] { startDate,memId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameTime,sqlParams);
        }

        /// <summary>
        /// 插入缴费日志表
        /// </summary>
        /// <param name="memId">会员ID</param>
        /// <param name="memTypeId">会员类型ID</param>
        /// <param name="freeTime">免费停车时长</param>
        /// <param name="payAmount">缴费金额</param>
        /// <param name="payDate">缴费日期</param>
        /// <param name="startDate">开始计费日期</param>
        /// <param name="effectiveDate">有效日期</param>
        /// <param name="userId">创建人</param>
        /// <returns></returns>
        public bool InserPayLog(long memId,long memTypeId,string freeTime,double payAmount,DateTime startDate,DateTime effectiveDate,long userId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(memId);
            sqlParams.Add(memTypeId);
            sqlParams.Add(freeTime);
            sqlParams.Add(payAmount);
            sqlParams.Add(startDate);
            sqlParams.Add(effectiveDate);
            sqlParams.Add(userId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertPayLog,sqlParams) > 0 ? true : false;
        }
    }
}
