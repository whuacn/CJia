using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IDutyPatientListPageView : IView
    {
        event EventHandler<DutyPatientListEventArgs> OnShowDutyPatientList;

        event EventHandler OnQueryDutyIllfield;

        event EventHandler<DutyPatientListEventArgs> OnAddDutyPatientList;

        void ExeShowDutyPatientList(List<Data.Patient> PatientList);

        void ExeShowDutyIllfieldList(List<Data.DoctorIllfield> IllfieldList);

        void ExeGoBack();

        void ExeShowSyncProgress(int now, int max, string Hint);

        event EventHandler OnQueryLeavehosPatient;
    }

    public class DutyPatientListEventArgs : EventArgs
    {
        public DutyPatientListEventArgs(string illfieldID)
        {
            IllfieldID = illfieldID;
        }
        public string IllfieldID;
        public List<Data.Patient> SelectedPatient;
    }
}
