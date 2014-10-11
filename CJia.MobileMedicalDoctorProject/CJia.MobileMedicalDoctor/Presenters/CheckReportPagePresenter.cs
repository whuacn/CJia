using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class CheckReportPagePresenter : Presenter<Models.CheckReportModel, Views.ICheckReportPageView>
    {
        Models.iCodeModel codeModel = new Models.iCodeModel();
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
        
        public CheckReportPagePresenter(Views.ICheckReportPageView view)
            : base(view)
        {
            View.OnQueryReportType += View_OnQueryReportType;
            View.OnQueryCheckReportResult += View_OnQueryCheckReportResult;
        }

        async void View_OnQueryCheckReportResult(object sender, Views.CheckReportPageEventArgs e)
        {
            //List<Data.CheckApply> ApplyList = Model.QueryLocalCheckApply(e.InhosID);
            //List<Data.CheckResult> ResultList = Model.QueryLocalCheckResult(e.InhosID);
            //View.ExeShowCheckReportResult(ApplyList, ResultList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryCheckApplyResponse checkApply = await service.QueryCheckApplyAsync(e.InhosID);
            List<Dictionary<string, string>> applyDicList = Entity.XmlToListDic(checkApply.Body.QueryCheckApplyResult);
            List<Data.CheckApply> ApplyList = Entity.GetEntity<Data.CheckApply>(applyDicList);
            
            CJia.iSmartMedical.MobileMedicDoctorService.QueryCheckResultResponse checkResult = await service.QueryCheckResultAsync(e.InhosID);
            List<Dictionary<string, string>> resultDicList = Entity.XmlToListDic(checkResult.Body.QueryCheckResultResult);
            List<Data.CheckResult> resultList = Entity.GetEntity<Data.CheckResult>(resultDicList);
            View.ExeShowCheckReportResult(ApplyList, resultList);
        }

        async void View_OnQueryReportType(object sender, EventArgs e)
        {
            //List<Data.iCode> ReportTypeList = codeModel.QueryLocalCodeListByGroup("检查化验报告");
            //View.ExeShowReportTypeList(ReportTypeList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryCodeListByGroupResponse codeListByGroup = await service.QueryCodeListByGroupAsync("检查化验报告");
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(codeListByGroup.Body.QueryCodeListByGroupResult);
            List<Data.iCode> codeList = Entity.GetEntity<Data.iCode>(dicList);
        }


        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
