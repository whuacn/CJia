using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class SelectOrganPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.SelectOrganModel,Views.ISelectOrgan>
    {
        public SelectOrganPresenter(Views.ISelectOrgan view)
            : base(view)
        {
            view.OnSearchOragn += view_OnSearchOragn;
            view.OnQueryOrganNameById += view_OnQueryOrganNameById;
        }

        /// <summary>
        /// 根据所输关键字查询组织
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearchOragn(object sender, Views.SelectOrganArgs e)
        {
            View.ExeGridOrgan(Model.QueryOrganBySearchKeyWord(e.SearchKeyWord));
        }

        /// <summary>
        /// 根据组织ID查询组织名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryOrganNameById(object sender, Views.SelectOrganArgs e)
        {
            e.SelectedOrganName = Model.QueryOrganNameById(e.SelectedOrganId);
        }
    }
}
