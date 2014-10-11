using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.Clinic.Pharm.Presenters
{
    public class MatchPharmPresenter:CJia.Presenter<Views.IMatchPharmView>
    {
        public Models.MatchPharmModel Model
        { get; private set; }

        public MatchPharmPresenter(Views.IMatchPharmView view)
            : base(view)
        {
            this.Model = new Models.MatchPharmModel();
        }

        protected override void OnViewSet()
        {

        }

    }
}