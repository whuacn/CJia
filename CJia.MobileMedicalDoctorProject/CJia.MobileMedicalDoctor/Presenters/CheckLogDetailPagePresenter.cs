using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class CheckLogDetailPagePresenter : Presenter<Models.DoctorCheckModel, Views.ICheckLogDetailPageView>
    {
        public CheckLogDetailPagePresenter(Views.ICheckLogDetailPageView view)
            : base(view)
        {
            View.OnSaveCheckLog += View_OnSaveCheckLog;
            View.OnDeleteCheckLog += View_OnDeleteCheckLog;
            View.OnQueryCheckLog += View_OnQueryCheckLog;
        }
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient Service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();

        void View_OnDeleteCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            Model.DeleteCheckLog(e.CheckLog);
            View.ExeDeleteCheckLog(e.CheckLog);
        }

        void View_OnSaveCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            if (e.CheckLog == null) return;
            Model.SaveCheckLogToLocal(e.CheckLog);
        }

        void View_OnQueryCheckLog(object sender, Views.CheckLogDetailEventArgs e)
        {
            QueryCheckLog(e.InhosID);
        }

        async void QueryCheckLog(string InhosID)
        {
            //List<Data.DoctorCheckLog> LogList = Model.QueryLocalPatientCheckLog(InhosID);
            //View.ExeShowCheckLogList(LogList);

            CJia.iSmartMedical.MobileMedicDoctorService.QueryCheckLogDetailResponse checkLog = await Service.QueryCheckLogDetailAsync(InhosID, "日志");
            List<Dictionary<string, string>> dicList = Entity.XmlToListDic(checkLog.Body.QueryCheckLogDetailResult);
            List<Data.DoctorCheckLog> LogList = Entity.GetEntity<Data.DoctorCheckLog>(dicList);
            View.ExeShowCheckLogList(LogList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
