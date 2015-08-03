using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 冲药presenter层
    /// </summary>
    public class SendPharmSelectPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.SendPharmSelectModel, CJia.PIVAS.Views.ISendPharmSelectView>
    {

        /// <summary>
        /// 登录的构造方法
        /// </summary>
        /// <param name="view"></param>
        public SendPharmSelectPresenter(Views.ISendPharmSelectView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnInitUsage += View_OnInitUsage;
            this.View.OnSelectLabel += View_OnSelectLabel;
            this.View.OnSelectLabelSum += View_OnSelectLabelSum;
            this.View.OnSelectPharmColloet += View_OnSelectPharmColloet;
            this.View.OnSelectPharm += View_OnSelectPharm;
        }

        #region View事件绑定方法

        //查询药品
        void View_OnSelectPharm(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeSelectPharm(this.Model.QueryPharm(e.PharmKey));
        }

        //查询药品汇总
        void View_OnSelectPharmColloet(object sender, Views.SendPharmSelectEventArgs e)
        {
            DataTable result = this.Model.QueryPharmColloct(e.startDate, e.endDate, e.IffieldID,e.BacthID, e.Group);
           this.View.ExeInitPharmColloet(result);
        }

        //查询瓶贴
        void View_OnSelectLabel(object sender, Views.SendPharmSelectEventArgs e)
        {
            //DataTable result = this.Model.QueryLabel(e.startDate, e.endDate, e.IffieldID,e.BacthID,"", e.Group,e.longTemporary);
            //this.View.ExeInitLabel(result);
            DataTable result = this.Model.QueryLabel(e.isPrintDate,e.startDate, e.endDate,e.isListDate,e.listDate,e.isZXDate,e.zxTime, e.IffieldDs, e.BatchIDs, "", e.Group, e.longTemporary,e.AllGrDr,e.usageIDs);
            this.View.ExeInitLabel(result);
        }

        //查询瓶贴汇总
        void View_OnSelectLabelSum(object sender, Views.SendPharmSelectEventArgs e)
        {
            //DataTable result = this.Model.QueryLabel(e.startDate, e.endDate, e.IffieldID,e.BacthID,"", e.Group,e.longTemporary);
            //this.View.ExeInitLabel(result);
            DataTable result = this.Model.QueryLabelSum(e.isPrintDate, e.startDate, e.endDate, e.isListDate, e.listDate, e.isZXDate, e.zxTime, e.IffieldDs, e.BatchIDs, "", e.Group, e.longTemporary, e.AllGrDr,e.usageIDs);
            this.View.ExeInitLabelSum(result);
        }

        //初始化批次事件绑定方法
        void View_OnInitBacth(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitBacth(Common.GetBatch());
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        //初始化给药途径事件绑定方法
        void View_OnInitUsage(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitUsage(Common.GetUsage());
        }

        #endregion

        /// <summary>
        /// 重写OnInitView 方法
        /// </summary>
        protected override void OnInitView()
        {

        }
    }
}
