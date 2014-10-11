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
    public partial class PatientView : DevExpress.XtraEditors.XtraUserControl
    {
        public PatientView()
        {
            InitializeComponent();
        }
        public PatientView(DataTable data)
        {
            InitializeComponent();
            BindPatient(data);
        }
        public void BindPatient(DataTable data)
        {
            vgcPatient.DataSource = data;
        }

        ///// <summary>
        ///// 关闭窗体事件
        ///// </summary>
        //public event EventHandler CloseForm;

        #region 窗体事件
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
