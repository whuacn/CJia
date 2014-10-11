using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IPatientCheckPageView : IView
    {
        event EventHandler<PatientCheckEventArgs> OnChangePatient;
    }

    public class PatientCheckEventArgs : EventArgs
    {
        public PatientCheckEventArgs(string inhosID)
        {
            InhosID = inhosID;
        }
        public string InhosID;
    }
}
