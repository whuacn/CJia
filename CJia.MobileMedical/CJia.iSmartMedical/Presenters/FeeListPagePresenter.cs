using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class FeeListPagePresenter : Presenter<Models.FeeListMode, Views.IFeeListPageView>
    {
        public FeeListPagePresenter(Views.IFeeListPageView view)
            : base(view)
        {
            View.OnShowPatientFee += View_OnShowPatientFee;
        }

        void View_OnShowPatientFee(object sender, Views.FeeListEventArgs e)
        {
            QueryPatientFee(e.InhosID);
        }

        void QueryPatientFee(string InhosID)
        {
            List<Data.PatientFee> FeeList = Model.QueryLocalFee(InhosID);
            
            List<Data.PatientPrepay> PrepayList = Model.QueryLocalPrepay(InhosID);
            
            View.ExeShowPatientFee(FeeList, PrepayList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
