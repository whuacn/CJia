using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// Ƶ�ʶ�Ӧ���ε�P��
    /// </summary>
    public class FrequencyToBatchPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.FrequencyToBatchModel,CJia.PIVAS.Views.DataManage.IFrequencyToBatchView>
    {

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="view"></param>
        public FrequencyToBatchPresenter(Views.DataManage.IFrequencyToBatchView view)
            : base(view)
        {
            this.View.OnLoadData += View_LoadData;

            this.View.OnDeleteFrequencyBatch += View_OnDeleteFrequencyBatch;
        }

        
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_LoadData(object sender, Views.DataManage.FrequencyToBatchEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.QueryFrequencyToBatch();
            this.View.ExeinitData(dt);
        }

        /// <summary>
        /// ɾ��Ƶ�ʶ�Ӧ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeleteFrequencyBatch(object sender, Views.DataManage.FrequencyToBatchEventArgs e)
        {
            bool IsDelete = this.Model.DeleteFrequencyBatch(e.UserId, e.FrequencyBatchId);
            if (IsDelete)
            {
                //this.View.ShowMessage("ɾ���ɹ�");
            }
            else
            { 
                this.View.ShowMessage("ɾ��ʧ��");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}