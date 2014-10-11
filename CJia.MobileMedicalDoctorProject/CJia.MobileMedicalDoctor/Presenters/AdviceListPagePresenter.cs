using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class AdviceListPagePresenter : Presenter<Models.AdviceModel, Views.IAdviceListPageView>
    {
        public AdviceListPagePresenter(Views.IAdviceListPageView view)
            : base(view)
        {
            View.OnQueryPatientAdvices += View_OnQueryPatientAdvices;
            View.OnQueryAdviceTypeList += View_OnQueryAdviceTypeList;
        }

        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        async void View_OnQueryAdviceTypeList(object sender, Views.AdviceEventArgs e)
        {
            //List<Data.AdviceTypeGroup> AdviceTypeList = Model.QueryPatientAdvicesTypeList(e.InhosID,e.StandingFlag);
            //View.ExeShowAdviceTypeList(AdviceTypeList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryAdviceCountResponse adviceCouunt = await service.QueryAdviceCountAsync(e.InhosID, e.StandingFlag);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(adviceCouunt.Body.QueryAdviceCountResult);
            List<Data.AdviceTypeGroup> AdviceList = Entity.GetEntity<Data.AdviceTypeGroup>(dicList);
            View.ExeShowAdviceTypeList(AdviceList);
        }

        async void View_OnQueryPatientAdvices(object sender, Views.AdviceEventArgs e)
        {
            //List<Data.PatientAdvices> AdviceList = Model.QueryLocalPatientAdvices(InhosID);
            //View.ExeShowAdviceList(AdviceList);
            CJia.iSmartMedical.MobileMedicDoctorService.QueryAdviceResponse advice = await service.QueryAdviceAsync(e.InhosID);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(advice.Body.QueryAdviceResult);
            List<Data.PatientAdvices> AdviceList = Entity.GetEntity<Data.PatientAdvices>(dicList);
            View.ExeShowAdviceList(AdviceList);
        }


        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
