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
    public partial class TemplateManage : Tools.Page,Views.ITemplateManage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                if (OnInitPage != null)
                {
                    OnInitPage(null, null);
                }
            }
        }
        protected override bool InitPage()
        {
            this.B_gr_Main = this.gr_Main;
            this.B_ddl_PageSize = this.ddl_PageSize;
            return true;
        }
        protected override object CreatePresenter()
        {
            return new Presenters.TemplateManagePresenter(this);
        }
        TemplateManageArgs templateManageArgs = new TemplateManageArgs();

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
                    node.Text = dr["NAME"].ToString();
                    node.EnablePostBack = true;
                    CreateTree(dr["ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 刷新模板
        /// </summary>
        public void RefreshTemplate()
        {
            if (OnTreeClick != null)
            {
                templateManageArgs.TypeID = tree_Main.SelectedNodeID;
                templateManageArgs.User = (DataTable)Session["User"];
                OnTreeClick(null, templateManageArgs);
            }
        }
        #endregion

        #region ITemplateManage成员
        public event EventHandler OnInitPage;
        public event EventHandler<TemplateManageArgs> OnTreeClick;
        public event EventHandler<TemplateManageArgs> OnDeleteTemp;
        public void ExeBindTree(DataTable data)
        {
            InitTree(data);
        }
        public void ExeBindTemplate(DataTable data)
        {
            //CJia.HealthInspection.Tools.ExtGridBase.TemplateData = data;
            InitGrid(data);
        }
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                this.gr_Main.SelectedRowIndexArray = new int[0];
                RefreshTemplate();
            }
            else
            {
                Alert.ShowInTop("删除失败，请与管理员联系……");
            }
        }
        #endregion
        protected void tree_Main_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            RefreshTemplate();
        }

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditTemplate.aspx?isEdit=1&ID=" + keys[0].ToString(), "编辑"));
                    break;
                case "Delete":
                    if (OnDeleteTemp != null)
                    {
                        templateManageArgs.TemplateID = keys[0].ToString();
                        OnDeleteTemp(null, templateManageArgs);
                    }
                    break;
            }
        }

        protected void win_Edit_Close(object sender, WindowCloseEventArgs e)
        {
            RefreshTemplate();
        }
    }
}