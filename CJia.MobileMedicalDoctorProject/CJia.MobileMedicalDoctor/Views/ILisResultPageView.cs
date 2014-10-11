using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface ILisResultPageView : IView
    {
        event EventHandler<LisResultEventArgs> OnQueryLisResult;

        void ExeShowLisResult(List<Data.LisResult> ResultList);
    }

    public class LisResultEventArgs : EventArgs
    {
        public LisResultEventArgs(string illcaseNo)
        {
            IllcaseNo = illcaseNo;
        }
        public string IllcaseNo;
        public string SampleNo;
        public string TestDate;
    }
}
