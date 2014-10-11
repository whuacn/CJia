using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Presenters
{
    public class ReportPresenter : CJia.Presenter<Views.IReportView>
    {
        private Models.ReportModel Model
        {
            get;
            set;
        }
        public ReportPresenter(Views.IReportView view)
            : base(view)
        {
            Model = new Models.ReportModel();
        }
        protected override void OnViewSet()
        {
            View.Load += View_Load;
            View.OnSelect += View_OnSelect;
            View.OnPrint += View_OnPrint;
        }

        void View_OnPrint(object sender, Views.ReportArgs e)
        {
            Model.ModifyReportByID(e.ReportID);
        }

        void View_OnSelect(object sender, Views.ReportArgs e)
        {
            DataTable data = Model.GetReportByName(e.PatientName);
            if (data != null && data.Rows.Count > 0)
            {
                View.BindReport(data);
            }
            else
            {
                Message.Show("无此病人检查报告");
                View.TxtPatientNameFocus();
            }
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetNowAllReport();
            View.BindReport(data);
        }
    }
}
