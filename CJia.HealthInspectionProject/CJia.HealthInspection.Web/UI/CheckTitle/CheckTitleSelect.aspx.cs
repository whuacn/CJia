using CJia.HealthInspection.Views;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.CheckTitle
{
    public partial class CheckTitleSelect : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.ICheckTitleSelect
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                if (OnInitTree != null)
                {
                    OnInitTree(null, null);
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.CheckTitleSelectPresenter(this);
        }
        protected override bool InitPage()
        {
            this.B_gr_Main = this.gr_Main;
            this.B_ddl_PageSize = this.ddl_PageSize;
            return true;
        }
        CheckTitleSelectArgs checkTitleSelectArgs = new CheckTitleSelectArgs();

        #region IcheckTitleSelect成员
        public event EventHandler OnInitTree;
        public event EventHandler<CheckTitleSelectArgs> OnTreeClick;
        public event EventHandler<CheckTitleSelectArgs> OnDelete;
        public void ExeBindTree(DataTable data)
        {
            InitTree(data);
        }
        public void ExeBindCheckTitle(DataTable data)
        {
            //CJia.HealthInspection.Tools.ExtGridBase.CheckTitleData = data;
            InitGrid(data);
        }
        public void ExeIsDelete(bool bol)
        {
            if (bol)
            {
                this.gr_Main.SelectedRowIndexArray = new int[0];
                RefreshCheckTitle();
            }
            else
            {
                Alert.ShowInTop("删除失败，请与管理员联系……");
            }
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 初始化TreeList
        /// </summary>
        public void InitTree(DataTable data)
        {
            this.tree_Main.Nodes.Clear();
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.NodeID = "1";
            node.Text = "全部";
            node.IconUrl = "~/Icons/package.png";
            node.EnablePostBack = true;
            node.Expanded = true;
            this.tree_Main.Nodes.Add(node);
            if (data != null && data.Rows.Count != 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["PARENTID"].ToString() == string.Empty)
                    {
                        node = new ExtAspNet.TreeNode();
                        node.NodeID = dr["ID"].ToString();
                        node.Text = dr["NAME"].ToString();
                        //node.IconUrl =
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        CreateTree(dr["ID"].ToString(), node, data);
                        this.tree_Main.Nodes.Add(node);
                    }
                }
            }
        }
        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="featList">数据</param>
        public void CreateTree(string parent, ExtAspNet.TreeNode pnode, DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENTID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["ID"].ToString();
                    //node.IconUrl = 
                    node.Text = dr["NAME"].ToString();
                    node.EnablePostBack = true;
                    CreateTree(dr["ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 刷新检查题目
        /// </summary>
        public void RefreshCheckTitle()
        {
            if (OnTreeClick != null)
            {
                checkTitleSelectArgs.TemplateID = tree_Main.SelectedNodeID;
                checkTitleSelectArgs.OrganId = ((DataTable)Session["User"]).Rows[0]["organ_id"].ToString();
                OnTreeClick(null, checkTitleSelectArgs);
            }
        }
        #endregion

        protected void tree_Main_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            RefreshCheckTitle();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {

        }


        protected void ddl_Search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_Main_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            { 
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("CheckTitleEdit.aspx?isEdit=1&ID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    if (OnDelete != null)
                    {
                        checkTitleSelectArgs.CheckTitleID = keys[0].ToString();
                        OnDelete(null, checkTitleSelectArgs);
                    }
                    break;
            }
        }

        protected void gr_Main_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        protected void gr_Main_PreRowDataBound(object sender, ExtAspNet.GridPreRowEventArgs e)
        {

        }

        protected void gr_Main_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {

        }

        protected void win_Edit_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            RefreshCheckTitle();
        }
    }
}