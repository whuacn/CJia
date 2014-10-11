using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    /// <summary>
    /// 超级管理员查询用户页面
    /// </summary>
    public partial class QuerySupervise : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IQuerySupervise
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            //if (!IsPostBack)
            //{
            //    querySupArgs.User = (DataTable)Session["User"];
            //    OnInit(null,querySupArgs);
            //}
            btnSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QuerySupervisePresenter(this);
        }

        Views.QuerySuperviseArgs querySupArgs = new Views.QuerySuperviseArgs();

        #region【虚方法实现】
       
        #endregion

        #region【界面事件】
        protected void btnNewSupervise_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddSupervise.aspx", "添加"));
        }

        protected void gridUser_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridUser.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditSupervise.aspx?isEdit=1&EditSuperviseID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    querySupArgs.User = (DataTable)Session["User"];
                    querySupArgs.DeletedUserId = keys[0].ToString();
                    OnDeleteUserId(null, querySupArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
            }
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
            querySupArgs.User = (DataTable)Session["User"];
            querySupArgs.DeletedUserArr = idArr;
            OnDeletedUserArr(null, querySupArgs);
            btnSearch_Trigger2Click(null, null);
        }

        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            querySupArgs.SearchKeyWords = btnSearch.Text;
            querySupArgs.User = (DataTable)Session["User"];
            OnSearch(null, querySupArgs);
        }

        protected void gridUser_RowDataBound(object sender, GridRowEventArgs e)
        {
            //// 查找user_type所在列数
            //int userTypeRowsValue = gridUser.FindColumn("user_type").ColumnIndex;
            //string userType = gridUser.Rows[e.RowIndex].Values[userTypeRowsValue];

            ////如果是超级管理员，编辑为灰色
            //LinkButtonField lbfEdit = gridUser.FindColumn("lbf_Edit") as LinkButtonField;
            //if (userType == "0")
            //{
            //    lbfEdit.Enabled = true;
            //}
            //else
            //{
            //    lbfEdit.Enabled = false;
            //}

            //// 查找user_type所在列数
            //int userTypeRowsValue = gridUser.FindColumn("user_type").ColumnIndex;
            //string userType = gridUser.Rows[e.RowIndex].Values[userTypeRowsValue];

            ////如果是超级管理员，编辑为灰色
            //LinkButtonField lbfEdit = gridUser.FindColumn("lbf_Edit") as LinkButtonField;
            ////如果是超级管理员，编辑为灰色
            //LinkButtonField lbfDelete = gridUser.FindColumn("lbf_Delete") as LinkButtonField;

            //if (userType == "0")
            //{
            //    lbfEdit.Enabled = false;
            //    lbfDelete.Enabled = false;
            //}
            //else
            //{
            //    if (userType == "1")
            //    {
            //        lbfEdit.Enabled = false;
            //        lbfDelete.Enabled = true;
            //    }
            //    else
            //    {
            //        lbfEdit.Enabled = true;
            //        lbfDelete.Enabled = true;
            //    }
            //}

        }

        // 绑定界面“编辑”“删除”状态
        protected void gridUser_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            //如果是超级管理员，编辑为灰色
            LinkButtonField lbfEdit = gridUser.FindColumn("lbf_Edit") as LinkButtonField;
            //如果是超级管理员（最高级），删除为灰色
            LinkButtonField lbfDelete = gridUser.FindColumn("lbf_Delete") as LinkButtonField;
            object[] a = (e.DataItem as DataRowView).Row.ItemArray;
            string b = a[11].ToString();
            if (b == "0")
            {
                lbfEdit.Enabled = false;
                lbfDelete.Enabled = false;
            }
            else
            {
                if (b == "1")
                {
                    lbfEdit.Enabled = false;
                    lbfDelete.Enabled = true;
                }
                else
                {
                    lbfEdit.Enabled = true;
                    lbfDelete.Enabled = true;
                }
            }

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
            InitGrid(dtUser);
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        public void ExeMessageBox(string message)
        {
            Alert.ShowInTop(message, "提示对话框", "location.href=location.href;");
        }
        #endregion

        #region【接口事件】
        ///// <summary>
        ///// 初始化事件
        ///// </summary>
        //public event EventHandler<Views.QuerySuperviseArgs> OnInit;

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QuerySuperviseArgs> OnSearch;

        /// <summary>
        /// 删除单个任务事件
        /// </summary>
        public event EventHandler<Views.QuerySuperviseArgs> OnDeleteUserId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        public event EventHandler<Views.QuerySuperviseArgs> OnDeletedUserArr;
        #endregion
       
    }
}
