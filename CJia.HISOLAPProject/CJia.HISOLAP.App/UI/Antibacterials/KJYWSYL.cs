using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI.Antibacterials
{
    public class KJYWSYL : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.PIVAS);
            string sql = @"SELECT DD.DEPT_NAME, SUM(IBD.COSTS) AMOUNT, '' DDDS
                                      FROM INP_BILL_DETAIL IBD, DEPT_DICT DD
                                     WHERE IBD.ORDERED_BY = DD.DEPT_CODE
                                       AND IBD.BILLING_DATE_TIME BETWEEN ? AND ?";
            if (!e.IsSelectAllDept)
            {
                sql += " and DD.DEPT_CODE in (" + CJia.HISOLAP.App.Tools.Help.GetDeptString(e.SelectDepts) + ")";
            }
            sql += @" GROUP BY DD.DEPT_NAME ORDER BY AMOUNT";
            object[] ob = new object[] { e.SelectStartDateTime, e.SelectEndDateTime };
            DataTable data = CJia.DefaultOleDb.Query(sql, ob);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "科室名称" }, { 1, "    金额    " }, { 2, "DDDs" } });
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public KJYWSYL()
        {
            this.ZBT = "抗菌药物药品使用统计报表";
            this.IsDeptName = true;
            this.FBT = "抗菌药物使用量";
            this.ReportType = Report.ReportType.Horizontal;
        }
    }
}
