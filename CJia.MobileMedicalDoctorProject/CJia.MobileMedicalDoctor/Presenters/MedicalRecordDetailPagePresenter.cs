using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class MedicalRecordDetailPagePresenter : Presenter<Models.MedicalRecordModel, Views.IMedicalRecordDetailPageView>
    {
        public MedicalRecordDetailPagePresenter(Views.IMedicalRecordDetailPageView view)
            : base(view)
        {
            View.OnQueryMedicalRecordDetail += View_OnQueryMedicalRecordDetail;
        }

        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        async void View_OnQueryMedicalRecordDetail(object sender, Views.IMedicalRecordDetailEventArgs e)
        {
            //Data.PatientEmrDoc Doc = Model.QueryPatientEmrDocDetail(e.InhosID, e.SectionNo);
            //View.ExeShowMedicalRecordDetail(Doc);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryPatientEmrDocDetailResponse PatientEmrDocDetail = await service.QueryPatientEmrDocDetailAsync(e.InhosID, e.SectionNo);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(PatientEmrDocDetail.Body.QueryPatientEmrDocDetailResult);
            List<Data.PatientEmrDoc> Doc = Entity.GetEntity<Data.PatientEmrDoc>(dicList);
            View.ExeShowMedicalRecordDetail(Doc[0]);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
