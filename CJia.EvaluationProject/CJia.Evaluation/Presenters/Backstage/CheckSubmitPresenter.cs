using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class CheckSubmitPresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.CheckSubmitModel, Views.Backstage.ICheckSubmit>
    {
        public CheckSubmitPresenter(Views.Backstage.ICheckSubmit view)
            : base(view)
        {
            view.OnInitPage += view_OnInitPage;
            view.OnIndexChange += view_OnIndexChange;
            view.OnSubmit += view_OnSubmit;
            view.OnReadDetail += view_OnReadDetail;
            view.OnSaveCheck += view_OnSaveCheck;
        }

        void view_OnSaveCheck(object sender, Views.Backstage.CheckSubmit e)
        {
            bool bol = Model.ModifyCheck(e.CheckID, e.CheckStateID, e.CheckResultID, e.CheckAdvice, e.ZhengGaiAdvice, e.EndDate, e.CheckDate, e.UserID, e.UserName);
            View.ExeBindIsSuccessCheck(bol);
        }

        void view_OnReadDetail(object sender, Views.Backstage.CheckSubmit e)
        {
            DataTable data = Model.GetCheckDataByID(e.CheckID);
            View.ExeBindCheckDetail(data);
        }

        void view_OnSubmit(object sender, Views.Backstage.CheckSubmit e)
        {
            if (e.TreeIDs.Length > 0)
            {
                bool isSuccess = true;
                foreach (string str in e.TreeIDs)
                {
                    isSuccess = Model.ModifyCheckState(str, "1202", e.UserID);
                    if (!isSuccess) break;
                }
                View.ExeBindIsSuccessSubmit(isSuccess);
            }
        }

        void view_OnIndexChange(object sender, Views.Backstage.CheckSubmit e)
        {
            DataTable data = Model.GetCheckData(e.CheckStateID);
            View.ExeBindCheckData(data);
        }

        void view_OnInitPage(object sender, EventArgs e)
        {
            DataTable statedata = Model.GetCheckState();
            DataTable resultdata = Model.GetCheckResult();
            View.ExeBindPage(statedata, resultdata);
        }
    }
}
