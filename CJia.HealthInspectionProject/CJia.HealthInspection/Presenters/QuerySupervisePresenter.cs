using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QuerySupervisePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QuerySuperviseModel,Views.IQuerySupervise>
    {
        public QuerySupervisePresenter(Views.IQuerySupervise view)
            : base(view)
        {
            //view.OnInit += view_OnInit;
            view.OnSearch += view_OnSearch;
            view.OnDeleteUserId += view_OnDeleteUserId;
            view.OnDeletedUserArr += view_OnDeletedUserArr;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QuerySuperviseArgs e)
        {
            string organId = e.User.Rows[0]["organ_id"].ToString();
            View.ExeGridUser(Model.QueryUserBySearch(e.SearchKeyWords));
        }

        /// <summary>
        /// 删除单个用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteUserId(object sender, Views.QuerySuperviseArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Model.DeleteUserRoleByUserId(trans.ID, updateBy, e.DeletedUserId);
                Model.DeleteUserById(trans.ID, updateBy, e.DeletedUserId);
                trans.Complete();
            }
        }

        /// <summary>
        /// 删除所选择多个用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedUserArr(object sender, Views.QuerySuperviseArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            // 如果删除用户中包括最高权限 则不允许删除
            for (int i = 0; i < e.DeletedUserArr.Count; i++)
            {
                if (e.DeletedUserArr[i].ToString() == "1000000001")
                {
                    // 查询此超级管理员名称
                    string userName = Model.QueryUserNameById("1000000001");
                    View.ExeMessageBox("不能删除【"+userName+"】");
                    return;
                }
            }
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedUserArr.Count; i++)
                {
                    bool s = Model.DeleteUserById(trans.ID, updateBy, e.DeletedUserArr[i].ToString());
                }
                trans.Complete();
            }
        }
    }
}
