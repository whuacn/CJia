using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// 瓶贴预览presenter层
    /// </summary>
    public class LabelScenningPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.LabelScenningModel, CJia.PIVAS.Views.Label.ILabelScanningView>
    {
        
        /// <summary>
        /// 瓶贴扫描构造函数
        /// </summary>
        /// <param name="view"></param>
        public LabelScenningPresenter(CJia.PIVAS.Views.Label.ILabelScanningView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnQueryLabeList += View_OnQueryLabeList;
            this.View.OnQueryBarCodeLabe += View_OnQueryBarCodeLabe;
            this.View.OnUpdateBarCode += View_OnUpdateBarCode;
            this.View.OnAnewPrintLabel += View_OnAnewPrintLabel;
            this.View.OnQueryLabelGroupIndex += View_OnQueryLabelGroupIndex;
            this.View.OnDelectPrindedLabel += View_OnDelectPrindedLabel;
            this.View.OnPharmFee += View_OnPharmFee;
            this.View.OnCancelPharmFee += View_OnCancelPharmFee;
            this.View.OnFeeTIME += View_OnFeeTIME;
            this.View.OnCancelFeeTIME += View_OnCancelFeeTIME;
            this.View.OnUpdateLabelExeStatus += View_OnUpdateLabelExeStatus;
            this.View.OnLabelIsFee += View_OnLabelIsFee;
            this.View.OnPrindedLabelDetail += View_OnPrindedLabelDetail;

        }



        
        #region View事件绑定方法

        // 打印瓶贴明细
        void View_OnPrindedLabelDetail(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExePrintLabelDetail(this.Model.QueryPrintLabelDetail(e.dataTime,e.LabelStype,e.longTemporary,e.grOrDr,e.IffieldID,e.BacthID));
        }

        // 查询瓶贴的扣费次数
        object View_OnLabelIsFee(object labelId)
        {
            return this.Model.QueryLabelTimes(labelId.ToString());
        }

        //开是否是退费时间
        object View_OnCancelFeeTIME(object feeTime)
        {
            return  CJia.PIVAS.Models.PIVASModel.QueryCancelFeeTime(feeTime.ToString());
        }

        //修改瓶贴冲药状态
        void View_OnUpdateLabelExeStatus(object labelId)
        {
            CJia.PIVAS.Models.PIVASModel.ExecuteLabelFee(labelId.ToString());
        }

        //获取扣费时间
        object View_OnFeeTIME(object feeTime)
        {
            return CJia.PIVAS.Models.PIVASModel.QueryFeeTime(feeTime.ToString());
        }

        //扣费扣库存
        object View_OnPharmFee(object groupIndex,object openDate,object count)
        {
            return CJia.PIVAS.Models.PIVASModel.ExecuteGroupIndexFee(groupIndex.ToString(), CJia.PIVAS.User.hisUserId.ToString(),(DateTime)openDate,(int)count,0);
        }

        //退费退库存
        object View_OnCancelPharmFee(object groupIndex, object openDate, object count)
        {
            return CJia.PIVAS.Models.PIVASModel.ExecuteGroupIndexFee(groupIndex.ToString(), CJia.PIVAS.User.hisUserId.ToString(), (DateTime)openDate, (int)count, 1);
        }

        //作废瓶贴
        void View_OnDelectPrindedLabel(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.Model.DelectPrintedLabel(e.BarCode, CJia.PIVAS.User.UserId.ToString());
        }

        //获取医嘱有效状态
        void View_OnQueryLabelGroupIndex(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeQueryLabelGroupIndex(this.Model.QueryLabelGroupIndex(e.BarCode));
        }

        //从新打印瓶贴
        void View_OnAnewPrintLabel(object sender, Views.Label.LabelScanningEventArgs e)
        {
             this.View.ExeQueryBarCodeLabel(this.Model.AnewPrintLabel(e.BarCode,CJia.PIVAS.User.UserId.ToString()));
        }

        //修改瓶贴状态
        void View_OnUpdateBarCode(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.Model.UpdateBarCodeStatus(e.BarCode, e.BarCodeStatus,CJia.PIVAS.User.UserId.ToString(),CJia.PIVAS.Tools.Helper.Sysdate);
        }


        //根据条形码返回瓶贴
        void View_OnQueryBarCodeLabe(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeQueryBarCodeLabel(this.Model.QueryBarCodeLabel(e.BarCode));
        }

        //查询瓶贴列表
        void View_OnQueryLabeList(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeQueryLabelList(this.Model.QueryLabelList(e.grOrDr,e.Date, e.ScenningType, e.IffieldID, e.BacthID,e.LabelStype,e.longTemporary));
        }

        //初始化批次事件绑定方法
        void View_OnInitBacth(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeInitBacth(Common.GetBatch());
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        #endregion

        /// <summary>
        /// 出事化View层
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
