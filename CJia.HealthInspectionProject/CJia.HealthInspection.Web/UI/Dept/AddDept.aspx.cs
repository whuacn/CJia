using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.Dept
{
    public partial class AddDept : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IAddDept
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SelectedOrganNameDeptAdd"] = null;
            }
            if (Session["SelectedOrganNameDeptAdd"] != null)
            {
                txtOrganName.Text = Session["SelectedOrganNameDeptAdd"].ToString();
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddDeptPresenter(this);
        }

        Views.AddDeptArgs addDeptArgs = new Views.AddDeptArgs();
        
        #region【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            addDeptArgs.DeptNo = txtDeptNo.Text;
            addDeptArgs.DeptName = txtDeptName.Text;
            addDeptArgs.OrganId = Session["SelectedOrganIdDeptAdd"].ToString();
            addDeptArgs.UserId = ((DataTable)Session["User"]).Rows[0]["user_id"].ToString();
            OnSave(null,addDeptArgs);
        }

        protected void btnSelectOrgan_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("SelectOrgan.aspx?status=addDept","选择组织"));
        }
        #endregion

        #region【自定义方法】
        #endregion

        #region【接口实现】
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message"></param>
        public void ExeMessage(string message)
        {
            Alert.ShowInTop(message,"提示对话框","location.href=location.href;");
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AddDeptArgs> OnSave;
        #endregion
    }
}