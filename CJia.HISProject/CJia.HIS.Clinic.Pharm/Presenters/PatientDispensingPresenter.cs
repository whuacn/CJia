using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.Clinic.Pharm.Presenters
{
    public class PatientDispensingPresenter:CJia.Presenter<Views.IPatientDispensingView>
    {
        public Models.PatientDispensingModel Model
        { get; private set; }

        public PatientDispensingPresenter(Views.IPatientDispensingView view)
            : base(view)
        {
            this.Model = new Models.PatientDispensingModel();
        }

        protected override void OnViewSet()
        {

        }

    }
}