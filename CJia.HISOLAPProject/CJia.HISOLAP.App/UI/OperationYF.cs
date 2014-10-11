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
    public partial class OperationYF : DevExpress.XtraEditors.XtraUserControl
    {
        public OperationYF()
        {
            InitializeComponent();
            filterView1.BindDefaultDepts();
        }
        public DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"  SELECT  { [SQGLBPFF DIM].[SQGLBPFF ID].[SQGLBPFF ID].ALLMEMBERS } ON COLUMNS, 
  { ([PERIOPERATIVE DIM].[SHOW NAME].[SHOW NAME].ALLMEMBERS ) } 
  ON ROWS
  FROM [JJFB] 
  WHERE ( {[Measures].[术前各类-备皮率%]},";
            string sql2 = @"  SELECT { [SQYJGLBPFF DIM].[SQYJGLBPFF ID].[SQYJGLBPFF ID].ALLMEMBERS } ON COLUMNS, 
    { ([PERIOPERATIVE DIM].[SHOW NAME].[SHOW NAME].ALLMEMBERS ) }
   ON ROWS 
   FROM [JJFB] 
   where({[Measures].[术前Ⅰ/甲-备皮率%]},";
            string sql3 = @" SELECT NON EMPTY { [Measures].[Ⅰ/甲愈合率%] } ON COLUMNS,
   { ([PERIOPERATIVE DIM].[SHOW NAME].[SHOW NAME].ALLMEMBERS ) }  ON ROWS
   FROM [JJFB] ";
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            dict1.Add(0, "手术名称");
            dict1.Add(1, "术前各类备皮方法情况_一类备皮率%");
            dict1.Add(2, "术前各类备皮方法情况_二类备皮率%");
            dict1.Add(3, "术前各类备皮方法情况_三类备皮率%");
            dict1.Add(4, "术前各类备皮方法情况_四类备皮率%");
            dict1.Add(5, "术前各类备皮方法情况_五类备皮率%");
            dict1.Add(6, "术前各类备皮方法情况_六类备皮率%");
            dict1.Add(7, "术前各类备皮方法情况_七类备皮率%");
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
            dict2.Add(0, "手术名称");
            dict2.Add(1, "术前Ⅰ/甲各类备皮方法情况_一类备皮率%");
            dict2.Add(2, "术前Ⅰ/甲各类备皮方法情况_二类备皮率%");
            dict2.Add(3, "术前Ⅰ/甲各类备皮方法情况_三类备皮率%");
            dict2.Add(4, "术前Ⅰ/甲各类备皮方法情况_四类备皮率%");
            dict2.Add(5, "术前Ⅰ/甲各类备皮方法情况_五类备皮率%");
            dict2.Add(6, "术前Ⅰ/甲各类备皮方法情况_六类备皮率%");
            dict2.Add(7, "术前Ⅰ/甲各类备皮方法情况_七类备皮率%");
            sql += CJia.HISOLAP.App.Tools.Help.DateFilter(e.SelectStartDateTime, e.SelectStartDateTime);
            string strDept = CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            if (strDept != "")
            {
                sql += ",";
                sql += CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            }
            else
            {

            }
            sql += ")";
            sql2 += CJia.HISOLAP.App.Tools.Help.DateFilter(e.SelectStartDateTime, e.SelectStartDateTime);
            string strDept1 = CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            if (strDept1 != "")
            {
                sql2 += ",";
                sql2 += CJia.HISOLAP.App.Tools.Help.DeptFilter(e.IsUseDept, e.IsSelectAllDept, e.SelectDepts);
            }
            else
            {

            }
            sql2 += ")";
            sql3 += e.filterDataDeptStr;
            DataTable data = CJia.DefaultOleDb.Query(sql);
            DataTable data2 = CJia.DefaultOleDb.Query(sql2);
            DataTable data3 = CJia.DefaultOleDb.Query(sql3);
            data = DataTableHelper.GetRealColName(data);
            data2 = DataTableHelper.GetRealColName(data2);
            data3 = DataTableHelper.GetRealColName(data3);
            data = DataTableHelper.UpdateColName(data, dict1);
            data2 = DataTableHelper.UpdateColName(data2, dict2);
            data3 = DataTableHelper.UpdateColName(data3, new Dictionary<int, string>() { { 0, "手术名称" } });
            
            data = DataTableHelper.MergeDataTable(data, "手术名称", data3, "手术名称");
            data = DataTableHelper.MergeDataTable(data, "手术名称", data2, "手术名称");
            if (data != null && data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
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
                    data.Rows[i][11] = data.Rows[i][11].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][11].ToString()), 4) * 100 : data.Rows[i][11];
                    data.Rows[i][12] = data.Rows[i][12].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][12].ToString()), 4) * 100 : data.Rows[i][12];
                    data.Rows[i][13] = data.Rows[i][13].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][13].ToString()), 4) * 100 : data.Rows[i][13];
                    data.Rows[i][14] = data.Rows[i][14].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][14].ToString()), 4) * 100 : data.Rows[i][14];
                    data.Rows[i][15] = data.Rows[i][15].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][15].ToString()), 4) * 100 : data.Rows[i][15];
                }
            }
            return data;
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

        private void filterView1_OnRefresh(object sender, RefreshEventArgs e)
        {
            OutoReport report = new OutoReport(ReportType.Vertical);
            report.FirstBT = 27;
            report.txtZBT = @"三级综合医院医疗质量评审指标";
            report.txtFBT = "围手术期备皮情况";
            report.txtRQ = e.SelectDateStr;
            report.txtZZJJMC = Tools.Help.GetHosName();
            report.txtZZJJDM = Tools.Help.GetHosCode();
            report.BindData(GetData(e));
            printControl1.PrintingSystem = report.PrintingSystem;
        }
    }
}
