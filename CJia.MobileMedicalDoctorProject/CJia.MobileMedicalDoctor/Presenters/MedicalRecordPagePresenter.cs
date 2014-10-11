using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class MedicalRecordPagePresenter : Presenter<Models.MedicalRecordModel, Views.IMedicalRecordPageView>
    {
        public MedicalRecordPagePresenter(Views.IMedicalRecordPageView view)
            : base(view)
        {
            View.OnQueryMedicalRecord += View_OnQueryMedicalRecord;
        }

        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        async void View_OnQueryMedicalRecord(object sender, Views.MedicalRecordEventArgs e)
        {
            //List<Data.PatientEmrDoc> DocList = Model.QueryLocalEmrDocHeader(e.InhosID);
            //View.ExeShowMedicalRecordList(DocList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryEmrDocHeaderResponse emrDocHeader = await service.QueryEmrDocHeaderAsync(e.InhosID);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(emrDocHeader.Body.QueryEmrDocHeaderResult);
            List<Data.PatientEmrDoc> PatientEmrDocList = Entity.GetEntity<Data.PatientEmrDoc>(dicList);
            View.ExeShowMedicalRecordList(PatientEmrDocList);
        }


        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
