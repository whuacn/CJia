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
    public partial class EditUser : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                editUserArgs.LoginUser = (DataTable)Session["User"];
                editUserArgs.UserId = Request.QueryString["EditUserID"];
                OnInit(null, editUserArgs);
            }
        }

        Views.EditUserArgs editUserArgs = new Views.EditUserArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.EditUserPresenter(this);
        }

        #region【界面事件】

        protected void btnSave_Click(object sender, EventArgs e)
        {
            editUserArgs.UserId = Request.QueryString["EditUserID"];
            editUserArgs.UserNo = txtUserNo.Text;
            editUserArgs.UserName = txtUserName.Text;
            foreach (CheckItem item in chkListRole.Items)
            {
                if (item.Selected)
                {
                    editUserArgs.RoleArr.Add(item.Value);
                }
            }
            editUserArgs.LoginUser = (DataTable)Session["User"];
            OnSave(null, editUserArgs);
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

        #region【接口实现】
        /// <summary>
        /// 绑定界面所选监督人员相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeBindControl(DataTable dtTask)
        {
            DataRow dr = dtTask.Rows[0];
            txtUserNo.Text = dr["user_no"].ToString();
            txtUserName.Text = dr["user_name"].ToString();
        }

        /// <summary>
        /// 绑定角色选择框
        /// </summary>
        /// <param name="dtOrganAllRole">某个组织所拥有的角色类型为“2”的全部角色</param>
        /// <param name="dtUserOwnRole">某用户所拥有的全角色</param>
        public void ExeCheckBoxList(DataTable dtOrganAllRole, DataTable dtUserOwnRole)
        {
            chkListRole.DataTextField = "role_name";
            chkListRole.DataValueField = "role_id";
            chkListRole.DataSource = dtOrganAllRole;
            chkListRole.DataBind();
            foreach (CheckItem item in chkListRole.Items)
            {
                foreach (DataRow drUser in dtUserOwnRole.Rows)
                {
                    if (item.Value == drUser["role_id"].ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        public void ExeMessageBox(string message, bool isCloseWindow)
        {
            if (isCloseWindow)
            {
                Alert.ShowInTop(message, "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop(message, "提示对话框");
            }
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.EditUserArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditUserArgs> OnSave;
        #endregion
    }
}