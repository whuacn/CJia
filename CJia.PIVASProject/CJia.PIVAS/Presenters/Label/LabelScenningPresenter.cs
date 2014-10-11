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
        }





        #region View事件绑定方法

        //从新打印瓶贴
        void View_OnAnewPrintLabel(object sender, Views.Label.LabelScanningEventArgs e)
        {
             this.View.ExeQueryBarCodeLabel(this.Model.AnewPrintLabel(e.BarCode,CJia.PIVAS.User.UserId.ToString()));
        }

        //修改瓶贴状态
        void View_OnUpdateBarCode(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.Model.UpdateBarCodeStatus(e.BarCode, e.BarCodeStatus);
        }


        //根据条形码返回瓶贴
        void View_OnQueryBarCodeLabe(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeQueryBarCodeLabel(this.Model.QueryBarCodeLabel(e.BarCode));
        }

        //查询瓶贴列表
        void View_OnQueryLabeList(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeQueryLabelList(this.Model.QueryLabelList(e.Date, e.ScenningType, e.IffieldID, e.BacthID));
        }

        //初始化批次事件绑定方法
        void View_OnInitBacth(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeInitBacth( this.Model.QueryAllBatch());
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.Label.LabelScanningEventArgs e)
        {
            this.View.ExeInitIffield(this.Model.QueryAllIffield());
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
