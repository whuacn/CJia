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
    public partial class SendPharmCollectReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SendPharmCollectReport()
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
        public void DataBindDataTable(DataTable SendpharmData, string officeName, string cbBatch,bool isDY, string startDate, string endDate,bool isZX, string zxDate,bool isKD,string kdDate,  string pharmCount, string labelCount, string printDate, string isGroup, bool IsAll, string longTemporary,string allDrGr)
        {
            this.xrRepertHeader.Text = longTemporary + isGroup + allDrGr + "药品汇总";
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

            this.xlZXDate.Text = zxDate;
            this.xrPrintBy.Text = CJia.PIVAS.User.UserName;
            this.lblPrintDate.Text = CJia.PIVAS.Tools.Helper.Sysdate.ToString();
            this.xrIllfielt.Text = officeName;
            this.xrBatch.Text = cbBatch;
            this.xrAllCount.Text = pharmCount.ToString();
            this.xrLabelCount.Text = labelCount.ToString();
            this.DataSource = SendpharmData;
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
