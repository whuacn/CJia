using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 冲药Presenter层
    /// </summary>
    public class PharmSendPresenter : Tools.Presenter<Models.PharmSendModel, Views.IPharmSendView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public PharmSendPresenter(Views.IPharmSendView view)
            : base(view)
        {
            view.Load += view_Load;
            view.OnPreviewLable += view_OnPreviewLable;
            View.OnDetail += View_OnDetail;
            View.OnPharmSend += View_OnPharmSend;
        }

        void View_OnPharmSend(object sender, Views.PharmSendArgs e)
        {
            DataTable timeDate = Model.GetStartAndOverTime(e.timeID);
            if (!View.ExeIsPharmSend(timeDate)) return;
            if (Model.isExistApply()) { View.ShowMessage("有退药申请，请先处理"); return; }
            DataTable data = Model.GetTodayNOPharmStore(e.timeID);
            if (data != null && data.Rows.Count > 0) { View.ExeBindTodayNoPharmStore(data,e.timeID); return; }
            //扣费用 扣库存 费用明细
            string seq = Model.GetPharmSendSeq();
            bool bol = Model.ModifyExeStatusByTimeID(seq, User.UserId, e.timeID, User.UserName, e.timeID);
            if (bol) { View.ShowMessage("冲药成功"); }
            else { View.ShowMessage("没有要冲的药"); }
        }

        void View_OnDetail(object sender, EventArgs e)
        {
            DataTable data = Model.GetTodayLableDetail();
            if (data == null) { View.ShowMessage("无数据"); return; }
            View.ExeBindTodayLableDetail(data);
        }

        void view_OnPreviewLable(object sender, EventArgs e)
        {
            DataTable data = Model.GetTodayLable();
            View.ExeBindTodayLable(data);
        }

        void view_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetPharmSendTime("2");
            if (data != null && data.Rows.Count > 0)
                View.ExeGetPharmSendTime(data);
        }

    }
}
