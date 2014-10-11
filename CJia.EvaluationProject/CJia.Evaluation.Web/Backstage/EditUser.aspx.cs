using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class EditUser : CJia.Evaluation.Tools.Page,CJia.Evaluation.Views.Backstage.IEditUser
    {
        CJia.Evaluation.Views.Backstage.EditUserArgs args = new Views.Backstage.EditUserArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnInitDept(null, null);
                txt_UserCode.Text = Request.QueryString["userCode"].ToString();
                txt_UserName.Text = Request.QueryString["userName"].ToString();
                ddl_Dept.SelectedValue = Request.QueryString["userDept"].ToString();
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.EditUserPresenter(this);
        }

        protected void btn_RePwd_Click(object sender, EventArgs e)
        {
            args.userId = Request.QueryString["userId"].ToString();
            args.Pwd = Help.PwdHelp.EncryptString("8888");
            DataTable dtUser = Session["User"] as DataTable;
            args.UserId = dtUser.Rows[0]["USER_ID"].ToString(); ;
            OnResetPwd(null, args);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            args.DeptId = ddl_Dept.SelectedValue;
            args.UserName = txt_UserName.Text;
            args.userId = Request.QueryString["userId"].ToString();
            DataTable dtUser = Session["User"] as DataTable;
            args.UserId = dtUser.Rows[0]["USER_ID"].ToString(); 
            OnEditUser(null, args);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #region【实现接口】
        public event EventHandler<Views.Backstage.EditUserArgs> OnInitDept;

        public event EventHandler<Views.Backstage.EditUserArgs> OnResetPwd;

        public event EventHandler<Views.Backstage.EditUserArgs> OnEditUser;

        public void ExeResturnEditMsg(bool bl)
        {
            if (bl)
            {
                Session["AddUserDeptId"] = ddl_Dept.SelectedValue;
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("修改失败", MessageBoxIcon.Error);
            }
        }

        public void ExeResturnResetMsg(bool bl)
        {
            if (!bl)
            {
                ExtAspNet.Alert.ShowInTop("重置失败，请重试。", ExtAspNet.MessageBoxIcon.Error);
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("操作成功。", ExtAspNet.MessageBoxIcon.Information);
            }
        }

        public void ExeBindDept(System.Data.DataTable dtDept)
        {
            ddl_Dept.DataValueField = "DEPT_ID";
            ddl_Dept.DataTextField = "DEPT_NAME";
            ddl_Dept.DataSource = dtDept;
            ddl_Dept.DataBind();
        }
        #endregion

        

        




        
    }
}