using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class PatientCheckPagePresenter : Presenter<Models.PatientCheckMode, Views.IPatientCheckPageView>
    {
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        public PatientCheckPagePresenter(Views.IPatientCheckPageView view)
            : base(view)
        {
            View.OnChangePatient += View_OnChangePatient;
        }

        async void View_OnChangePatient(object sender, Views.PatientCheckEventArgs e)
        {
            //Model.SaveTodayCheckPatient(e.InhosID);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryResentPatientCountResponse countResponse = await service.QueryResentPatientCountAsync(iCommon.DoctorID + e.InhosID, iCommon.Today, "近期病人");
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(countResponse.Body.QueryResentPatientCountResult);
            int count = int.Parse(dicList[0]["RecentPatientCount"]);
            if (count == 0)
            {
                CJia.iSmartMedical.MobileMedicDoctorService.InsertDoctorPatientsResponse insertPatient = await service.InsertDoctorPatientsAsync(iCommon.DoctorID + e.InhosID, iCommon.DoctorID, e.InhosID, "近期病人", iCommon.Today);
                List<Dictionary<string, string>> dicList1 = Entity.XmlToListDic(insertPatient.Body.InsertDoctorPatientsResult);
                //if (dicList1[0]["isInsert"] == "true")
                //{
                //    MessageDialog msgdlg = new MessageDialog("添加成功");
                //    msgdlg.ShowAsync();
                //}
            }
        }
        
        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
