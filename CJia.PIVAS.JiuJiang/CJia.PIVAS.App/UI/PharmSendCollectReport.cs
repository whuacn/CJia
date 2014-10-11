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
    public partial class PharmSendCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmSendCollectReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData">数据</param>
        /// <param name="printDate">打印时间</param>
        public void DataBind(DataTable pharmSendData, string printDate)
        {
            this.lblPrintDate.Text = printDate;
            this.DataSource = pharmSendData;
            this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.lblSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "PHARM_TOTAL");
            this.GroupHeader1.GroupFields.Add(new GroupField("PHARM_SEND_NO"));
            this.lblPharmSendNO.DataBindings.Add("Text", this.DataSource, "PHARM_SEND_NO");
            this.CreateDocument();
            this.ShowPreview();
        }

    }
}
