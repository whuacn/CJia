using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 冲药查询Presenter层
    /// </summary>
    public class PharmSendSelectPresenter:Tools.Presenter<Models.PharmSendSelectModel, Views.IPharmSendSelectView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public PharmSendSelectPresenter(Views.IPharmSendSelectView view)
            : base(view)
        {
            view.OnRefresh += view_OnRefresh;
            View.OnGridClick += View_OnGridClick;
            view.OnPrint += view_OnPrint;
        }

        void view_OnPrint(object sender, Views.PharmSendSelectArgs e)
        {
            if (e.isChecked) 
            {
                DataTable data = Model.GetLabelCollectByPharmTime(e.PharmSendTime);
                View.ExeBindCollectReport(data); return;
            }
            DataTable data1 = Model.GetLabelAndCheckByPharmTime(e.PharmSendTime);
            View.ExeBindReport(data1);
        }

        void View_OnGridClick(object sender, Views.PharmSendSelectArgs e)
        {
            DataTable data1 = Model.GetLableDetailByPharmSendNO(e.PharmSendNO);
            DataTable data2 = Model.GetLableStatByPharmSendNO(e.PharmSendNO);
            View.ExeBindLabel(data1,data2);
        }

        void view_OnRefresh(object sender, Views.PharmSendSelectArgs e)
        {
            DataTable data = Model.GetPharmSendNOByTime(e.PharmSendTime);
            View.ExeBindPharmSendNO(data);
        }

    }
}
