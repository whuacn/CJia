using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// ���ζ�Ӧ��ҩ��P��
    /// </summary>
    public class BatchToRedDrugPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.BatchToRedDrugModel, CJia.PIVAS.Views.DataManage.IBatchToRedDrugView>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="view"></param>
        public BatchToRedDrugPresenter(Views.DataManage.IBatchToRedDrugView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnInitEdit += View_OnInitEdit;
        }

        /// <summary>
        /// ��ʼ��ҳ��gridcontrol���ݵķ���
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
        /// ��ʼ����ѡ���ֵ
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
        /// ��дOnInitView
        /// </summary>
        protected override void OnInitView()
        {
              base.OnInitView();
        }
    }
}