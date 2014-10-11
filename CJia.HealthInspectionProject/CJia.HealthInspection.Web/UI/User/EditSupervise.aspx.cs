using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.User
{
    /// <summary>
    /// 超级管理员修改用户页面
    /// </summary>
    public partial class EditSupervise : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditSupervise
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SelectedOrganNameSupersiveEdit"] = null;
                editSupArgs.UserId = Request.QueryString["EditSuperviseID"];
                OnInit(null, editSupArgs);
            }
            if (Session["SelectedOrganNameSupersiveEdit"] != null)
            {
                txtOrganName.Text = Session["SelectedOrganNameSupersiveEdit"].ToString();
            }
        }

        Views.EditSuperviseArgs editSupArgs = new Views.EditSuperviseArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.EditSupervisePresenter(this);
        }

        #region【界面事件】

        protected void btnSave_Click(object sender, EventArgs e)
        {
            editSupArgs.UserId = Request.QueryString["EditSuperviseID"];
            editSupArgs.UserNo = txtUserNo.Text;
            editSupArgs.UserName = txtUserName.Text;
            editSupArgs.OrganId = Session["SelectedOrganIdSupersiveEdit"].ToString();
            editSupArgs.RoleId = ViewState["RoleId"].ToString();

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
                                editSupArgs.ListFunction.Add(node.NodeID);
                            }
                            // 记录这个已勾选的叶节点
                            editSupArgs.ListFunction.Add(node.Nodes[i].NodeID);

                        }
                    }
                }
            }
            editSupArgs.LoginUser = (DataTable)Session["User"];
            OnSave(null, editSupArgs);
           
        }

        protected void btnSelectOrgan_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Dept/SelectOrgan.aspx?status=editSupervise", "选择组织")); 
        }

        protected void treeRole_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treePower.CheckAllNodes(e.Node.Nodes);
                return;
            }
            treePower.UncheckAllNodes(e.Node.Nodes);
        }

        #endregion

        #region【自定义方法】
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
        /// 绑定界面所选监督人员相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeBindControl(DataTable dtTask)
        {
            DataRow dr = dtTask.Rows[0];
            Session["SelectedOrganIdSupersiveEdit"] = dr["organ_id"]; // 当进入编辑页面未选择部门时需要为其赋值，否则为null
            txtUserNo.Text = dr["user_no"].ToString();
            txtUserName.Text = dr["user_name"].ToString();
            txtOrganName.Text = dr["organ_name"].ToString();
            ViewState["RoleId"] = dr["role_id"].ToString();
        }

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree">所有功能</param>
        /// <param name="dtFun">该用户所拥有功能</param>
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
        public void ExeMessageBox(string message, bool isCloseWindow)
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
        public event EventHandler<Views.EditSuperviseArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditSuperviseArgs> OnSave;
        #endregion
    }
}