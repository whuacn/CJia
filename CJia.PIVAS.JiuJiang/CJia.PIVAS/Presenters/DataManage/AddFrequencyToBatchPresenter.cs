using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 添加频率对应批次的P层
    /// </summary>
    public class AddFrequencyToBatchPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddFrequencyToBatchModel,CJia.PIVAS.Views.DataManage.IAddFrequencyToBatchView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view"></param>
        public AddFrequencyToBatchPresenter(Views.DataManage.IAddFrequencyToBatchView view)
            : base(view)
        {
            this.View.OnInitLoadData += View_OnInitLoadData;
            this.View.OnAddFrequencyBatch += View_OnAddFrequencyBatch;
        }

        /// <summary>
        /// 初始化频率和批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInitLoadData(object sender, Views.DataManage.AddFrequencyToBatchEventArgs e)
        {
            DataTable dtFrequency = new DataTable();
            DataTable dtIllfield = new DataTable();
            DataTable dtBatch=new DataTable();
            dtFrequency = this.Model.QueryFrequency();
            dtIllfield = this.Model.QueryIllfield();
            CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel editFrequecyBatch = new Models.DataManage.EditFrequencyToBatchModel();
            dtBatch = editFrequecyBatch.QueryBatch();
            this.View.ExeGridLookUpDataBind(dtFrequency, dtBatch, dtIllfield);
        }

        /// <summary>
        /// 增加频率对应批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAddFrequencyBatch(object sender, Views.DataManage.AddFrequencyToBatchEventArgs e)
        {
            bool isHave = this.Model.QueryIllfieldFrequency(e.FrequencyId,e.Illfield);
            if(!isHave)
            {
                bool IsInsert = this.Model.InsertFrquencyBatch(e.FrequencyId, e.FrequencyName, e.FrequencyFilter, e.BatchsName, e.UserId,e.Illfield,e.IllfieldName);
                if(IsInsert)
                {
                    //this.View.ShowMessage("插入成功");
                    this.View.CloseWindow();
                }
            }
            else
            {
                this.View.ShowMessage("设置失败！该病区该频率已经存在设置信息！");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}