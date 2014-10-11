using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 瓶贴汇总报表
    /// </summary>
    public partial class LabelReport : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelReport()
        {
            InitializeComponent();
        }

        //public DataRow[] LabelDetails;

        ///// <summary>
        ///// 绑定数据
        ///// </summary>
        ///// <param name="LabelDetails"></param>
        //public void DataBind(DataRow[] LabelDetails)
        //{
        //    this.LabelDetails = LabelDetails;
        //}

        ///// <summary>
        ///// 打印瓶贴
        ///// </summary>
        //public void PrintLable()
        //{
        //    if(this.LabelDetails != null)
        //    {
        //        this.patientName.Text = this.LabelDetails[0]["PATIENT_NAME"].ToString();
        //        this.age.Text = this.LabelDetails[0]["AGE"].ToString();
        //        this.patientID.Text = this.LabelDetails[0]["INHOS_ID"].ToString().Substring(0,10);
        //        this.illfield.Text = this.LabelDetails[0]["ILLFIELD_NAME"].ToString();
        //        this.bed.Text = this.LabelDetails[0]["BED_NAME"].ToString();
        //        this.batch.Text = this.LabelDetails[0]["BATCH_NAME"].ToString();
        //        this.usege.Text = this.LabelDetails[0]["USAGE_NAME"].ToString();
        //        this.doctor.Text = this.LabelDetails[0]["DOCTOR_NAME"].ToString();


        //        int allLabelCount = (LabelDetails.Length - 1) / 7 + 1;
        //        //int allLabelCount = 3;
        //        for(int i = 1; i <= allLabelCount; i++)
        //        {
        //            this.pageCount.Text = i.ToString() + @"/" + allLabelCount.ToString();
        //            this.DataSource = this.GetDataSource(i);
        //            this.pharmName.DataBindings.Add("Text",this.DataSource,"PHARM_NAME");
        //            this.spec.DataBindings.Add("Text",this.DataSource,"SPEC");
        //            this.dosage.DataBindings.Add("Text", this.DataSource, "DOSAGE");
        //            this.from.DataBindings.Add("Text", this.DataSource, "FACTORY_NAME");
        //            CJia.PIVAS.Tools.barcode barcode = new Tools.barcode();
        //            barcode.Height = 60;
        //            this.barcode.Image =  barcode.GetCodeImage("1234567890123", Tools.barcode.Code39Model.Code39Normal,true);
        //            //this.barcode.Image = CJia.PIVAS.Tools.erweima.CreateQRcode("134567566543435457uhgfsdfgfdssdfss发生地方");
        //            this.CreateDocument(); //创建文档
        //            this.Print();
        //        }
        //    }
        //}

        //private DataTable GetDataSource(int nowCount)
        //{
        //    DataTable result = this.LabelDetails[0].Table.Clone();
        //    for(int i = (nowCount - 1) * 3; i < nowCount * 3; i++)
        //    {
        //        DataRow row = result.NewRow();
        //        if(i < this.LabelDetails.Length)
        //        {
        //            row.ItemArray = this.LabelDetails[i].ItemArray;
        //        }
        //        //else
        //        //{
        //        //    row.ItemArray = this.LabelDetails[0].ItemArray;
        //        //}
        //        result.Rows.Add(row);
        //    }
        //    return result;
        //}

    }
}
