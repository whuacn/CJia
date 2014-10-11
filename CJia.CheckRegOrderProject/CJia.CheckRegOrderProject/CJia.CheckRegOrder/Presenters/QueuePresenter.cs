using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class QueuePresenter:CJia.Presenter<Views.IQueueView>
    {
        private Models.QueueModel Model
        {
            get;
            set;
        }

        public QueuePresenter(Views.IQueueView view)
            : base(view)
        {
            this.Model = new Models.QueueModel();
        }

        protected override void OnViewSet()
        {
            this.View.OnLoadEvent += View_OnLoadEvent;
            this.View.OnCancleQueueEvent += View_CancleQueue;
            this.View.OnCancleWaitEvent += View_CancleWait;
            this.View.OnFliterClinicEvent += View_FliterClinic;
            this.View.OnAllocateClinicEvent += View_AllocateClinicEvent;
            this.View.OnFreshEvent += View_OnFreshEvent;
        }

      
        /// <summary>
        /// 分配诊室事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_AllocateClinicEvent(object sender, EventArgs e)
        {
            OnBindNotExistQueue();
            OnBindExistQueue();
        }

        /// <summary>
        /// 窗体加载时显示病人队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLoadEvent(object sender, EventArgs e)
        {
            OnBindNotExistQueue();
            OnBindExistQueue();
            OnBindClinic();
        }

        /// <summary>
        /// 登记未排队病人列表
        /// </summary>
        void OnBindNotExistQueue()
        {
            DataTable dtNotExistQueue = Model.GetPatientByNotExistQueue();
            if (dtNotExistQueue.Rows.Count == 0)
            {
                dtNotExistQueue = null;
            }
            View.ExeBindNotExistQueue(dtNotExistQueue);
        }

        /// <summary>
        ///  排队病人队列
        /// </summary>
        void OnBindExistQueue()
        {
            DataTable dtExistQueue = Model.GetPatientByExistQueue();
            if (dtExistQueue.Rows.Count == 0)
            {
                dtExistQueue = null;
            }
            else
            {
                View.ExeBindExistQueue(dtExistQueue);
            }
        }

        /// <summary>
        /// radioGroup 诊室绑定
        /// </summary>
        void OnBindClinic()
        {
            DataTable dtClinicName = Model.GetClinicName();
            if (dtClinicName != null)
            {
                View.ExeBindClinicName(dtClinicName);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 取消排队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_CancleQueue(object sender, Views.QueueArgs e)
        {
            if (Model.IsSuccessCancleQueue(e.PatientID))
            {
                OnBindExistQueue();
                OnBindNotExistQueue();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 取消等待 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_CancleWait(object sender, Views.QueueArgs e)
        {
            if (Model.IsSuccessCancleWait(e.PatientID))
            {
                OnBindNotExistQueue();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// radioGroup 筛选诊室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_FliterClinic(object sender, Views.QueueArgs e)
        {
            DataTable dtFilterClinic;
            //    radioGroup 选择"全部"
            if (e.ClinicID == 0)
            {
                dtFilterClinic = Model.GetPatientByExistQueue();
                if (dtFilterClinic.Rows.Count == 0)
                {
                    dtFilterClinic = null;
                }
            }
            else
            {
                dtFilterClinic = Model.GetPatientByFilterClinicId(e.ClinicID);
                if (dtFilterClinic.Rows.Count == 0)
                {
                    dtFilterClinic = null;
                }
            }
            View.ExeBindExistQueue(dtFilterClinic);
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnFreshEvent(object sender, EventArgs e)
        {
            OnBindNotExistQueue();
            OnBindExistQueue();
            OnBindClinic();
        }
    }
}
