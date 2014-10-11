using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.App.Report;
using CJia.HISOLAP.App.Tools;

namespace CJia.HISOLAP.App.UI
{
    public partial class SurgicalView : DevExpress.XtraEditors.XtraUserControl
    {
        public SurgicalView()
        {
            InitializeComponent();
            filterView1.BindDefaultDepts();
        }
        public DataTable GetData(RefreshEventArgs e)
        {
            string sql = @" SELECT NON EMPTY {[Measures].[（一）手术麻醉方式情况_1、麻醉总例数],
[Measures].[（一）手术麻醉方式情况_2、全身麻醉总例数],
[Measures].[（一）手术麻醉方式情况_     其中：体外循环例数],
[Measures].[（一）手术麻醉方式情况_3、脊髓麻醉例数],
 [Measures].[（一）手术麻醉方式情况_4、其他麻醉例数], 
[Measures].[（二）实施镇痛治疗情况_1、实施镇痛例数],
[Measures].[（二）实施镇痛治疗情况_2、门诊患者例数],
 [Measures].[（二）实施镇痛治疗情况_3、住院患者例数],
 [Measures].[（二）实施镇痛治疗情况_     其中：手术后镇痛],
 [Measures].[（三）实施心肺复苏情况_1、实施心肺复苏治疗例数],
 [Measures].[（三）实施心肺复苏情况_2、实施心肺复苏成功例数],
 [Measures].[（四）麻醉复苏管理情况_1、麻醉复苏管理例数],
 [Measures].[（四）麻醉复苏管理情况_2、进入麻醉复苏室例数],
[Measures].[（四）麻醉复苏管理情况_3、离室时评分大于等于4分例数],
 [Measures].[（五）麻醉非预期的情况_1、麻醉非预期的相关事件例数], 
 [Measures].[（五）麻醉非预期的情况_2、麻醉中发生未预期的意识障碍例数],
[Measures].[（五）麻醉非预期的情况_3、麻醉中出现氧饱和度重度降低例数],
[Measures].[（五）麻醉非预期的情况_4、全身麻醉结束时使用催醒药物例数],
 [Measures].[（五）麻醉非预期的情况_5、麻醉中因误咽误吸引发呼吸道梗阻例数], 
 [Measures].[（五）麻醉非预期的情况_6、麻醉意外死亡例数], 
 [Measures].[（五）麻醉非预期的情况_7、其他非预期的相关事件例数],
 [Measures].[（六）麻醉麻醉分级管理情况_1、麻醉分级管理例数], 
[Measures].[（六）麻醉麻醉分级管理情况_2、麻醉分级管理Ⅰ级例数],
 [Measures].[（六）麻醉麻醉分级管理情况_     其中：麻醉Ⅰ级术后死亡例数],
 [Measures].[（六）麻醉麻醉分级管理情况_3、麻醉分级管理Ⅱ级例数],
[Measures].[（六）麻醉麻醉分级管理情况_     其中：麻醉Ⅱ级术后死亡例数],
 [Measures].[（六）麻醉麻醉分级管理情况_4、麻醉分级管理Ⅲ级例数],
[Measures].[（六）麻醉麻醉分级管理情况_     其中：麻醉Ⅲ级术后死亡例数],
 [Measures].[（六）麻醉麻醉分级管理情况_5、麻醉分级管理Ⅳ级例数], 
[Measures].[（六）麻醉麻醉分级管理情况_     其中：麻醉Ⅳ级术后死亡例数],
[Measures].[（六）麻醉麻醉分级管理情况_6、麻醉分级管理Ⅴ级例数], 
 [Measures].[（六）麻醉麻醉分级管理情况_     其中：麻醉Ⅴ级术后死亡例数]}
ON ROWS, NON EMPTY { ([DATE DIM].[DATE YEAR NAME].[DATE YEAR NAME].ALLMEMBERS ) }  ON COLUMNS FROM [JJFB] ";
            sql += e.filterDataDeptStr;
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "本期数量" } });
            return data;
        }

        private void filterView1_OnRefresh(object sender, RefreshEventArgs e)
        {
            OutoReport report = new OutoReport(ReportType.Horizontal);
            report.txtZBT = @"三级综合医院医疗质量评审指标";
            report.txtFBT = "医院手术麻醉情况";
            report.txtRQ = e.SelectDateStr;
            report.txtZZJJMC = Tools.Help.GetHosName();
            report.txtZZJJDM = Tools.Help.GetHosCode();
            report.BindData(GetData(e));
            printControl1.PrintingSystem = report.PrintingSystem;
        }

    }
}
