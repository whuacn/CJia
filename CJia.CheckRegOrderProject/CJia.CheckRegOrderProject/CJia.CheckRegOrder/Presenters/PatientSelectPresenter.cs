using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class PatientSelectPresenter : CJia.Presenter<Views.IPatientSelectView>
    {
        private Models.PatientSelectModel Model
        {
            get;
            set;
        }
        public PatientSelectPresenter(Views.IPatientSelectView view)
            : base(view)
        {
            Model = new Models.PatientSelectModel();
        }
        protected override void OnViewSet()
        {
            View.Load += View_Load;
            View.OnSelectByNO += View_OnSelectByNO;
            View.OnSelectByName += View_OnSelectByName;
            View.OnSelect += View_OnSelect;
        }

        void View_OnSelect(object sender, Views.PatientSelectArgs e)
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
            View.ShowMessage("无此病人就诊信息");
            View.TxtPatientNOFocus();
        }

        void View_OnSelectByName(object sender, Views.PatientSelectArgs e)
        {
            if (!BindByName(e.PatientName))
            {
                View.ShowMessage("无此病人就诊信息");
            }
            View.TxtPatientNameFocus();
        }

        void View_OnSelectByNO(object sender, Views.PatientSelectArgs e)
        {
            if (!BindByNO(e.PatientNO)) 
            {
                View.ShowMessage("无此病人就诊信息");
            }
            View.TxtPatientNOFocus();
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetPatient();
            View.ExeBindPatient(data);
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
                View.ExeBindPatient(data);
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
                View.ExeBindPatient(data);
                return true;
            }
            return false;
        }
        #endregion
    }
}
