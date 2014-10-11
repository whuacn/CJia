using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.App.Tools;
using CJia.HISOLAP.App.Report;

namespace CJia.HISOLAP.App.UI
{
    public partial class KeyOperationView : DevExpress.XtraEditors.XtraUserControl
    {
        public KeyOperationView()
        {
            InitializeComponent();
            this.filterView1.BindDefaultDepts();
            //OutoReport report = new OutoReport(ReportType.Vertical);
            //report.txtZBT = @"三级综合医院医疗质量评审指标";
            //report.txtFBT = "住院重点手术情况";
            //report.txtRQ = "2013年";
            //report.txtZZJJMC = "九江市妇幼保健院";
            //report.txtZZJJDM = "3566753112";
            //report.BindData(GetData());
            //printControl1.PrintingSystem = report.PrintingSystem;
        }
        public DataTable GetData(RefreshEventArgs e)
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
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" } });
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
            data = DataTableHelper.UpdateDataRow(data, "项目名称", oldToNew);
            return data;
        }

        private void filterView1_OnRefresh(object sender, RefreshEventArgs e)
        {
            OutoReport report = new OutoReport(ReportType.Vertical);
            report.txtZBT = @"三级综合医院医疗质量评审指标";
            report.txtFBT = "住院重点手术情况";
            report.txtRQ = e.SelectDateStr;
            report.txtZZJJMC = "九江市妇幼保健院";
            report.txtZZJJDM = "3566753112";
            report.BindData(GetData(e));
            printControl1.PrintingSystem = report.PrintingSystem;
        }



    }
}
