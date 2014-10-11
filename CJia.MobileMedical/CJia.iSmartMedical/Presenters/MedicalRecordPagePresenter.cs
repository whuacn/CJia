using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class MedicalRecordPagePresenter : Presenter<Models.MedicalRecordModel, Views.IMedicalRecordPageView>
    {
        public MedicalRecordPagePresenter(Views.IMedicalRecordPageView view)
            : base(view)
        {
            View.OnQueryMedicalRecord += View_OnQueryMedicalRecord;
        }

        void View_OnQueryMedicalRecord(object sender, Views.MedicalRecordEventArgs e)
        {
            QueryPatientEmrDoc(e.InhosID);
        }

        void QueryPatientEmrDoc(string InhosID)
        {
            List<Data.PatientEmrDoc> DocList = Model.QueryLocalEmrDocHeader(InhosID);
            
            View.ExeShowMedicalRecordList(DocList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
