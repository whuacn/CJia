using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 修改批次对应冲药p层
    /// </summary>
    public class EditBatchToRedDrugPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditBatchToRedDrugModel,CJia.PIVAS.Views.DataManage.IEditBatchToRedDrugView>
    {
        /// <summary>
        /// 修改批次的M层
        /// </summary>
        /// <param name="view"></param>
        public EditBatchToRedDrugPresenter(Views.DataManage.IEditBatchToRedDrugView view)
            : base(view)
        {
            this.View.OnUpdateBatchSet += View_OnUpdateBatchSet;
            this.View.OnIsRepeat += View_OnIsRepeat;
        }

        //传回UI层告知修改是否有重复
        void View_OnIsRepeat(object sender, Views.DataManage.EditBatchToRedDrugEventArgs e)
        {
            bool IsRepeat = this.Model.IsRepeat(e.Batch_id, e.BatchTime);
            this.View.ExeIsRepeat(IsRepeat);
        }

        /// <summary>
        /// /重写OnInitView
        /// </summary>
        protected override void OnInitView()
        {

        }

        /// <summary>
        /// 修改批次对应的冲药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateBatchSet(object sender, Views.DataManage.EditBatchToRedDrugEventArgs e)
        {
            bool IsUpdate = this.Model.UpdateBatchSet(e.BatchTime, e.Time_id, e.User_id, e.Batch_id);
            if(IsUpdate)
            {
                //this.View.ShowMessage("修改成功");
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("修改失败");
            }
        }
    }
}