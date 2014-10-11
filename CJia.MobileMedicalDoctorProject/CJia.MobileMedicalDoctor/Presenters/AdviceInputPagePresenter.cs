using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class AdviceInputPagePresenter : Presenter<Models.AdviceInputModel, Views.IAdviceInputPageView>
    {
        Models.iCodeModel CodeModel = new Models.iCodeModel();
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
        public AdviceInputPagePresenter(Views.IAdviceInputPageView view)
            : base(view)
        {
            View.OnQueryAdvice += View_OnQueryAdvice;
            View.OnQueryUsage += View_OnQueryUsage;
            View.OnQueryFrequence += View_OnQueryFrequence;
            View.OnSaveAdvice += View_OnSaveAdvice;
        }

        void View_OnSaveAdvice(object sender, Views.AdviceInputEventArgs e)
        {
            string exMsg = "";
            bool Result = Model.SaveAdvice(e.ListNewAdvice, ref exMsg);
            View.ExeEndSaveAdvice(Result, exMsg);
        }

        #region 频率
        async void View_OnQueryFrequence(object sender, EventArgs e)
        {
            //List<Data.iFrequency> listFrequence = Model.QueryLocalFrequence();
            //View.ExeShowFrequence(listFrequence);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryFrequenceResponse frequence = await service.QueryFrequenceAsync();
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(frequence.Body.QueryFrequenceResult);
            List<Data.iFrequency> frequencyList = Entity.GetEntity<Data.iFrequency>(dicList);
            View.ExeShowFrequence(frequencyList);
        }
        #endregion

        #region 用法
        async void View_OnQueryUsage(object sender, EventArgs e)
        {
            //List<Data.iUsage> listUsage = Model.QueryLocalUsage();
            //View.ExeShowUsage(listUsage);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryUsageResponse usage = await service.QueryUsageAsync();
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(usage.Body.QueryUsageResult);
            List<Data.iUsage> usageList = Entity.GetEntity<Data.iUsage>(dicList);
            View.ExeShowUsage(usageList);
        }
        #endregion

        #region 查询医嘱
        async void View_OnQueryAdvice(object sender, Views.AdviceInputEventArgs e)
        {
            //List<Data.iAdvice> AdviceList = Model.QueryLocalAdvice(e.StandingFlag, e.AdviceTypeID, e.AdviceFilter);
            //View.ExeShowAdviceList(AdviceList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryAdviceByLikeResponse advice = await service.QueryAdviceByLikeAsync(e.AdviceTypeID, e.AdviceFilter, e.StandingFlag);
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(advice.Body.QueryAdviceByLikeResult);
            List<Data.iAdvice> adviceList = Entity.GetEntity<Data.iAdvice>(dicList);
            View.ExeShowAdviceList(adviceList);
        }
        #endregion

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
