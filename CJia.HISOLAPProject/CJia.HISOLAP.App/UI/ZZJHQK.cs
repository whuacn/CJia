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
    public partial class ZZJHQK : DevExpress.XtraEditors.XtraUserControl
    {
        public ZZJHQK()
        {
            InitializeComponent();
            this.filterView1.BindDefaultDepts();
        }
        public DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT NON EMPTY { 
                             [Measures].[非预期的24/48小时重返重症医学科率（%）],
                             [Measures].[呼吸机相关肺炎预防率（%）], 
                             [Measures].[呼吸机相关肺炎发病率（%）],
                             [Measures].[中心静脉置留相关血流感染发生率（%）],
                             [Measures].[留置导尿管相关泌尿系感染发病率（%）],
                             [Measures].[重症患者死亡率（%）],
                             [Measures].[重症患者压疮发生率（%）], 
                             [Measures].[人工气道脱出总数],
                             [Measures].[气道脱出再次插入总数] 
                              } ON rows,
                            {[DATE DIM].[DATE TIME].[All]} ON COLUMNS
                             FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string> { { 0, "项目名称" }, { 1, "本期数量" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            //（一）资源配置
            oldToNew.Add("非预期的24/48小时重返重症医学科率（%）", "（一）重症医学（ICU）质量_      1、非预期的24/48小时重返重症医学科率（%）");
            oldToNew.Add("呼吸机相关肺炎预防率（%）", "（一）重症医学（ICU）质量_      2、呼吸机相关肺炎预防率（%）");
            oldToNew.Add("呼吸机相关肺炎发病率（%）", "（一）重症医学（ICU）质量_      3、呼吸机相关肺炎发病率（%）");
            oldToNew.Add("中心静脉置留相关血流感染发生率（%）", "（一）重症医学（ICU）质量_      4、中心静脉置留相关血流感染发生率（%）");
            oldToNew.Add("留置导尿管相关泌尿系感染发病率（%）", "（一）重症医学（ICU）质量_      5、留置导尿管相关泌尿系感染发病率（%）");
            oldToNew.Add("重症患者死亡率（%）", "（一）重症医学（ICU）质量_      6、重症患者死亡率（%）");
            oldToNew.Add("重症患者压疮发生率（%）", "（一）重症医学（ICU）质量_      7、重症患者压疮发生率（%）");
            oldToNew.Add("人工气道脱出总数", "（一）重症医学（ICU）质量_      8、人工气道脱出总数");
            oldToNew.Add("气道脱出再次插入总数", "（一）重症医学（ICU）质量_      9、气道脱出再次插入总数");
            data = DataTableHelper.UpdateDataRow(data, "项目名称", oldToNew);
            for (int i = 0; i < data.Rows.Count-2; i++)
            {
                data.Rows[i][1] = Math.Round(Convert.ToDouble(data.Rows[i][1]), 4) * 100 + "%";
            }
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
