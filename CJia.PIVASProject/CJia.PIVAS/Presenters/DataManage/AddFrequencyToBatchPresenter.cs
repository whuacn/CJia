using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// ���Ƶ�ʶ�Ӧ���ε�P��
    /// </summary>
    public class AddFrequencyToBatchPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddFrequencyToBatchModel,CJia.PIVAS.Views.DataManage.IAddFrequencyToBatchView>
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="view"></param>
        public AddFrequencyToBatchPresenter(Views.DataManage.IAddFrequencyToBatchView view)
            : base(view)
        {
            this.View.OnInitLoadData += View_OnInitLoadData;
            this.View.OnAddFrequencyBatch += View_OnAddFrequencyBatch;
        }

        /// <summary>
        /// ��ʼ��Ƶ�ʺ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInitLoadData(object sender, Views.DataManage.AddFrequencyToBatchEventArgs e)
        {
            DataTable dtFrequency = new DataTable();
            DataTable dtBatch=new DataTable();
            dtFrequency = this.Model.QueryFrequency();
            CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel editFrequecyBatch = new Models.DataManage.EditFrequencyToBatchModel();
            dtBatch = editFrequecyBatch.QueryBatch();
            this.View.ExeGridLookUpDataBind(dtFrequency,dtBatch);
        }

        /// <summary>
        /// ����Ƶ�ʶ�Ӧ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAddFrequencyBatch(object sender, Views.DataManage.AddFrequencyToBatchEventArgs e)
        {
            bool IsInsert = this.Model.InsertFrquencyBatch(e.FrequencyId, e.FrequencyName, e.FrequencyFilter, e.BatchsName, e.UserId);
            if(IsInsert)
            {
                //this.View.ShowMessage("����ɹ�");
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("����ʧ��");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}