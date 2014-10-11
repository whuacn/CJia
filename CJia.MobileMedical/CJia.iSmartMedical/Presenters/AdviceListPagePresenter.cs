using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class AdviceListPagePresenter : Presenter<Models.AdviceModel, Views.IAdviceListPageView>
    {
        public AdviceListPagePresenter(Views.IAdviceListPageView view)
            : base(view)
        {
            View.OnQueryPatientAdvices += View_OnQueryPatientAdvices;
            View.OnQueryAdviceTypeList += View_OnQueryAdviceTypeList;
        }

        void View_OnQueryAdviceTypeList(object sender, Views.AdviceEventArgs e)
        {
            List<Data.AdviceTypeGroup> AdviceTypeList = Model.QueryPatientAdvicesTypeList(e.InhosID,e.StandingFlag);
            View.ExeShowAdviceTypeList(AdviceTypeList);
        }

        void View_OnQueryPatientAdvices(object sender, Views.AdviceEventArgs e)
        {
            QueryPatientAdvices(e.InhosID);
        }

        void QueryPatientAdvices(string InhosID)
        {
            List<Data.PatientAdvices> AdviceList = Model.QueryLocalPatientAdvices(InhosID);            
            View.ExeShowAdviceList(AdviceList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
