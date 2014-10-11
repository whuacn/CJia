using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 根据发药单号药品统计报表
    /// </summary>
    public partial class PharmSendReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmSendReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData">数据</param>
        /// <param name="printDate">打印时间</param>
        public void DataBind(DataTable pharmSendData,string illfieldName, string printDate,string selectDate)
        {
            this.lblPrintDate.Text = printDate;
            this.lblSelectDate.Text = selectDate;
            this.DataSource = pharmSendData;
            this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.lblSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.lblFacName.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "TOTAL");
            this.lblUnit.DataBindings.Add("Text", this.DataSource, "ACCOUNT_UNIT");
            this.lblIllName.Text = illfieldName;
            this.CreateDocument();
            this.ShowPreview();
        }

    }
}
