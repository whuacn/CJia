using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 添加病区对应用法的P层
    /// </summary>
    public class AddDeptUsagePresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddDeptUsageModel,CJia.PIVAS.Views.DataManage.IAddDeptUsageView>
    {

        public AddDeptUsagePresenter(Views.DataManage.IAddDeptUsageView view)
            : base(view)
        {
            this.View.OnInitLoadDept += View_OnInitLoadData;
            this.View.OnInsertData += View_OnInsertData;
            this.View.OnRowClick += View_OnRowClick;
        }

        
        void View_OnInitLoadData(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            DataTable dtDept = new DataTable();
            dtDept = this.Model.QueryDept();
            this.View.ExeInitLoadDept(dtDept);
        }

        /// <summary>
        /// 插入病区对应用法数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInsertData(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            bool blIsRepeat = this.Model.QueryIsRepeat(e.OfficeId, e.UsageId);
            if (blIsRepeat==false)
            {
                bool blIsInsert = this.Model.InsertPivas(e.OfficeId, e.OfficeName, e.UsageId, e.UsageName, e.UserId);
                if(blIsInsert)
                {
                    //this.View.ShowMessage("添加成功");
                    this.View.CloseWindow();
                }
                else
                {
                    this.View.ShowMessage("添加失败");
                }
            }
            else
            {
                this.View.ShowMessage("配置中已有一条相同数据");
            }
            
        }

        /// <summary>
        /// 点击病区下拉框的一行触发  根据获取到得病区id来得到对应没分配的用法ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnRowClick(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            DataTable dtUsage = new DataTable();
            dtUsage = this.Model.QueryUsage(e.OfficeId);
            this.View.ExtLoadUsage(dtUsage);
        }

        protected override void OnInitView()
        {

        }

    }
}