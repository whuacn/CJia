using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class MyPatientsPagePresenter : Presenter<Models.MyPatientsPageModel, Views.IMyPatientsPageView>
    {
        //SmartMedicService.WebServiceSoapClient service = new SmartMedicService.WebServiceSoapClient();
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
        public MyPatientsPagePresenter(Views.IMyPatientsPageView view)
            : base(view)
        {
            View.OnShowMyPatientList += View_OnShowMyPatientList;
            View.OnShowOfficePatientList += View_OnShowOfficePatientList;
            View.OnShowDutyPatientList += View_OnShowDutyPatientList;
            View.OnShowHistoryPatientList += View_OnShowHistoryPatientList;
            View.OnShowTodayPatientList += View_OnShowTodayPatientList;
        }

        //近期查房
        async void View_OnShowTodayPatientList(object sender, EventArgs e)
        {
            //List<Data.Patient> patientList = Model.QueryLocalTodayPatientList(iCommon.DoctorID);
            //View.ExeShowPatientList(patientList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryResentPatientListResponse x = await service.QueryResentPatientListAsync(iCommon.DoctorID, "近期病人", iCommon.Today);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(x.Body.QueryResentPatientListResult);
            List<Data.Patient> patientList = Entity.GetEntity<Data.Patient>(dicList);
        }

        //出院患者
        async void View_OnShowHistoryPatientList(object sender, EventArgs e)
        {
            //List<Data.Patient> patientList = Model.QueryLocalHistoryPatientList(iCommon.DoctorID);
            //View.ExeShowPatientList(patientList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryMyPatientListResponse x = await service.QueryMyPatientListAsync(iCommon.DoctorID, "已出院");
            List<Dictionary<string, string>> DoctorPatientLiset = Entity.XmlToListDic(x.Body.QueryMyPatientListResult);
            List<Data.Patient> listpatient = Entity.GetEntity<Data.Patient>(DoctorPatientLiset);
            View.ExeShowPatientList(listpatient);
        }

        //值班病人
        async void View_OnShowDutyPatientList(object sender, EventArgs e)
        {
            //List<Data.Patient> patientList = Model.QueryLocalDutyPatientList(iCommon.DoctorID);
            //View.ExeShowPatientList(patientList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryDutyResentPatientListResponse x = await service.QueryDutyResentPatientListAsync(iCommon.DoctorID, "值班病人");
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(x.Body.QueryDutyResentPatientListResult);
            List<Data.Patient> patientList = Entity.GetEntity<Data.Patient>(dicList);
            View.ExeShowPatientList(patientList);
        }

        //科室病人
        async void View_OnShowOfficePatientList(object sender, EventArgs e)
        {
            //List<Data.Patient> patientList = Model.QueryLocalOfficePatientList(iCommon.LoginUser.DeptID);
            //View.ExeShowPatientList(patientList);
            CJia.iSmartMedical.MobileMedicDoctorService.QueryDeptPatientsListResponse x = await service.QueryDeptPatientsListAsync(iCommon.LoginUser.DeptID, "正住院");
            List<Dictionary<string, string>> DeptPatientList = Entity.XmlToListDic(x.Body.QueryDeptPatientsListResult);
            List<Data.Patient> listDeptPatient = Entity.GetEntity<Data.Patient>(DeptPatientList);
            View.ExeShowPatientList(listDeptPatient);
        }

        //我的病人
        async void View_OnShowMyPatientList(object sender, EventArgs e)
        {
            //List<Data.Patient> patientList = Model.QueryLocalDoctorPatientList(iCommon.DoctorID);
            //View.ExeShowPatientList(patientList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryMyPatientListResponse x = await service.QueryMyPatientListAsync(iCommon.DoctorID,"正住院");
            List<Dictionary<string, string>> DoctorPatientLiset = Entity.XmlToListDic(x.Body.QueryMyPatientListResult);
            List<Data.Patient> listpatient = Entity.GetEntity<Data.Patient>(DoctorPatientLiset);
            View.ExeShowPatientList(listpatient);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
