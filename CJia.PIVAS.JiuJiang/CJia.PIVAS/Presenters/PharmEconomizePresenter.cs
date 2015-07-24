using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// ��¼�����P��
    /// </summary>
    public class PharmEconomizePresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.PharmEconomizeModel, CJia.PIVAS.Views.IPharmEconomizeView>
    {

        /// <summary>
        /// ��¼�Ĺ��췽��
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

        // ҩƷ���
        object View_OnAddPharm(object selectPharm,object selectIllfield)
        {
            return this.Model.AddPharm(selectPharm as DataTable, selectIllfield as string);
        }

        //��ʼ�������¼��󶨷���
        void View_OnInitIffield(object sender, Views.SendPharmSelectEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        // ��ȡ��Լ��ҩ��Ϣ
        void View_OnSelectPharmEconomize(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectPharmEconomize(this.Model.SelectPharmEconomize(e.startDate, e.endDate,e.illfitld, e.pharmIds));
            this.View.ExeSelectAddPharm(this.Model.SelectAddPharmDetail(e.startDate, e.endDate, e.illfitld, e.pharmIds), this.Model.SelectAddPharm(e.startDate, e.endDate, e.illfitld, e.pharmIds));
        }

        // ��ȡ��Լ��ҩ��Ϣ(���)
        void View_OnSelectPharmEconomizeInput(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectPharmEconomizeInput(this.Model.SelectPharmEconomizeInput(e.endDate, e.illfitld, e.pharmIds));
            //this.View.ExeSelectAddPharm(this.Model.SelectAddPharmDetail(e.startDate, e.endDate, e.illfitld, e.pharmIds), this.Model.SelectAddPharm(e.startDate, e.endDate, e.illfitld, e.pharmIds));
        }

        // ��ѯ������ҩƷ��Ϣ
        void View_OnSelectFilterPharm(object sender, Views.PharmEconomizeViewEventArgs e)
        {
            this.View.ExeSelectFilterPharm(this.Model.SelectFilterPharm(e.illfitld));
        }

        /// <summary>
        /// ��дOnInitView ����
        /// </summary>
        protected override void OnInitView()
        {

        }

    }
}