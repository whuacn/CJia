using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class RegistePresenter : CJia.Presenter<Views.IRegisteView>
    {
        private Models.RegisteModel Model
        {
            set;
            get;
        }
        public RegistePresenter(Views.IRegisteView view)
            : base(view)
        {
            Model = new Models.RegisteModel();
        }
        protected override void OnViewSet()
        {
            View.OnSelectHIS += View_OnSelectHIS;
            View.OnClientRegiste += View_OnClientRegiste;
            View.OnCheckRegiste += View_OnCheckRegiste;
            View.Load += View_Load;
            this.View.CancleQueue += View_CancleQueue;      // 取消排队 by zeng
        }

        void View_OnCheckRegiste(object sender, Views.RegisteArgs e)
        {
            if (isExistLinePatient(e.PatientNOFocus))
            {
                View.ShowMessage("此病人今天已登记，请她耐心等候");
                View.ExeReset();
                return;
            }
            if (isExistNotLinePatient(e.PatientNOFocus))
            {
                if (Message.ShowQuery("此病人已登记未排队，是否将其重新待排队？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    if (Model.ModifyStateByPatientNO(e.PatientNOFocus))
                    {
                        View.ExeReset();
                        return;
                    }
                }
                return;
            }
            if (Model.AddCheckPatient(e.PatientData, User.UserID, e.AdmissionsType,e.patientHistory))
            {
                View.ShowMessage("此检查病人登记成功");
                View.ExeReset();
            }
        }

        void View_OnClientRegiste(object sender, Views.RegisteArgs e)
        {
            if (isExistLinePatient(e.PatientNOFocus))
            {
                View.ShowMessage("此病人今天已登记，请她耐心等候");
                View.ExeReset();
                return;
            }
            if (isExistNotLinePatient(e.PatientNOFocus))
            {
                if (Message.ShowQuery("此病人已登记未排队，是否将其重新待排队？", Message.Button.YesNo) == Message.Result.Yes)
                {
                    if (Model.ModifyStateByPatientNO(e.PatientNOFocus))
                    {
                        View.ExeReset();
                        return;
                    }
                }
                return;
            }
            if (Model.AddClinicPatient(e.PatientData, User.UserID, e.AdmissionsType))
            {
                View.ShowMessage("此门诊病人登记成功");
                View.ExeReset();
            }
        }

        void View_OnSelectHIS(object sender, Views.RegisteArgs e)
        {
            DataTable data = Model.GetHISPatient(e.PatientNO, e.InvoiceNO);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindPatientInfo(data);
            }
            else
            {
                View.ShowMessage("无此病人挂号检查信息");
            }
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable SeverityData = Model.GetCodeValueByType("宫颈炎");
            DataTable CINData = Model.GetCodeValueByType("CIN");
            DataTable StageData = Model.GetCodeValueByType("宫颈瘤");
            DataTable TreatData = Model.GetCodeValueByType("宫颈治疗");
            DataTable LeucorrheaData = Model.GetCodeValueByType("白带");
            View.ExeBindComboBox(SeverityData, CINData, StageData, TreatData, LeucorrheaData);

            //  排队列表  by zeng
            DataTable dtExistQueue = Model.GetPatientByExistQueue();
            if (dtExistQueue != null)
            {
                View.GetPatientByExistQueue(dtExistQueue);
            }
        }
        /// <summary>
        /// 取消排队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_CancleQueue(object sender, EventArgs e)
        {
            if (View.IsExistClinic == "待定")
            {
                Message.Show("该病人已经在等待!");
                return;
            }
            else if (View.IsExistClinic == "")
            {
                return;
            }
            else
            {
                if (Message.ShowQuery("确定取消该排队病人？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    Model.IsSuccessCancleQueue(View.PatientIdByQueue);
                }
            }
        }

        #region 内部函数
        /// <summary>
        /// 根据病人卡号判断待排队和排队队列中是否有此病人
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <returns></returns>
        bool isExistLinePatient(string patientNO)
        {
            DataTable data = Model.GetLinePatientByNO(patientNO);
            if (data != null && data.Rows.Count > 0) return true;
            else return false;
        }
        /// <summary>
        /// 根据病人卡号判断未排队队列中是否有此病人
        /// </summary>
        /// <param name="patientNO">病人卡号</param>
        /// <returns></returns>
        bool isExistNotLinePatient(string patientNO)
        {
            DataTable data = Model.GetNotLinePatientByPatientNO(patientNO);
            if (data != null && data.Rows.Count > 0) return true;
            else return false;
        }
        #endregion
    }
}
