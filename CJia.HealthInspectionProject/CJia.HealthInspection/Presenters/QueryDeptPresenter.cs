using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryDeptPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryDeptModel,Views.IQueryDept>
    {
        public QueryDeptPresenter(Views.IQueryDept view)
            : base(view)
        {
            view.OnSearch += view_OnSearch;
            view.OnDeleteDeptById += view_OnDeleteDeptById;
            view.OnDeletedDeptArr += view_OnDeletedDeptArr;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QueryDeptArgs e)
        {
            DataTable dt = Model.QueryDeptBySearch(e.SearchKeyWords, e.User.Rows[0]["organ_id"].ToString());
            View.ExeGridDept(dt);
        }

        /// <summary>
        /// 删除单个部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteDeptById(object sender, Views.QueryDeptArgs e)
        {
            if (Model.DeleteDeptById(e.User.Rows[0]["user_id"].ToString(), e.DeletedDeptId))
            {
                string a = "";
            }
        }

        /// <summary>
        ///  删除所选择多个组织
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedDeptArr(object sender, Views.QueryDeptArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedDeptArr.Count; i++)
                {
                    bool s = Model.DeleteDeptById(trans.ID, updateBy, e.DeletedDeptArr[i].ToString());
                }
                trans.Complete();
            }
        }

    }
}
