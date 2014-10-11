using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface ICheckLogDetailPageView : IView
    {
        event EventHandler<CheckLogDetailEventArgs> OnSaveCheckLog;

        event EventHandler<CheckLogDetailEventArgs> OnDeleteCheckLog;

        void ExeDeleteCheckLog(Data.DoctorCheckLog CheckLog);

        event EventHandler<CheckLogDetailEventArgs> OnQueryCheckLog;

        void ExeShowCheckLogList(List<Data.DoctorCheckLog> LogList);
    }

    public class CheckLogDetailEventArgs : EventArgs
    {
        public Data.DoctorCheckLog CheckLog;
        public string InhosID;
        public CheckLogDetailEventArgs()
        {

        }
        public CheckLogDetailEventArgs(string inhosID)
        {
            InhosID = inhosID;
        }

        public CheckLogDetailEventArgs(string inhosID, Data.DoctorCheckLog checkLog)
        {
            InhosID = inhosID;
            CheckLog = checkLog;
        }
    }
}
