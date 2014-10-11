using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IMedicalRecordPageView : IView
    {
        event EventHandler<MedicalRecordEventArgs> OnQueryMedicalRecord;

        void ExeShowMedicalRecordList(List<Data.PatientEmrDoc> DocList);
    }

    public class MedicalRecordEventArgs : EventArgs
    {
        public MedicalRecordEventArgs(string inhosID)
        {
            InhosID = inhosID;
        }
        public string InhosID;
    }
}
