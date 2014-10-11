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
    public abstract partial class BZUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public BZUserControl()
        {
            InitializeComponent();
            if (data != null)
            {
                filterView1.Data = data;
                filterView1.BindDefaultDepts();
            }
        }

        /// <summary>
        /// 下拉框数据源
        /// </summary>
        public static DataTable data;

        //public DataTable Data
        //{
        //    set
        //    {
        //        this.data = value;
        //    }
        //    get
        //    {
        //        return this.data;
        //    }
        //}
        
        private bool isSetZBT = false;
        private string zbt;
        /// <summary>
        /// 主标题
        /// </summary>
        public string ZBT
        {
            get
            {
                return this.zbt;
            }
            set
            {
                this.isSetZBT = true;
                this.zbt = value;
            }
        }

        private bool isSetFBT = false;
        private string fbt;
        /// <summary>
        /// 副标题
        /// </summary>
        public string FBT
        {
            get
            {
                return this.fbt;
            }
            set
            {
                this.isSetFBT = true;
                this.fbt = value;
            }
        }

        private bool isDeptName = false;

        public bool IsDeptName
        {
            set
            {
                isDeptName = value;
            }
            get
            {
                return isDeptName;
            }
        }

        private bool isSetReportType = false;
        private ReportType reportType;
        /// <summary>
        /// 报表类型
        /// </summary>
        public ReportType ReportType
        {
            get
            {
                return this.reportType;
            }
            set
            {
                isSetReportType = true;
                this.reportType = value;
            }
        }

        /// <summary>
        /// 不许实现的虚方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public abstract DataTable GetData(RefreshEventArgs e);

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
            if (!isSetZBT)
            {
                throw new Exception("没用设置主标题");
            }
            if (!isSetFBT)
            {
                throw new Exception("没用设置副标题");
            }
            if (!isSetReportType)
            {
                throw new Exception("没用设置报表类型");
            }

            OutoReport report = new OutoReport(this.ReportType);
            report.FirstBT = 27;
            if (this.isDeptName)
            {
                if (e.SelectDepts.Count > 0)
                {
                    string deptName = "<";
                    foreach (string a in e.SelectDepts.Keys)
                    {
                        deptName += a + ", ";
                    }
                    string b = deptName.Substring(0, deptName.Length - 2) + "> ";
                    if (b.Length > 26)
                    {
                        report.txtDeptName = b.Substring(0, 26) + "...>";
                    }
                    else
                    {
                        report.txtDeptName = b;
                    }
                    
                }
            }
            else
            {
                report.txtFBT = this.FBT;
            }
            report.txtZBT = this.ZBT;
            report.txtFBT = this.FBT;
            report.txtRQ = e.SelectDateStr;
            report.txtZZJJMC = Tools.Help.GetHosName();
            report.txtZZJJDM = Tools.Help.GetHosCode();
            report.BindData(GetData(e));
            printControl1.PrintingSystem = report.PrintingSystem;
        }
    }
}
