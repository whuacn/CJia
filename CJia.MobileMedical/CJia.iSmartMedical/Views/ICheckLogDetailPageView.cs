using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface ICheckLogDetailPageView : IView
    {
        event EventHandler<CheckLogDetailEventArgs> OnSaveCheckLog;

        void ExeSaveSuccess();

        event EventHandler<CheckLogDetailEventArgs> OnDeleteCheckLog;

        void ExeDeleteCheckLog(Data.DoctorCheckLog CheckLog);

        event EventHandler<CheckLogDetailEventArgs> OnQueryCheckLog;

        void ExeShowCheckLogList(List<Data.DoctorCheckLog> LogList);

        event EventHandler<CheckLogDetailEventArgs> OnUpdateCheckLog;

        void ExeUpdateCheckLog(Data.DoctorCheckLog CheckLog);
    }

    public class CheckLogDetailEventArgs : EventArgs
    {
        public Data.DoctorCheckLog CheckLog;
        public string InhosID;
        public string DCLID;
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
