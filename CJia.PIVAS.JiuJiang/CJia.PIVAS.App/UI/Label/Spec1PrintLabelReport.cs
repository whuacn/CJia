using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 瓶贴汇总报表
    /// </summary>
    public partial class Spec1PrintLabelReport : DevExpress.XtraReports.UI.XtraReport
    {
        public Spec1PrintLabelReport()
        {
            InitializeComponent();
        }

        public DataTable LabelDetails = null;

        /// <summary>
        /// 这次共打印
        /// </summary>
        public int allLabel = 0;

        /// <summary>
        /// 
        /// </summary>
        public int PringedLabel = 0;

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="LabelDetails"></param>
        public void DataBind(DataTable LabelDetails, int allLabelCount,int i,string LabelBarCode,DateTime GenDate)
        {
            this.PrintingSystem.ShowMarginsWarning = false;
            this.ShowPrintMarginsWarning = false;
            this.ShowPreviewMarginLines = false;
            this.ShowPrintStatusDialog = false;
            DataView dv = LabelDetails.AsDataView();
            dv.Sort = " LABEL_ID DESC,HIS_ADVICE_ID ASC ";
            this.LabelDetails = dv.ToTable();
            if(this.LabelDetails != null && this.LabelDetails.Rows.Count != 0)
            {
                this.InitLabelTop(GenDate);
                this.InitLabelDate(allLabelCount, i, LabelBarCode);
            }
        }

        /// <summary>
        /// 打印瓶贴
        /// </summary>
        public void LabelPrint()
        {
            if(this.LabelDetails != null && this.LabelDetails.Rows.Count != 0)
            {
                this.CreateDocument();
                string printerName = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("LabelPrinterName");
                if(printerName == "")
                {
                    this.Print();
                }
                else
                {
                    this.Print(printerName);
                }
            }
            else
            {
                this.PringedLabel++;
            }
        }

        /// <summary>
        /// 将瓶贴保存为图片格式
        /// </summary>
        /// <returns></returns>
        public Image GenImage()
        {
            this.CreateDocument();
            Directory.CreateDirectory(Application.StartupPath + "\\LabelPreview");
            string path = Application.StartupPath + "\\LabelPreview\\" + DateTime.Now.ToString("yyyyMMddhhmmssfffffff") + ".jpg";
            this.ExportToImage(path);
            return Image.FromFile(path);
        }

        /// <summary>
        /// 初始化瓶贴固有信息
        /// </summary>
        private void InitLabelTop(DateTime GenDate)
        {
            this.illfield.Text = this.LabelDetails.Rows[0]["ILLFIELD"].ToString();
            this.usage.Text = this.LabelDetails.Rows[0]["USAGE"].ToString();

            string bedStr =  this.LabelDetails.Rows[0]["BED_ID"].ToString();
            if(bedStr.Length > 2)
            {
                this.bed.Text = bedStr;
            }
            else
            {
                this.bed.Text = bedStr + "床";
            }
            this.patientName.Text = this.LabelDetails.Rows[0]["PATIENT_NAME"].ToString();
            this.gender.Text = this.LabelDetails.Rows[0]["GENDER"].ToString();
            this.age.Text = this.LabelDetails.Rows[0]["AGE"].ToString();
            this.patientID.Text = this.LabelDetails.Rows[0]["INHOS_ID"].ToString();
            //this.adviceNO.Text = this.LabelDetails.Rows[0]["GROUP_INDEX"].ToString();
            this.pharm.Text = this.LabelDetails.Rows[0]["PHARM_TYPE"].ToString();
            this.LongTemporary.Text = this.LabelDetails.Rows[0]["LONG_TEMPORARY_NAME"].ToString();
            if(this.LabelDetails.Columns.Contains("GEN_NAME"))
            {
                this.check.Text = this.LabelDetails.Rows[0]["GEN_NAME"].ToString();
            }
            else
            {
                this.check.Text = User.UserName;
            }
            //this.listDate.Text = this.LabelDetails.Rows[0]["LIST_DATE"].ToString();
            this.doctor.Text = this.LabelDetails.Rows[0]["DOCTOR_NAME"].ToString();
            this.bacth.Text = this.LabelDetails.Rows[0]["BATCH_NAME"].ToString();
            this.labFrequency.Text = "[" + this.LabelDetails.Rows[0]["FREQUENCY_NAME"].ToString() + "]";

            this.PrintDate.Text = GenDate.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                this.PharmTime.Text = DateTime.Parse(this.LabelDetails.Rows[0]["PHARM_TIME"].ToString()).ToShortDateString();
            }
            catch
            {
                this.PharmTime.Text = this.LabelDetails.Rows[0]["PHARM_TIME"].ToString();
            }
        }

        /// <summary>
        /// 初始化瓶贴药品主信息
        /// </summary>
        /// <param name="allLabelCount">所有页数</param>
        /// <param name="i">当前页数</param>
        private void InitLabelDate(int allLabelCount,int i,string BarCode)
        {
            this.pageCount.Text = "第" + i.ToString() + @"/" + allLabelCount.ToString() + "张";
            this.DataSource = this.LabelDetails;
            this.pharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.spec.DataBindings.Add("Text", this.DataSource, "SPEC_UNIT");
            this.dosage.DataBindings.Add("Text", this.DataSource, "DOSAGE");
            //this.from.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
            this.count.DataBindings.Add("Text", this.DataSource, "AMOUNT");
            CJia.PIVAS.Tools.BarCode.Height = 55;
            this.barcode.Image = CJia.PIVAS.Tools.BarCode.GetCodeImage(BarCode, CJia.PIVAS.Tools.BarCode.Code39Model.Code39FullAscII, true);
            this.labBarCode.Text = BarCode;
        }



    }
}
