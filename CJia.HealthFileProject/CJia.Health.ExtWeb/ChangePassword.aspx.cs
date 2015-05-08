using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb
{
    public partial class ChangePassword : CJia.Health.Tools.Page, CJia.Health.Views.Web.IEditPasswordView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.EditPasswordPresenter(this);
        }
        Views.Web.EditPasswordArgs editPasswordArgs = new Views.Web.EditPasswordArgs();

        #region IEditPasswordView成员
        public event EventHandler<Views.Web.EditPasswordArgs> OnSave;
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("密码修改成功", "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
        }
        #endregion
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                DataTable data = Session["User"] as DataTable;
                if (txt_OldPasswdD.Text != data.Rows[0]["USER_PWD"].ToString())
                { Alert.ShowInTop("原始密码错误！"); return; }
                if (OnSave != null)
                {
                    editPasswordArgs.NewPassword = txt_NewPasswdD.Text;
                    editPasswordArgs.UserData = data;
                    OnSave(sender, editPasswordArgs);
                    data.Rows[0]["USER_PWD"] = txt_NewPasswdD.Text;
                }
            }
        }
    }
}