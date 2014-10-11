using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.HealthInspection.Web.UI
{
    public partial class UnitSelect : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IUnitSelect
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (IsPostBack)
            {
                //if (OnGetAllUnit != null)
                //{
                //    unitSelectArgs.User = ((DataTable)Session["User"]);
                //    OnGetAllUnit(null, unitSelectArgs);
                //}
                btnSearch_Trigger2Click(null, null);
            }
           
        }

        Views.UnitSelectEventArgs unitSelectArgs = new Views.UnitSelectEventArgs();
        protected override object CreatePresenter()
        {
            return new Presenters.UnitSelectPresenter(this);
        }

        #region【界面事件】
        protected void gr_Main_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditUnit.aspx?EditUnitId="+keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    unitSelectArgs.User = (DataTable)Session["User"];
                    unitSelectArgs.DeletedUnitId = keys[0].ToString();
                    OnDeleteUnitId(null, unitSelectArgs);
                    btnSearch_Trigger2Click(null, null);
                    break;
            }
        }

        protected void btnDataBaseDelete_Click(object sender, EventArgs e)
        {
            int[] selectedArr = gr_Main.SelectedRowIndexArray;
            if (selectedArr.Length == 0)
            {
                return;
            }
            List<object> idArr = new List<object>();
            for (int i = 0; i < selectedArr.Length; i++)
            {
                idArr.Add(this.gr_Main.DataKeys[selectedArr[i]][0]);

            }
            unitSelectArgs.User = (DataTable)Session["User"];
            unitSelectArgs.DeletedUnitArr = idArr;
            OnDeletedUnitArr(null, unitSelectArgs);
            btnSearch_Trigger2Click(null, null);
        }

        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            unitSelectArgs.SearchKeyWords = btnSearch.Text;
            unitSelectArgs.User = (DataTable)Session["User"];
            OnSearch(null, unitSelectArgs);
        }
        #endregion

        #region【自定义方法】

        protected override bool InitPage()
        {
            this.B_gr_Main = gr_Main;
            this.B_ddl_PageSize = ddl_PageSize;
            return true;
        }

        #endregion

        #region【接口实现】
        public void ExeBindAllUnit(DataTable data)
        {
            InitGrid(data);
        }
        #endregion

        #region【接口事件】

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.UnitSelectEventArgs> OnSearch;

        /// <summary>
        /// 删除单个单位事件
        /// </summary>
        public event EventHandler<Views.UnitSelectEventArgs> OnDeleteUnitId;

        /// <summary>
        /// 删除所选单位组
        /// </summary>
        public event EventHandler<Views.UnitSelectEventArgs> OnDeletedUnitArr;
        #endregion

    }
}