using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.ExeTask
{
    public partial class SelectTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.ISelectTask
    {
        CJia.HealthInspection.Views.SelectTaskArgs selectTask = new Views.SelectTaskArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                selectTask.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
                OnInitTask(null, selectTask);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectTaskPresenter(this);
        }

        protected override bool InitPage()
        {
            this.B_gr_Main = gridTask;
            //this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        protected void gridTask_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            object[] key = gridTask.DataKeys[e.RowIndex];
            Session["TaskIdExe"] = key[0];
            Session["TaskNameExe"] = key[1];
            Session["TaskTemplateIdExe"] = key[2];
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.gridTask.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择单位...");
                return;
            }
            Session["TaskIdExe"] = gridTask.DataKeys[gridTask.SelectedRowIndexArray[0]][0];
            Session["TaskNameExe"] = gridTask.DataKeys[gridTask.SelectedRowIndexArray[0]][1];
            Session["TaskTemplateIdExe"] = gridTask.DataKeys[gridTask.SelectedRowIndexArray[0]][2];
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #region【实现接口】
        public event EventHandler<Views.SelectTaskArgs> OnInitTask;

        public event EventHandler<Views.SelectTaskArgs> OnQueryTaskByID;

        public void ExeGetSelectTask(DataTable dtTask)
        {
            Session["TaskIdExe"] = dtTask.Rows[0]["TASK_ID"];
            Session["TaskNameExe"] = dtTask.Rows[0]["TASK_NAME"];
        }

        public void ExeBindTask(System.Data.DataTable dtTask)
        {
            InitGrid(dtTask);
        }
        #endregion

        
    }
}