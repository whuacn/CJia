using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 冲药查询Model层
    /// </summary>
    public class PharmSendSelectModel : Tools.Model
    {
        /// <summary>
        /// 根据时间获得冲药单号
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>冲药单号</returns>
        public DataTable GetPharmSendNOByTime(DateTime time)
        {
            object[] sqlParams = ChangeDateTime(time);
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryPharmSendNOBySendTime, sqlParams);
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
        /// 根据发药单号得到瓶贴明细
        /// </summary>
        /// <param name="pharmSendNO">发药单号</param>
        /// <returns>瓶贴明细</returns>
        public DataTable GetLableDetailByPharmSendNO(string pharmSendNO)
        {
            object[] sqlParams = new object[] { pharmSendNO };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLableDetailByPharmSendNO, sqlParams);
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
        /// 根据发药单号得到汇总药品统计
        /// </summary>
        /// <param name="pharmSendNO">发药单号</param>
        /// <returns>汇总药品统计</returns>
        public DataTable GetLableStatByPharmSendNO(string pharmSendNO)
        {
            object[] sqlParams = new object[] { pharmSendNO };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelStatByPharmSendNO, sqlParams);
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
        /// 根据发药时间查询瓶贴信息及审核人信息
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>瓶贴信息及审核人信息</returns>
        public DataTable GetLabelAndCheckByPharmTime(DateTime time)
        {
            object[] sqlParams = ChangeDateTime(time);
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelAndCheckByPharmTime, sqlParams);
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
        /// 根据发药时间查询汇总药品统计
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>汇总药品统计</returns>
        public DataTable GetLabelCollectByPharmTime(DateTime time)
        {
            object[] sqlParams = ChangeDateTime(time);
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryLabelCollectBySendTime, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        #region 内部调用方法
        /// <summary>
        /// 根据一具体时间，得到一天的时间范围
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public object[] ChangeDateTime(DateTime date)
        {
            DateTime startdate = DateTime.Parse(date.ToShortDateString() + " 00:00:00");
            DateTime enddate = DateTime.Parse(date.ToShortDateString() + " 23:59:59");
            object[] sqlParams = new object[] { startdate, enddate };
            return sqlParams;
        }
        #endregion
    }
}
