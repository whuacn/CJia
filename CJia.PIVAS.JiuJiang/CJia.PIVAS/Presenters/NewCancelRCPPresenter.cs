using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    public class NewCancelRCPPresenter : Tools.Presenter<Models.NewCancelRCPModel, Views.INewCancelRCPView>
    {
        public NewCancelRCPPresenter(Views.INewCancelRCPView view)
            : base(view)
        {
            view.Load += view_Load;
            view.OnRefresh += view_OnRefresh;
            view.OnPrint += view_OnPrint;
        }

        void view_OnPrint(object sender, Views.NewCancelRCPEventArgs e)
        {
            if(!e.IsAllPharm && e.retreatStatus == "Succeed")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 1);
                View.ExePrintCancelPharmDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "Succeed")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle,e.StartDate, e.EndDate, e.IllfieldID, 1);
                View.ExePrintCancelPharm(data);
            }
            else if(!e.IsAllPharm && e.retreatStatus == "TumDown")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 2);
                View.ExePrintCancelPharmDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "TumDown")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 2);
                View.ExePrintCancelPharm(data);
            }
            else if(!e.IsAllPharm && e.retreatStatus == "No")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 3);
                View.ExePrintCancelPharmDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "NO")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 3);
                View.ExePrintCancelPharm(data);
            }




            //if (e.IsAllPharm && !e.IsRefuse)
            //{
            //    DataTable data = Model.GetCancelStatByIffieldAndDate(e.StartDate, e.EndDate, e.IllfieldID, 1);
            //    View.ExePrintCancelPharm(data);
            //}
            //else if (e.IsAllPharm && e.IsRefuse)
            //{
            //    DataTable data = Model.GetCancelStatByIffieldAndDate(e.StartDate, e.EndDate, e.IllfieldID, 2);
            //    View.ExePrintCancelPharm(data);
            //}
            //else if (!e.IsAllPharm && e.IsRefuse)
            //{
            //    DataTable data = Model.GetCancelByIffieldAndDate(e.StartDate, e.EndDate, e.IllfieldID, 2);
            //    View.ExePrintCancelPharmDetail(data);
            //}
            //else if (!e.IsAllPharm && !e.IsRefuse)
            //{
            //    DataTable data = Model.GetCancelByIffieldAndDate(e.StartDate, e.EndDate, e.IllfieldID, 1);
            //    View.ExePrintCancelPharmDetail(data);
            //}
        }

        void view_OnRefresh(object sender, Views.NewCancelRCPEventArgs e)
        {
            if (!e.IsAllPharm && e.retreatStatus == "Succeed")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle,e.StartDate, e.EndDate, e.IllfieldID, 1);
                View.ExeBindRCPDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "Succeed")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle,e.StartDate, e.EndDate, e.IllfieldID, 1);
                View.ExeBindTotalCancelPharm(data);
            }
            else if(!e.IsAllPharm && e.retreatStatus == "TumDown")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 2);
                View.ExeBindRefuseRCPDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "TumDown")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 2);
                View.ExeBindRefuseTotalCancelPharm(data);
            }
            else if(!e.IsAllPharm && e.retreatStatus == "No")
            {
                DataTable data = Model.GetCancelByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 3);
                View.ExeBindRefuseRCPDetail(data);
            }
            else if(e.IsAllPharm && e.retreatStatus == "No")
            {
                DataTable data = Model.GetCancelStatByIffieldAndDate(e.dateStyle, e.StartDate, e.EndDate, e.IllfieldID, 3);
                View.ExeBindRefuseTotalCancelPharm(data);
            }
            
        }

        void view_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetAllIffield();
            View.ExeBindIllfield(data);
        }
    }
}
