using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Organ
{
    public partial class QueryOrgan : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IQueryOrgan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            btnSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.QueryOrganPresenter(this);
        }

        Views.QueryOrganArgs queryOrganArgs = new Views.QueryOrganArgs();

        #region【虚方法实现】
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

        #region【界面事件】

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddOrgan.aspx", "添加"));
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
            queryOrganArgs.User = (DataTable)Session["User"];
            queryOrganArgs.DeletedOrganArr = idArr;
            OnDeletedOrganArr(null, queryOrganArgs);
            btnSearch_Trigger2Click(null, null);
        }

        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            queryOrganArgs.SearchKeyWords = btnSearch.Text;
            queryOrganArgs.User = (DataTable)Session["User"];
            OnSearch(null, queryOrganArgs);
        }

        protected void gridUser_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gridUser.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditOrgan.aspx?EditOrganID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    queryOrganArgs.User = (DataTable)Session["User"];
                    queryOrganArgs.DeletedOrganId = keys[0].ToString();
                    OnDeleteOrganId(null, queryOrganArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
            }
        }
        #endregion

        #region【自定义方法】
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定组织
        /// </summary>
        /// <param name="dtOrgan"></param>
        public void ExeGridOrgan(DataTable dtOrgan)
        {
            InitGrid(dtOrgan);
        }
        #endregion

        #region【接口事件】

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.QueryOrganArgs> OnSearch;

        /// <summary>
        /// 删除单个组织
        /// </summary>
        public event EventHandler<Views.QueryOrganArgs> OnDeleteOrganId;

        /// <summary>
        /// 删除所选多个组织
        /// </summary>
        public event EventHandler<Views.QueryOrganArgs> OnDeletedOrganArr;
        #endregion

        
    }
}