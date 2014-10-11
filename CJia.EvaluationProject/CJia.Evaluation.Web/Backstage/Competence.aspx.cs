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
    public partial class Competence : CJia.Evaluation.Tools.Page,CJia.Evaluation.Views.Backstage.ICompetence
    {
        CJia.Evaluation.Views.Backstage.CompetenceArgs args = new Views.Backstage.CompetenceArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                args.UserID = Request.QueryString["userID"].ToString();
                OnInitColumn(null, args);
                OninitMenu(null, args);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.CompetencePresenter(this);
        }

        #region【页面方法】
        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="data">全部功能</param>
        /// <param name="dtFun">该用户所拥有功能</param>
        public void CreateColumnTree(string parent, ExtAspNet.TreeNode pnode, DataTable data, DataTable dtFun)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                    node.Text = dr["COLUMN_TREE_NAME"].ToString();
                    foreach (DataRow drf in dtFun.Rows)
                    {
                        if (dr["COLUMN_TREE_ID"].ToString() == drf["MENU_ID"].ToString())
                        {
                            node.Checked = true;
                        }
                    }

                    node.EnableCheckBox = true;
                    node.AutoPostBack = true;
                    CreateColumnTree(dr["COLUMN_TREE_ID"].ToString(), node, data, dtFun);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="data">全部功能</param>
        /// <param name="dtFun">该用户所拥有功能</param>
        public void CreateMenuTree(string parent, ExtAspNet.TreeNode pnode, DataTable data, DataTable dtFun)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["MENU_ID"].ToString();
                    node.Text = dr["MENU_NAME"].ToString();
                    foreach (DataRow drf in dtFun.Rows)
                    {
                        if (dr["MENU_ID"].ToString() == drf["MENU_ID"].ToString())
                        {
                            node.Checked = true;
                        }
                    }

                    node.EnableCheckBox = true;
                    node.AutoPostBack = true;
                    CreateMenuTree(dr["MENU_ID"].ToString(), node, data, dtFun);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 递归获得树状结构已选节点ID
        /// </summary>
        /// <param name="list"></param>
        /// <param name="Node"></param>
        /// <returns></returns>
        private List<string> GetTreeSelectID(List<string> list, ExtAspNet.TreeNode Node)
        {
            bool isAddParent = false;
            for (int i = 0; i < Node.Nodes.Count; i++)
            {
                // 如果当前叶节点已勾选
                if (Node.Nodes[i].Checked)
                {
                    if (isAddParent == false )
                    {
                        if (!list.Contains(Node.NodeID))
                        {
                            list.Add(Node.NodeID);
                        }
                        isAddParent = true;
                    }
                    list.Add(Node.Nodes[i].NodeID);
                    // 记录这个已勾选的叶节点
                }
                GetTreeSelectID(list, Node.Nodes[i]);
            }
            return list;
        }

        #endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.CompetenceArgs> OnInitColumn;

        public event EventHandler<Views.Backstage.CompetenceArgs> OninitMenu;

        public event EventHandler<Views.Backstage.CompetenceArgs> OnDepeteInsertCompetence;

        public void ExeReturnInsertMsg(bool isInsert)
        {
            if (isInsert)
            {
                args.UserID = Request.QueryString["userID"].ToString();
                OnInitColumn(null, args);
                OninitMenu(null, args);
                Alert.ShowInTop("权限编辑成功.", MessageBoxIcon.Information);
            }
            else
            {
                Alert.ShowInTop("权限编辑失败.", MessageBoxIcon.Error);
            }
        }

        public void ExeBindColumn(System.Data.DataTable dtColumn, DataTable dtFun)
        {
            this.treeColumn.Nodes.Clear();
            //ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            //node.NodeID = "0";
            //node.Text = "全部";
            //node.IconUrl = "~/Icons/package.png";
            //node.AutoPostBack = true;
            //node.Expanded = true;
            //node.EnableCheckBox = true;
            if (dtColumn != null && dtColumn.Rows.Count != 0)
            {
                foreach (DataRow dr in dtColumn.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode nodeChild = new ExtAspNet.TreeNode();
                        nodeChild.NodeID = dr["COLUMN_TREE_ID"].ToString();
                        nodeChild.Text = dr["COLUMN_TREE_NAME"].ToString();
                        //node.IconUrl =
                        nodeChild.EnableCheckBox = true;
                        nodeChild.Expanded = true;
                        nodeChild.AutoPostBack = true;

                        foreach (DataRow drf in dtFun.Rows)
                        {
                            if (dr["COLUMN_TREE_ID"].ToString() == drf["MENU_ID"].ToString())
                            {
                                nodeChild.Checked = true;
                            }
                        }

                        CreateColumnTree(dr["COLUMN_TREE_ID"].ToString(), nodeChild, dtColumn, dtFun);
                        this.treeColumn.Nodes.Add(nodeChild);
                    }
                }
            }
            
        }

        public void ExeBindMenu(System.Data.DataTable dtMenu, DataTable dtFun)
        {
            this.treeMenu.Nodes.Clear();
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.NodeID = "0";
            node.Text = "功能菜单";
            node.IconUrl = "~/Icons/package.png";
            node.AutoPostBack = true;
            node.Expanded = true;
            node.EnableCheckBox = true;
            if (dtMenu != null && dtMenu.Rows.Count != 0)
            {
                foreach (DataRow dr in dtMenu.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode nodeChild = new ExtAspNet.TreeNode();
                        nodeChild.NodeID = dr["MENU_ID"].ToString();
                        nodeChild.Text = dr["MENU_NAME"].ToString();
                        //node.IconUrl =
                        nodeChild.EnableCheckBox = true;
                        nodeChild.Expanded = true;
                        nodeChild.AutoPostBack = true;

                        foreach (DataRow drf in dtFun.Rows)
                        {
                            if (dr["MENU_ID"].ToString() == drf["MENU_ID"].ToString())
                            {
                                nodeChild.Checked = true;
                            }
                        }

                        CreateMenuTree(dr["MENU_ID"].ToString(), nodeChild, dtMenu, dtFun);
                        node.Nodes.Add(nodeChild);
                    }
                }
            }
            this.treeMenu.Nodes.Add(node);
        }
        #endregion

        #region【页面事件】
        protected void treeColumn_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treeColumn.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                treeColumn.UncheckAllNodes(e.Node.Nodes);
            }
        }

        protected void treeMenu_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treeMenu.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                treeMenu.UncheckAllNodes(e.Node.Nodes);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            List<string> MenuCompetenceList = new List<string>();
            List<string> ColumnCompetenceList = new List<string>();
            List<object[]> obListDelete = new List<object[]>();
            List<object[]> obListInsert=new List<object[]>() ;
            foreach (ExtAspNet.TreeNode node in treeMenu.Nodes)
            {
                GetTreeSelectID(MenuCompetenceList, node);
            }
            foreach (ExtAspNet.TreeNode node in treeColumn.Nodes)
            {
                GetTreeSelectID(ColumnCompetenceList, node);
            }

            for (int i = 0; i < MenuCompetenceList.Count; i++)
            {
                object[] ob = new object[] { Request.QueryString["userID"].ToString(), MenuCompetenceList[i].ToString(), "0", dtUser.Rows[0]["USER_ID"].ToString() };
                obListInsert.Add(ob);
            }
            for (int i = 0; i < ColumnCompetenceList.Count; i++)
            {
                object[] ob = new object[] { Request.QueryString["userID"].ToString(), ColumnCompetenceList[i].ToString(), "1", dtUser.Rows[0]["USER_ID"].ToString() };
                obListInsert.Add(ob);
            }
            object[] obDelete = new object[] { dtUser.Rows[0]["USER_ID"].ToString(), Request.QueryString["userID"].ToString() };
            obListDelete.Add(obDelete);
            args.obListDelete = obListDelete;
            args.obListInsert = obListInsert;
            OnDepeteInsertCompetence(null, args);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion
    }
}