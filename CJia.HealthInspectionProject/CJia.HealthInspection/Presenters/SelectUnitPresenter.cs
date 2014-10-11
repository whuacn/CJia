using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class SelectUnitPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.SelectUnitModel, Views.ISelectUnit>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public SelectUnitPresenter(Views.ISelectUnit view)
            : base(view)
        {
            View.OnQueryUnitByKew += View_OnQueryUnitByKew;
            View.OnQueryUnitById += View_OnQueryUnitById;
        }

        void View_OnQueryUnitByKew(object sender, Views.SelectUnitArgs e)
        {
            DataTable dtUnit = Model.QueryUnitByKew(e.KeyWord, e.Organ_id);
            View.ExeBindGrid(dtUnit);
        }

        void View_OnQueryUnitById(object sender, Views.SelectUnitArgs e)
        {
            DataTable dtUnint = Model.QueryUnitById(e.UnitId);
            if (dtUnint != null)
            {
                View.ExeGetUnitInfo(dtUnint);
            }
            else
            {
                ExtAspNet.Alert.Show("无数据");
            }
        }
    }
}
