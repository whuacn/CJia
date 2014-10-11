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
    public partial class QueryUser : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IQueryUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            btnSearch_Trigger2Click(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.QueryUserPresenter(this);
        }

        Views.QueryUserArgs queryUserArgs = new Views.QueryUserArgs();

        #region【界面事件】

        protected void gridUser_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridUser.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditUser.aspx?EditUserID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    queryUserArgs.User = (DataTable)Session["User"];
                    queryUserArgs.DeletedUserId = keys[0].ToString();
                    OnDeleteUserId(null, queryUserArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddUser.aspx", "添加"));
        }

        protected void btnDataBaseDelete_Click(object sender, EventArgs e)
        {
            int[] selectedArr = gridUser.SelectedRowIndexArray;
            if (selectedArr.Length == 0)
            {
                return;
            }
            List<object> idArr = new List<object>();
            for (int i = 0; i < selectedArr.Length; i++)
            {
                idArr.Add(this.gridUser.DataKeys[selectedArr[i]][0]);

            }
            queryUserArgs.User = (DataTable)Session["User"];
            queryUserArgs.DeletedUserArr = idArr;
            OnDeletedUserArr(null, queryUserArgs);
            btnSearch_Trigger2Click(null, null);
        }

        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            queryUserArgs.SearchKeyWords = btnSearch.Text;
            queryUserArgs.User = (DataTable)Session["User"];
            OnSearch(null, queryUserArgs);
        }
        #endregion

        #region【自定义方法】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridUser;
            this.B_ddl_PageSize = dropPageSize;
            return true;
        }
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定界面人员Grid
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeGridUser(DataTable dtUser)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtUser.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridUser.PageSize;
            ps.CurrentPageIndex = gridUser.PageIndex;
            gridUser.RecordCount = dtUser.Rows.Count;
            gridUser.DataSource = dtUser;
            gridUser.DataBind();
            InitGrid(dtUser);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QueryUserArgs> OnSearch;

        /// <summary>
        /// 删除单个任务事件
        /// </summary>
        public event EventHandler<Views.QueryUserArgs> OnDeleteUserId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        public event EventHandler<Views.QueryUserArgs> OnDeletedUserArr;
        #endregion

        // 绑定界面“编辑”“删除”状态
        protected void gridUser_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            //如果是超级管理员，编辑为灰色
            LinkButtonField lbfEdit = gridUser.FindColumn("lbf_Edit") as LinkButtonField;
            //如果是超级管理员（最高级），删除为灰色
            LinkButtonField lbfDelete = gridUser.FindColumn("lbf_Delete") as LinkButtonField;
            object[] a = (e.DataItem as DataRowView).Row.ItemArray;
            string b = a[11].ToString();
            if (b == "2")
            {
                lbfEdit.Enabled = false;
                lbfDelete.Enabled = false;
            }
            else
            {
                lbfEdit.Enabled = true;
                lbfDelete.Enabled = true;
                //if (b == "1")
                //{
                //    lbfEdit.Enabled = false;
                //    lbfDelete.Enabled = true;
                //}
                //else
                //{
                //    lbfEdit.Enabled = true;
                //    lbfDelete.Enabled = true;
                //}
            }

        }

        

    }
}