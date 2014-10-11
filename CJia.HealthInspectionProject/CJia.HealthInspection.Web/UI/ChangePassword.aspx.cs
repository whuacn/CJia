using CJia.HealthInspection.Views;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI
{
    public partial class ChangePassword : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IChangePassword
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ChangePasswordArgs changePasswordArgs = new ChangePasswordArgs();
        protected override object CreatePresenter()
        {
            return new Presenters.ChangePasswordPresenter(this);
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                DataTable data = Session["User"] as DataTable;
                if (txt_OldPasswdD.Text != data.Rows[0]["USER_PWD"].ToString())
                {
                    Alert.ShowInTop("旧密码错误！");
                    txt_OldPasswdD.Text = "";
                    txt_OldPasswdD.Focus();
                    return;
                }
                if (OnSave != null)
                {
                    changePasswordArgs.NewPassword = txt_NewPasswdD.Text;
                    changePasswordArgs.UserData = data;
                    OnSave(sender, changePasswordArgs);
                    data.Rows[0]["USER_PWD"] = txt_NewPasswdD.Text;
                }
            }
        }
        public event EventHandler<ChangePasswordArgs> OnSave;
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("修改成功！");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }
    }
}