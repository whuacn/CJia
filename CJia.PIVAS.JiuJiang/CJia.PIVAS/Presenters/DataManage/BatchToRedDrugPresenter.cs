using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 批次对应冲药的P层
    /// </summary>
    public class BatchToRedDrugPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.BatchToRedDrugModel, CJia.PIVAS.Views.DataManage.IBatchToRedDrugView>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="view"></param>
        public BatchToRedDrugPresenter(Views.DataManage.IBatchToRedDrugView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnInitEdit += View_OnInitEdit;
        }

        /// <summary>
        /// 初始化页面gridcontrol数据的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLoadData(object sender, Views.DataManage.BatchToRedDrugEventArgs e)
        {
            DataTable dt = this.Model.QueryBatchSet();
            if (dt != null)
            {
                this.View.ExeinitData(dt);
            }
        }

        /// <summary>
        /// 初始化单选框的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInitEdit(object sender, Views.DataManage.BatchToRedDrugEventArgs e)
        {
            CJia.PIVAS.Models.DataManage.RedDrugModel reddrug=new Models.DataManage.RedDrugModel();
            DataTable dt = reddrug.GetRedDrug(e.TimeType.ToString());
            this.View.ExeinitEditData(dt);
        }

        /// <summary>
        /// 重写OnInitView
        /// </summary>
        protected override void OnInitView()
        {
              base.OnInitView();
        }
    }
}