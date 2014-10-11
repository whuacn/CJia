using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI.Antibacterials
{
    public class BQKJYWSYQD : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.PIVAS);
            string sql = @"SELECT DEPT_NAME, 90 DDDs
                                      FROM PAT_VISIT PV, DEPT_DICT GDV
                                    WHERE PV.DEPT_ADMISSION_TO = GDV.DEPT_CODE
                                      AND PV.DISCHARGE_DATE_TIME BETWEEN ? and ? ";
            if (!e.IsSelectAllDept)
            {
                sql += " and PV.DEPT_ADMISSION_TO in (" + CJia.HISOLAP.App.Tools.Help.GetDeptString(e.SelectDepts) + ")";
            }
            sql += " GROUP BY DEPT_NAME";
            object[] ob = new object[] { e.SelectStartDateTime, e.SelectEndDateTime };
            DataTable data = CJia.DefaultOleDb.Query(sql, ob);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "病区名称" }, { 1, "   DDDs   " } });
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public BQKJYWSYQD()
        {
            this.ZBT = "抗菌药物药品使用统计报表";
            this.IsDeptName = true;
            this.FBT = "病区抗菌药物使用率";
            this.ReportType = Report.ReportType.Horizontal;
        }
    }
}
