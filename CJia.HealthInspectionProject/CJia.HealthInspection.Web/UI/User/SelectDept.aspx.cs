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
    public partial class SelectDept : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.ISelectDept
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                selectDeptArgs.User = (DataTable)Session["User"];
                OnInit(null,selectDeptArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectDeptPresenter(this);
        }

        Views.SelectDeptArgs selectDeptArgs = new Views.SelectDeptArgs();

        #region【界面事件】
        protected void btnSearch_Trigger2Click(object sender, EventArgs e)
        {
            selectDeptArgs.SearchKey = ttbSearch.Text;
            selectDeptArgs.User = (DataTable)Session["User"];
            OnSearchDept(null,selectDeptArgs);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            SetValue();
        }

        protected void gridDept_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            SetValue();
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
            return true;
        }

        /// <summary>
        /// 选择单位后赋值并关闭窗口
        /// </summary>
        void SetValue()
        {
            if (this.gridDept.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择单位...");
                return;
            }
            if (Request.QueryString["status"] == "add")
            {
                Session["SelectedDeptIdAdd"] = gridDept.DataKeys[gridDept.SelectedRowIndexArray[0]][0].ToString();
                selectDeptArgs.SelectedDeptId = gridDept.DataKeys[gridDept.SelectedRowIndexArray[0]][0].ToString();
                //Common.SelectedDeptId = gridDept.DataKeys[gridDept.SelectedRowIndexArray[0]][0].ToString();
                OnQueryDeptNameById(null, selectDeptArgs);
                Session["SelectedDeptNameAdd"] = selectDeptArgs.SelectedDeptName;
            }
            if (Request.QueryString["status"] == "edit")
            {
                Session["SelectedDeptIdEdit"] = gridDept.DataKeys[gridDept.SelectedRowIndexArray[0]][0].ToString();
                selectDeptArgs.SelectedDeptId = gridDept.DataKeys[gridDept.SelectedRowIndexArray[0]][0].ToString();
                OnQueryDeptNameById(null, selectDeptArgs);
                Session["SelectedDeptNameEdit"] = selectDeptArgs.SelectedDeptName;
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference()); // 关闭当前窗口
        }
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定Grid单位
        /// </summary>
        /// <param name="dtDept"></param>
        public void ExeGridDept(DataTable dtDept)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtDept.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridDept.PageSize;
            ps.CurrentPageIndex = gridDept.PageIndex;
            gridDept.RecordCount = dtDept.Rows.Count;
            gridDept.DataSource = dtDept;
            gridDept.DataBind();
            InitGrid(dtDept);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.SelectDeptArgs> OnInit;

        /// <summary>
        /// 查询部门
        /// </summary>
        public event EventHandler<Views.SelectDeptArgs> OnSearchDept;

        /// <summary>
        /// 根据部门Id查询名称
        /// </summary>
        public event EventHandler<Views.SelectDeptArgs> OnQueryDeptNameById;
        #endregion

      
    }
}