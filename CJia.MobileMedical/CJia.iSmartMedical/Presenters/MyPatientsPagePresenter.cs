using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class MyPatientsPagePresenter : Presenter<Models.MyPatientsPageModel, Views.IMyPatientsPageView>
    {
        public MyPatientsPagePresenter(Views.IMyPatientsPageView view)
            : base(view)
        {
            View.OnShowMyPatientList += View_OnShowMyPatientList;
            View.OnShowOfficePatientList += View_OnShowOfficePatientList;
            View.OnShowDutyPatientList += View_OnShowDutyPatientList;
            View.OnShowHistoryPatientList += View_OnShowHistoryPatientList;
            View.OnShowTodayPatientList += View_OnShowTodayPatientList;
        }

        void View_OnShowTodayPatientList(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = Model.QueryLocalTodayPatientList(iCommon.DoctorID);
            View.ExeShowPatientList(patientList);
        }

        void View_OnShowHistoryPatientList(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = Model.QueryLocalHistoryPatientList(iCommon.DoctorID);
            View.ExeShowPatientList(patientList);
        }

        void View_OnShowDutyPatientList(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = Model.QueryLocalDutyPatientList(iCommon.DoctorID);
            View.ExeShowPatientList(patientList);
        }

        void View_OnShowOfficePatientList(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = Model.QueryLocalOfficePatientList(iCommon.LoginUser.DeptID);
            View.ExeShowPatientList(patientList);
        }

        void View_OnShowMyPatientList(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = Model.QueryLocalDoctorPatientList(iCommon.DoctorID);
            View.ExeShowPatientList(patientList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
