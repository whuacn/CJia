using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class PrintApplyPresenter : CJia.Health.Tools.Presenter<Models.PrintApplyModel, Views.IPrintApplyView>
    {
        public PrintApplyPresenter(Views.IPrintApplyView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnPatientSearch += view_OnPatientSearch;
            view.OnPatientDoubleClick += view_OnPatientDoubleClick;
            //view.OnSelectPicture += view_OnSelectPicture;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.PrintApplyEventArgs e)
        {

        }


        ///// <summary>
        ///// 绑定图片
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void view_OnSelectPicture(object sender, Views.PrintApplyEventArgs e)
        //{
        //    DataTable dtPic = Model.QueryPicture(e.HealthId);
        //    View.ExePicture(dtPic);
        //}

        /// <summary>
        /// 查询绑定病人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnPatientSearch(object sender, Views.PrintApplyEventArgs e)
        {
            if (!e.isInput)
            {
                View.ExeGridPatient(Model.QueryPatient(e.StartDate, e.EndDate, e.PatientName, e.RecordNo));
            }
            else
            {
                View.ExeGridPatient(Model.QueryPatientByInputDate(e.InputStartDate, e.InputEndDate, e.PatientName, e.RecordNo));
            }
        }

        /// <summary>
        /// 双击病人列表查询图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnPatientDoubleClick(object sender, Views.PrintApplyEventArgs e)
        {
            DataTable dt = Model.QueryPictureByHealthId(e.HealthId);
            View.ExeBindChkPicture(Model.QueryPictureByHealthId(e.HealthId));
        }
    }
}
