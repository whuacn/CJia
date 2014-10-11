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
    public partial class CancelPharmDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CancelPharmDetailReport()
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
                this.lblTitle.Text = "静脉药物配置中心成功退药明细单";
                this.lblCancelName.Text = "退药人";
                this.lblCancelDate.Text = "退药时间";
            }
            else if(retreatStatus == "TumDown")
            {
                this.lblTitle.Text = "静脉药物配置中心拒绝退药明细单";
                this.lblCancelName.Text = "拒绝人";
                this.lblCancelDate.Text = "拒绝时间";
            }
            else
            {
                this.lblTitle.Text = "静脉药物配置中心未退药明细单";
                this.lblCancelName.Text = "操作人";
                this.lblCancelDate.Text = "操作时间";
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
            this.GroupHeader3.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            this.lblIllName.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.GroupHeader1.GroupFields.Add(new GroupField("BED_ID"));
            this.txtPatientInfo.DataBindings.Add("Text", this.DataSource, "PATIENT_INFO");
            this.GroupHeader2.GroupFields.Add(new GroupField("LABEL_ID"));
            this.txtLabelID.DataBindings.Add("Text", this.DataSource, "GROUP_INDEX");
            this.txtPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.txtSQR.DataBindings.Add("Text", this.DataSource, "CANCEL_USER_NAME");
            this.txtDoctorName.DataBindings.Add("Text", this.DataSource, "LIST_DOCTOR_NAME");
            this.txtSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.txtAmount.DataBindings.Add("Text", this.DataSource, "PHARM_AMOUNT");
            this.txtUnit.DataBindings.Add("Text", this.DataSource, "AMOUNT_UNIT");
            this.txtReson.DataBindings.Add("Text", this.DataSource, "CANCEL_REASON");
            this.txtBatchName.DataBindings.Add("Text", this.DataSource, "BATCH_NAME");
            this.txtCancelName.DataBindings.Add("Text", this.DataSource, "CHECK_USER_NAME");
            this.txtCancelDate.DataBindings.Add("Text", this.DataSource, "CHECK_TIME");
            this.lblIllName.Text = illfieldName;
            this.CreateDocument();
            this.ShowPreview();
        }

    }
}
