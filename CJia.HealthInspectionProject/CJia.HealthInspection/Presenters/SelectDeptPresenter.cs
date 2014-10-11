using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class SelectDeptPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.SelectDeptModel,Views.ISelectDept>
    {
        public SelectDeptPresenter(Views.ISelectDept view)
            : base(view)
        {
            view.OnInit +=view_OnInit;
            view.OnSearchDept += view_OnSearchDept;
            view.OnQueryDeptNameById += view_OnQueryDeptNameById;
        }

        /// <summary>
        /// 根据部门ID查询部门名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryDeptNameById(object sender, Views.SelectDeptArgs e)
        {
            if (e.SelectedDeptId != "")
            {
                e.SelectedDeptName = Model.QueryDeptNameById(e.SelectedDeptId);
            }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.SelectDeptArgs e)
        {
            string userOrganId = e.User.Rows[0]["organ_id"].ToString();
            View.ExeGridDept(Model.QueryAllDept(userOrganId));
        }

        /// <summary>
        /// 查询部门事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearchDept(object sender, Views.SelectDeptArgs e)
        {
            string userOrganId = e.User.Rows[0]["organ_id"].ToString();
            View.ExeGridDept(Model.QueryDeptBySearchKeyWord(e.SearchKey,userOrganId));
        }
    }
}
