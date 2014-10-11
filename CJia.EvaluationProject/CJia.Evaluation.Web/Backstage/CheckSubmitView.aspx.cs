using CJia.Evaluation.Views.Backstage;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class CheckSubmitView : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.ICheckSubmit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {

                if (OnInitPage != null)
                {
                    OnInitPage(null, null);
                    rbState_SelectedIndexChanged(null, null);
                }
            }
        }
        protected override bool InitPage()
        {
            if (Request.QueryString["id"] != null)
            {
                InitPageControls(Request.QueryString["id"]);//初始化页面
            }
            this.B_gr_Main = this.gr_Main;
            return true;
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.CheckSubmitPresenter(this);
        }
        CheckSubmit checkSubmitArgs = new CheckSubmit();
        public event EventHandler OnInitPage;
        public event EventHandler<CheckSubmit> OnIndexChange;
        public event EventHandler<CheckSubmit> OnSubmit;
        public event EventHandler<CheckSubmit> OnReadDetail;
        public event EventHandler<CheckSubmit> OnSaveCheck;
        public void ExeBindIsSuccessCheck(bool bol)
        {

        }
        public void ExeBindCheckDetail(DataTable data)
        { }
        public void ExeBindIsSuccessSubmit(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("提交成功！", "提示对话框", "location.href=location.href;");
            }
            else
            {
                Alert.ShowInTop("提交失败，请与管理员联系……！", "提示对话框");
            }
        }
        public void ExeBindCheckData(DataTable data)
        {
            InitGrid(data);
        }
        public void ExeBindPage(DataTable stateData, DataTable resultData)
        {
            if (stateData != null && stateData.Rows.Count > 0)
            {
                string id = Request.QueryString["id"];
                if (id == "2")
                {
                    stateData.Rows.RemoveAt(0);
                }
                else if (id == "3")
                {
                    DataRow dr = stateData.NewRow();
                    dr["NAME"] = "全部";
                    dr["CODE"] = "0";
                    stateData.Rows.InsertAt(dr, stateData.Rows.Count);
                }
                rbState.DataTextField = "NAME";
                rbState.DataValueField = "CODE";
                rbState.DataSource = stateData;
                rbState.DataBind();
                rbState.SelectedIndex = 0;
            }
        }

        protected void rbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnIndexChange != null)
            {
                if (rbState.SelectedValue == "1201" || rbState.SelectedValue == "1204")
                {
                    btnSubmit.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                }
                checkSubmitArgs.CheckStateID = rbState.SelectedValue;
                OnIndexChange(null, checkSubmitArgs);
            }
        }

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Read":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("CheckResultDetial.aspx?ID=" + keys[0].ToString(), "详情"));
                    break;
                case "Check":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("CheckEditView.aspx?ID=" + keys[0].ToString(), "评审"));
                    break;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一条款...");
                return;
            }
            string[] ids = new string[this.gr_Main.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_Main.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_Main.DataKeys[this.gr_Main.SelectedRowIndexArray[i]][0].ToString();
            }
            if (OnSubmit != null)
            {
                DataTable userData = Session["User"] as DataTable;
                checkSubmitArgs.TreeIDs = ids;
                if (userData != null)
                {
                    checkSubmitArgs.UserID = userData.Rows[0]["USER_ID"].ToString();
                    checkSubmitArgs.UserName = userData.Rows[0]["USER_NAME"].ToString();
                }
                OnSubmit(null, checkSubmitArgs);
            }
        }
        public void InitPageControls(string id)
        {
            LinkButtonField lf = (LinkButtonField)(gr_Main.Columns[7]);
            if (id == "2")
            {
                gr_Main.EnableCheckBoxSelect = false;
                btnSubmit.Visible = false;
                lf.HeaderText = "评审";
                lf.CommandName = "Check";
                lf.Icon = ExtAspNet.Icon.BookEdit;
                win_Edit.Width = 650;
                win_Edit.Height = 440;
                win_Edit.Icon = ExtAspNet.Icon.BookEdit;
            }
            else if (id == "3")
            {
                rbState.Width = 350;
                rbState.ColumnNumber = 5;
                gr_Main.EnableCheckBoxSelect = false;
                btnSubmit.Visible = false;
            }
        }

        protected void win_Edit_Close(object sender, WindowCloseEventArgs e)
        {
            rbState_SelectedIndexChanged(null, null);
        }
    }
}