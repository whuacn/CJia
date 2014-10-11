using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 修改频率对应批次的P层
    /// </summary>
    public class EditFrequencyToBatchPresenter : PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel, CJia.PIVAS.Views.DataManage.IEditFrequencyToBatchView>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="view"></param>
        public EditFrequencyToBatchPresenter(Views.DataManage.IEditFrequencyToBatchView view)
            : base(view)
        {
            this.View.OnInitLoadBatch += View_OnInitBatch;
            this.View.OnUpdateFrequencyBatch += View_OnUpdateFrequencyBatch;
            this.View.OnUpdateCheckFrequencyBatch += View_OnUpdateCheckFrequencyBatch;
            this.View.OnQueryFrequencytoBatch += View_OnQueryFrequencytoBatch;
        }

        //获取频率对应批次
        object View_OnQueryFrequencytoBatch(object frequencyId,object illfieldID)
        {
           return  this.Model.QueryFrequencytoBatch(frequencyId.ToString(),illfieldID.ToString());
        }

        //初始化批次多选框
        void View_OnInitBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.QueryBatch();
            this.View.ExeInitLoadBatch(dt);
        }

        // 修改批次
        void View_OnUpdateFrequencyBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            bool IsUpdate = this.Model.UpdataFrequencyBatch(e.BatchsName, e.UserId, e.FrequencyBatchId);
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

        /// <summary>
        /// 审方修改批次（审方用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateCheckFrequencyBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                CJia.PIVAS.Models.CheckAdviceModel checkAdviceModel = new CJia.PIVAS.Models.CheckAdviceModel();
                int checkSeq = checkAdviceModel.GetCheckSeq();
                //插入审核表
                checkAdviceModel.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                //将之前审核明细置为无效

                int detailId = checkAdviceModel.GetDetailIdByGroupIndex(e.GroupIndex);
                checkAdviceModel.ModifyCheckDetailValid(trans.ID, User.UserId, detailId);

                //checkAdviceModel.ModifyCheckDetailGroupIndex(trans.ID, e.GroupIndex, User.UserId);

                int detailSeq = checkAdviceModel.GetCheckDetailSeq();
                this.Model.UpdateCheckBatch(trans.ID, detailSeq, checkSeq, e.BatchsName, e.UserId,detailId);

                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                List<string> GroupIndex = new List<string>();
                GroupIndex.Add(e.GroupIndex);
                if(GroupIndex != null && GroupIndex.Count != 0)
                {
                    checkAdviceModel.DeleteCommonLabel(trans.ID, GroupIndex);
                    checkAdviceModel.InsertCommonLabel(trans.ID, GroupIndex, CJia.PIVAS.User.UserId);
                    checkAdviceModel.InsertLabelDetail(trans.ID, GroupIndex);
                }
                trans.Complete();
                this.View.CloseWindow();
            }
        }
    }
}