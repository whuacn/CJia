using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Organ
{
    public partial class EditOrgan : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditOrgan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                editOrganArgs.OrganId = Request.QueryString["EditOrganID"];
                OnInit(null,editOrganArgs);
            }
        }

        Views.EditOrganArgs editOrganArgs = new Views.EditOrganArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.EditOrganPresenter(this);
        }

        #region【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            editOrganArgs.OrganId = Request.QueryString["EditOrganID"];
            editOrganArgs.OrganNo = this.txtOrganNo.Text;
            editOrganArgs.OrganName = this.txtOrganName.Text;
            editOrganArgs.AreaId = ViewState["area_id"].ToString();
            editOrganArgs.UserId = ((DataTable)Session["User"]).Rows[0]["user_id"].ToString();
            OnSave(null, editOrganArgs);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void treeArea_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                return;
            }
            ViewState["area_id"] = e.NodeID;
            txtArea.Text = e.Node.Text;
        }
        #endregion

        #region【自定义事件】
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
                    node.NodeID = dr["AREA_ID"].ToString();
                    node.Text = dr["AREA_NAME"].ToString(); 
                    node.EnablePostBack = true;
                    node.AutoPostBack = true;
                    CreateTree(dr["AREA_ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }
        #endregion


        #region【接口实现】

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        public void ExeBindTree(DataTable dtTree)
        {
            this.treeArea.Nodes.Clear();
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.NodeID = "0";
            node.Text = "全部";
            node.IconUrl = "~/Icons/package.png";
            node.AutoPostBack = true;
            node.Expanded = true; 
            node.EnablePostBack = true;
            if (dtTree != null && dtTree.Rows.Count != 0)
            {
                foreach (DataRow dr in dtTree.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode nodeChild = new ExtAspNet.TreeNode();
                        nodeChild.NodeID = dr["AREA_ID"].ToString();
                        nodeChild.Text = dr["AREA_NAME"].ToString();
                        //node.IconUrl =
                        nodeChild.Expanded = true; 
                        nodeChild.EnablePostBack = true;
                        nodeChild.AutoPostBack = true;
                        CreateTree(dr["AREA_ID"].ToString(), nodeChild, dtTree);
                        node.Nodes.Add(nodeChild);
                    }
                }
            }
            this.treeArea.Nodes.Add(node);
        }

        /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="dtOrgan"></param>
        public void ExeBindControl(DataTable dtOrgan)
        {
            DataRow dr = dtOrgan.Rows[0];
            txtOrganNo.Text = dr["organ_no"].ToString();
            txtOrganName.Text = dr["organ_name"].ToString();
            txtArea.Text = dr["area_name"].ToString();
            ViewState["area_id"] = dr["area_id"].ToString(); // 所选区域ID（直接保存，不触发控件时需要）
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

        #region【接口实现】
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.EditOrganArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditOrganArgs> OnSave;
        #endregion
    }
}