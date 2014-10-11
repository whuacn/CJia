using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Evaluation.Presenters.FrontStage
{
    public class HomePagePresenter:CJia.Evaluation.Tools.PresenterPage<Models.FrontStage.HomePageModel,Views.FrontStage.IHomePage>
    {
        public HomePagePresenter(Views.FrontStage.IHomePage view)
            : base(view)
        {
           view.OnInit+=view_OnInit;
        }

        private void view_OnInit(object sender, EventArgs e)
        {
            DataTable data = Model.GetTreeList();
            View.ExeBindTree(data);
        }
    }
}
