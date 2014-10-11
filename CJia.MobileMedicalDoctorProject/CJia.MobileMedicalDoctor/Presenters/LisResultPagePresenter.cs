using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class LisResultPagePresenter : Presenter<Models.LisResultMode, Views.ILisResultPageView>
    {
        public LisResultPagePresenter(Views.ILisResultPageView view)
            : base(view)
        {
            View.OnQueryLisResult += View_OnQueryLisResult;
        }

        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        async void View_OnQueryLisResult(object sender, Views.LisResultEventArgs e)
        {
            //List<Data.LisResult> ResultList = Model.QueryLocalLisResult(e.IllcaseNo);
            //View.ExeShowLisResult(ResultList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryLisResultResponse lisResult = await service.QueryLisResultAsync(e.IllcaseNo);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(lisResult.Body.QueryLisResultResult);
            List<Data.LisResult> lisResultList = Entity.GetEntity<Data.LisResult>(dicList);
            View.ExeShowLisResult(lisResultList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
