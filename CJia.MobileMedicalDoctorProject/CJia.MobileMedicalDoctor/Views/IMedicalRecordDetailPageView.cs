using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface IMedicalRecordDetailPageView : IView
    {
        event EventHandler<IMedicalRecordDetailEventArgs> OnQueryMedicalRecordDetail;

        void ExeShowMedicalRecordDetail(Data.PatientEmrDoc DocContent);
    }

    public class IMedicalRecordDetailEventArgs : EventArgs
    {
        public IMedicalRecordDetailEventArgs()
        {

        }
        public string InhosID;
        public string SectionNo;
    }
}
