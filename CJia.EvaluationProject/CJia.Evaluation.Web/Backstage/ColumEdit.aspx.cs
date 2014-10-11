using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class ColumEdit : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IColumEdit
    {
        CJia.Evaluation.Views.Backstage.ColumEditArgs columnEditArgs = new Views.Backstage.ColumEditArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsRefresh"]!=null && Session["IsRefresh"].ToString() == "1")
            {
                OnQueryColumTree(null, null);
                Session["IsRefresh"] = "0";
            }
            if (!IsPostBack)
            {
                OnQueryColumTree(null, null);
                //ExtAspNet.TreeNodeCollection nodes = new ExtAspNet.TreeNodeCollection(tree_Main);
                //ExtAspNet.TreeNode[] node = tree_Main.GetExpandedNodes();
                //for (int i = 0; i < node.Length; i++)
                //{
                //    nodes.Add(node[i]);
                //}
                //tree_Main.ExpandAllNodes(nodes);
                //tree_Main.ExpandAllNodes(nodes);
            }
        }

        protected void btnAddColum_Click(object sender, EventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                columnEditArgs.ColumnID = Convert.ToInt64(selectedId);
                OnQueryColumnLevel(null, columnEditArgs);
                int ColumnLevel = Convert.ToInt32(Session["ColumnLevelAdd"]);
                if (ColumnLevel <= 6)
                {
                    string[] ExpandIds = tree_Main.GetExpandedNodeIDs();
                    Session["ExpandendNodeIds"] = ExpandIds;
                    if (ColumnLevel == 4)
                    {
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&ColumnLevel=" + ColumnLevel + "&OpearType=AddDept", "新增栏目"));
                    }
                    else if(ColumnLevel == 5)
                    {
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&ColumnLevel=" + ColumnLevel + "&OpearType=AddCheckWay", "新增栏目"));
                    }
                    else if (ColumnLevel == 6)
                    {
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&ColumnLevel=" + ColumnLevel + "&OpearType=AddScore", "新增栏目"));
                    }
                    else
                    {
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&ColumnLevel=" + ColumnLevel + "&OpearType=NoOpear", "新增栏目"));
                    }
                }
                else
                {
                    Alert.ShowInTop("此级以下不能添加栏目！",MessageBoxIcon.Warning);
                }
            }
            else
            {
                //PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId="+null+"&ColumnTreeName=Root", "新增栏目"));
                Alert.ShowInTop("请选择节点！");
            }
            
            //if (ColumnLevel < 6)
            //{
                
            //    if (!String.IsNullOrEmpty(selectedId))
            //    {
            //        PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddColumnTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text, "新增栏目"));
            //    }
            //    else
            //    {
            //        Alert.ShowInTop("请选择节点！");
            //    }
            //}
            //else
            //{
            //    Alert.ShowInTop("此级以下不能添加栏目！");
            //}
        }

        protected void btnEditColum_Click(object sender, EventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                string[] ExpandIds = tree_Main.GetExpandedNodeIDs();
                Session["ExpandendNodeIds"] = ExpandIds;
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditColumTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text, "编辑栏目"));
               // tree_Main.FindNode(selectedId).
                columnEditArgs.ColumnID = Convert.ToInt64(selectedId);
                OnQueryColumnLevel(null, columnEditArgs);
                int ColumnLevel = Convert.ToInt32(Session["ColumnLevelAdd"]);
                if (ColumnLevel == 5)
                {
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditColumTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&OpearType=Dept", "编辑栏目"));
                }
                else if (ColumnLevel == 6)
                {
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditColumTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&OpearType=AddCheckWay", "编辑栏目"));
                }
                else if (ColumnLevel == 7)
                {
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditColumTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&OpearType=AddScore", "编辑栏目"));
                }
                else
                {
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditColumTree.aspx?ColumnTreeId=" + selectedId + "&ColumnTreeName=" + tree_Main.FindNode(selectedId).Text + "&OpearType=NoOpear", "编辑栏目"));
                }

            }
            else
            {
                Alert.ShowInTop("请选择节点！",MessageBoxIcon.Warning);
            }
        }

        protected void btnDeleteColum_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            columnEditArgs.UserID = dtUser.Rows[0]["USER_ID"].ToString();
            string selectedId = tree_Main.SelectedNodeID;
            
            if (!String.IsNullOrEmpty(selectedId))
            {
                string[] ExpandIds = tree_Main.GetExpandedNodeIDs();
                Session["ExpandendNodeIds"] = ExpandIds;
                columnEditArgs.ColumnID = Convert.ToInt64(selectedId);
                OnDeleteColumnTree(null, columnEditArgs);
            }
            else
            {
                Alert.ShowInTop("请选择节点！", MessageBoxIcon.Warning);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.ColumEditPresenter(this);
        }

        #region【页面方法】
        public void InitTree(DataTable data)
        {
            this.tree_Main.Nodes.Clear();
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            //node.NodeID = "1";
            //node.Text = "全部";
            //node.IconUrl = "~/Icons/package.png";
            //node.EnablePostBack = true;
            //node.Expanded = true;
            //this.tree_Main.Nodes.Add(node);
            if (data != null && data.Rows.Count != 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        node = new ExtAspNet.TreeNode();
                        node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                        node.Text = dr["COLUMN_TREE_NAME"].ToString();
                        node.ToolTip = dr["COLUMN_DESCRIPTION"].ToString();
                        //node.IconUrl = "~/Icons/group.png";
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
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
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                    node.Text = dr["COLUMN_TREE_NAME"].ToString();
                    node.ToolTip = dr["COLUMN_DESCRIPTION"].ToString();
                    //node.IconUrl = "~/Icons/group.png";
                    //node.Expanded = true;
                    node.EnablePostBack = true;
                    CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 展开特定的节点
        /// </summary>
        /// <param name="NodeIds"></param>
        /// <param name="Node"></param>
        private void ExpandNodes(string[] NodeIds,ExtAspNet.TreeNode Node)
        {
            foreach (ExtAspNet.TreeNode node in Node.Nodes)
            { 
                if(NodeIds.Contains<string>(node.NodeID))
                {
                    node.Expanded=true;
                    ExpandNodes(NodeIds, node);
                }
            }
        }

        #endregion

        #region 【实现接口】
        public event EventHandler<Views.Backstage.ColumEditArgs> OnQueryColumTree;

        public event EventHandler<Views.Backstage.ColumEditArgs> OnQueryColumnLevel;

        public event EventHandler<Views.Backstage.ColumEditArgs> OnDeleteColumnTree;

        public void ExeReturnDeleteMsg(bool IsDelete)
        {
            if (!IsDelete)
            {
                Alert.ShowInTop("删除失败！", MessageBoxIcon.Error);
            }
            else
            {
                PageContext.Refresh();
            }
        }

        public void ExeBindColumTree(System.Data.DataTable dtColumTree)
        {
            InitTree(dtColumTree);
            if (Session["ExpandendNodeIds"] != null)
            {
                string[] ExpandIds = Session["ExpandendNodeIds"] as string[];
                foreach (ExtAspNet.TreeNode node in tree_Main.Nodes)
                {
                    ExpandNodes(ExpandIds, node);
                }
                Session["ExpandendNodeIds"] = null;
            }
        }

        public void ExeReturnColumnLevel(int ColumnLevel)
        {
            Session["ColumnLevelAdd"] = ColumnLevel;
        }
        #endregion
    }
}