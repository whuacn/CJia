using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class UnitSelectPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.UnitSelectModel, Views.IUnitSelect>
    {
        public UnitSelectPresenter(Views.IUnitSelect view)
            : base(view)
        {
            //view.OnGetAllUnit += view_OnGetAllUnit;
            view.OnSearch += view_OnSearch;
            view.OnDeleteUnitId += view_OnDeleteUnitId;
            view.OnDeletedUnitArr += view_OnDeletedUnitArr;
        }

        //void view_OnGetAllUnit(object sender, Views.UnitSelectEventArgs e)
        //{
        //    DataTable data = Model.GetAllUnit(e.User.Rows[0]["organ_id"].ToString());
        //    View.ExeBindAllUnit(data);
        //}
        
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.UnitSelectEventArgs e)
        {
            DataTable dt = Model.QueryUnitBySearch(e.SearchKeyWords,e.User.Rows[0]["organ_id"].ToString());
            View.ExeBindAllUnit(dt);
        }

        /// <summary>
        /// 删除单个单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeleteUnitId(object sender, Views.UnitSelectEventArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            Model.DeleteUnitById(updateBy,e.DeletedUnitId);
        }

        /// <summary>
        /// 删除所选单位组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDeletedUnitArr(object sender, Views.UnitSelectEventArgs e)
        {
            string updateBy = e.User.Rows[0]["user_id"].ToString();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                for (int i = 0; i < e.DeletedUnitArr.Count; i++)
                {
                    bool s = Model.DeleteUnitById(trans.ID, updateBy, e.DeletedUnitArr[i].ToString());
                }
                trans.Complete();
            }
        }
        
    }
}
