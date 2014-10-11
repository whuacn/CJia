using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 瓶贴汇总报表
    /// </summary>
    public partial class StorageReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StorageReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品数据绑定
        /// </summary>
        /// <param name="LabelCollect">药品类数据集</param>
        /// <returns></returns>
        public void DataBind( DataTable StorageSource,DateTime NowTime, string DrugName,string BatchNO,string Firm)
        {
            this.xrReportHeader.Text = @"静脉药物配置中心库存统计报表
" + NowTime.Year + "年" + NowTime.Month + "月" + NowTime.Day + "日" + NowTime.Hour + "时" + NowTime.Minute + "分" + NowTime.Second + "秒" ;
            StorageSource.DefaultView.Sort = " DRUG_NAME ,DRUG_SPEC ,FIRM_ID";
            StorageSource = StorageSource.DefaultView.ToTable();
            this.DataSource = StorageSource;
            if(DrugName != "")
            { 
                this.xrLbltext.Text="药品名称: "+DrugName;
            }
            if(BatchNO != "")
            {
                this.xrLbltext.Text = this.xrLbltext.Text + "      批号: " + BatchNO;
            }
            if (Firm != "")
            {
                this.xrLbltext.Text = this.xrLbltext.Text + "      生产厂商: " + Firm;
            }
            if (DrugName == "" && BatchNO == "" && Firm== "")
            {
                this.xrLbltext.Visible = false;
                this.xrLabel1.Visible=false;
            }
            this.xrFirm.DataBindings.Add("Text", this.DataSource, "FIRM_ID");
            this.xrSpec.DataBindings.Add("Text", this.DataSource, "DRUG_SPEC");
            this.xrBatch.DataBindings.Add("Text", this.DataSource, "BATCH_NO");
            this.xrExpireDate.DataBindings.Add("Text", this.DataSource, "EXPIRE_DATE");
            this.xrDrugName.DataBindings.Add("Text", this.DataSource, "DRUG_NAME");
            this.xrQuantity.DataBindings.Add("Text", this.DataSource, "Quantity");
            this.xrUnits.DataBindings.Add("Text", this.DataSource, "UNITS" );
            this.xrPrice.DataBindings.Add("Text", this.DataSource, "PRICE");
//            this.xrPTY.DataBindings.Add("Text", this.DataSource, "PTY");
//            this.xrJSY.DataBindings.Add("Text", this.DataSource, "JSY");
//            this.xrDMY.DataBindings.Add("Text", this.DataSource, "DMY");
//            this.xrGCY.DataBindings.Add("Text", this.DataSource, "GCY");
//            this.xrKSS.DataBindings.Add("Text", this.DataSource, "KSS");
//            this.xrAllCount.DataBindings.Add("Text", this.DataSource, "SUBTOTAL");
            this.labPrintDate.Text = NowTime.ToString();
            this.CreateDocument(); //创建文档
            this.ShowPreviewDialog();
        }

    }
}
