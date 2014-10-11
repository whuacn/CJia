using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryRolePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryRoleModel,Views.IQueryRole>
    {
        public QueryRolePresenter(Views.IQueryRole view)
            : base(view)
        {
            view.OnSearch += view_OnSearch;
            view.OnDeleteRole += view_OnDeleteRole;
            view.OnDeleteRoleArr += view_OnDeleteRoleArr;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QueryRoleArgs e)
        {
            string organId = e.User.Rows[0]["organ_id"].ToString();
            View.ExeGridRole(Model.QueryRoleByOrganAndSearch(e.SearchKeyWords,organId));
        }

        /// <summary>
        /// 删除单个角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteRole(object sender, Views.QueryRoleArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Model.DeleteRoleFunctionByRoleId(trans.ID,updateBy,e.DeleteRoleId);
                Model.DeleteRoleById(trans.ID,updateBy,e.DeleteRoleId);
                trans.Complete();
            }
        }

        /// <summary>
        /// 删除所勾选多个角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteRoleArr(object sender, Views.QueryRoleArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeleteRoleIdArr.Count; i++)
                {
                    Model.DeleteRoleFunctionByRoleId(trans.ID,updateBy,e.DeleteRoleIdArr[i].ToString());
                    Model.DeleteRoleById(trans.ID, updateBy, e.DeleteRoleIdArr[i].ToString());
                }
                trans.Complete();
            }
        }
    }
}
