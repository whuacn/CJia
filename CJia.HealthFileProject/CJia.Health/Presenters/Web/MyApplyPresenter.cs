using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class MyApplyPresenter:CJia.Health.Tools.PresenterPage<Models.Web.MyApplyModel,Views.Web.IMyApplyView>
    {
        public MyApplyPresenter(Views.Web.IMyApplyView view)
            : base(view)
        {
            view.OnLoadMyApply += view_OnLoadMyApply;
            view.OnDetail += view_OnDetail;
            view.OnUndo += view_OnUndo;
        }

        void view_OnUndo(object sender, Views.Web.MyApplyArgs e)
        {
            Model.ModfiyBorrowList(e.ListID, e.UserData.Rows[0]["USER_ID"].ToString());
        }

        void view_OnDetail(object sender, Views.Web.MyApplyArgs e)
        {
            DataTable data = Model.GetMyApplyDetail(e.ListID);
            View.ExeBindApplyDetail(data);
        }

        void view_OnLoadMyApply(object sender, Views.Web.MyApplyArgs e)
        {
            DataTable data = Model.GetMyApplyList(e.UserData.Rows[0]["USER_ID"].ToString());
            View.ExeBindInit(data);
        }
    }
}
