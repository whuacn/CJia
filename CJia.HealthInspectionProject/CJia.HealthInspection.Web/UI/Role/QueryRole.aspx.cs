using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Role
{
    public partial class QueryRole : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IQueryRole
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            ttbSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryRolePresenter(this);
        }

        Views.QueryRoleArgs queryRoleArgs = new Views.QueryRoleArgs();

        #region 【实现虚方法】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridRole;
            this.B_ddl_PageSize = dropPageSize;
            return true;
        }
        #endregion

        #region【界面事件】
        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            queryRoleArgs.SearchKeyWords = ttbSearch.Text;
            queryRoleArgs.User = (DataTable)Session["User"];
            OnSearch(null, queryRoleArgs);
        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddRole.aspx","新增"));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int[] selectedArr = gridRole.SelectedRowIndexArray;
            if (selectedArr.Length == 0)
            {
                return;
            }
            List<object> idArr = new List<object>();
            for (int i = 0; i < selectedArr.Length; i++)
            {
                idArr.Add(this.gridRole.DataKeys[selectedArr[i]][0]);

            }
            queryRoleArgs.User = (DataTable)Session["User"];
            queryRoleArgs.DeleteRoleIdArr = idArr;
            OnDeleteRoleArr(null, queryRoleArgs);
            ttbSearch_Trigger2Click(null, null);
        }

        protected void gridRole_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddRole.aspx", "新增"));
        }

        protected void gridRole_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridRole.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditRole.aspx?EditRoleID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    queryRoleArgs.User = (DataTable)Session["User"];
                    queryRoleArgs.DeleteRoleId = keys[0].ToString();
                    OnDeleteRole(null, queryRoleArgs);
                    ttbSearch_Trigger2Click(null, null);
                    break;
            }
        }

        #endregion

        #region【自定义方法】
        
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtRole"></param>
        public void ExeGridRole(DataTable dtRole)
        {
            InitGrid(dtRole);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 删除单个角色
        /// </summary>
        public event EventHandler<Views.QueryRoleArgs> OnDeleteRole;

        /// <summary>
        /// 删除单个角色
        /// </summary>
        public event EventHandler<Views.QueryRoleArgs> OnDeleteRoleArr;

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QueryRoleArgs> OnSearch;
        #endregion
    }
}