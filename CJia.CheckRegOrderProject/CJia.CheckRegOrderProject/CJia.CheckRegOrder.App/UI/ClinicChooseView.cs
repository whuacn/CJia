using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class ClinicChooseView : CJia.Editors.View , Views.IClinicChooseView
    {
        //  CJia.Editors.View , DevExpress.XtraEditors.XtraUserControl
        public ClinicChooseView()
        {
            InitializeComponent();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.ClinicChoosePresenter(this);
        }

        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClinicChooseView_Load(object sender, EventArgs e)
        {
            OnLoadEvent(null, null);
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        Views.ClinicArgs clinicArgs = new Views.ClinicArgs();


        public ClinicChooseView(DataRow datarow)
        {
            InitializeComponent();
            if (datarow["clinic_id"].ToString() != "待定" && datarow["clinic_id"].ToString() != "")
            {
                clinicArgs.ClinicID = int.Parse(datarow["clinic_id"].ToString());
            }
            OnLoadEvent(null, null);
            clinicArgs.PatientID = int.Parse(datarow["patient_id"].ToString());

            // 等待排队病人无队列号
            if (datarow["queue_no"].ToString() == "")
            {
                clinicArgs.QueueNo = 0;
                //DataRowNoQueue = datarow;
                clinicArgs.DataRowBySelectedNoQueuePatient = datarow;
            }
            else
            {
                clinicArgs.QueueNo = 1;
            }
        }

        /// <summary>
        /// 绑定诊室下拉列表
        /// </summary>
        /// <param name="dtClinicName"></param>
        public void ExeBindClinicName(DataTable dtClinicName)
        {
            if (dtClinicName == null || dtClinicName.Rows.Count == 0)
            {
                Message.Show("当前没有诊室，请先维护诊室！");
                return;
            }
            cbClinic.DataSource = dtClinicName;
            cbClinic.DisplayMember = "clinic_name";
            cbClinic.ValueMember = "clinic_id";
            cbClinic.SelectedValue = clinicArgs.ClinicID;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbClinic.SelectedValue != null)
            {
                clinicArgs.ClinicID = int.Parse(cbClinic.SelectedValue.ToString());
                btnOk_ClickEvent(sender, clinicArgs);
            }
            else
            {
                clinicArgs.ClinicID = 0;
                MessageBox.Show("请选择诊室！");
                return;
            }

        }

        /// <summary>
        /// 关闭父窗口
        /// </summary>
        public void CloseParentFrm()
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnCancle_ClickEvent(null, null);
        }



        /// <summary>
        /// 初始化加载事件，加载下拉诊室
        /// </summary>
        public event EventHandler OnLoadEvent;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.ClinicArgs> btnOk_ClickEvent;

        /// <summary>
        /// 取消事件
        /// </summary>
        public event EventHandler btnCancle_ClickEvent;
    }
}
