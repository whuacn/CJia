//***************************************************
// 文件名（File Name）:      CancelRCPPresenter.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.26
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

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 退药查询业务层
    /// </summary>
    public class CancelRCPPresenter:Tools.Presenter<Models.CancelRCPModel,Views.ICancelRCPView>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public CancelRCPPresenter(Views.ICancelRCPView view)
            : base(view)
        {
            View.OnRefresh += View_OnRefresh;
            View.OnPrint += View_OnPrint;
            View.OnSelecteRCPId += View_OnSelecteRCPId;
        }

        /// <summary>
        /// 刷新事件（查询退药单）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnRefresh(object sender, Views.CancelRCPArgs e)
        {
            int labelStatus = 0;
            //  汇总显示
            if (e.selectValue == "1")
            {
                DataTable dtTotalPharm = Model.QueryTotalCancelPharm(e.queryDate);
                if (dtTotalPharm != null)
                {
                    View.ExeBindGridTotalCancelPharm(dtTotalPharm);
                }
            }
            else
            {
                if (e.selectValue == "")
                {
                    labelStatus = 1000303;     // 确认退药
                }
                else if (e.selectValue == "2")
                {
                    labelStatus = 1000305;    // 拒绝退药
                }
                DataTable dtRCPDetail = Model.QueryRCP(labelStatus, e.queryDate);
                if (dtRCPDetail != null)
                {
                    //  绑定退药单药品详细信息
                    View.ExeBindGridRCPDetail(dtRCPDetail);
                }
            }
            //  绑定退药单号Id和退药时间
            View.ExeBindGridRCPId(Model.QueryGridDisTinCancelRCPID(e.queryDate));     
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnPrint(object sender, Views.CancelRCPArgs e)
        {
            DataTable dtPrint = Model.QueryPrintCancelPharm(e.queryDate);
            if (dtPrint != null)
            {
                View.ExeBindPrintCancelPharm(dtPrint);
            }
        }

        /// <summary>
        /// 选择左侧gridControl单号绑定相应单号瓶贴数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnSelecteRCPId(object sender, Views.CancelRCPArgs e)
        {
            int labelStatus = 0;
            DataTable dtSelectedRCPId;
            if (e.selectValue == "1")
            {
                labelStatus = 1000303;  // 确认退药
                // 汇总
                if (e.selectValue == "1")
                {
                    dtSelectedRCPId = Model.QueryGridAllCancelRCPBySelectedId(labelStatus, e.queryDate, e.selectedRCPId);
                }
                else
                {
                    dtSelectedRCPId = Model.QueryGridCancelRCPBySelectedId(labelStatus, e.queryDate, e.selectedRCPId);
                }
            }
            else
            {
                labelStatus = 1000305;    // 拒绝退药
                dtSelectedRCPId = Model.QueryGridCancelRCPBySelectedId(labelStatus, e.queryDate, e.selectedRCPId);
            }
            if (dtSelectedRCPId != null)
            {
                View.ExeBindGridRCPDetail(dtSelectedRCPId);
            }
        }
    }
}
