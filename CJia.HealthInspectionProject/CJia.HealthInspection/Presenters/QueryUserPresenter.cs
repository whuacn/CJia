using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryUserPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryUserModel,Views.IQueryUser>
    {
        public QueryUserPresenter(Views.IQueryUser view)
            : base(view)
        {
            view.OnSearch += view_OnSearch;
            view.OnDeleteUserId += view_OnDeleteUserId;
            view.OnDeletedUserArr += view_OnDeletedUserArr;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QueryUserArgs e)
        {
            string organId = e.User.Rows[0]["organ_id"].ToString();
            View.ExeGridUser(Model.QueryNormalUserBySearch(e.SearchKeyWords, organId));
        }

        /// <summary>
        /// 删除单个用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteUserId(object sender, Views.QueryUserArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Model.DeleteUserRoleByUserId(trans.ID,updateBy,e.DeletedUserId);
                Model.DeleteUserById(trans.ID,updateBy, e.DeletedUserId);
                trans.Complete();
            }
        }

        /// <summary>
        /// 删除所选择多个用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedUserArr(object sender, Views.QueryUserArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedUserArr.Count; i++)
                {
                    Model.DeleteUserRoleByUserId(trans.ID, updateBy, e.DeletedUserArr[i].ToString());
                    bool s = Model.DeleteUserById(trans.ID, updateBy, e.DeletedUserArr[i].ToString());
                }
                trans.Complete();
            }
        }
    }
}
