using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class CompleteQuery : CJia.Health.Tools.View, CJia.Health.Views.ICompleteQuery
    {
        public CompleteQuery()
        {
            InitializeComponent();
            InitPage();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.CompleteQueryPresenter(this);
        }

        public void InitPage()
        {
            //dtStart.DateTime = DateTime.Parse(Sysdate.ToShortDateString()).AddMonths(-1);
            //dtEnd.DateTime = DateTime.Parse(Sysdate.ToShortDateString()).AddDays(1).AddSeconds(-1);
            //cboFileDate.SelectedText = 
        }
        public event EventHandler<CompleteQueryArgs> OnCompleteQuery;
        public void ExeBindTatalData(DataTable data)
        {
            //DataColumn col = new DataColumn("PRICE", typeof(float));
            //data.Columns.Add(col);
            //DataColumn col2 = new DataColumn("TOTALPRICE", typeof(float));
            //data.Columns.Add(col2);
            //float price;
            //try
            //{
            //    price = float.Parse(txtPrice.Text);
            //}
            //catch
            //{
            //    price = 0;
            //}
            //if (data != null && data.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in data.Rows)
            //    {
            //        dr["PRICE"] = price;
            //        dr["TOTALPRICE"] = price * int.Parse(dr["TOTAL"].ToString());
            //    }
            //}
            //gcTatal.Visible = true;
            //gcAll.Visible = false;
            //gcTatal.DataSource = data;
            gcTatal.Visible = false;
            gcAll.Visible = true;
            gcAll.DataSource = data;
        }
        public void ExeBindAllData(DataTable data)
        {
            gcTatal.Visible = false;
            gcAll.Visible = true;
            gcAll.DataSource = data;

        }
        Views.CompleteQueryArgs comQueryArgs = new Views.CompleteQueryArgs();

        private void btnSearch1_Click_1(object sender, EventArgs e)
        {
            if (OnCompleteQuery != null)
            {
                comQueryArgs.CompleteDate = cboFileDate.Text;
                comQueryArgs.RecordBegin = txtSNO.Text.Trim();
                comQueryArgs.RecordEnd = txtBNO.Text.Trim();
                OnCompleteQuery(null, comQueryArgs);
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnSearch1.Focus();
                    btnSearch1_Click_1(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnExpXLS_Click(object sender, EventArgs e)
        {
            sfExcel.Filter = "(Excel2007).xlsx|*.xlsx";
            sfExcel.ShowDialog();
            
            string strfilePath = sfExcel.FileName.ToString();
            DataTable dt = (gcAll.DataSource) as DataTable;
            ExportToExcel(dt, strfilePath);
        }

        public void ExportToExcel(DataTable dt, string filePath)
        {
            if (dt == null)//检查数据表是否为空，如果为空，则退出
                return;
            //创建Excel应用程序对象，如果未创建成功则退出
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能你的电脑未装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1]; //取得sheet1
            Microsoft.Office.Interop.Excel.Range range = null;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            for (int i = 0; i < dt.Columns.Count; i++)//写入标题
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;//写入标题名称
                //设置标题的样式
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                range.Font.Bold = true; //粗体
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //居中
                range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null); //背景色
                range.EntireColumn.AutoFit(); //自动设置列宽
                range.EntireRow.AutoFit(); //自动设置行高
            }
            //写入DataTable中数据的内容
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    //写入内容
                    worksheet.Cells[r + 2, c + 1] = "'" + dt.Rows[r][c].ToString();
                    //设置样式
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[r + 2, c + 1];
                    range.Font.Size = 9; //字体大小
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null); //加边框
                    range.EntireColumn.AutoFit(); //自动调整列宽
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
                System.Windows.Forms.Application.DoEvents();
            }
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            if (dt.Columns.Count > 1)
            {
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            }
            try
            {
                workbook.Saved = true;
                workbook.SaveCopyAs(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出文件时出错，文件可能正被打开!\n" + ex.ToString());
                return;
            }
            workbooks.Close();
            if (xlApp != null)
            {
                xlApp.Workbooks.Close();
                xlApp.Quit();
                int generation = System.GC.GetGeneration(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;
                System.GC.Collect(generation);
            }
            GC.Collect(); //强行销毁
            #region 强行杀死最近打开的Excel进程
            System.Diagnostics.Process[] excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            System.DateTime startTime = new DateTime();
            int m, killID = 0;
            for (m = 0; m < excelProc.Length; m++)
            {
                if (startTime < excelProc[m].StartTime)
                {
                    startTime = excelProc[m].StartTime;
                    killID = m;
                }
            }
            if (excelProc[killID].HasExited == false)
            {
                excelProc[killID].Kill();
            }
            #endregion
        }
    }
}
