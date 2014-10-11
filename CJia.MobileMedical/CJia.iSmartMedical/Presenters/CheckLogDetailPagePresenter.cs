using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class CheckLogDetailPagePresenter : Presenter<Models.DoctorCheckModel, Views.ICheckLogDetailPageView>
    {
        public CheckLogDetailPagePresenter(Views.ICheckLogDetailPageView view)
            : base(view)
        {
            View.OnSaveCheckLog += View_OnSaveCheckLog;
            View.OnDeleteCheckLog += View_OnDeleteCheckLog;
            View.OnQueryCheckLog += View_OnQueryCheckLog;
            View.OnUpdateCheckLog += View_OnUpdateCheckLog;
        }

        void View_OnUpdateCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            Data.DoctorCheckLog CheckLog = Model.QueryLocalCheckLog(e.DCLID);
            if (CheckLog != null)
            {
                View.ExeUpdateCheckLog(CheckLog);
            }
        }

        void View_OnDeleteCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            Model.DeleteCheckLog(e.CheckLog);
            View.ExeDeleteCheckLog(e.CheckLog);
        }

        void View_OnSaveCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            if (e.CheckLog == null) return;
            Model.SaveCheckLogToLocal(e.CheckLog);
            View.ExeSaveSuccess();
        }

        void View_OnQueryCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            QueryCheckLog(e.InhosID);
        }

        void QueryCheckLog(string InhosID)
        {
            List<Data.DoctorCheckLog> LogList = Model.QueryLocalPatientCheckLog(InhosID);
 
            View.ExeShowCheckLogList(LogList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
