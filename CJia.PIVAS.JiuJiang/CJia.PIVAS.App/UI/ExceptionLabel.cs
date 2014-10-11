//***************************************************
// 文件名（File Name）:      PatientView.cs(病人信息UI层)
//
// 视图（Views）:            hm_patient_view
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CJia.PIVAS.Models;

namespace CJia.PIVAS.App.UI
{
    public partial class ExceptionLabel : DevExpress.XtraEditors.XtraUserControl
    {
        public ExceptionLabel()
        {
            InitializeComponent();
        }
        public ExceptionLabel(DataTable data)
        {
            InitializeComponent();
            this.gdcLabel.DataSource = data;
            this.gdvLabelCollect.ExpandAllGroups();
        }

        //瓶贴列表表格绑定事件
        private void gdvLabelCollect_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                string stutas = this.gdvLabelCollect.GetDataRow(e.RowHandle)["LABEL_STATUS_CODE"].ToString();
                if(stutas == "1000501")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if(stutas == "1000601")
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else if(stutas == "1000602")
                {
                    e.Appearance.BackColor = Color.SlateBlue;
                }

            }
        }
    }
}
