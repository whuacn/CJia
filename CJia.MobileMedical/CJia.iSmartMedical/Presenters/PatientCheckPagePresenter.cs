using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class PatientCheckPagePresenter : Presenter<Models.PatientCheckMode, Views.IPatientCheckPageView>
    {
        public PatientCheckPagePresenter(Views.IPatientCheckPageView view)
            : base(view)
        {
            View.OnChangePatient += View_OnChangePatient;
        }

        void View_OnChangePatient(object sender, Views.PatientCheckEventArgs e)
        {
            Model.SaveTodayCheckPatient(e.InhosID);
        }
        
        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
