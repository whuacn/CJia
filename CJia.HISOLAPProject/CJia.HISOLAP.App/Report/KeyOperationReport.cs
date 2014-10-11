using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

/// <summary>
/// 住院重点手术情况
/// </summary>
public partial class KeyOperationReport : DevExpress.XtraReports.UI.XtraReport
{
    public KeyOperationReport()
    {
        InitializeComponent();
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    /// <param name="pharmSendData">数据</param>
    /// <param name="printDate">打印时间</param>
    public void DataBind(DataTable data)
    {
        this.DataSource = data;
        if (data == null || data.Rows.Count <= 0) return;
        this.Cell1.DataBindings.Add("Text", this.DataSource, data.Columns[0].ColumnName);
        this.Cell2.DataBindings.Add("Text", this.DataSource, data.Columns[7].ColumnName);
        this.Cell3.DataBindings.Add("Text", this.DataSource, data.Columns[8].ColumnName);
        this.Cell4.DataBindings.Add("Text", this.DataSource, data.Columns[6].ColumnName);
        this.Cell5.DataBindings.Add("Text", this.DataSource, data.Columns[2].ColumnName);
        this.Cell6.DataBindings.Add("Text", this.DataSource, data.Columns[3].ColumnName);
        this.Cell7.DataBindings.Add("Text", this.DataSource, data.Columns[4].ColumnName);
        this.Cell8.DataBindings.Add("Text", this.DataSource, data.Columns[5].ColumnName);
        this.CreateDocument();
        //this.ShowPreview();
    }

}
