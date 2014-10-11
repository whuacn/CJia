using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.User
{
    public partial class AddUser : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IAddUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addUserArgs.User = (DataTable)Session["User"];
                OnInit(null,addUserArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddUserPresenter(this);
        }

        Views.AddUserArgs addUserArgs = new Views.AddUserArgs();

        #region【界面事件】
      

        // 保存事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            addUserArgs.UserNo = txtUserNo.Text;
            addUserArgs.UserName = txtUserName.Text;
            addUserArgs.UserType = "3";
            foreach (CheckItem item in chkListRole.Items)
            {
                if (item.Selected)
                {
                    addUserArgs.RoleArr.Add(item.Value);
                }
            }
            addUserArgs.User = (DataTable)Session["User"];
            OnSave(null, addUserArgs);
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                foreach (CheckItem item in chkListRole.Items)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (CheckItem item in chkListRole.Items)
                {
                    item.Selected = false;
                }
            }
        }

        #endregion

        #region【自定义方法】
         
        #endregion

        #region【接口绑定】
        /// <summary>
        /// 绑定角色选择框
        /// </summary>
        /// <param name="dtRole"></param>
        public void ExeCheckBoxList(DataTable dtRole)
        {
            chkListRole.DataTextField = "role_name";
            chkListRole.DataValueField = "role_id";
            chkListRole.DataSource = dtRole;
            chkListRole.DataBind();
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        public void ExeMessageBox(string message)
        {
            Alert.ShowInTop(message, "提示对话框", "location.href=location.href;");
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.AddUserArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AddUserArgs> OnSave;

        #endregion

    }
}