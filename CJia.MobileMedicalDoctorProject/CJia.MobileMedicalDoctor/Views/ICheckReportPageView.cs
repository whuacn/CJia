using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface ICheckReportPageView : IView
    {
        event EventHandler OnQueryReportType;

        event EventHandler<CheckReportPageEventArgs> OnQueryCheckReportResult;

        void ExeShowReportTypeList(List<Data.iCode> ReportTypeList);

        void ExeShowCheckReportResult(List<Data.CheckApply> ApplyList,List<Data.CheckResult> ResultList);
    }

    public class CheckReportPageEventArgs : EventArgs
    {
        public CheckReportPageEventArgs(string inhosID)
        {
            InhosID = inhosID;
        }
        public string InhosID;
    }
}
