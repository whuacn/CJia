using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 登录界面的P层
    /// </summary>
    public class PharmEconomizePresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.PharmEconomizeModel, CJia.PIVAS.Views.IPharmEconomizeView>
    {

        /// <summary>
        /// 登录的构造方法
        /// </summary>
        /// <param name="view"></param>
        public PharmEconomizePresenter(Views.IPharmEconomizeView view)
            : base(view)
        {
            this.View.OnSelectFilterPharm += View_OnSelectFilterPharm;
            this.View.OnSelectPharmEconomize += View_OnSelectPharmEconomize;
            this.View.OnSelectPharmEconomizeInput += View_OnSelectPharmEconomizeInput;
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnAddPharm += View_OnAddPharm;
            this.View.OnAddFilterPharm += View_OnAddFilterPharm;
            this.View.OnDeleteFilterPharm += View_OnDeleteFilterPharm;
        }

        void View_OnDeleteFilterPharm(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.Model.DeleteFilterPharm(e.illfitld, e.pharmId);
        }

        void View_OnAddFilterPharm(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.Model.AddFilterPharm(e.illfitld, e.pharmId);
        }

        // 药品入库
        object View_OnAddPharm(object selectPharm,object selectIllfield)
        {
            return this.Model.AddPharm(selectPharm as DataTable, selectIllfield as string);
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        // 获取节约用药信息
        void View_OnSelectPharmEconomize(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectPharmEconomize(this.Model.SelectPharmEconomize(e.startDate, e.endDate,e.illfitld, e.pharmIds));
            this.View.ExeSelectAddPharm(this.Model.SelectAddPharmDetail(e.startDate, e.endDate, e.illfitld, e.pharmIds), this.Model.SelectAddPharm(e.startDate, e.endDate, e.illfitld, e.pharmIds));
        }

        // 获取节约用药信息(入库)
        void View_OnSelectPharmEconomizeInput(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectPharmEconomizeInput(this.Model.SelectPharmEconomizeInput(e.endDate, e.illfitld, e.pharmIds));
            //this.View.ExeSelectAddPharm(this.Model.SelectAddPharmDetail(e.startDate, e.endDate, e.illfitld, e.pharmIds), this.Model.SelectAddPharm(e.startDate, e.endDate, e.illfitld, e.pharmIds));
        }

        // 查询过滤用药品信息
        void View_OnSelectFilterPharm(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectFilterPharm(this.Model.SelectFilterPharm(e.illfitld));
        }

        /// <summary>
        /// 重写OnInitView 方法
        /// </summary>
        protected override void OnInitView()
        {

        }

    }
}