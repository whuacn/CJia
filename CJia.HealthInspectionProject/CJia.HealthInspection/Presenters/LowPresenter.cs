using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class LowPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.LowModel, Views.ILow>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public LowPresenter(Views.ILow view)
            : base(view)
        {
            view.OnInitTree += view_OnInitTree;
            view.OnTreeClick += view_OnTreeClick;

        }

        void view_OnInitTree(object sender, Views.LowArgs e)
        {
            DataTable data = Model.GetLowTreeData();
            View.ExeBindTree(data);
        }

        void view_OnTreeClick(object sender, Views.LowArgs e)
        {
            DataTable dtResult = Model.SelectLowFileById(e.LowFileId);
            View.ExeShowLowPage(dtResult);
        }
    }
}
