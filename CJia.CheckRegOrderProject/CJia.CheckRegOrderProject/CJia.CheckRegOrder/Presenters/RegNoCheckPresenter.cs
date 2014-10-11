using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class RegNoCheckPresenter : CJia.Presenter<Views.IRegNoCheckView>
    {
        private Models.RegNoCheckModel Model
        {
            get;
            set;
        }
        public RegNoCheckPresenter(Views.IRegNoCheckView view)
            : base(view)
        {
            Model = new Models.RegNoCheckModel();
        }
        protected override void OnViewSet()
        {
            View.Load += View_Load;
            View.OnDelete += View_OnDelete;
        }

        void View_OnDelete(object sender, Views.RegNoCheckArgs e)
        {
            if (Model.DeleteRegNoCheckPatient(e.PatientID))
            {
                View_Load(null, null);
            }
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetRegNoCheckPatient();
            View.ExeBindRegNoCheckPatient(data);
        }
    }
}
