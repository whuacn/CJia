using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class PackManageViewPresenter : Tools.Presenter<Models.PackManageViewModel, Views.IPackManageView>
    {
        public PackManageViewPresenter(Views.IPackManageView view)
            : base(view)
        {
            View.OnSearchPat += View_OnSearchPat;
            View.OnAndInPack += View_OnAndInPack;
            View.OnPrint += View_OnPrint;
            View.OnOut += View_OnOut;
            View.OnDeletePack += View_OnDeletePack;
            View.OnSearchPack += View_OnSearchPack;
        }

        void View_OnSearchPack(object sender, Views.PackManageViewArgs e)
        {
            DataTable data = Model.GetPack(e.Start, e.End, e.PackAddress, e.PatCode, e.PatName, e.PackCode, e.PackName);
            View.ExeBindPack(data);
        }

        void View_OnDeletePack(object sender, Views.PackManageViewArgs e)
        {
            try
            {
                using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    Model.DeletePack(trans.ID, e.PackID, User.UserData.Rows[0]["USER_ID"].ToString());
                    Model.DeletePackDetail(trans.ID, e.PackID, User.UserData.Rows[0]["USER_ID"].ToString());
                    trans.Complete();
                }
                View.ExeIsDeletePack(true);
            }
            catch
            {
                View.ExeIsDeletePack(false);
            }
        }

        void View_OnOut(object sender, Views.PackManageViewArgs e)
        {
            bool bol = Model.DeletePackDetailOne(e.PackID, e.HealthID, User.UserData.Rows[0]["USER_ID"].ToString());
            View.ExeIsOut(bol);
        }

        void View_OnPrint(object sender, Views.PackManageViewArgs e)
        {
            string printer = Tools.ConfigHelper.GetAppStrings("Printer");
            PrintHelper print = new PrintHelper();
            print.PrintPack(printer, false, e.PackName, e.PackCode);
        }

        void View_OnAndInPack(object sender, Views.PackManageViewArgs e)
        {
            DataTable data = Model.GetPatientByNO(e.RecordNO);
            if (data.Rows.Count > 0)
            {
                DataTable pack = Model.GetPackByID(data.Rows[0]["ID"].ToString());
                if (pack.Rows.Count > 0)
                    View.ShowMessage("此病案已打包");
                else
                {
                    if (Model.AddPackDetail(e.PackID, data.Rows[0]["ID"].ToString(), User.UserData.Rows[0]["USER_ID"].ToString()))
                        View.ExeIsAndInPack(data.Rows[0]);
                }
            }
            else
            {
                View.ShowWarning("此病案条码不符合打包条件（已审核通过未锁定的有效病案）");
            }
        }

        void View_OnSearchPat(object sender, Views.PackManageViewArgs e)
        {
            DataTable data = Model.GetPatient(e.PackCode, e.PackName);
            View.ExeBindPat(data);
        }
    }
}
