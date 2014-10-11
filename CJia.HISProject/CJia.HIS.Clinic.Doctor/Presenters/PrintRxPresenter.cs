using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.Clinic.Pharm.Presenters
{
    public class PrintRxPresenter:CJia.Presenter<Views.IPrintRxView>
    {
        public Models.PrintRxModel Model
        { get; private set; }

        public PrintRxPresenter(Views.IPrintRxView view)
            : base(view)
        {
            this.Model = new Models.PrintRxModel();
        }

        protected override void OnViewSet()
        {

        }

    }
}