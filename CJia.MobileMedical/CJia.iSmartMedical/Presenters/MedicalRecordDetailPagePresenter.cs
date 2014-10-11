using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class MedicalRecordDetailPagePresenter : Presenter<Models.MedicalRecordModel, Views.IMedicalRecordDetailPageView>
    {
        public MedicalRecordDetailPagePresenter(Views.IMedicalRecordDetailPageView view)
            : base(view)
        {
            View.OnQueryMedicalRecordDetail += View_OnQueryMedicalRecordDetail;
        }

        void View_OnQueryMedicalRecordDetail(object sender, Views.IMedicalRecordDetailEventArgs e)
        {
            QueryPatientEmrDocDetail(e.InhosID, e.SectionNo);
        }

        void QueryPatientEmrDocDetail(string InhosID,string SectionNo)
        {
            Data.PatientEmrDoc Doc = Model.QueryPatientEmrDocDetail(InhosID, SectionNo);
            View.ExeShowMedicalRecordDetail(Doc);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
