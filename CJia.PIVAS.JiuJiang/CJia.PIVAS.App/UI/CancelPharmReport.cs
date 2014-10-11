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
    public partial class CancelPharmReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CancelPharmReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData"></param>
        /// <param name="illfieldName"></param>
        /// <param name="printDate"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="i">1为已退，2为拒绝</param>
        public void DataBind(string dateStyle, DataTable pharmSendData, string illfieldName, string printDate, string startDate, string endDate, string retreatStatus)
        {
            if(retreatStatus == "Succeed")
            {
                this.lblTitle.Text = "静脉药物配置中心成功退药汇总";
            }
            else if(retreatStatus == "TumDown")
            {
                this.lblTitle.Text = "静脉药物配置中心拒绝退药汇总";
            }
            else
            {
                this.lblTitle.Text = "静脉药物配置中心未退药汇总";
            }

            if(dateStyle == "Print")
            {
                this.txtDateStyle.Text = "打印时间";
            }
            else
            {
                this.txtDateStyle.Text = "操作时间";
            }
            this.lblPrintDate.Text = printDate;
            this.lblStartDate.Text = startDate;
            this.lblEndDate.Text = endDate;
            this.DataSource = pharmSendData;
            this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.lblSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.lblFacName.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "TOTAL");
            this.lblUnit.DataBindings.Add("Text", this.DataSource, "AMOUNT_UNIT");
            this.lblIllName.Text = illfieldName;
            this.CreateDocument();
            this.ShowPreview();
        }

    }
}
