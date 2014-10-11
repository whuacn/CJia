using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.FrontStage
{
    public partial class HomePage : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.FrontStage.IHomePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    DataTable useData = Session["User"] as DataTable;
                    tbt_Clock.Text = DateTime.Now.ToString();
                    tbt_Info.Text = "欢迎【" + useData.Rows[0]["USER_NAME"].ToString() + "】";
                }
                OnInit(null, null);
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.FrontStage.HomePagePresenter(this);
        }
        public event EventHandler OnInit;
        public void ExeBindTree(DataTable data)
        {
            InitTree(data);
        }

        #region 内部调用方法
        /// <summary>
        /// 获得tree列数，并传参到页面
        /// </summary>
        public string TreeCount = null;
        public void GetTreeCount(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] drs = data.Select(" LV='1'");
                TreeCount = "[";
                for (int i = 0; i < drs.Length; i++)
                {
                    if (i == drs.Length - 1)
                    {
                        TreeCount = TreeCount + drs[i]["COLUMN_TREE_ID"].ToString();
                    }
                    else
                    {
                        TreeCount = TreeCount + drs[i]["COLUMN_TREE_ID"].ToString() + ",";
                    }
                }
                TreeCount = TreeCount + "]";
            }
        }
        public void InitTree(DataTable data)
        {
            ad_Main.Panes.Clear();
            ExtAspNet.AccordionPane ap;
            if (data != null && data.Rows.Count != 0)
            {
                GetTreeCount(data);
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["LV"].ToString() == "1")
                    {
                        ap = new ExtAspNet.AccordionPane();
                        ap.AutoScroll = true;
                        ap.Expanded = true;
                        ap.IconUrl = "~/Icons/book.png";
                        ap.Layout = ExtAspNet.Layout.Fit;
                        ap.ID = dr["COLUMN_TREE_ID"].ToString();
                        ap.Title = dr["COLUMN_TREE_NAME"].ToString() + ":" + dr["COLUMN_DESCRIPTION"].ToString();
                        CreateTree(dr["COLUMN_TREE_ID"].ToString(), ap, data);
                        ad_Main.Panes.Add(ap);
                    }
                }
            }
        }
        public void CreateTree(string parent, ExtAspNet.AccordionPane pnode, DataTable data)
        {
            ExtAspNet.Tree tree = new ExtAspNet.Tree();
            tree.ShowBorder = false;
            tree.ShowHeader = false;
            tree.AutoScroll = true;
            tree.ID = parent;
            pnode.Items.Add(tree);
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                    if (dr["COLUMN_DESCRIPTION"].ToString().Length > 15)
                    {
                        node.Text = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString().Substring(0, 15) + "...";
                    }
                    else
                    {
                        node.Text = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString();
                    }
                    node.IconUrl = "~/Icons/database_yellow.png";
                    node.ToolTip = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString();
                    //node.NavigateUrl = "ErrorPage.aspx";
                    node.NavigateUrl = "javascript:void(0)";
                    node.OnClientClick = "alert('未维护正确的栏目信息,请与管理员联系！'); return false;";
                    node.EnablePostBack = false;
                    CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
                    tree.Nodes.Add(node);
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
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                    if (dr["COLUMN_DESCRIPTION"].ToString().Length > 12)
                    {
                        node.Text = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString().Substring(0, 12) + "...";
                    }
                    else
                    {
                        node.Text = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString();
                    }
                    node.ToolTip = dr["COLUMN_TREE_NAME"].ToString() + " " + dr["COLUMN_DESCRIPTION"].ToString();
                    node.IconUrl = "~/Icons/database_yellow.png";
                    string treeID = CJia.Evaluation.Tools.Utils.AESEncrypt(dr["COLUMN_TREE_ID"].ToString());
                    node.NavigateUrl = "FirstOne.aspx?id=" + treeID;
                    node.EnablePostBack = true;
                    CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                    pnode.OnClientClick = "";
                    pnode.NavigateUrl = "";
                }
            }
        }
        #endregion
    }
}