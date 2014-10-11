//***************************************************
// 文件名（File Name）:      CancelApplyPresenter.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.22
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CJia.PIVAS.Tools;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 退药处理业务层
    /// </summary>
    public class CancelApplyPresenter:Tools.Presenter<Models.CancelApplyModel,Views.ICancelApplyView>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="view"></param>
        public CancelApplyPresenter(Views.ICancelApplyView view)
            : base(view)
        {
            view.Load += view_Load;
            View.OnOkCancel += View_OnOkCancel;
            View.OnRefuseApply += View_OnRefuseApply;
            View.OnCancelPreview += View_OnCancelPreview;
        }

        
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_Load(object sender, EventArgs e)
        {
            BindOfficeName();
        }

        /// <summary>
        /// 绑定病区
        /// </summary>
        void BindOfficeName()
        {
            DataTable dtOfficeName = Model.QueryOfficeName();
            if (dtOfficeName != null)
            {
                View.ExeBindOfficeName(dtOfficeName);
            }
        }

        /// <summary>
        /// 确认退药事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnOkCancel(object sender, Views.CancelApplyArgs e)
        {
            long cancelRCPSeq = Model.QueryNextCancelRCPId();   // 获取退药Sequence
            //  插入退药表退药单号
            if (Model.InsertCancelRCP(cancelRCPSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName))
            {
                //  修改瓶贴表瓶贴状态    修改退药申请表状态
                if (Model.UpdatePivasLabelStatus(User.UserId, e.group_index) && Model.UpdateCancelApplyByAgree(cancelRCPSeq, User.UserId, e.group_index))
                {
                    //  勾选打印
                    if (e.isPrint)
                    {
                        View.ExeBindPrintApplyCancelPharm(Model.QueryPrintApplyCancelPharm(e.group_index));
                    }
                }
            }
        }

        /// <summary>
        /// 拒绝退药事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnRefuseApply(object sender, Views.CancelApplyArgs e)
        {
            // 获取拒绝退药Sequence
            long refuseRCPSeq = Model.QueryNextCancelRCPId();   
            //  插入退药表拒绝退药单号
            if (Model.InsertCancelRCP(refuseRCPSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName))
            {
                Model.UpdateCancelApplyByRefuse(refuseRCPSeq, User.UserId, e.group_index);
            }
        }

        /// <summary>
        /// 预览退药事件，即查询绑定申请退药列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCancelPreview(object sender, Views.CancelApplyArgs e)
        {
            DataTable dtCancelApply = Model.QueryGridByCancelApply(e.queryDate,e.queryExeStatus,e.queryIllFieldId);
            DataColumn isChecked = new DataColumn("isChecked",typeof(System.Boolean));
            dtCancelApply.Columns.Add(isChecked);

            if (dtCancelApply != null)
            {
                View.ExeBindGridCancelApply(dtCancelApply);
            }
        }
       
    }
}
