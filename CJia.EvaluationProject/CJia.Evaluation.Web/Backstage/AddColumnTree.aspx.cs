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
    public partial class AddColumnTree : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IAddColumnTree
    {
        CJia.Evaluation.Views.Backstage.AddColumnTreeArgs addColumnTreeArgs = new Views.Backstage.AddColumnTreeArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OpearType"].ToString() == "AddDept")
                {
                    gr_Duty_Dept.Hidden = false;
                    gr_Help_Dept.Hidden = false;
                }
                else if (Request.QueryString["OpearType"].ToString() == "AddCheckWay")
                {
                    txt_Check_Way.Enabled = true;
                }
                else if (Request.QueryString["OpearType"].ToString() == "AddScore")
                {
                    txt_Score.Enabled = true;
                    txt_Score_Standard.Enabled = true;
                }
                string ColumnTreeId = Request.QueryString["ColumnTreeId"].ToString();
                string ColumnTreeName = Request.QueryString["ColumnTreeName"].ToString();
                txt_parent_Column.Text = ColumnTreeName;
                Models.Backstage.AddColumnTreeModel model = new Models.Backstage.AddColumnTreeModel();
                DataTable dtColumnGrade = model.QueryColumnGrade();
                ddl_ColumnGreade.DataValueField = "CODE";
                ddl_ColumnGreade.DataTextField = "NAME";
                ddl_ColumnGreade.DataSource = dtColumnGrade;
                ddl_ColumnGreade.DataBind();
                OnInitDept(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.AddColumnTreePresenter(this);
        }

        #region【内部方法】
        public void InitTree(ExtAspNet.Tree tree, DataTable data)
        {
            tree.Nodes.Clear();
            if (data != null && data.Rows.Count != 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["PARENT_ID"].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                        node.NodeID = dr["DEPT_ID"].ToString();
                        node.Text = dr["DEPT_NAME"].ToString();
                        //node.IconUrl = "~/Icons/group.png";
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        node.EnableCheckBox = true;
                        CreateTree(dr["DEPT_ID"].ToString(), node, data);
                        tree.Nodes.Add(node);
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
                    node.NodeID = dr["DEPT_ID"].ToString();
                    node.Text = dr["DEPT_NAME"].ToString();
                    //node.IconUrl = "~/Icons/group.png";
                    node.EnablePostBack = true;
                    node.EnableCheckBox = true;
                    CreateTree(dr["DEPT_ID"].ToString(), node, data);
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
            for (int i = 0; i < Node.Nodes.Count; i++)
            {
                // 如果当前叶节点已勾选
                if (Node.Nodes[i].Checked)
                {
                    list.Add(Node.Nodes[i].NodeID);
                    // 记录这个已勾选的叶节点
                }
                GetTreeSelectID(list, Node.Nodes[i]);
            }
            return list;
        }

        #endregion

        #region【页面事件】
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable; 
            addColumnTreeArgs.ColumnTreeName = txt_Column_Nmae.Text;
            addColumnTreeArgs.ColumnTreeDescript = txt_Column_Descript.Text;
            addColumnTreeArgs.ColumnGrade = Convert.ToInt64(ddl_ColumnGreade.SelectedValue);
            addColumnTreeArgs.ColumnNo = Convert.ToInt32(txt_Column_No.Text);
            addColumnTreeArgs.ParentColumnTreeId = Request.QueryString["ColumnTreeId"].ToString();
            addColumnTreeArgs.UserID = Convert.ToInt64(dtUser.Rows[0]["USER_ID"].ToString());
            List<string> listDuty = new List<string>();
            List<string> listHelp = new List<string>();
            foreach (ExtAspNet.TreeNode node in tree_Duty_Dept.Nodes)
            {
                GetTreeSelectID(listDuty, node);
            }
            foreach (ExtAspNet.TreeNode node in tree_Help_Dept.Nodes)
            {
                GetTreeSelectID(listHelp, node);
            }

            addColumnTreeArgs.DutyDept = listDuty;
            addColumnTreeArgs.HelpDept = listHelp;
            addColumnTreeArgs.CheckWay = txt_Check_Way.Text;
            addColumnTreeArgs.Score = txt_Score.Text;
            addColumnTreeArgs.ScoreStandard = txt_Score_Standard.Text;
            if (Request.QueryString["ColumnLevel"].ToString() == "4")
            {
                OnInsertColumnTree(null, addColumnTreeArgs);
            }
            else
            {
                OnAddColumnTree(null, addColumnTreeArgs);
            }
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

        #region
        /// <summary>
        /// 添加普通栏目
        /// </summary>
        public event EventHandler<Views.Backstage.AddColumnTreeArgs> OnAddColumnTree;

        /// <summary>
        /// 添加4级栏目
        /// </summary>
        public event EventHandler<Views.Backstage.AddColumnTreeArgs> OnInsertColumnTree;

        public event EventHandler<Views.Backstage.AddColumnTreeArgs> OnInitDept;

        public void ExeShowAddResult(bool bl)
        {
            if (!bl)
            {
                ExtAspNet.Alert.ShowInTop("添加失败", MessageBoxIcon.Error);
            }
            else
            {
                Session["IsRefresh"] = "1";
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }
        
        public void ExeBindDeptTree(DataTable dtDept)
        {
            InitTree(tree_Duty_Dept, dtDept);
            InitTree(tree_Help_Dept, dtDept);
        }
        #endregion
    }
}