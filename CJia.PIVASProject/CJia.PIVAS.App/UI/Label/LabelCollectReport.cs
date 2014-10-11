using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 瓶贴汇总报表
    /// </summary>
    public partial class LabelCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelCollectReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品数据绑定
        /// </summary>
        /// <param name="LabelCollect">药品类数据集</param>
        /// <returns></returns>
        public void DataBind( DataTable LabelCollect,DateTime selectDate)
        {
            this.xrReportHeader.Text = "静脉配置中心" + selectDate.Year + "年" + selectDate.Month + "月" + selectDate.Day + @"日
" + "生成瓶贴汇总报表";
            this.DataSource = LabelCollect;
            this.GroupHeader1.GroupFields.Add(new GroupField("BATCH_ID"));
            this.xrBacth.DataBindings.Add("Text", this.DataSource, "BATCH_NAME", "静脉配置中心" + selectDate.Year + "年" + selectDate.Month + "月" + selectDate.Day + @"日 {0} 生成瓶贴汇总");
            this.xrIffield.DataBindings.Add("Text", this.DataSource, "OFFICE_NAME" );
            this.xrPTY.DataBindings.Add("Text", this.DataSource, "PTY");
            this.xrJSY.DataBindings.Add("Text", this.DataSource, "JSY");
            this.xrDMY.DataBindings.Add("Text", this.DataSource, "DMY");
            this.xrGCY.DataBindings.Add("Text", this.DataSource, "GCY");
            this.xrKSS.DataBindings.Add("Text", this.DataSource, "KSS");
            this.xrAllCount.DataBindings.Add("Text", this.DataSource, "SUBTOTAL");
            this.labPrintDate.Text = selectDate.ToString();
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }

    }
}
