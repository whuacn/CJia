using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class ReportView : CJia.Editors.View, Views.IReportView
    {//  CJia.Editors.View
        public ReportView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.ReportPresenter(this);
        }
        /// <summary>
        /// 参数设置
        /// </summary>
        Views.ReportArgs reportArgs = new Views.ReportArgs();

        #region IReportView成员
        public string PatientName
        {
            get { return txtPatientName.Text.Trim(); }
            set { txtPatientName.Text = value; }
        }
        public string SavePath
        {
            get
            {
                if (gvReport.GetFocusedDataRow() != null)
                {
                    return gvReport.GetFocusedDataRow()["save_path"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        public int ReportID
        {
            get { return int.Parse(gvReport.GetFocusedDataRow()["report_id"].ToString()); }
        }
        public event EventHandler<Views.ReportArgs> OnSelect;
        public event EventHandler<Views.ReportArgs> OnPrint;
        public event EventHandler Load;
        public void BindReport(DataTable data)
        {
            gcReport.DataSource = data;
            TxtPatientNameFocus();
        }
        public void TxtPatientNameFocus()
        {
            PatientName = PatientName;
            txtPatientName.Focus();
            txtPatientName.SelectAll();
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (OnSelect != null)
            {
                reportArgs.PatientName = PatientName;
                OnSelect(sender, reportArgs);
            }
        }
        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (OnSelect != null)
                {
                    reportArgs.PatientName = PatientName;
                    OnSelect(sender, reportArgs);
                }
            }
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            if (SavePath != null)
            {
                System.Diagnostics.Process.Start(SavePath); //用本地默认程序打开PDF
            }
            else
            {
                MessageBox.Show("不存在检查报告");
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!isPrint()) return;
            if(OnPrint!=null)
            {
                PrintPDF(SavePath);
                reportArgs.ReportID = ReportID;
                OnPrint(sender, reportArgs);
                Load(null, null);
            }
        }
        /// <summary>
        /// 判断能否打印
        /// </summary>
        /// <returns></returns>
        bool isPrint()
        {
            if (SavePath == null)
            {
                MessageBox.Show("不存在检查报告");
                return false;
            }
            if (PrinterSettings.InstalledPrinters.Count <= 0)//判断是否安装打印机
            {
                MessageBox.Show("没有可用打印机");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打印pdf文件方法 
        /// </summary>
        /// <param name="fileMath">打印的pdf的文件路径</param>
        private void PrintPDF(string fileMath)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //不现实调用程序窗口,但是对于某些应用无效
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //采用操作系统自动识别的模式
            p.StartInfo.UseShellExecute = true;
            //要打印的文件路径，可以是WORD,EXCEL,PDF,TXT等等
            p.StartInfo.FileName = fileMath;
            //指定执行的动作，是打印，即print，打开是 open
            p.StartInfo.Verb = "print";
            //开始
            p.Start();
        }
    }
}
