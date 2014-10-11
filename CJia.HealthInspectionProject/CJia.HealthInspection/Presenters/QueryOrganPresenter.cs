using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryOrganPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryOrganModel,Views.IQueryOrgan>
    {
        public QueryOrganPresenter(Views.IQueryOrgan view)
            : base(view)
        {
            view.OnSearch += view_OnSearch;
            view.OnDeleteOrganId += view_OnDeleteOrganId;
            view.OnDeletedOrganArr += view_OnDeletedOrganArr;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QueryOrganArgs e)
        {
            View.ExeGridOrgan(Model.QueryOrganBySearch(e.SearchKeyWords));
        }

        /// <summary>
        /// 删除单个组织事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteOrganId(object sender, Views.QueryOrganArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            Model.DeleteOrganById(updateBy,e.DeletedOrganId);
        }

        /// <summary>
        /// 删除多个组织事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedOrganArr(object sender, Views.QueryOrganArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedOrganArr.Count; i++)
                {
                    bool s = Model.DeleteOrganById(trans.ID, updateBy, e.DeletedOrganArr[i].ToString());
                }
                trans.Complete();
            }
        }
    }
}
