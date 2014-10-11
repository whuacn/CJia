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
    public partial class SelectOrgan : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.ISelectOrgan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            ttbSearch_Trigger2Click(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectOrganPresenter(this);
        }

        Views.SelectOrganArgs selectOrgan = new Views.SelectOrganArgs();

        #region【界面事件】
        protected void gridOrgan_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            SetValue();
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            selectOrgan.SearchKeyWord = ttbSearch.Text;
            OnSearchOragn(null,selectOrgan);
        }

        protected void btnOk_Click(object sender, EventArgs e)
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
            this.B_gr_Main = gridOrgan;
            return true;
        }

        /// <summary>
        /// 选择组织后赋值并关闭窗口
        /// </summary>
        public void SetValue()
        {
            if (this.gridOrgan.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择组织...");
                return;
            }
            string selectedId = gridOrgan.DataKeys[gridOrgan.SelectedRowIndexArray[0]][0].ToString();
            selectOrgan.SelectedOrganId = selectedId;
            
            if (Request.QueryString["status"] == "addSupervise")
            {
                Session["SelectedOrganIdSuperviseAdd"] = selectedId;
                OnQueryOrganNameById(null, selectOrgan);
                Session["SelectedOrganNameSuperviseAdd"] = selectOrgan.SelectedOrganName;
            }
            if (Request.QueryString["status"] == "editSupervise")
            {
                Session["SelectedOrganIdSupersiveEdit"] = selectedId;
                OnQueryOrganNameById(null, selectOrgan);
                Session["SelectedOrganNameSupersiveEdit"] = selectOrgan.SelectedOrganName;
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【接口实现】
        /// <summary>
        /// 绑定Grid组织
        /// </summary>
        /// <param name="dtOrgan"></param>
        public void ExeGridOrgan(DataTable dtOrgan)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtOrgan.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridOrgan.PageSize;
            ps.CurrentPageIndex = gridOrgan.PageIndex;
            gridOrgan.RecordCount = dtOrgan.Rows.Count;
            gridOrgan.DataSource = dtOrgan;
            gridOrgan.DataBind();
            InitGrid(dtOrgan);
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 查询组织事件
        /// </summary>
        public event EventHandler<Views.SelectOrganArgs> OnSearchOragn;

        /// <summary>
        /// 根据组织Id查询名称
        /// </summary>
        public event EventHandler<Views.SelectOrganArgs> OnQueryOrganNameById;
        #endregion
    }
}