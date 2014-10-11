using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 发药明细报表
    /// </summary>
    public partial class LabelDetailReport : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelDetailReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData">数据</param>
        /// <param name="printDate">打印时间</param>
        public void DataBind(string title,DataTable PharmDetialData,  string startDate, string printDate,int labelCount)
        {
            this.xrLabel1.Text = title + "瓶贴明细";
            this.DataSource = PharmDetialData;
            this.GroupHeader1.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            this.GroupHeader2.GroupFields.Add(new GroupField("BATCH_ID"));
            this.GroupHeader3.GroupFields.Add(new GroupField("BED_ID"));
            this.GroupHeader4.GroupFields.Add(new GroupField("LABEL_ID"));
            this.txtIllfield.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.txtBatch.DataBindings.Add("Text", this.DataSource, "BATCH_NAME");
            this.xrBatchLabelCount.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT");
            //this.txtPatient.DataBindings.Add("Text", this.DataSource, "NAME");
            //this.xrPatientLabelCount.DataBindings.Add("Text", this.DataSource, "PATIENT_LABEL_COUNT");
            //this.txtLabel.DataBindings.Add("Text", this.DataSource, "LABEL_BAR_ID");
            this.xrLabelCount.Text = labelCount.ToString();
            this.lblPrintDate.Text = printDate;
            this.txtPrintName.Text = CJia.PIVAS.User.UserName;
            this.lblStartDate.Text = startDate;
            //this.lblEndDate.Text = endDate;
            this.txtName.DataBindings.Add("Text", this.DataSource, "NAME");
            this.txtLabelCode.DataBindings.Add("Text", this.DataSource, "LABEL_BAR_ID");
            this.txtPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.txtPharmSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.txtPharmFaction.DataBindings.Add("Text", this.DataSource, "PHARM_FACTION");
            this.txtCount.DataBindings.Add("Text", this.DataSource, "PHARM_AMOUNT");
            this.txtUnit.DataBindings.Add("Text", this.DataSource, "AMOUNT_UNIT");
            this.txtSendBy.DataBindings.Add("Text", this.DataSource, "PHARM_DOSAGE");
            this.txtSendDate.DataBindings.Add("Text", this.DataSource, "DOSAGE_UNIT");
            this.CreateDocument();
            this.ShowPreview();
        }
    }
}
