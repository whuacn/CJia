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
    /// 发药统计报表
    /// </summary>
    public partial class BatchSendPharmCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BatchSendPharmCollectReport()
        {
            InitializeComponent(); 
        }
        ///// <summary>
        ///// 数据绑定
        ///// </summary>
        ///// <param name="pharmSendData">数据</param>
        ///// <param name="printDate">打印时间</param>
        //public void DataBind(DataTable SendpharmData, string officeName,string cbBatch,string startDate, string endDate, string printDate, string isGroup)
        //{
        //    this.lblIllfielt.Text = officeName;
        //    this.lblPrintDate.Text = printDate;
        //    this.lblStartDate.Text = startDate;
        //    this.lblIsGroup.Text = isGroup;
        //    this.lblEndDate.Text = endDate;
        //    this.DataSource = SendpharmData;
        //    this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
        //    this.lblSpec.DataBindings.Add("Text", this.DataSource, "PHARM_SPEC");
        //    this.lblFactory.DataBindings.Add("Text", this.DataSource, "PHARM_FACTION");
        //    this.lblAmount.DataBindings.Add("Text", this.DataSource, "AMOUNT");
        //    this.lblunit.DataBindings.Add("Text", this.DataSource, "UNITS");
        //    this.CreateDocument();
        //    this.ShowPreview();
        //}


        /// <summary>
        /// 药品数据绑定
        /// </summary>
        /// <param name="pharmCollect"></param>
        /// <param name="selectDate"></param>
        /// <param name="selectIffleld"></param>
        /// <param name="selectBatch"></param>
        /// <param name="selectList"></param>
        /// <param name="labelCount"></param>
        public void DataBindDataTable(DataTable SendpharmData, string officeName, string startDate, string endDate, string printDate,string allLabelCount,string allPharmCount, string isGroup, string longTemporary)
        {
            this.xrRepertHeader.Text = longTemporary +   isGroup + "药品明细";
            //this.xrLabel1.Visible = !IsAll;
            this.lblStartDate.Text = startDate;
            this.lblEndDate.Text = endDate;
            this.xrPrintBy.Text = CJia.PIVAS.User.UserName;
            this.lblPrintDate.Text = CJia.PIVAS.Tools.Helper.Sysdate.ToString();
            this.txtPharmCount.Text = allPharmCount;
            this.txtLabelCount.Text = allLabelCount;
            this.GroupHeader2.GroupFields.Add(new GroupField("BATCH_NAME"));
            this.GroupHeader1.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            this.DataSource = SendpharmData;
            this.xrAllCount.DataBindings.Add("Text", this.DataSource, "BATCH_PHARM_COUNT");
            this.xrLabelCount.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT");
            this.txtLabelCount.DataBindings.Add("Text", this.DataSource, "ILLFIELD_LABEL_COUNT");
            this.txtPharmCount.DataBindings.Add("Text", this.DataSource, "ILLFIELD_PHARM_COUNT");
            this.xrBatch.DataBindings.Add("Text", this.DataSource, "BATCH_NAME");
            this.xrIllfielt.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.xrPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.xrSpec.DataBindings.Add("Text", this.DataSource, "PHARM_SPEC");
            this.xrFactory.DataBindings.Add("Text", this.DataSource, "PHARM_FACTION");
            this.xrUnit.DataBindings.Add("Text", this.DataSource, "UNITS");
            this.xrCount.DataBindings.Add("Text", this.DataSource, "AMOUNT");
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }
    }
}
