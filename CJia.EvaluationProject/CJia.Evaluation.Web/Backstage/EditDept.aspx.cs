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
    public partial class EditDept : CJia.Evaluation.Tools.Page,CJia.Evaluation.Views.Backstage.IEditDept
    {
        CJia.Evaluation.Views.Backstage.EditDeptArgs args = new Views.Backstage.EditDeptArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnInitDept(null, null);
                args.DeptId = Request.QueryString["DeptId"].ToString();
                OnQueryDeptById(null, args);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.EditDeptPresenter(this);
        }

        #region【实现接口】
        public event EventHandler<Views.Backstage.EditDeptArgs> OnInitDept;

        public event EventHandler<Views.Backstage.EditDeptArgs> OnUpdateDept;

        public event EventHandler<Views.Backstage.EditDeptArgs> OnQueryDeptById;

        public void ExeBindParentDept(System.Data.DataTable dtDept)
        {
            if (dtDept != null && dtDept.Rows != null && dtDept.Rows.Count > 0)
            {
                txt_Dept_Name.Text = dtDept.Rows[0]["DEPT_NAME"].ToString();
                ddl_Parent_Dept.SelectedValue = dtDept.Rows[0]["PARENT_ID"].ToString();
            }
        }

        public void ExeReturnUpdateMsg(bool isUpdate)
        {
            if (isUpdate)
            {
                Session["IsDeptUpdate"] = "1";
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("修改失败", MessageBoxIcon.Error);
            }
        }

        public void ExeBingDept(System.Data.DataTable dtDept)
        {
            ddl_Parent_Dept.DataValueField = "DEPT_ID";
            ddl_Parent_Dept.DataTextField = "DEPT_NAME";
            ddl_Parent_Dept.DataSource = dtDept;
            ddl_Parent_Dept.DataBind();
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable; 
            if (Request.QueryString["DeptId"].ToString() != ddl_Parent_Dept.SelectedValue)
            {
                args.DeptId = Request.QueryString["DeptId"].ToString();
                args.DeptName = txt_Dept_Name.Text;
                args.ParentDeptID = ddl_Parent_Dept.SelectedValue;
                args.UserId = dtUser.Rows[0]["USER_ID"].ToString(); 
                OnUpdateDept(null, args);
            }
            else
            {
                Alert.ShowInTop("父级科室不能为自己", MessageBoxIcon.Warning);
            }
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }





       
    }
}