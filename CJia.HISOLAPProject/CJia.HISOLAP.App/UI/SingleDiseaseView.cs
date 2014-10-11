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
    public partial class SingleDiseaseView : DevExpress.XtraEditors.XtraUserControl
    {
        public SingleDiseaseView()
        {
            InitializeComponent();
            this.filterView1.BindDefaultDepts();
        }

        public DataTable GetData(RefreshEventArgs e)
        {
            string sql1 = @"SELECT { [OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_医嘱离院],
[OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_医嘱转院],
[OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_医嘱转区],
[OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_自动离院],
[OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_死亡离院],
[OUTHOS MODE DIM].[OUTHOS TYPE NAME].[OUTHOS TYPE NAME].&[出院者离院方式情况_其他离院] } ON COLUMNS,
 { (DESCENDANTS([DISEASE TYPE DIM].[PARENT].[Level 02].ALLMEMBERS) 
   ) } ON ROWS
    FROM [JJFB] 
	where ({[Measures].[出院患者例数]},";
            sql1 += CJia.HISOLAP.App.Tools.Help.DateFilter(e.SelectStartDateTime, e.SelectEndDateTime);
            string strDept = CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            if (strDept != "")
            {
                sql1 += ",";
                sql1 += CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            }
            else
            {
 
            }
            sql1 += ")";
            DataTable data1 = CJia.DefaultOleDb.Query(sql1);
            string sql2 = @"SELECT {[Measures].[出院患者例数],[Measures].[患者住院天数],[Measures].[患者住院费用],  [Measures].[平均天数], [Measures].[平均费用],	 
	 [Measures].[出院死亡率%]
	   } ON COLUMNS, 
	 { (DESCENDANTS([DISEASE TYPE DIM].[PARENT].[Level 02].ALLMEMBERS) ) } ON ROWS 
	 FROM [JJFB]";
            sql2 += e.filterDataDeptStr;
            DataTable data2 = CJia.DefaultOleDb.Query(sql2);


            data1 = DataTableHelper.MergeLevel(data1, new List<int>() { 0, 1 });
            data2 = DataTableHelper.MergeLevel(data2, new List<int>() { 0, 1 });

            data1 = DataTableHelper.GetRealColName(data1);
            data2 = DataTableHelper.GetRealColName(data2);

            data1 = DataTableHelper.UpdateColName(data1, new Dictionary<int, string>() { {0,"单病种名称"}});
            data2 = DataTableHelper.UpdateColName(data2, new Dictionary<int, string>() { { 0, "单病种名称" } });


            DataTable allData = DataTableHelper.MergeDataTable(data2, "单病种名称", data1, "单病种名称");
            //allData = DataTableHelper.ColOrder(allData, new List<string>() { "出院者离院情况_医嘱离院", "出院者离院情况_" });

            allData.Columns["出院死亡率%"].SetOrdinal(allData.Columns.Count-1);
            return allData;
        }

        private void filterView1_OnRefresh(object sender, RefreshEventArgs e)
        {
            Report.OutoReport v = new Report.OutoReport(Report.ReportType.Vertical);
            v.txtZBT = @"三级综合医院医疗质量评审指标";
            v.txtFBT = @"三级综合医院医疗质量评审指标";
            v.txtRQ = "2012年";
            v.txtZZJJMC = "九江市妇幼保健院";
            v.txtZZJJDM = "495571840";
            v.txtRQ = e.SelectDateStr;
            v.BindData(GetData(e));
            printControl1.PrintingSystem = v.PrintingSystem;
        }
    }
}
