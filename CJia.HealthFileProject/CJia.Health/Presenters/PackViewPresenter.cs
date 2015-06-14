using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class PackViewPresenter : Tools.Presenter<Models.PackViewModel, Views.IPackView>
    {
        public PackViewPresenter(Views.IPackView view)
            : base(view)
        {
            View.OnSearchPatient += View_OnSearchPatient;
            View.OnOK += View_OnOK;
            View.OnPack += View_OnPack;
        }

        void View_OnPack(object sender, Views.PackViewArgs e)
        {
            try
            {
                DataTable packData = Model.GetPackByName(e.PackName);
                if (packData.Rows.Count > 0)
                {
                    View.ShowWarning("存在相同的包名称，打包/上架失败");
                }
                else
                {
                    using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                    {
                        string packID = Model.GetPackID(trans.ID);
                        string packCode = Model.GetPackCode();
                        Model.AddPack(trans.ID, packID, packCode, e.PackName, e.PackAddress, e.PackRemark, User.UserData.Rows[0]["USER_ID"].ToString());
                        foreach (string id in e.HealthID)
                        {
                            Model.AddPackDetail(trans.ID, packID, id, User.UserData.Rows[0]["USER_ID"].ToString());
                        }
                        trans.Complete();
                        if (e.isPrintCode)
                        {
                            //打印包标签
                            string printer = Tools.ConfigHelper.GetAppStrings("Printer");
                            PrintHelper print = new PrintHelper();
                            print.PrintPack(printer, false, e.PackName, packCode);
                        }
                    }
                    View.ExeisPack(true);
                }
            }
            catch
            {
                View.ExeisPack(false);
            }
        }

        void View_OnOK(object sender, Views.PackViewArgs e)
        {
            DataTable data = Model.GetPatientByNO(e.RecordNo);
            if (data.Rows.Count > 0)
            {
                DataTable pack = Model.GetPackByID(data.Rows[0]["ID"].ToString());
                if (pack.Rows.Count > 0)
                    View.ShowMessage("此病案已打包");
                else
                    View.ExeisOk(data.Rows[0]);
            }
            else
            {
                View.ShowWarning("此病案不符合打包条件（已审核通过未锁定的有效病案）");
            }
        }

        void View_OnSearchPatient(object sender, Views.PackViewArgs e)
        {
            DataTable data = Model.GetPatientByInputDate(e.Start, e.End);
            View.ExeBindData(data);
        }
    }
}
