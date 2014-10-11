using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �齣ά����P��
    /// </summary>
    public class RedDrugViewPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.RedDrugModel, CJia.PIVAS.Views.DataManage.IRedDrugView>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="view"></param>
        public RedDrugViewPresenter(Views.DataManage.IRedDrugView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnDeleteTimeSet += View_OnDeleteTimeSet;
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLoadData(object sender, Views.DataManage.RedDrugEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = this.Model.GetRedDrug(e.Whichpage.ToString());
            this.View.ExeInitData(dt);
            //if (dt != null && dt.Rows != null && dt.Rows.Count != 0)
            //{
            //    this.View.ExeInitData(dt);
            //}
            
        }

        /// <summary>
        /// ɾ��ʱ��ά������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeleteTimeSet(object sender, Views.DataManage.RedDrugEventArgs e)
        {
            bool IsDelete = this.Model.DeleteTimeSet(e.UserId,e.TimeId);
            if (IsDelete)
            {
                //this.View.ShowMessage("ɾ���ɹ�");
            }
            else
            {
                this.View.ShowMessage("ɾ��ʧ��");
            }
        }

        /// <summary>
        /// ��дOnInitView()
        /// </summary>
        protected override void OnInitView()
        {
            
        }
    }
}