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
        /// ��ʼ��gridcontrol
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
        /// ����ɾ��ѡ������  ��״̬��Ϊ0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeleteDeptUsage(object sender, Views.DataManage.DeptUsageEventArgs e)
        {
            bool IsDelete = this.Model.DeleteDeptUsage(e.UserId, e.PivasSetId);
            if(IsDelete)
            {
                this.View_OnInitLoadData(null, null);
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