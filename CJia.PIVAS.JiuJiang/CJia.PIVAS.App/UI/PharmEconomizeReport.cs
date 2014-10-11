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
    public partial class PharmEconomizeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmEconomizeReport()
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
        public void DataBindDataTable(DataTable pharmEconomizeData, string illfieldName, string startDate, string endDate, string RKZL, string RKZJ)
        {
            DataTable result = null;
            if(pharmEconomizeData != null && pharmEconomizeData.Rows != null && pharmEconomizeData.Rows.Count > 0)
            {
                result = pharmEconomizeData.Copy();
                result.DefaultView.Sort = " PHATM_NAME,SPEC,FACTORY_NAME,UNITS ";
                result = result.DefaultView.ToTable();
            }
            this.xlIllfield.Text = illfieldName;
            this.lblStartDate.Text = startDate;
            this.lblEndDate.Text = endDate;
            this.xrPrintBy.Text = CJia.PIVAS.User.UserName;
            this.lblPrintDate.Text = CJia.PIVAS.Tools.Helper.Sysdate.ToString();
            this.xrRKZL.Text = RKZL;
            this.xrRKZJ.Text = RKZJ;
            this.DataSource = pharmEconomizeData;
            this.xrPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.xrSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.xrFactory.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
            this.xrEcon.DataBindings.Add("Text", this.DataSource, "ECONOMIZE_COUNT");
            this.xrUnit.DataBindings.Add("Text", this.DataSource, "UNITS");
            this.xrPrice.DataBindings.Add("Text", this.DataSource, "INHOS_PRICE");
            this.xrMoney.DataBindings.Add("Text", this.DataSource, "ALL_MONEY");
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }
    }
}
