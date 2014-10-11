using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Dept
{
    public partial class EditDept : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditDept
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SelectedOrganNameDeptEdit"] = null;
                editDeptArgs.DeptId = Request.QueryString["EditDeptID"];
                OnInit(null, editDeptArgs);
            }
            if (Session["SelectedOrganNameDeptEdit"] != null)
            {
                txtOrganName.Text = Session["SelectedOrganNameDeptEdit"].ToString();
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.EditDeptPresenter(this);
        }

        Views.EditDeptArgs editDeptArgs = new Views.EditDeptArgs();

        #region【界面事件】

        protected void btnSelectOrgan_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("SelectOrgan.aspx?status=editDept", "选择组织"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            editDeptArgs.DeptId = Request.QueryString["EditDeptID"];
            editDeptArgs.DeptNo = txtDeptNo.Text;
            editDeptArgs.DeptName = txtDeptName.Text;
            editDeptArgs.OrganId = Session["SelectedOrganIdDeptEdit"].ToString();
            editDeptArgs.User = (DataTable)Session["User"];
            OnSave(null, editDeptArgs);
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
            txtDeptNo.Text = dr["dept_no"].ToString();
            txtDeptName.Text = dr["dept_name"].ToString();
            txtOrganName.Text = dr["organ_name"].ToString();
            Session["SelectedOrganIdDeptEdit"] = dr["organ_id"]; // 当进入编辑页面未选择组织时需要为其赋值，否则为null
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
        public event EventHandler<Views.EditDeptArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditDeptArgs> OnSave;
        #endregion
    }
}