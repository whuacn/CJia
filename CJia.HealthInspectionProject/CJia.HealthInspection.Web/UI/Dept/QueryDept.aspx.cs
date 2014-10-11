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
    public partial class QueryDept : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IQueryDept
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            btnSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryDeptPresenter(this);
        }

        Views.QueryDeptArgs queryDeptArgs = new Views.QueryDeptArgs();

        #region【界面事件】
        protected void gridDept_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridDept.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditDept.aspx?isEdit=1&EditDeptID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    queryDeptArgs.User = (DataTable)Session["User"];
                    queryDeptArgs.DeletedDeptId = keys[0].ToString();
                    OnDeleteDeptById(null, queryDeptArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
            }
        }

        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            queryDeptArgs.SearchKeyWords = btnSearch.Text;
            queryDeptArgs.User = (DataTable)Session["User"];
            OnSearch(null, queryDeptArgs);
        }

        protected void btnDataBaseDelete_Click(object sender, EventArgs e)
        {
            int[] selectedArr = gridDept.SelectedRowIndexArray;
            if (selectedArr.Length == 0)
            {
                return;
            }
            List<object> idArr = new List<object>();
            for (int i = 0; i < selectedArr.Length; i++)
            {
                idArr.Add(this.gridDept.DataKeys[selectedArr[i]][0]);

            }
            queryDeptArgs.User = (DataTable)Session["User"];
            queryDeptArgs.DeletedDeptArr = idArr;
            OnDeletedDeptArr(null, queryDeptArgs);
            btnSearch_Trigger2Click(null, null);
        }
        #endregion

        #region【自定义方法】
          /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridDept;
            this.B_ddl_PageSize = dropPageSize;
            return true;
        }
       
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定界面部门Grid
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeGridDept(DataTable dtUser)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtUser.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridDept.PageSize;
            ps.CurrentPageIndex = gridDept.PageIndex;
            gridDept.RecordCount = dtUser.Rows.Count;
            gridDept.DataSource = dtUser;
            gridDept.DataBind();
            InitGrid(dtUser);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 根据Id删除部门
        /// </summary>
        public event EventHandler<Views.QueryDeptArgs> OnDeleteDeptById;

        /// <summary>
        /// 删除所选部门组
        /// </summary>
        public event EventHandler<Views.QueryDeptArgs> OnDeletedDeptArr;

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QueryDeptArgs> OnSearch;
        #endregion
    }
}