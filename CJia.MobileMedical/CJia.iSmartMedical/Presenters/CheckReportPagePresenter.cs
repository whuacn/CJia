using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class CheckReportPagePresenter : Presenter<Models.CheckReportModel, Views.ICheckReportPageView>
    {
        Models.iCodeModel codeModel = new Models.iCodeModel();
        public CheckReportPagePresenter(Views.ICheckReportPageView view)
            : base(view)
        {
            View.OnQueryReportType += View_OnQueryReportType;
            View.OnQueryCheckReportResult += View_OnQueryCheckReportResult;
        }

        void View_OnQueryCheckReportResult(object sender, Views.CheckReportPageEventArgs e)
        {
            List<Data.CheckApply> ApplyList = Model.QueryLocalCheckApply(e.InhosID);
            List<Data.CheckResult> ResultList = Model.QueryLocalCheckResult(e.InhosID);
            View.ExeShowCheckReportResult(ApplyList, ResultList);
        }

        void View_OnQueryReportType(object sender, EventArgs e)
        {
            QueryReportType("检查化验报告");
        }

        async void QueryReportType(string Group)
        {
            List<Data.iCode> ReportTypeList = codeModel.QueryLocalCodeListByGroup(Group);

            View.ExeShowReportTypeList(ReportTypeList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
