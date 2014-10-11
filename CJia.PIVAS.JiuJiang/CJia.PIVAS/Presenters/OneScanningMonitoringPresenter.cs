using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    public class OneScanningMonitoringPresenter : Tools.Presenter<Models.OneScanningMonitoringModel, Views.IOneScanningMonitoringView>
    {
        public OneScanningMonitoringPresenter(Views.IOneScanningMonitoringView view)
            : base(view)
        {
            this.View.OnOutLogin += View_OnOutLogin;
            this.View.OnInit += View_OnInit;
        }

        void View_OnInit(object sender, Views.OneScanningMonitoringEventArgs e)
        {
            DataTable result = this.Model.SelectLogin(e.no);
            this.View.ExeInit(result);
        }

        void View_OnOutLogin(object sender, Views.OneScanningMonitoringEventArgs e)
        {
            this.Model.OutLogin(e.userId, e.no);
        }

    
    }
}
