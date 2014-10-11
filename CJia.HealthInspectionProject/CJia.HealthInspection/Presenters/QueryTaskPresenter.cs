using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryTaskModel,Views.IQueryTask>
    {
        public QueryTaskPresenter(Views.IQueryTask view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSearch += view_OnSearch;
            view.OnDeleteTaskId += view_OnDeleteTask;
            view.OnDeletedTaskArr += view_OnDeletedTaskArr;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.QueryTaskArgs e)
        {
            BindDropTaskType();
            BindGridTask(e);
        }

        #region【自定义方法】
        /// <summary>
        /// 绑定任务Grid
        /// </summary>
        void BindGridTask(Views.QueryTaskArgs e)
        {
            View.ExeGridTask(Model.QueryTaskByOrganId(e.User.Rows[0]["organ_id"].ToString()));
        }

        void BindDropTaskType()
        {
            View.ExeDropTaskType(Model.QueryTaskType());
        }
        #endregion

        /// <summary>
        /// 查询任务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.QueryTaskArgs e)
        {
            View.ExeGridTask(Model.QueryTaskBySearch(e.SelectedTaskTypeId, e.SearchKeyWord, e.User.Rows[0]["organ_id"].ToString()));
        }

        /// <summary>
        /// 删除所选任务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteTask(object sender, Views.QueryTaskArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            Model.DeleteTaskById(updateBy,e.DeleteTaskId);
        }

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedTaskArr(object sender, Views.QueryTaskArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedTaskArr.Count; i++)
                {
                    bool s = Model.DeleteTaskById(trans.ID,updateBy,e.DeletedTaskArr[i].ToString());
                }
                trans.Complete();
            }
        }
    }
}
