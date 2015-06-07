using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class IPSetViewPresenter : Tools.Presenter<Models.IPSetViewModel, Views.IIPSetView>
    {
        public IPSetViewPresenter(Views.IIPSetView view)
            : base(view)
        {
            View.OnAdd += View_OnAdd;
            View.OnDelete += view_OnDelete;
            View.OnInitView += View_OnInitView;
        }

        void View_OnInitView(object sender, Views.IPSetViewArgs e)
        {
            DataTable data = Model.GetIP();
            View.ExeBindData(data);
        }

        void view_OnDelete(object sender, Views.IPSetViewArgs e)
        {
            try
            {
                using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    foreach (string ip in e.IPList)
                    {
                        Model.DeleteIP(trans.ID, ip, User.UserData.Rows[0]["USER_ID"].ToString());
                    }
                    trans.Complete();
                }
                View.ExeIsDelete(true);
            }
            catch
            {
                View.ExeIsDelete(false);
            }
        }

        void View_OnAdd(object sender, Views.IPSetViewArgs e)
        {
            try
            {
                using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    foreach (string ip in e.IPList)
                    {
                        DataTable data = Model.GetIP(ip);
                        if (data.Rows.Count > 0)
                            continue;
                        Model.AddIP(trans.ID, ip, User.UserData.Rows[0]["USER_ID"].ToString());
                    }
                    trans.Complete();
                }
                View.ExeIsAdd(true);
            }
            catch
            {
                View.ExeIsAdd(false);
            }
        }
    }
}
