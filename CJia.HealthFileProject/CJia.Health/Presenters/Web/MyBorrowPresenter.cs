using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class MyBorrowPresenter : CJia.Health.Tools.PresenterPage<Models.Web.MyBorrowModel, Views.Web.IMyBorrowView>
    {
        public MyBorrowPresenter(Views.Web.IMyBorrowView view)
            : base(view)
        {
            view.OnLoadBorrow += view_OnLoadBorrow;
            view.OnDetail += view_OnDetail;
        }

        void view_OnDetail(object sender, Views.Web.MyBorrowArgs e)
        {
            DataTable data = Model.GetMyBorrowDetail(e.ListID);
            View.ExeDetail(data);
        }

        void view_OnLoadBorrow(object sender, Views.Web.MyBorrowArgs e)
        {
            DataTable data = Model.GetMyBorrowList(e.UserData.Rows[0]["USER_ID"].ToString());
            View.ExeInit(data);
        }
    }
}
