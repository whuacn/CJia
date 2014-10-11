using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    public class DeptUsagePresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.DeptUsageModel,CJia.PIVAS.Views.DataManage.IDeptUsageView>
    {
        public DeptUsagePresenter(Views.DataManage.IDeptUsageView view)
            : base(view)
        {
            this.View.OnInitLoadData += View_OnInitLoadData;
            this.View.OnDeleteDeptUsage += View_OnDeleteDeptUsage;
        }

        /// <summary>
        /// 初始化gridcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInitLoadData(object sender, Views.DataManage.DeptUsageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.QueryDeptUsage();
            this.View.ExeDataBinds(dt);
        }

        /// <summary>
        /// 物理删除选中数据  把状态置为0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeleteDeptUsage(object sender, Views.DataManage.DeptUsageEventArgs e)
        {
            bool IsDelete = this.Model.DeleteDeptUsage(e.UserId, e.PivasSetId);
            if(IsDelete)
            {
                this.View_OnInitLoadData(null, null);
                //this.View.ShowMessage("删除成功");
            }
            else
            {
                this.View.ShowMessage("删除失败");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}