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
    public partial class EditCheckTitle : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IEditCheckTitle
    {
        CJia.HealthInspection.Views.EditCheckTitleArgs editCheckTitleArgs = new Views.EditCheckTitleArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                DataTable dtTitle = Session["ExeCheckTitleList"] as DataTable;
                if (dtTitle != null && dtTitle.Rows != null && dtTitle.Rows.Count > 0)
                {
                    InitGrid(dtTitle);
                }
                OnInit(null, null);
                ddl_Big_SelectedIndexChanged(null, null);
                ddl_Middle_SelectedIndexChanged(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.EditCheckTitlePresenter(this);
        }

        protected override bool InitPage()
        {
            this.B_gr_Main = gr_title;
            //this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        protected void gr_title_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_title.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Details":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("../CheckTitle/CheckTitleEdit.aspx?isEdit=0&ID=" + keys[0].ToString(), "详情"));
                    break;
                case "Delete":
                    BindGRTitle(RemoveCheckTitle(keys[0].ToString()));
                    break;
            }
        }

        protected void gr_SingleTitle_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_SingleTitle.DataKeys[e.RowIndex];
            //if (Session["ExeCheckTitleClassList"] == null)
            //{
            //    List<AnswerTitle> ListAnswerTitle = new List<AnswerTitle>();
            //    Session["ExeCheckTitleClassList"] = ListAnswerTitle;
            //}
            switch (e.CommandName)
            {
                case "Details":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("../CheckTitle/CheckTitleEdit.aspx?isEdit=0&ID=" + keys[0].ToString(), "详情"));
                    break;
                case "Add":
                    BindGRTitle(AddCheckTitleToTemp(keys[0].ToString()));
                    break;
            }
        }

        protected void gr_SingleTitle_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {

            if (Session["SingleTitle"] != null)
            {
                gr_SingleTitle.PageIndex = e.NewPageIndex;
                DataTable dt = Session["SingleTitle"] as DataTable;
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = dt.DefaultView;
                ps.AllowPaging = true; //是否可以分页
                ps.PageSize = gr_SingleTitle.PageSize; //显示的数量
                ps.CurrentPageIndex = gr_SingleTitle.PageIndex; //取得当前页的页码
                gr_SingleTitle.RecordCount = dt.Rows.Count;
                gr_SingleTitle.DataSource = ps;
                gr_SingleTitle.DataBind();
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (this.gr_SingleTitle.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一道检查题...");
                return;
            }
            string[] ids = new string[this.gr_SingleTitle.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_SingleTitle.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_SingleTitle.DataKeys[this.gr_SingleTitle.SelectedRowIndexArray[i]][0].ToString();
            }
            //if (Session["ExeCheckTitleClassList"] == null)
            //{
            //    List<AnswerTitle> ListAnswerTitle = new List<AnswerTitle>();
            //    Session["ExeCheckTitleClassList"] = ListAnswerTitle;
            //}
            foreach (string str in ids)
            {
                BindGRTitle(AddCheckTitleToTemp(str));
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void ddl_Big_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Big.SelectedValue == "0")
            {
                ddl_Middle.Items.Clear();
                ddl_Middle.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                ddl_Middle.SelectedValue = "0";
                ddl_Small.Items.Clear();
                ddl_Small.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                ddl_Small.SelectedValue = "0";
            }
            else
            {
                editCheckTitleArgs.BigTempID = ddl_Big.SelectedValue;
                OnBigChanged(null, editCheckTitleArgs);
                ddl_Middle_SelectedIndexChanged(null, null);
            }
        }

        protected void ddl_Middle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Middle.SelectedValue == "0" || ddl_Middle.SelectedValue == null)
            {
                ddl_Small.Items.Clear();
                ddl_Small.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                ddl_Small.SelectedValue = "0";
            }
            else
            {
                editCheckTitleArgs.MidTempID = ddl_Middle.SelectedValue;
                OnMidChanged(null, editCheckTitleArgs);
            }
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            editCheckTitleArgs.organ = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            editCheckTitleArgs.BigTempID = ddl_Big.SelectedValue == "0" ? "" : ddl_Big.SelectedValue;
            editCheckTitleArgs.MidTempID = ddl_Middle.SelectedValue == "0" ? "" : ddl_Middle.SelectedValue;
            editCheckTitleArgs.SmallTempID = ddl_Small.SelectedValue == "0" ? "" : ddl_Small.SelectedValue;
            OnGetTitleBySmallType(null, editCheckTitleArgs);
        }

        #region【内部方法】
        /// <summary>
        /// 移除检查题目
        /// </summary>
        /// <param name="checkTitleID"></param>
        /// <returns></returns>
        public DataTable RemoveCheckTitle(string checkTitleID)
        {
            //if (Session["ExeCheckTitleClassList"] != null && (Session["ExeCheckTitleClassList"] as List<AnswerTitle>) != null && (Session["ExeCheckTitleClassList"] as List<AnswerTitle>).Count>0)
            //{
                DataTable data = Session["ExeCheckTitleList"] as DataTable;
                if (data != null && data.Rows.Count > 0)
                {
                    DataRow[] drs = data.Select(" CHECK_TITLE_ID=" + checkTitleID);
                    data.Rows.Remove(drs[0]);
                    //List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                    //AnswerTitle answer = ListAnswerTitle.Find(delegate(AnswerTitle v) { return v.TitleID == Convert.ToInt64(checkTitleID); });
                    //ListAnswerTitle.Remove(answer);
                    //Session["ExeCheckTitleClassList"] = ListAnswerTitle;
                }
                Session["ExeCheckTitleList"] = data;
                return data;
            //}
            //else
            //    return null;
        }

        /// <summary>
        /// 绑定添加的检查题目
        /// </summary>
        /// <param name="data"></param>
        public void BindGRTitle(DataTable data)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = data.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = gr_title.PageSize; //显示的数量
            ps.CurrentPageIndex = gr_title.PageIndex; //取得当前页的页码
            gr_title.RecordCount = data.Rows.Count;
            gr_title.DataSource = ps;
            gr_title.DataBind();
        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ddl"></param>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public void BindDDL(DataTable data, ExtAspNet.DropDownList ddl, string text, string value)
        {
            ddl.DataSource = data;
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }

        /// <summary>
        /// 想模板中添加检查题目
        /// </summary>
        /// <param name="checkTitleID"></param>
        /// <returns></returns>
        public DataTable AddCheckTitleToTemp(string checkTitleID)
        {
            DataTable data = Session["ExeCheckTitleList"] as DataTable;
            //DataTable titleData = Tools.ExtGridBase.TemplateCheckTitleData;
            DataTable titleData = Session["SingleTitle"] as DataTable;
            DataRow[] drs = titleData.Select(" CHECK_TITLE_ID=" + checkTitleID);
            bool bol = false;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["CHECK_TITLE_ID"].ToString() == checkTitleID)
                    {
                        bol = true;
                        Alert.ShowInTop("题目【" + dr["CHECK_TITLE_NAME"].ToString() + "】已在检查题目列表中。", MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else
            {
                data = new DataTable();
                data.Columns.Add(new DataColumn("CHECK_TITLE_ID"));
                data.Columns.Add(new DataColumn("CHECK_TITLE_NAME"));
                data.Columns.Add(new DataColumn("CHECK_TITLE_CONTENT"));
            }
            if (!bol)
            {
                DataRow dr = data.NewRow();
                dr["CHECK_TITLE_ID"] = drs[0]["CHECK_TITLE_ID"];
                dr["CHECK_TITLE_NAME"] = drs[0]["CHECK_TITLE_NAME"];
                dr["CHECK_TITLE_CONTENT"] = drs[0]["CHECK_TITLE_CONTENT"];
                data.Rows.Add(dr.ItemArray);
                //List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                //AnswerTitle SingleTitle = new AnswerTitle();
                //SingleTitle.TitleID = Convert.ToInt64(drs[0]["CHECK_TITLE_ID"]);
                //SingleTitle.TitleName = drs[0]["CHECK_TITLE_NAME"].ToString();
                //SingleTitle.TitleContent = drs[0]["CHECK_TITLE_CONTENT"].ToString();
                //ListAnswerTitle.Add(SingleTitle);
                //Session["ExeCheckTitleClassList"] = ListAnswerTitle;
            }
            Session["ExeCheckTitleList"] = data;
            return data;
        }
        #endregion

        #region【实现接口】
        public new event EventHandler<Views.EditCheckTitleArgs> OnInit;

        public event EventHandler<Views.EditCheckTitleArgs> OnBigChanged;

        public event EventHandler<Views.EditCheckTitleArgs> OnMidChanged;

        public event EventHandler<Views.EditCheckTitleArgs> OnGetTitleBySmallType;

        public void ExeBindBigTempType(DataTable dtBigTemp)
        {
            if (dtBigTemp != null)
            {
                BindDDL(dtBigTemp, ddl_Big, "BIG_TEMPLATE_NAME", "BIG_TEMPLATE_ID");
                ddl_Big.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
            }
        }

        public void ExeBindMidTempType(DataTable dtMidTemp)
        {
            if (dtMidTemp != null)
            {
                BindDDL(dtMidTemp, ddl_Middle, "MIDDLE_TEMPLATE_NAME", "MIDDLE_TEMPLATE_ID");
                ddl_Middle.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
            }
        }

        public void ExeBindSmallTemptype(DataTable dtSmallTemp)
        {
            if (dtSmallTemp != null)
            {
                BindDDL(dtSmallTemp, ddl_Small, "SMALL_TEMPLATE_NAME", "SMALL_TEMPLATE_ID");
                ddl_Small.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
            }
        }

        public void ExeBindTitle(DataTable dtTitle)
        {
            Session["SingleTitle"] = dtTitle;
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtTitle.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = gr_SingleTitle.PageSize; //显示的数量
            ps.CurrentPageIndex = gr_SingleTitle.PageIndex; //取得当前页的页码
            gr_SingleTitle.RecordCount = dtTitle.Rows.Count;
            gr_SingleTitle.DataSource = ps;
            gr_SingleTitle.DataBind();

        }
        #endregion





        
    }
}