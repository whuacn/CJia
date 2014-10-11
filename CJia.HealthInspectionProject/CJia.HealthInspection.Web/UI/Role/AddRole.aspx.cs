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
    public partial class AddRole : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IAddRole
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                addRoleArgs.User = (DataTable)Session["User"];
                OnInit(null, addRoleArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddRolePresenter(this);
        }

        Views.AddRoleArgs addRoleArgs = new Views.AddRoleArgs();

        #region【虚方法实现】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_Tree = treePower;
            return true;
        }
        #endregion

        #region【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            addRoleArgs.RoleName = txtRoleName.Text;
            
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
                                addRoleArgs.ListFunction.Add(node.NodeID);
                            }
                            // 记录这个已勾选的叶节点
                            addRoleArgs.ListFunction.Add(node.Nodes[i].NodeID);

                        }
                    }
                }
            }
            addRoleArgs.User = (DataTable)Session["User"];
            OnSave(null,addRoleArgs);
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

        #region【自定义方法】
       
        #endregion

        #region【接口实现】

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
                PageContext.Refresh();
            }
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.AddRoleArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AddRoleArgs> OnSave;


        #endregion
    }
}