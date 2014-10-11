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
    public partial class SendPharmDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SendPharmDetailReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData">数据</param>
        /// <param name="printDate">打印时间</param>
        public void DataBind(DataTable PharmDetialData, bool isDY, string startDate, string endDate, bool isZX, string zxDate, bool isKD, string kdDate,string printDate, string isGroup, string longTemporary, string allDrGr)
        {
            this.xrRepertHeader.Text = longTemporary + isGroup + allDrGr + "瓶贴明细";
            //this.xrLabel1.Visible = !IsAll;

            if(isDY)
            {
                this.xrDY1.Visible = true;
                this.xrDY2.Visible = true;
                this.xlDYstart.Visible = true;
                this.xlDYEnd.Visible = true;
                this.xlDYstart.Text = startDate;
                this.xlDYEnd.Text = endDate;
            }
            if(isZX)
            {
                this.xlZX.Visible = true;
                this.xlZXDate.Visible = true;
                this.xlZXDate.Text = zxDate;
            }
            if(isKD)
            {
                this.xlKD1.Visible = true;
                this.xlKDDate.Visible = true;
                this.xlKDDate.Text = kdDate;
            }


            this.DataSource = PharmDetialData;
            this.GroupHeader1.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            this.GroupHeader2.GroupFields.Add(new GroupField("BATCH_ID"));
            this.GroupHeader3.GroupFields.Add(new GroupField("BED_ID"));
            this.GroupHeader4.GroupFields.Add(new GroupField("LABEL_ID"));
            this.txtIllfield.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.xrIllfieldLabelCount.DataBindings.Add("Text", this.DataSource, "ILLFIELD_LABEL_COUNT");
            this.txtBatch.DataBindings.Add("Text", this.DataSource, "BATCH_NAME");
            this.xrBatchLabelCount.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT");
            this.txtPatient.DataBindings.Add("Text", this.DataSource, "NAME");
            this.xrPatientLabelCount.DataBindings.Add("Text", this.DataSource, "PATIENT_LABEL_COUNT");
            this.txtLabel.DataBindings.Add("Text", this.DataSource, "LABEL_BAR_ID");
            this.lblPrintDate.Text = printDate;
            this.txtPrintName.Text = CJia.PIVAS.User.UserName;
            //this.lblStartDate.Text = startDate;
            //this.lblEndDate.Text = endDate;
            //this.xlZXDate.Text = zxDate;
            this.txtPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.txtPharmSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.txtPharmFaction.DataBindings.Add("Text", this.DataSource, "PHARM_FACTION");
            this.txtCount.DataBindings.Add("Text", this.DataSource, "PHARM_DOSAGE");
            this.txtUnit.DataBindings.Add("Text", this.DataSource, "DOSAGE_UNIT");
            this.txtSendBy.DataBindings.Add("Text", this.DataSource, "PHARM_SEND_USER_NAME");
            this.txtSendDate.DataBindings.Add("Text", this.DataSource, "PHARM_SEND_DATE");
            this.CreateDocument();
            this.ShowPreview();
        }
    }
}
