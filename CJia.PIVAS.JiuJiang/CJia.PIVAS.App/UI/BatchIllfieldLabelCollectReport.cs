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
    public partial class BatchIllfieldLabelCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BatchIllfieldLabelCollectReport()
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
        public void DataBindDataTable(DataTable SendpharmData,bool isDY, string startDate, string endDate,bool isZX, string zxDate,bool isKD,string kdDate, string printDate, string isGroup, string longTemporary, string allDrGr)
        {
            this.xrRepertHeader.Text = longTemporary + isGroup + allDrGr + "瓶贴汇总";

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
            
            this.xrPrintBy.Text = CJia.PIVAS.User.UserName;
            this.lblPrintDate.Text = CJia.PIVAS.Tools.Helper.Sysdate.ToString();
            this.DataSource = SendpharmData;
            this.xrIllfield.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.xrBatch1.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT1");
            this.xrBatch2.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT2");
            this.xrBatch3.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT3");
            this.xrBatch4.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT4");
            this.xrBatch5.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT5");
            this.xrBatch6.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNT6");
            this.xrBatchZ.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNTZ");
            this.xrBatchW.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNTW");
            this.xrBatchB.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNTB");
            this.xrBatchL.DataBindings.Add("Text", this.DataSource, "BATCH_LABEL_COUNTL");
            this.xrAllBatch.DataBindings.Add("Text", this.DataSource, "ALL_BATCH_LABEL_COUNT");
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }
    }
}
