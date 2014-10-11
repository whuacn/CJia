using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface IAdviceListPageView : IView
    {
        event EventHandler<AdviceEventArgs> OnQueryPatientAdvices;

        event EventHandler<AdviceEventArgs> OnQueryAdviceTypeList;

        void ExeShowAdviceList(List<Data.PatientAdvices> AdviceList);

        void ExeShowAdviceTypeList(List<Data.AdviceTypeGroup> AdviceTypeList);
    }

    public class AdviceEventArgs : EventArgs
    {
        public AdviceEventArgs(string inhosID)
        {
            InhosID = inhosID;
        }
        public string StandingFlag;
        public string InhosID;
    }
}
