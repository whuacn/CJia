using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewKeyOperationView : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT {
                                                    [Measures].[手术例数], 
                                                    [Measures].[死亡例数],
                                                    [Measures].[住院重点手术死亡率%], 
                                                    [Measures].[术后非预期再手术例数], 
                                                    [Measures].[术后非预期再手术率%],
                                                    [Measures].[平均住院天数], 
                                                    [Measures].[平均住院费用]
                                                    } ON COLUMNS, 
                                                    { (DESCENDANTS([KEY OPERATION DIM].[PARENT CODE].[Level 02].ALLMEMBERS) ) }  ON ROWS 
                                                    FROM [JJFB] 
                                                    ";
            //sql = sql + @" WHERE ( " + CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts) + ": " + CJia.HISOLAP.App.Tools.Help.DateFilter(e.SelectStartDateTime, e.SelectEndDateTime) + ")";
            sql += e.filterDataDeptStr;
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.MergeLevel(data, new List<int>() { 0, 1 });
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "手术例数" }, { 2, "死亡例数" }, { 3, "住院重点手术死亡率" }, { 4, "术后非预期再手术例数" }, { 5, "术后非预期再手术率" }, { 6, "平均住院天数" }, { 7, "平均住院费用" } }, new Dictionary<int, string>() { { 0, "30%" }, { 1, "10%" }, { 2, "10%" }, { 3, "10%" }, { 4, "10%" }, { 5, "10%" }, { 6, "10%" }, { 7, "10%" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();

            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    oldToNew.Add(data.Rows[i][0].ToString(), "住院重点手术指标_ " + data.Rows[i][0].ToString());

                    data.Rows[i][5] = data.Rows[i][5] != null && data.Rows[i][5].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][5].ToString()), 4) * 100 + "%" : data.Rows[i][5];
                    data.Rows[i][3] = data.Rows[i][3] != null && data.Rows[i][3].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][3].ToString()), 4) * 100 + "%" : data.Rows[i][3];
                    data.Rows[i][6] = data.Rows[i][6] != null && data.Rows[i][6].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][6].ToString()), 2) : data.Rows[i][6];
                    data.Rows[i][7] = data.Rows[i][7] != null && data.Rows[i][7].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][7].ToString()), 2) : data.Rows[i][7];
                }
            }
            data = DataTableHelper.UpdateDataRow(data, "项目名称$30%", oldToNew);
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewKeyOperationView()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "住院重点手术情况";
            this.ReportType = Report.ReportType.Vertical;
        }

    }
}

