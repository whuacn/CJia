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
    public partial class HLYYQK : DevExpress.XtraEditors.XtraUserControl
    {
        public HLYYQK()
        {
            InitializeComponent();
            this.filterView1.BindDefaultDepts();
        }
        public DataTable GetData(RefreshEventArgs e)
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
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称"}, {1, "本期数量"}});
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    oldToNew.Add(data.Rows[i][0].ToString(), "（一）合理用药_       " + (i + 1).ToString() + "、" + data.Rows[i][0].ToString());
                    data.Rows[i][1] = data.Rows[i][1] != null && data.Rows[i][1].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][1].ToString()), 4) * 100 + "%" : data.Rows[i][1];
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

        private void dockPanel1_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if(e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
            if(e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
            {
                Control control = this.printControl1;
                control.Location = new Point(this.dockPanel1.Width + 2, control.Location.Y);
                control.Width = this.Width - this.dockPanel1.Width;
            }
            if(e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
            {
                Control control = this.printControl1;
                control.Location = new Point(25, control.Location.Y);
                control.Width = this.Width - 25;
            }
        }



    }
}
