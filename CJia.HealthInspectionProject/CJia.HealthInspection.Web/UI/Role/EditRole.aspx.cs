using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Role
{
    public partial class EditRole : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditRole
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                editRoleArgs.RoleId = Request.QueryString["EditRoleID"].ToString();
                editRoleArgs.User = (DataTable)Session["User"];
                OnInit(null,editRoleArgs);
            }

        }

        protected override object CreatePresenter()
        {
            return new Presenters.EditRolePresenter(this);
        }

        Views.EditRoleArgs editRoleArgs = new Views.EditRoleArgs();

        #region【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            editRoleArgs.RoleId = Request.QueryString["EditRoleID"].ToString();
            editRoleArgs.RoleName = txtRoleName.Text;

            ExtAspNet.TreeNode nodeCollection = treePower.Nodes[0];
            foreach (ExtAspNet.TreeNode node in nodeCollection.Nodes)
            {
                // 如果当前节点有叶节点
                if (node.Nodes.Count > 0)
                {
                    // 循环叶节点
                    for (int i = 0; i < node.Nodes.Count; i++)
                    {
                        // 如果当前叶节点已勾选
                        if (node.Nodes[i].Checked)
                        {
                            // 如果是第一个叶节点时，记录此叶节点的根节点（根节点只需记录一次）
                            if (i == 0)
                            {
                                editRoleArgs.ListFunction.Add(node.NodeID);
                            }
                            // 记录这个已勾选的叶节点
                            editRoleArgs.ListFunction.Add(node.Nodes[i].NodeID);

                        }
                    }
                }
            }
            editRoleArgs.User = (DataTable)Session["User"];
            OnSave(null, editRoleArgs);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void treePower_NodeCheck(object sender, ExtAspNet.TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treePower.CheckAllNodes(e.Node.Nodes);
                return;
            }
            treePower.UncheckAllNodes(e.Node.Nodes);
        }
        #endregion

        #region【虚方法实现】
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="pnode">节点</param>
        /// <param name="featList">数据</param>
        #region【自定义事件】
        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="data">全部功能</param>
        /// <param name="dtFun">该用户所拥有功能</param>
        public void CreateTree(string parent, ExtAspNet.TreeNode pnode, DataTable data, DataTable dtFun)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr["PARENT_ID"].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["FUNCTION_ID"].ToString();
                    node.Text = dr["FUNCTION_NAME"].ToString();
                    foreach (DataRow drf in dtFun.Rows)
                    {
                        if (dr["function_id"].ToString() == drf["function_id"].ToString())
                        {
                            node.Checked = true;
                        }
                    }

                    node.EnableCheckBox = true;
                    node.AutoPostBack = true;
                    CreateTree(dr["FUNCTION_ID"].ToString(), node, data, dtFun);
                    pnode.Nodes.Add(node);
                }
            }
        }
        #endregion

        #region【接口实现】

        /// <summary>
        /// 绑定控件值
        /// </summary>
        /// <param name="roleName">根据角色ID所查出的角色名称</param>
        /// <param name="dtFun">角色所拥有权限</param>
        public void ExeBindControl(string roleName)
        {
            txtRoleName.Text = roleName;
        }

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        /// <param name="dtFun">角色所拥有权限</param>
        public void ExeBindTree(DataTable dtTree, DataTable dtFun)
        {
            this.treePower.Nodes.Clear();
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.NodeID = "0";
            node.Text = "全部";
            node.IconUrl = "~/Icons/package.png";
            node.AutoPostBack = true;
            node.Expanded = true;
            node.EnableCheckBox = true;
            if (dtTree != null && dtTree.Rows.Count != 0)
            {
                foreach (DataRow dr in dtTree.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode nodeChild = new ExtAspNet.TreeNode();
                        nodeChild.NodeID = dr["FUNCTION_ID"].ToString();
                        nodeChild.Text = dr["FUNCTION_NAME"].ToString();
                        //node.IconUrl =
                        nodeChild.EnableCheckBox = true;
                        nodeChild.Expanded = true;
                        nodeChild.AutoPostBack = true;

                        foreach (DataRow drf in dtFun.Rows)
                        {
                            if (dr["function_id"].ToString() == drf["function_id"].ToString())
                            {
                                nodeChild.Checked = true;
                            }
                        }

                        CreateTree(dr["FUNCTION_ID"].ToString(), nodeChild, dtTree, dtFun);
                        node.Nodes.Add(nodeChild);
                    }
                }
            }
            this.treePower.Nodes.Add(node);
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        public void ExeMessageBox(string message,bool isCloseWindow)
        {
            if (isCloseWindow)
            {
                Alert.ShowInTop(message, "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop(message, "提示对话框");
            }
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.EditRoleArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditRoleArgs> OnSave;

        #endregion
    }
}