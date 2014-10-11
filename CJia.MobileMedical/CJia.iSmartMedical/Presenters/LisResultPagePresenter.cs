using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class LisResultPagePresenter : Presenter<Models.LisResultMode, Views.ILisResultPageView>
    {
        public LisResultPagePresenter(Views.ILisResultPageView view)
            : base(view)
        {
            View.OnQueryLisResult += View_OnQueryLisResult;
        }

        void View_OnQueryLisResult(object sender, Views.LisResultEventArgs e)
        {
            QueryListResult(e.IllcaseNo);
        }

        void QueryListResult(string IllcaseNo)
        {
            List<Data.LisResult> ResultList = Model.QueryLocalLisResult(IllcaseNo);

            View.ExeShowLisResult(ResultList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
