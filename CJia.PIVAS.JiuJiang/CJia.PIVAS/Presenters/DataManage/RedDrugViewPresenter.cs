using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 书剑维护的P层
    /// </summary>
    public class RedDrugViewPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.RedDrugModel, CJia.PIVAS.Views.DataManage.IRedDrugView>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="view"></param>
        public RedDrugViewPresenter(Views.DataManage.IRedDrugView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnDeleteTimeSet += View_OnDeleteTimeSet;
        }

        /// <summary>
        /// 初始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLoadData(object sender, Views.DataManage.RedDrugEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.GetRedDrug(e.Whichpage.ToString());
            this.View.ExeInitData(dt);
            //if (dt != null && dt.Rows != null && dt.Rows.Count != 0)
            //{
            //    this.View.ExeInitData(dt);
            //}
            
        }

        /// <summary>
        /// 删除时间维护数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeleteTimeSet(object sender, Views.DataManage.RedDrugEventArgs e)
        {
            bool IsDelete = this.Model.DeleteTimeSet(e.UserId,e.TimeId);
            if (IsDelete)
            {
                //this.View.ShowMessage("删除成功");
            }
            else
            {
                this.View.ShowMessage("删除失败");
            }
        }

        /// <summary>
        /// 重写OnInitView()
        /// </summary>
        protected override void OnInitView()
        {
            
        }
    }
}