using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class EditPasswordView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IEditPasswordView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.EditPasswordPresenter(this);
        }

        /// <summary>
        /// 参数
        /// </summary>
        Views.Web.EditPasswordArgs editPasswordArgs = new Views.Web.EditPasswordArgs();

        #region IEditPasswordView成员
        public event EventHandler<Views.Web.EditPasswordArgs> OnSave;
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Response.Write("<script language=javascript>alert('密码修改成功！');</script>");
            }
        }
        #endregion

        protected void btnResert_Click(object sender, EventArgs e)
        {
            Resert();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                DataTable data = Session["User"] as DataTable;
                if (txtOldPassword.Text != data.Rows[0]["USER_PWD"].ToString())
                { lblMsg.Text = "原始密码错误！"; return; }
                if (OnSave != null)
                {
                    editPasswordArgs.NewPassword = txtPassword.Text;
                    editPasswordArgs.UserData = data;
                    OnSave(sender, editPasswordArgs);
                    data.Rows[0]["USER_PWD"] = txtPassword.Text;
                    Resert();
                }
            }
        }

        public void Resert()
        {
            txtOldPassword.Text = "";
            txtPassword.Text = "";
            txtTrePassword.Text = "";
            lblMsg.Text = "";
        }

        protected void Server_Validate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 4)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}