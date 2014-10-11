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
    /// 发药明细报表
    /// </summary>
    public partial class PharmSendDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmSendDetailReport()
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
            throw new Exception("此报表已经作废！");
            //this.lblPrintDate.Text = printDate;
            //this.DataSource = pharmSendData;
            //this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            //this.lblSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            //this.lblAmount.DataBindings.Add("Text", this.DataSource, "NEWAMOUNT");
            //this.lblCheckName.DataBindings.Add("Text", this.DataSource, "USER_NAME");
            //this.lblCheckDate.DataBindings.Add("Text", this.DataSource, "CHECK_DATE");
            //this.GroupHeader1.GroupFields.Add(new GroupField("PHARM_SEND_NO"));
            //this.lblPharmSendNO.DataBindings.Add("Text", this.DataSource, "PHARM_SEND_NO");
            //this.GroupHeader1.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            //this.lblIllFieldName.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            //this.GroupHeader2.GroupFields.Add(new GroupField("PATIENT_NAME"));
            //this.lblPatientName.DataBindings.Add("Text", this.DataSource, "PATIENT_NAME");
            //this.GroupHeader2.GroupFields.Add(new GroupField("LABEL_NO"));
            //this.lblLabelNO.DataBindings.Add("Text", this.DataSource, "LABEL_NO");
            //this.CreateDocument();
            //this.ShowPreview();
        }

    }
}
