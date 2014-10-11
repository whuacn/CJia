using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �޸�Ƶ�ʶ�Ӧ���ε�P��
    /// </summary>
    public class EditFrequencyToBatchPresenter : PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel, CJia.PIVAS.Views.DataManage.IEditFrequencyToBatchView>
    {
        /// <summary>
        /// ���췽��
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

        //��ȡƵ�ʶ�Ӧ����
        object View_OnQueryFrequencytoBatch(object frequencyId,object illfieldID)
        {
           return  this.Model.QueryFrequencytoBatch(frequencyId.ToString(),illfieldID.ToString());
        }

        //��ʼ�����ζ�ѡ��
        void View_OnInitBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.QueryBatch();
            this.View.ExeInitLoadBatch(dt);
        }

        // �޸�����
        void View_OnUpdateFrequencyBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            bool IsUpdate = this.Model.UpdataFrequencyBatch(e.BatchsName, e.UserId, e.FrequencyBatchId);
            if(IsUpdate)
            {
                //this.View.ShowMessage("�޸ĳɹ�");
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("�޸�ʧ��");
            }
        }

        /// <summary>
        /// ���޸����Σ����ã�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateCheckFrequencyBatch(object sender, Views.DataManage.EditFrequencyToBatchEventArgs e)
        {
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                CJia.PIVAS.Models.CheckAdviceModel checkAdviceModel = new CJia.PIVAS.Models.CheckAdviceModel();
                int checkSeq = checkAdviceModel.GetCheckSeq();
                //������˱�
                checkAdviceModel.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                //��֮ǰ�����ϸ��Ϊ��Ч

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