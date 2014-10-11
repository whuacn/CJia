using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace CJia.PEIS.App.UI
{
    /// <summary>
    /// 根据发药单号药品统计报表
    /// </summary>
    public partial class CheckListReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CheckListReport()
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
            this.DataSource = pharmSendData;
            //this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.CreateDocument();
            this.ShowPreview();
        }

    }
}
