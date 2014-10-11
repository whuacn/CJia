using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class PatientHistoryPresenter : CJia.Presenter<Views.IPatientHistoryView>
    {
        private Models.PatientHistoryModel Model
        {
            get;
            set;
        }
        public PatientHistoryPresenter(Views.IPatientHistoryView view)
            : base(view)
        {
            Model = new Models.PatientHistoryModel();
        }
        protected override void OnViewSet()
        {
            View.Load += View_Load;
            View.OnSelectByNO += View_OnSelectByNO;
            View.OnSelectByName += View_OnSelectByName;
            View.OnSelect += View_OnSelect;
            View.OnGCClick += View_OnGCClick;
            View.OnSave += View_OnSave;
        }

        void View_OnSave(object sender, Views.PatientHistoryArgs e)
        {
            bool bol = Model.ModifyPatientHistory(e.patientHistory, User.UserID);
            if (bol)
            {
                View.Reset();
                View.TxtPatientNOFocus();
            }
        }

        void View_OnGCClick(object sender, Views.PatientHistoryArgs e)
        {
            DataTable data = Model.GetPatientByID(e.PatientID);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindEditHistory(data);
            }
        }

        void View_OnSelect(object sender, Views.PatientHistoryArgs e)
        {
            if (BindByNO(e.PatientNO))
            {
                View.TxtPatientNOFocus();
                return;
            }
            if (BindByName(e.PatientName))
            {
                View.TxtPatientNameFocus();
                return;
            }
            View.ShowMessage("无此病人病史登记信息");
            View.TxtPatientNOFocus();
        }

        void View_OnSelectByName(object sender, Views.PatientHistoryArgs e)
        {
            if (!BindByName(e.PatientName))
            {
                View.ShowMessage("无此病人病史登记信息");
            }
            View.TxtPatientNameFocus();
        }

        void View_OnSelectByNO(object sender, Views.PatientHistoryArgs e)
        {
            if (!BindByNO(e.PatientNO))
            {
                View.ShowMessage("无此病人病史登记信息");
            }
            View.TxtPatientNOFocus();
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable SeverityData = Model.GetCodeValueByType("宫颈炎");
            DataTable CINData = Model.GetCodeValueByType("CIN");
            DataTable StageData = Model.GetCodeValueByType("宫颈瘤");
            DataTable TreatData = Model.GetCodeValueByType("宫颈治疗");
            DataTable LeucorrheaData = Model.GetCodeValueByType("白带");
            View.ExeBindComboBox(SeverityData, CINData, StageData, TreatData, LeucorrheaData);
            DataTable phdata = Model.GetPatient();
            View.ExeBindHistory(phdata);
        }

        #region 内部调用函数
        /// <summary>
        /// 根据病人工号查询是否能返回data
        /// </summary>
        /// <param name="patientNO"></param>
        /// <returns></returns>
        public bool BindByNO(string patientNO)
        {
            DataTable data = Model.GetPatientByNO(patientNO);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindHistory(data);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据病人姓名查询是否能返回data
        /// </summary>
        /// <param name="patientName"></param>
        /// <returns></returns>
        public bool BindByName(string patientName)
        {
            DataTable data = Model.GetPatientByName(patientName);
            if (data != null && data.Rows.Count > 0)
            {
                View.ExeBindHistory(data);
                return true;
            }
            return false;
        }
        #endregion
    }
}
