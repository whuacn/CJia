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
    public partial class AddUser : CJia.Evaluation.Tools.Page,CJia.Evaluation.Views.Backstage.IAddUser
    {
        CJia.Evaluation.Views.Backstage.AddUserArgs args = new Views.Backstage.AddUserArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_Dept.Text = Request.QueryString["DeptName"].ToString();
                txt_PWD.Text = "8888";
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.AddUserPresenter(this);
        }

        #region【实现接口】
        public event EventHandler<Views.Backstage.AddUserArgs> OnInsertUser;

        public void ExeReturnInsertMsg(bool isInsert)
        {
            if (isInsert)
            {
                Session["AddUserDeptId"] = Request.QueryString["DeptId"].ToString();
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("添加失败！", ExtAspNet.MessageBoxIcon.Error);
            }
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            args.UserName = txt_UserName.Text;
            args.UserID = dtUser.Rows[0]["USER_ID"].ToString();
            args.DeptID = Request.QueryString["DeptId"].ToString();
            args.UserCode = txt_UserCode.Text;
            args.UserPwd = Help.PwdHelp.EncryptString(txt_PWD.Text);
            CJia.Evaluation.Models.Backstage.AddUserModel model = new Models.Backstage.AddUserModel();
            bool isHaceUserCode = model.IsHaveUserCode(args.UserCode);
            if (isHaceUserCode)
            {
                Alert.ShowInTop("此用户代码已存在！", MessageBoxIcon.Warning);
            }
            else
            {
                OnInsertUser(null, args);
            }
        }


        
    }
}