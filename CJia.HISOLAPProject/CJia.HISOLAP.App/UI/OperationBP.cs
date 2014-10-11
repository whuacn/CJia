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
    public partial class OperationBP : DevExpress.XtraEditors.XtraUserControl
    {
        public OperationBP()
        {
            InitializeComponent();
            filterView1.BindDefaultDepts();
            
        }
        public DataTable GetData(RefreshEventArgs e)
        {
            string sql = @" SELECT NON EMPTY { [Measures].[一、二代头孢菌素使用比率],
[Measures].[万古霉素喹若酮等比率],
[Measures].[术前一小时内使用比率],
[Measures].[术前二小时内使用比率],
[Measures].[血量大于1500ml比率],
[Measures].[手术超三小时使用比率],
 [Measures].[术后24小时停止使用比率],
[Measures].[术后48小时停止使用比率],
 [Measures].[术后72小时停止使用比率],
 [Measures].[术后72小时继续使用比率]
  } ON COLUMNS, 
 { ([PERIOPERATIVE DIM].[SHOW NAME].[SHOW NAME].ALLMEMBERS ) }  ON ROWS
 FROM  [JJFB]";
            sql += e.filterDataDeptStr;
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "手术名称" } });
            if (data != null && data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    //oldToNew.Add(data.Rows[i][0].ToString(), i + 1 + ")" + data.Rows[i][0].ToString());
                    data.Rows[i][1] = data.Rows[i][1].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][1].ToString()), 4) * 100 : data.Rows[i][1];
                    data.Rows[i][2] = data.Rows[i][2].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][2].ToString()), 4) * 100 : data.Rows[i][2];
                    data.Rows[i][3] = data.Rows[i][3].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][3].ToString()), 4) * 100 : data.Rows[i][3];
                    data.Rows[i][4] = data.Rows[i][4].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][4].ToString()), 4) * 100 : data.Rows[i][4];
                    data.Rows[i][5] = data.Rows[i][5].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][5].ToString()), 4) * 100 : data.Rows[i][5];
                    data.Rows[i][6] = data.Rows[i][6].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][6].ToString()), 4) * 100 : data.Rows[i][6];
                    data.Rows[i][7] = data.Rows[i][7].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][7].ToString()), 4) * 100 : data.Rows[i][7];
                    data.Rows[i][8] = data.Rows[i][8].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][8].ToString()), 4) * 100 : data.Rows[i][8];
                    data.Rows[i][9] = data.Rows[i][9].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][9].ToString()), 4) * 100 : data.Rows[i][9];
                    data.Rows[i][10] = data.Rows[i][10].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][10].ToString()), 4) * 100 : data.Rows[i][10];
                }
            }
            return data;
        }

        private void filterView1_OnRefresh(object sender, RefreshEventArgs e)
        {
            OutoReport report = new OutoReport(ReportType.Vertical);
            report.FirstBT = 35;
            report.txtZBT = @"三级综合医院医疗质量评审指标";
            report.txtFBT = "围手术期预防情况";
            report.txtRQ = e.SelectDateStr;
            report.txtZZJJMC = Tools.Help.GetHosName();
            report.txtZZJJDM = Tools.Help.GetHosCode();
            report.BindData(GetData(e));
            printControl1.PrintingSystem = report.PrintingSystem;
        }
    }
}
