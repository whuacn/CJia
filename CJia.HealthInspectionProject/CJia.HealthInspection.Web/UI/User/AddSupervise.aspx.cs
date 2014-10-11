using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    /// <summary>
    /// 超级管理员添加用户页面
    /// </summary>
    public partial class Check : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IAddSupervise
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                Session["SelectedOrganNameSuperviseAdd"] = null;
                OnInit(null,null);
            }
            if (Session["SelectedOrganNameSuperviseAdd"] != null)
            {
                txtOrganName.Text = Session["SelectedOrganNameSuperviseAdd"].ToString();
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddSupervisePresenter(this);
        }

        Views.AddSuperviseArgs addSuperArgs = new Views.AddSuperviseArgs();

        #region【虚方法实现】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_Tree = treeRole;
            return true;
        }
        #endregion

        #region【界面事件】
        // 选择单位
        protected void btnSelectOrgan_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Dept/SelectOrgan.aspx?status=addSupervise", "选择组织")); 
        }

        // 保存事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            addSuperArgs.UserNo = txtUserNo.Text;
            addSuperArgs.UserName = txtUserName.Text;
            addSuperArgs.User = (DataTable)Session["User"];
            // 超级管理员
            if (chkSupperMan.Checked)
            {
                addSuperArgs.OrganId = "";
                addSuperArgs.UserType = "1";
                addSuperArgs.RoleType = "0";
                addSuperArgs.IsCheckSupper = true;
            }
            // 普通管理员
            else
            {
                if (txtOrganName.Text == "")
                {
                    Alert.Show("组织不能为空！");
                    txtOrganName.Required = true;
                    txtOrganName.ShowRedStar = true;
                    return;
                }
                addSuperArgs.OrganId = Session["SelectedOrganIdSuperviseAdd"].ToString();
                addSuperArgs.UserType = "2";
                addSuperArgs.RoleType = "1";
                ExtAspNet.TreeNode nodeCollection = treeRole.Nodes[0];
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
                                    addSuperArgs.ListFunction.Add(node.NodeID);
                                }
                                // 记录这个已勾选的叶节点
                                addSuperArgs.ListFunction.Add(node.Nodes[i].NodeID);
                               
                            }
                        }
                    }
                }
            }
            OnSave(null, addSuperArgs);
        }

        // 角色设置
        protected void treeRole_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                treeRole.CheckAllNodes(e.Node.Nodes);
                return;
            }
            treeRole.UncheckAllNodes(e.Node.Nodes);
        }

        protected void chkSupperMan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupperMan.Checked)
            {
                txtOrganName.Enabled = false;
                btnSelectOrgan.Enabled = false;
                treeRole.Enabled = false;
                txtOrganName.Required = false;
                txtOrganName.ShowRedStar = false;
                txtOrganName.Text = "";
                treeRole.UncheckAllNodes();
            }
            else
            {
                txtOrganName.Enabled = true;
                btnSelectOrgan.Enabled = true;
                treeRole.Enabled = true;
                txtOrganName.Required = true;
                txtOrganName.ShowRedStar = true;
            }
        }
        #endregion

        #region【自定义方法】
       
        #endregion

        #region【接口绑定】
        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        public void ExeBindTree(DataTable dtTree)
        {
            InitTree(dtTree, "FUNCTION_ID", "PARENT_ID", "FUNCTION_NAME");
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        public void ExeMessageBox(string message)
        {
            Alert.ShowInTop(message, "提示对话框", "location.href=location.href;"); 
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.AddSuperviseArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AddSuperviseArgs> OnSave;

        #endregion
    }
}