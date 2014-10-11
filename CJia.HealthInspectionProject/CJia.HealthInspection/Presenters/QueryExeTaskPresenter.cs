using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class QueryExeTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.QueryExeTaskModel,Views.IQueryExeTask>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public QueryExeTaskPresenter(Views.IQueryExeTask view)
            : base(view)
        {
            view.OnQueryExeTaskByKeyWord += view_OnQueryExeTaskByKeyWord;
        }

        void view_OnQueryExeTaskByKeyWord(object sender, Views.QueryExeTaskArgs e)
        {
            DataTable dtExeTask = Model.QueryExeTaskByKeyWord(e.OrganId, e.keyWord);
            View.ExeBindExeTask(dtExeTask);
        }
    }
}
