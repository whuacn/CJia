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
    public partial class EditTemplate : Tools.Page,Views.IEditTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                if (OnInit != null)
                { 
                    addCheckTitleArgs.TemplateID=this.Request["ID"].ToString();
                    OnInit(null, addCheckTitleArgs);
                    ddl_Big_SelectedIndexChanged(null, null);
                    ddl_Middle_SelectedIndexChanged(null, null);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.EditTemplatePresenter(this);
        }
        protected override bool InitPage()
        {
            this.B_gr_Main = this.gr_Main;
            return true;
        }
        AddCheckTitleArgs addCheckTitleArgs = new AddCheckTitleArgs();
        AddTemplateArgs addTemplateArgs = new AddTemplateArgs();
        #region IEditTemplate成员
        public event EventHandler<AddTemplateArgs> OnSaveTemplate;
        public event EventHandler<AddTemplateArgs> OnSmlTemplateChange;
        public event EventHandler<AddCheckTitleArgs> OnInit;
        public event EventHandler<AddCheckTitleArgs> OnBigTempChange;
        public event EventHandler<AddCheckTitleArgs> OnMidTempChange;
        public event EventHandler<AddCheckTitleArgs> OnSave;
        public event EventHandler<AddCheckTitleArgs> OnSaveSingleTitle;
        public event EventHandler<AddTemplateArgs> OnEditSave;
        public void ExeBindTemplate(DataTable data)
        {
            Session["CheckTitleToTempData"] = data;
            txt_TemplateName.Text = data.Rows[0]["TEMPLATE_NAME"].ToString();
            txt_big.Text = data.Rows[0]["BIG_TEMPLATE_NAME"].ToString();
            txt_middle.Text = data.Rows[0]["MIDDLE_TEMPLATE_NAME"].ToString();
            txt_small.Text = data.Rows[0]["SMALL_TEMPLATE_NAME"].ToString();
            BindGRTitle(data);
        }
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("修改成功", "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("修改失败，请与管理员联系……");
            }
        }
        public void ExeBindBigTemp(DataTable data, bool bol)
        {
            BindDDL(data, ddl_Big, "BIG_TEMPLATE_NAME", "BIG_TEMPLATE_ID");
        }
        public void ExeBindMidTemp(DataTable data, bool bol)
        {
            BindDDL(data, ddl_Middle, "MIDDLE_TEMPLATE_NAME", "MIDDLE_TEMPLATE_ID");
        }
        public void ExeBindSmallTemp(DataTable data, bool bol)
        {
            BindDDL(data, ddl_Small, "SMALL_TEMPLATE_NAME", "SMALL_TEMPLATE_ID");
        }
        public void ExeBindCheckTitle(DataTable data)
        {
            Session["TemplateCheckTitleData"] = new DataTable();
            Session["TemplateCheckTitleData"] = data;
            //Tools.ExtGridBase.TemplateCheckTitleData = data;
            InitGrid(data);
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
                DataRow dr = data.NewRow();
                dr["CHECK_TITLE_ID"] = drs[0]["CHECK_TITLE_ID"];
                dr["CHECK_TITLE_NAME"] = drs[0]["CHECK_TITLE_NAME"];
                dr["CHECK_TITLE_CONTENT"] = drs[0]["CHECK_TITLE_CONTENT"];
                data.Rows.Add(dr.ItemArray);
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

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable data = Session["CheckTitleToTempData"] as DataTable;
            if (data != null && data.Rows.Count > 0)
            {
                if (OnEditSave != null)
                {
                    addTemplateArgs.TemplateName = txt_TemplateName.Text;
                    addTemplateArgs.TemplateID = this.Request["ID"].ToString();
                    addTemplateArgs.CheckTitleToTempData = data;
                    OnEditSave(null, addTemplateArgs);
                }
            }
            else
            {
                Alert.ShowInTop("请向模板中添加检查题目");
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

        protected void ddl_Big_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnBigTempChange != null)
            {
                addCheckTitleArgs.BigTemplateID = ddl_Big.SelectedValue;
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

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            if (OnSmlTemplateChange != null)
            {
                addTemplateArgs.SmallTemplateID = ddl_Small.SelectedValue;
                addTemplateArgs.OrganId = ((DataTable)Session["User"]).Rows[0]["organ_id"].ToString();
                OnSmlTemplateChange(null, addTemplateArgs);
            }
        }


        
    }
}