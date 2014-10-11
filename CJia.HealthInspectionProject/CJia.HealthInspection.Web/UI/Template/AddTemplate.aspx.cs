using CJia.HealthInspection.Views;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Template
{
    public partial class AddTemplate : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IAddTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                if (OnInit != null)
                {
                    OnInit(null, null);
                    ddl_Big_SelectedIndexChanged(null, null);
                    ddl_Middle_SelectedIndexChanged(null, null);
                    ddl_Big2_SelectedIndexChanged(null, null);
                    ddl_Middle2_SelectedIndexChanged(null, null);
                    //Common.CheckTitleToTempData = null;
                    Session["CheckTitleToTempData"] = new DataTable();
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.AddTemplatePresenter(this);
        }
        AddCheckTitleArgs addCheckTitleArgs = new AddCheckTitleArgs();
        AddTemplateArgs addTemplateArgs = new AddTemplateArgs();
        #region IAddTemplate成员
        public event EventHandler<AddCheckTitleArgs> OnInit;
        public event EventHandler<AddCheckTitleArgs> OnBigTempChange;
        public event EventHandler<AddCheckTitleArgs> OnMidTempChange;
        public event EventHandler<AddCheckTitleArgs> OnSave;
        public event EventHandler<AddCheckTitleArgs> OnSaveSingleTitle;
        public event EventHandler<AddTemplateArgs> OnSaveTemplate;
        public event EventHandler<AddTemplateArgs> OnSmlTemplateChange;
        public void ExeBindCheckTitle(DataTable data)
        {
            //CJia.HealthInspection.Tools.ExtGridBase.TemplateCheckTitleData = data;
            Session["TemplateCheckTitleData"] = new DataTable();
            Session["TemplateCheckTitleData"] = data;
            InitGrid(data);
        }
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Session["CheckTitleToTempData"] = null;
                Alert.ShowInTop("添加成功！", "提示对话框", "location.href=location.href;");
            }
            else
            {
                Alert.ShowInTop("添加失败，请与管理员联系……！", "提示对话框");
            }
        }
        public void ExeBindBigTemp(DataTable data, bool bol)
        {
            BindDDL(data, ddl_Big, "BIG_TEMPLATE_NAME", "BIG_TEMPLATE_ID");
            BindDDL(data, ddl_Big2, "BIG_TEMPLATE_NAME", "BIG_TEMPLATE_ID");
        }
        public void ExeBindMidTemp(DataTable data, bool bol)
        {
            if (!bol)
            {
                BindDDL(data, ddl_Middle, "MIDDLE_TEMPLATE_NAME", "MIDDLE_TEMPLATE_ID");
            }
            else
            {
                BindDDL(data, ddl_Middle2, "MIDDLE_TEMPLATE_NAME", "MIDDLE_TEMPLATE_ID");
            }
        }
        public void ExeBindSmallTemp(DataTable data, bool bol)
        {
            if (!bol)
            {
                BindDDL(data, ddl_Small, "SMALL_TEMPLATE_NAME", "SMALL_TEMPLATE_ID");
            }
            else
            {
                BindDDL(data, ddl_Small2, "SMALL_TEMPLATE_NAME", "SMALL_TEMPLATE_ID");
            }
        }
        #endregion

        #region 内部调用方法
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
            DataTable data = Session["CheckTitleToTempData"] as DataTable;
            //DataTable titleData = Tools.ExtGridBase.TemplateCheckTitleData;
            DataTable titleData = Session["TemplateCheckTitleData"] as DataTable;
            if (data == null || data.Rows.Count == 0)
            {
                data = titleData.Clone();
            }
            DataRow[] drs = titleData.Select(" CHECK_TITLE_ID=" + checkTitleID);
            bool bol = false;
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["CHECK_TITLE_ID"].ToString() == checkTitleID)
                    {
                        bol = true;
                        break;
                    }
                }
            }
            if (!bol)
            {
                data.Rows.Add(drs[0].ItemArray);
            }
            Session["CheckTitleToTempData"] = data;
            return data;
        }
        /// <summary>
        /// 移除检查题目
        /// </summary>
        /// <param name="checkTitleID"></param>
        /// <returns></returns>
        public DataTable RemoveCheckTitle(string checkTitleID)
        {
            DataTable data = Session["CheckTitleToTempData"] as DataTable;
            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] drs = data.Select(" CHECK_TITLE_ID=" + checkTitleID);
                data.Rows.Remove(drs[0]);
            }
            Session["CheckTitleToTempData"] = data;
            return data;
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
        #endregion

        protected override bool InitPage()
        {
            this.B_gr_Main = this.gr_Main;
            return true;
        }

        protected void ddl_Big_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnBigTempChange != null)
            {
                addCheckTitleArgs.BigTemplateID = ddl_Big.SelectedValue;
                addCheckTitleArgs.isFirst = false;
                OnBigTempChange(null, addCheckTitleArgs);
                ddl_Middle_SelectedIndexChanged(null, null);
            }
        }

        protected void ddl_Middle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnMidTempChange != null)
            {
                addCheckTitleArgs.MiddleTemplateID = ddl_Middle.SelectedValue;
                addCheckTitleArgs.isFirst = false;
                OnMidTempChange(null, addCheckTitleArgs);
            }
        }

        protected void gr_title_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gr_title.PageIndex = e.NewPageIndex;
            this.InitGrid(Session["CheckTitleToTempData"] as DataTable);
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

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
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

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable data = Session["CheckTitleToTempData"] as DataTable;
            if (data != null && data.Rows.Count > 0)
            {
                if (OnSaveTemplate != null)
                {
                    addTemplateArgs.SmallTemplateID = ddl_Small.SelectedValue;
                    addTemplateArgs.TemplateName = txt_TemplateName.Text;
                    addTemplateArgs.CheckTitleToTempData = data;
                    addTemplateArgs.OrganId = ((DataTable)Session["User"]).Rows[0]["organ_id"].ToString();
                    OnSaveTemplate(null, addTemplateArgs);
                }
            }
            else
            {
                Alert.ShowInTop("请向模板中添加检查题目");
            }
        }

        protected void ddl_Big2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnBigTempChange != null)
            {
                addCheckTitleArgs.BigTemplateID = ddl_Big2.SelectedValue;
                addCheckTitleArgs.isFirst = true;
                OnBigTempChange(null, addCheckTitleArgs);
                ddl_Middle2_SelectedIndexChanged(null, null);
            }
        }

        protected void ddl_Middle2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnMidTempChange != null)
            {
                addCheckTitleArgs.MiddleTemplateID = ddl_Middle2.SelectedValue;
                addCheckTitleArgs.isFirst = true;
                OnMidTempChange(null, addCheckTitleArgs);
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请至少选择一道检查题...");
                return;
            }
            string[] ids = new string[this.gr_Main.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_Main.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_Main.DataKeys[this.gr_Main.SelectedRowIndexArray[i]][0].ToString();
            }
            foreach (string str in ids)
            {
                BindGRTitle(AddCheckTitleToTemp(str));
            }
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            if (OnSmlTemplateChange != null)
            {
                addTemplateArgs.SmallTemplateID = ddl_Small2.SelectedValue;
                addTemplateArgs.OrganId = ((DataTable)Session["User"]).Rows[0]["organ_id"].ToString();
                OnSmlTemplateChange(null, addTemplateArgs);
            }
        }


        
    }
}