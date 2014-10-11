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
    public partial class StorageLabel : DevExpress.XtraEditors.XtraUserControl
    {
        public StorageLabel()
        {
            InitializeComponent();
        }
        public StorageLabel(DataTable data)
        {
            InitializeComponent();
            this.gdcLabel.DataSource = data;
            this.gdvLabelCollect.ExpandAllGroups();
        }
  }
}
