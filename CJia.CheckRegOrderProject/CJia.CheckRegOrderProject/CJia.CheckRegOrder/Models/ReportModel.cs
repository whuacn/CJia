using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Models
{
    public class ReportModel
    {
        /// <summary>
        /// 查询出当天所有检查病人的报告
        /// </summary>
        /// <returns></returns>
        public DataTable GetNowAllReport()
        {
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectReport);
            if (data != null && data.Rows.Count > 0)
            {
                return ChangeData(data);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据病人姓名查询报告
        /// </summary>
        /// <param name="patientName">姓名</param>
        /// <returns></returns>
        public DataTable GetReportByName(string patientName)
        {
            object[] sqlParam = new object[] { patientName };
            DataTable data = CJia.DefaultSQL.Query(SqlTools.sqlSelectReportByName,sqlParam);
            if (data != null && data.Rows.Count > 0)
            {
                return ChangeData(data);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据报告id修改报告信息
        /// </summary>
        /// <param name="reportID">报告id</param>
        /// <returns></returns>
        public bool ModifyReportByID(int reportID)
        {
            object[] sqlParam = new object[] { reportID };
            return CJia.DefaultSQL.Execute(SqlTools.sqlUpdateReportByID, sqlParam) > 0 ? true : false;
        }

        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ChangeData(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["print_state"].ToString() == "1")
                {
                    dr["print_state"] = "已打印";
                }
                else
                {
                    dr["print_state"] = "未打印";
                }
            }
            return data;
        }

    }
}
