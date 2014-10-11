//***************************************************
// 文件名（File Name）:      RCPReportView.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.26
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CJia.PIVAS.App.UI
{
    public partial class RCPReportView : DevExpress.XtraReports.UI.XtraReport
    {
        public RCPReportView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dtData"></param>
        public void DataBind(DataTable dtData)
        {
            if (dtData.Rows.Count < 1)
            {
                return;
            }
            this.DataSource = dtData;
            this.lblRCPId.DataBindings.Add("Text", this.DataSource, "CANCEL_RCP_ID");
            this.lblCancelTime.DataBindings.Add("Text", this.DataSource, "CHECK_TIME");
            this.lblIllFieldName.DataBindings.Add("Text", this.DataSource, "ILLFIELD_NAME");
            this.lblLabelNo.DataBindings.Add("Text", this.DataSource, "LABEL_NO");
            this.xtcPharmName.DataBindings.Add("Text", this.DataSource, "PHARM_NAME");
            this.xtcSPEC.DataBindings.Add("Text", this.DataSource, "SPEC");
            this.xtcPharmAmount.DataBindings.Add("Text", this.DataSource, "PHARM_AMOUNT");
            this.GroupHeader1.GroupFields.Add(new GroupField("LABEL_NO"));
            this.GroupHeader2.GroupFields.Add(new GroupField("ILLFIELD_NAME"));
            this.CreateDocument();
            this.ShowPreview();
        }
    }
}
