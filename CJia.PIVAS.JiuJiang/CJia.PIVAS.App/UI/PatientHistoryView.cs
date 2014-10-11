//***************************************************
// 文件名（File Name）:      PatientHistoryView.cs(病史资料UI层)
//
// 视图（Views）:            patient_history_view
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

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 病史资料
    /// </summary>
    public partial class PatientHistoryView : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public PatientHistoryView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientName">姓名</param>
        /// <param name="inhosId">住院号</param>
        /// <param name="illfieldName">病区名称</param>
        /// <param name="officeName">科室</param>
        /// <param name="bedName">床名</param>
        /// <param name="data">data数据</param>
        public PatientHistoryView(string patientName, string inhosId, string illfieldName, string officeName, string bedName, DataTable data)
        {
            InitializeComponent();
            BindPatientHistory(patientName, inhosId, illfieldName, officeName, bedName, data);
        }
        /// <summary>
        /// 病史资料数据绑定
        /// </summary>
        /// <param name="patientName">姓名</param>
        /// <param name="inhosId">住院号</param>
        /// <param name="illfieldName">病区名称</param>
        /// <param name="officeName">科室</param>
        /// <param name="bedName">床名</param>
        /// <param name="data">data数据</param>
        public void BindPatientHistory(string patientName, string inhosId, string illfieldName, string officeName, string bedName, DataTable data)
        {
            txtPatientName.Text = patientName;
            txtInhosID.Text = inhosId.ToString();
            txtIllfieldName.Text = illfieldName;
            txtOfficeName.Text = officeName;
            txtBedName.Text = bedName;
            gcPatientHoistory.DataSource = data;
            gvPatientHistory.ExpandAllGroups();
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
