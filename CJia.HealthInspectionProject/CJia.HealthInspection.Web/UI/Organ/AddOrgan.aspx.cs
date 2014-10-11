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
    public partial class AddOrgan : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IAddOrgan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnInit(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddOrganPresenter(this);
        }

        Views.AddOrganArgs addOrganArgs = new Views.AddOrganArgs();

        #region【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            addOrganArgs.OrganNo = this.txtOrganNo.Text;
            addOrganArgs.OrganName = this.txtOrganName.Text;
            addOrganArgs.AreaId = ViewState["area_id"].ToString();
            addOrganArgs.UserId = ((DataTable)Session["User"]).Rows[0]["user_id"].ToString();
            OnSave(null,addOrganArgs);
        }

        protected void treeArea_NodeCommand(object sender, TreeCommandEventArgs e)
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
        /////   <summary> 
        /////   绑定生成一个有树结构的下拉菜单 
        /////   </summary> 
        /////   <param   name= "dtNodeSets "> 菜单记录数据所在的表 </param> 
        /////   <param   name= "strParentColumn "> 表中用于标记父记录的字段 </param> 
        /////   <param   name= "strRootValue "> 第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录 </param> 
        /////   <param   name= "strIndexColumn "> 索引字段，也就是放在DropDownList的Value里面的字段 </param> 
        /////   <param   name= "strTextColumn "> 显示文本字段，也就是放在DropDownList的Text里面的字段 </param> 
        /////   <param   name= "drpBind "> 需要绑定的DropDownList </param> 
        /////   <param   name= "i "> 用来控制缩入量的值，请输入-1 </param> 
        //private void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, ExtAspNet.DropDownList drpBind, int i)
        //{
        //    //每向下一层，多一个缩入单位 
        //    i++;

        //    DataView dvNodeSets = new DataView(dtNodeSets);
        //    dvNodeSets.RowFilter = strParentColumn + "= " + strRootValue;

        //    string strPading = " ";     //缩入字符

        //    //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格 
        //    for (int j = 0; j < i; j++)
        //        strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了

        //    foreach (DataRowView drv in dvNodeSets)
        //    {
        //        //TreeNode tnNode = new TreeNode();
        //        ExtAspNet.ListItem li = new ExtAspNet.ListItem(strPading + "├ " + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
        //        drpBind.Items.Add(li);
        //        MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, drpBind, i);
        //    }

        //    //递归结束，要回到上一层，所以缩入量减少一个单位 
        //    i--;
        //}

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
                    node.AutoPostBack = true;
                    node.EnablePostBack = true;
                    CreateTree(dr["AREA_ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }
        #endregion

        #region【接口实现】

        ///// <summary>
        ///// 绑定下拉角色
        ///// </summary>
        ///// <param name="dtArea"></param>
        //public void ExeDropArea(DataTable dtArea)
        //{
        //    ddlArea.DataValueField = "AREA_ID";
        //    ddlArea.DataTextField = "AREA_NAME";
        //    ddlArea.DataSimulateTreeLevelField = "PARENT_ID";
        //    ddlArea.EnableSimulateTree = true;
        //    //MakeTree(dtArea, "PARENT_ID", "0", "AREA_ID", "AREA_NAME", ddlArea, -1);
        //    //ddlArea.DataEnableSelectField = ;
        //    ddlArea.DataSource = dtArea;
        //    ddlArea.DataBind();
        //}

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
                        nodeChild.AutoPostBack = true;
                        nodeChild.EnablePostBack = true;
                        CreateTree(dr["AREA_ID"].ToString(), nodeChild, dtTree);
                        node.Nodes.Add(nodeChild);
                    }
                }
            }
            this.treeArea.Nodes.Add(node);
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
        public event EventHandler<Views.AddOrganArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AddOrganArgs> OnSave;
        #endregion
    }
}