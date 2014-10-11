using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewHLYYQK : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT 
                              { 
	                            [Measures].[抗菌药物处方数/门诊处方（%）], 
	                            [Measures].[注射剂处方数/门诊处方（%）],
	                            [Measures].[药费收入占医疗总收入比重（%）], 
	                            [Measures].[抗菌药物出库金额占西药出库总金额比重（%）], 
	                            [Measures].[常用抗菌药物种类与可提供药敏实验种类比例（%）]
                              } ON ROWS,
                             {[DATE DIM].[DATE TIME].[ALL]} ON COLUMNS 
                              FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "本期数量" } }, new Dictionary<int, string>() { { 0, "70%" }, { 1, "30%" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    oldToNew.Add(data.Rows[i][0].ToString(), "（一）合理用药_       " + (i + 1).ToString() + "、" + data.Rows[i][0].ToString());
                    data.Rows[i][1] = data.Rows[i][1] != null && data.Rows[i][1].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][1].ToString()), 4) * 100 + "%" : data.Rows[i][1];
                }
            }
            data = DataTableHelper.UpdateDataRow(data, "项目名称$70%", oldToNew);
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewHLYYQK()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "医院合理用药情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
