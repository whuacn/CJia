using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �޸����ζ�Ӧ��ҩp��
    /// </summary>
    public class EditBatchToRedDrugPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditBatchToRedDrugModel,CJia.PIVAS.Views.DataManage.IEditBatchToRedDrugView>
    {
        /// <summary>
        /// �޸����ε�M��
        /// </summary>
        /// <param name="view"></param>
        public EditBatchToRedDrugPresenter(Views.DataManage.IEditBatchToRedDrugView view)
            : base(view)
        {
            this.View.OnUpdateBatchSet += View_OnUpdateBatchSet;
            this.View.OnIsRepeat += View_OnIsRepeat;
        }

        //����UI���֪�޸��Ƿ����ظ�
        void View_OnIsRepeat(object sender, Views.DataManage.EditBatchToRedDrugEventArgs e)
        {
            bool IsRepeat = this.Model.IsRepeat(e.Batch_id, e.BatchTime);
            this.View.ExeIsRepeat(IsRepeat);
        }

        /// <summary>
        /// /��дOnInitView
        /// </summary>
        protected override void OnInitView()
        {

        }

        /// <summary>
        /// �޸����ζ�Ӧ�ĳ�ҩ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateBatchSet(object sender, Views.DataManage.EditBatchToRedDrugEventArgs e)
        {
            bool IsUpdate = this.Model.UpdateBatchSet(e.BatchTime, e.Time_id, e.User_id, e.Batch_id);
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
    }
}