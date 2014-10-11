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
    public partial class PharmSendStatReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PharmSendStatReport()
        {
            InitializeComponent(); 
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="pharmSendData">数据</param>
        /// <param name="printDate">打印时间</param>
        public void DataBind(DataTable pharmSendData, string officeName, string batchName, string start, string end, string printDate)
        {
            this.lblPrintDate.Text = printDate;
            this.lblStartDate.Text = start;
            this.lblEndDate.Text = end;
            this.DataSource = pharmSendData;
            this.lblPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.lblSpec.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.lblFactoryName.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
            this.lblAmountUnit.DataBindings.Add("Text", this.DataSource, "AMOUNT_UNIT");
            this.lblFormName.DataBindings.Add("Text", this.DataSource, "FORM_NAME");
            this.lblPharmAmount.DataBindings.Add("Text", this.DataSource, "TOTAL");
            this.lblPrice.DataBindings.Add("Text", this.DataSource, "INHOS_PRICE");
            if (officeName.Length != 0) this.lblIllFieldName.Text = officeName;
            else RemoveOfficeNameLable();
            if (batchName.Length != 0) this.lblBacthName.Text = batchName;
            else RemoveBatchNameLable();
            if (officeName.Length == 0 && batchName.Length == 0) RemoveAllLabel();
            this.GetTotalMoney(pharmSendData);
            this.CreateDocument();
            this.ShowPreview();
        }

        #region 内部调用函数
        /// <summary>
        /// 统计总金额
        /// </summary>
        /// <param name="data"></param>
        public void GetTotalMoney(DataTable data)
        {
            if (data == null) return;
            double f = 0.00;
            foreach(DataRow dr in data.Rows)
            {
                f = f + double.Parse(dr["TOTAL"].ToString()) * double.Parse(dr["INHOS_PRICE"].ToString());
            }
            this.lblMoney.Text = f.ToString("#0.0000"); //将数字格式化金额
        }
        /// <summary>
        /// 移除显现批次名称的label
        /// </summary>
        public void RemoveOfficeNameLable()
        {
            this.lblIllFieldName.Visible = false;
            this.lblBacthName.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 25.95831F);
            this.GroupHeader1.HeightF = 48.95831F;
        }
        /// <summary>
        /// 移除显现病区名称的label
        /// </summary>
        public void RemoveBatchNameLable()
        {
            this.lblBacthName.Visible = false;
            this.lblBacthName.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 25.95831F);
            this.GroupHeader1.HeightF = 48.95831F;
        }
        /// <summary>
        /// 移除显现病区及批次的label
        /// </summary>
        public void RemoveAllLabel()
        {
            this.lblIllFieldName.Visible = false;
            this.lblBacthName.Visible = false;
            this.lblBacthName.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.lblIllFieldName.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.GroupHeader1.HeightF = 25.95833F;         
        }
        #endregion
    }
}
