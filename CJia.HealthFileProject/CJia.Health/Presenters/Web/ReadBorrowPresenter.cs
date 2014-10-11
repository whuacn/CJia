using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class ReadBorrowPresenter : CJia.Health.Tools.PresenterPage<Models.Web.ReadBorrowModel, Views.Web.IReadBorrowView>
    {
        public ReadBorrowPresenter(Views.Web.IReadBorrowView view)
            : base(view)
        {
            view.OnLoadBorrow += view_OnLoadBorrow;
        }

        void view_OnLoadBorrow(object sender, Views.Web.ReadBorrowArgs e)
        {
            DataTable data = Model.GetMyBorrow(e.UserData.Rows[0]["USER_ID"].ToString());
            View.ExeBindBorrow(data);
        }
    }
}
