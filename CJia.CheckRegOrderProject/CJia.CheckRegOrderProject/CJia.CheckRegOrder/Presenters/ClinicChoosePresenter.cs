using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.CheckRegOrder.Presenters
{
    public class ClinicChoosePresenter:CJia.Presenter<Views.IClinicChooseView>
    {
        private Models.ClinicChooseModel Model
        {
            get;
            set;
        }

        public ClinicChoosePresenter(Views.IClinicChooseView view)
            : base(view)
        {
            this.Model = new Models.ClinicChooseModel();
        }

        protected override void OnViewSet()
        {
            this.View.OnLoadEvent += View_OnLoadEvent;
            this.View.btnOk_ClickEvent += View_btnOk_ClickEvent;
            this.View.btnCancle_ClickEvent += View_btnCancle_ClickEvent;
        }

        /// <summary>`  
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_btnOk_ClickEvent(object sender, Views.ClinicArgs e)
        {
            //    为待排队病人分配队列编号
            if (e.QueueNo == 0)
            {
                string queueNo = Model.GetPatientMaxQueueNo();      // 取得排队编号
                if (Model.IsSuccessAllocationClinic(e.PatientID, queueNo, e.ClinicID))
                {
                    //    插入阴道镜系统病人表和病史表
                    if (e.DataRowBySelectedNoQueuePatient["admissions_type"].ToString() == "检查病人")
                    {
                        if (!Model.IsExistSickNumFormSickData(e.DataRowBySelectedNoQueuePatient["patient_no"].ToString()))
                        {
                            //    插入病人表
                            Model.IsSuccessInsertColposcopyToSickData(e.DataRowBySelectedNoQueuePatient);
                            //    插入病史表
                            Model.IsSuccessInsertColposcopyToSickHistoryData(e.DataRowBySelectedNoQueuePatient);
                        }
                    }
                    this.View.CloseParentFrm();
                }
            }
            //    为排队病人修改队列编号
            else
            {
                if (Model.IsUpdateSuccessByClinic(e.PatientID, e.ClinicID))
                {
                    this.View.CloseParentFrm();
                }
            }
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_btnCancle_ClickEvent(object sender, EventArgs e)
        {
            this.View.CloseParentFrm();
        }

        void View_OnLoadEvent(object sender, EventArgs e)
        {
            //    下拉诊室绑定
            View.ExeBindClinicName(Model.GetClinicName());
        }
    }
}
