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
    public partial class AddDept : CJia.Evaluation.Tools.Page,CJia.Evaluation.Views.Backstage.IAddDept
    {
        CJia.Evaluation.Views.Backstage.AddDeptArgs addDeptArgs = new Views.Backstage.AddDeptArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnQueryAllDept(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.AddDeptPresenter(this);
        }

        #region【时间方法】
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            addDeptArgs.DeptName = txt_Dept_Name.Text;
            addDeptArgs.ParentId = ddl_Parent_Dept.SelectedValue;
            addDeptArgs.UserId = dtUser.Rows[0]["USER_ID"].ToString(); 
            OnInsertDept(null, addDeptArgs);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.AddDeptArgs> OnQueryAllDept;

        public event EventHandler<Views.Backstage.AddDeptArgs> OnInsertDept;

        public void ExeReturnAddDeptMsg(bool isInsert)
        {
            if (!isInsert)
            {
                Session["IsDeptUpdate"] = "1";
                ExtAspNet.Alert.ShowInTop("添加失败！", ExtAspNet.MessageBoxIcon.Error);
            }
            else
            {
                Session["IsDeptUpdate"] = "1";
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }

        public void ExeBindDept(System.Data.DataTable dtDept)
        {
            ddl_Parent_Dept.DataValueField = "DEPT_ID";
            ddl_Parent_Dept.DataTextField = "DEPT_NAME";
            ddl_Parent_Dept.DataSource = dtDept;
            ddl_Parent_Dept.DataBind();
        }
        #endregion

        
        
    }
}