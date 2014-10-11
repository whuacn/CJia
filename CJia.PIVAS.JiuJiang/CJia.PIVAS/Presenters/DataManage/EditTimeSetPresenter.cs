using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// �޸�ʱ�����ݵ�P��
    /// </summary>
    public class EditTimeSetPresenter:CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditTimeSetModel, CJia.PIVAS.Views.DataManage.IEditTimeSetView>
    {
        /// <summary>
        /// P�㹹�췽��
        /// </summary>
        /// <param name="view"></param>
        public EditTimeSetPresenter(Views.DataManage.IEditTimeSetView view)
            : base(view)
        {
            this.View.OnInserttimeSet += View_OnInserttimeSet;
            this.View.OnUpdateTimeSet += View_OnUpdateTimeSet;
            this.View.OnIsUpdateRepeat += View_OnIsUpdateRepeat;
            this.View.OnIsInsertRepeat += View_OnIsInsertRepeat;
        }

        /// <summary>
        /// �ж����ʱ���Ƿ����ص�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnIsInsertRepeat(object sender, Views.DataManage.EditTimeSetEventArgs e)
        {
            bool isInsertRepeat = this.Model.isInsertRepeat(e.Whichpage.ToString(), e.StartTime, e.EndTime);
            this.View.ExeIsRepeat(isInsertRepeat);
        }

        /// <summary>
        /// �ж��޸�ʱ���Ƿ����ص�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnIsUpdateRepeat(object sender, Views.DataManage.EditTimeSetEventArgs e)
        {
            bool isUpdateRepeat = this.Model.IsUpdateRepeat(e.Whichpage.ToString(), e.TimeId, e.StartTime, e.EndTime);
            this.View.ExeIsRepeat(isUpdateRepeat);
        }


        /// <summary>
        /// ����ʱ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInserttimeSet(object sender, Views.DataManage.EditTimeSetEventArgs e)
        {
            bool IsInsert = this.Model.InsertTimeSet(e.TimeName, e.StartTime, e.OverTime, e.Whichpage, e.UserId);
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

        /// <summary>
        /// �޸�ʱ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateTimeSet(object sender, Views.DataManage.EditTimeSetEventArgs e)
        {
            bool IsUpdate = this.Model.UpdateTimeSet(e.TimeName, e.StartTime, e.OverTime, e.UserId, e.TimeId);
            if (IsUpdate)
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
        /// ��дOnInitView����
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }

    }
}