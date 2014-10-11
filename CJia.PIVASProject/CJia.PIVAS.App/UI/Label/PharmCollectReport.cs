using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 药品汇总报表
    /// </summary>
    public partial class PharmCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmCollectReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品数据绑定
        /// </summary>
        /// <param name="pharmCollect">药品类数据集</param>
        /// <returns></returns>
        public void DataBind(DataTable pharmCollect,DateTime selectDate,string selectIffleld,string selectList)
        {
            this.xrRepertHeader.Text = "静脉配置中心" + selectDate.Year + "年" + selectDate.Month + "月" + selectDate.Day + @"日
" + "拼贴药品汇总报表";
            this.xrLesionv.Text = selectIffleld;
            this.xrArrange.Text = selectList;
            this.DataSource = pharmCollect;
            this.xrGoodsName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.xrCurrentName.DataBindings.Add("Text", this.DataSource, "PHARM_COMMON_NAME");
            this.xrCount.DataBindings.Add("Text", this.DataSource, "ALL_PHARM_AMOUNT");
            this.xrUnit.DataBindings.Add("Text", this.DataSource, "AMOUNT_UNIT");
            this.xrSpecification.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.labPrintDate.Text = selectDate.ToString();
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }

    }
}
