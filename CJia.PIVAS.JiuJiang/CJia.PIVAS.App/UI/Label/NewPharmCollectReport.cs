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
    public partial class NewPharmCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public NewPharmCollectReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品数据绑定
        /// </summary>
        /// <param name="pharmCollect"></param>
        /// <param name="selectDate"></param>
        /// <param name="selectIffleld"></param>
        /// <param name="selectBatch"></param>
        /// <param name="selectList"></param>
        /// <param name="labelCount"></param>
        public void DataBind(DataTable pharmCollect, string selectIffleld, string selectBatch, int pharmCount, int labelCount, string type, string longTemporary,string  drGr,string zrMr)
        {
            this.xrRepertHeader.Text = longTemporary + " " + type + " " + drGr + " 摆药单";
            this.xlZXRQ.Text = zrMr;
            this.xrPrintDate.Text = CJia.PIVAS.Tools.Helper.Sysdate.ToString();
            this.xrPrintBy.Text = CJia.PIVAS.User.UserName;
            this.xrIllfielt.Text = selectIffleld;
            this.xrBatch.Text = selectBatch;
            this.xrAllCount.Text = pharmCount.ToString();
            this.xrLabelCount.Text = labelCount.ToString();
            this.DataSource = pharmCollect;
            this.xrPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.xrSpec.DataBindings.Add("Text", this.DataSource, "PHARM_SPEC");
            this.xrFactory.DataBindings.Add("Text", this.DataSource, "PHARM_FACTION");
            this.xrUnit.DataBindings.Add("Text", this.DataSource, "UNITS");
            this.xrCount.DataBindings.Add("Text", this.DataSource, "AMOUNT");
            this.xrRealCount.DataBindings.Add("Text", this.DataSource, "REALITY_PHARM_AMOUNT");
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }

    }
}
