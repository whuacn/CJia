using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    public class ErrorPresenter : Tools.Presenter<Models.ErrorModel, Views.IError>
    {
        public ErrorPresenter(Views.IError view)
            : base(view)
        {
            view.OnInitPage += view_OnInitPage;
        }

        void view_OnInitPage(object sender, EventArgs e)
        {
            DataTable data = Model.QueryError();
            View.ExeBindData(data);
        }
    }
}
