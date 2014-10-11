using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    public partial class SelectUnit : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.ISelectUnit
    {
        CJia.HealthInspection.Views.SelectUnitArgs selectUnitArgs = new Views.SelectUnitArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectUnitPresenter(this);
        }

        protected override bool InitPage()
        {
            this.B_gr_Main = gridUnit;
            //this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            selectUnitArgs.KeyWord = txt_Unit.Text;
            selectUnitArgs.Organ_id = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            OnQueryUnitByKew(null, selectUnitArgs);
        }


        protected void gridUnit_PreRowDataBound(object sender, ExtAspNet.GridPreRowEventArgs e)
        {

        }

        protected void gridUnit_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            object[] key = gridUnit.DataKeys[e.RowIndex];
            selectUnitArgs.UnitId = Convert.ToInt64(key[0]);
            OnQueryUnitById(null, selectUnitArgs);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.gridUnit.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择单位...");
                return;
            }
            selectUnitArgs.UnitId = (long)gridUnit.DataKeys[gridUnit.SelectedRowIndexArray[0]][0];
            OnQueryUnitById(null, selectUnitArgs);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #region
        public event EventHandler<Views.SelectUnitArgs> OnQueryUnitByKew;

        public event EventHandler<Views.SelectUnitArgs> OnQueryUnitById;

        public void ExeBindGrid(System.Data.DataTable dt)
        {
            //PagedDataSource ps = new PagedDataSource();
            //ps.DataSource = dt.DefaultView;
            //ps.AllowPaging = true;
            //ps.PageSize = gridUnit.PageSize;
            //ps.CurrentPageIndex = gridUnit.PageIndex;
            //gridUnit.RecordCount = gridUnit.Rows.Count;
            //gridUnit.DataSource = dt;
            //gridUnit.DataBind();
            //CJia.HealthInspection.Tools.ExtGridBase.UnitData = dt;
            InitGrid(dt);
        }

        public void ExeGetUnitInfo(System.Data.DataTable dt)
        {
            if (Request.QueryString["WhichPage"] == "Check")
            {
                Session["UnitID"] = dt.Rows[0]["UNIT_ID"];
                Session["UnitName"] = dt.Rows[0]["UNIT_NAME"];
                Session["UnitAddress"] = dt.Rows[0]["UNIT_ADDRESS"];
            }
            if (Request.QueryString["WhichPage"] == "Task")
            {
                Session["UnitIdTask"] = dt.Rows[0]["UNIT_ID"];
                Session["UnitNameTask"] = dt.Rows[0]["UNIT_NAME"];
                Session["UnitAddressTask"] = dt.Rows[0]["UNIT_ADDRESS"];
            }
            //Common.UnitId = Convert.ToInt64(dt.Rows[0]["UNIT_ID"]);
            //Common.UnitName = dt.Rows[0]["UNIT_NAME"].ToString();
            //Common.UnitAddress = dt.Rows[0]["UNIT_ADDRESS"].ToString();
        }
        #endregion

    }
}