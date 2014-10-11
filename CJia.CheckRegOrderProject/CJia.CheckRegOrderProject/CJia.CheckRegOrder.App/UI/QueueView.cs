using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class QueueView : CJia.Editors.View, Views.IQueueView
    {
        //   DevExpress.XtraEditors.XtraUserControl , CJia.Editors.View 
        public QueueView()
        {
            InitializeComponent();
        }

        
        protected override object CreatePresenter()
        {
            return new Presenters.QueuePresenter(this);
        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueueView_Load(object sender, EventArgs e)
        {
            OnLoadEvent(null, null);
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        Views.QueueArgs queueArgs = new Views.QueueArgs();

        /// <summary>
        /// 查询结果不为空时绑定登记未检查病人
        /// </summary>
        /// <param name="dtNotExistQueue">登记未检查病人数据集</param>
        public void ExeBindNotExistQueue(DataTable dtNotExistQueue)
        {
            this.gridNoQueue.DataSource = dtNotExistQueue;
        }

        /// <summary>
        /// 绑定诊室筛选 
        /// </summary>
        /// <param name="dtClinicName"></param>
        public void ExeBindClinicName(DataTable dtClinicName)
        {
            if (rgClinic.Properties.Items.Count > dtClinicName.Rows.Count)
            {
                return;
            }
            for (int i = 1; i <= dtClinicName.Rows.Count; i++)
            {
                DevExpress.XtraEditors.Controls.RadioGroupItem clinicGroup = new DevExpress.XtraEditors.Controls.RadioGroupItem(Convert.ToInt64(dtClinicName.Rows[i - 1]["clinic_id"]), dtClinicName.Rows[i - 1]["clinic_name"].ToString());
                this.rgClinic.Properties.Items.Add(clinicGroup);
                if (i == dtClinicName.Rows.Count)
                {
                    DevExpress.XtraEditors.Controls.RadioGroupItem clinicGroupAll = new DevExpress.XtraEditors.Controls.RadioGroupItem(Convert.ToInt64(0), "全部");
                    this.rgClinic.Properties.Items.Add(clinicGroupAll);
                    this.rgClinic.Size = new System.Drawing.Size(90*(i+1),24);
                    break;
                }
            }
            this.groupControl2.Controls.Add(this.rgClinic);
        }

        /// <summary>
        /// 诊室筛选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reslut = rgClinic.SelectedIndex;
            queueArgs.ClinicID = int.Parse(rgClinic.Properties.Items[reslut].Value.ToString());
            OnFliterClinicEvent(sender, queueArgs);
        }

        /// <summary>
        /// 查询结果不为空时绑定正在排队病人
        /// </summary>
        /// <param name="dtExistQueue">排队病人数据集</param>
        public void ExeBindExistQueue(DataTable dtExistQueue)
        {
            this.gridQueue.DataSource = dtExistQueue;
        }

        /// <summary>
        /// 排队列表和等待列表为空处理
        /// </summary>
        /// <param name="sender">触发控件</param>
        /// <param name="e">控件属性</param>
        private void GridView_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            if (columnView.GridControl.DataSource == null  )
            {
                string str = "当前没有数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Top + 30, e.Bounds.Left + 30, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
        }


        /// <summary>
        /// 取消排队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancleQueue_Click(object sender, EventArgs e)
        {
            if (gvQueue.GetFocusedDataRow() != null)
            {
                queueArgs.PatientID = int.Parse(gvQueue.GetFocusedDataRow()["patient_id"].ToString());
                if (Message.ShowQuery("确定取消该排队病人？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    OnCancleQueueEvent(sender, queueArgs);
                    OnFliterClinicEvent(sender, queueArgs);    // radioGroup焦点 1.6
                }
            }
            else
            {
                queueArgs.PatientID = 0;
                Message.Show("当前没有排队病人！");
                return;
            }
        }

        /// <summary>
        /// 登机未排队病人取消等待
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancleWait_Click(object sender, EventArgs e)
        {
            if (gvNoQueue.GetFocusedDataRow() != null)
            {
                queueArgs.PatientID = int.Parse(gvNoQueue.GetFocusedDataRow()["patient_id"].ToString());
                if (Message.ShowQuery("确定取消该等待病人？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    OnCancleWaitEvent(sender, queueArgs);
                    OnFliterClinicEvent(sender, queueArgs);    // radioGroup焦点 1.6
                }
            }
            else
            {
                queueArgs.PatientID = 0;
                Message.Show("当前没有等待病人！");
                return;
            }

        }

        /// <summary>
        /// 为待排队病人分配诊室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridNoQueue_DoubleClick(object sender, EventArgs e)
        {
            if (gvNoQueue.GetFocusedDataRow() != null)
            {
                DataRow dr = gvNoQueue.GetFocusedDataRow();
                Clinic clinicFrm = new Clinic(dr);
                clinicFrm.ShowDialog();
                OnAllocateClinicEvent(null,null);
                OnFliterClinicEvent(sender, queueArgs);    // radioGroup焦点 1.6
            }
            else
            {
                MessageBox.Show("当前没有等待病人！");
                return;
            }
        }

        /// <summary>
        /// 为排队病人修改诊室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridQueue_DoubleClick(object sender, EventArgs e)
        {
            if (gvQueue.GetFocusedDataRow() != null)
            {
                DataRow dr = gvQueue.GetFocusedDataRow();
                Clinic clinicFrm = new Clinic(dr);
                clinicFrm.ShowDialog();
                OnAllocateClinicEvent(null, null);
                OnFliterClinicEvent(sender, queueArgs);    // radioGroup焦点 1.6
            }
            else
            {
                MessageBox.Show("当前没有排队病人！");
                return;
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnFreshEvent(null,null);
        }

        /// <summary>
        /// 初始化加载事件，加载等待病人列表、排队列表和下拉诊室
        /// </summary>
        public event EventHandler OnLoadEvent;

        /// <summary>
        /// 分配诊室事件
        /// </summary>
        public event EventHandler OnAllocateClinicEvent;

        /// <summary>
        /// 取消排队事件
        /// </summary>
        public event EventHandler<Views.QueueArgs> OnCancleQueueEvent;

        /// <summary>
        /// 取消等待事件
        /// </summary>
        public event EventHandler<Views.QueueArgs> OnCancleWaitEvent;

        /// <summary>
        /// radioGroup筛选诊室
        /// </summary>
        public event EventHandler<Views.QueueArgs> OnFliterClinicEvent;

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        public event EventHandler OnFreshEvent; 
    }
}

        

