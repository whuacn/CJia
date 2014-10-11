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
    public partial class EditColumTree : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IEditColumTree
    {
        CJia.Evaluation.Views.Backstage.EditColumTreeArgs editColumnTreeArgs = new Views.Backstage.EditColumTreeArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OpearType"].ToString() == "Dept")
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
                editColumnTreeArgs.ColumnID = Request.QueryString["ColumnTreeId"].ToString();
                CJia.Evaluation.Models.Backstage.EditColumTreeModel model = new Models.Backstage.EditColumTreeModel();
                DataTable dtColumnGrade = model.QueryColumnGrade();
                ddl_ColumnGreade.DataValueField = "CODE";
                ddl_ColumnGreade.DataTextField = "NAME";
                ddl_ColumnGreade.DataSource = dtColumnGrade;
                ddl_ColumnGreade.DataBind();
                OnQueryColumnNode(null, editColumnTreeArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.EditColumTreePresenter(this);
        }

        #region【页面事件】
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            editColumnTreeArgs.ColumnTreeName = txt_Column_Nmae.Text;
            editColumnTreeArgs.ColumnTreeDescript = txt_Column_Descript.Text;
            editColumnTreeArgs.ColumnNo = Convert.ToInt32(txt_Column_No.Text);
            editColumnTreeArgs.ColumnGrade = Convert.ToInt64(ddl_ColumnGreade.SelectedValue);
            editColumnTreeArgs.ColumnID = Request.QueryString["ColumnTreeId"].ToString();
            editColumnTreeArgs.UserID = Convert.ToInt64(dtUser.Rows[0]["USER_ID"].ToString());
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
            editColumnTreeArgs.DutyDept = listDuty;
            editColumnTreeArgs.HelpDept = listHelp;
            editColumnTreeArgs.CheckWay = txt_Check_Way.Text;
            editColumnTreeArgs.Score = txt_Score.Text;
            editColumnTreeArgs.ScoreStandard = txt_Score_Standard.Text;
            OnUpdateColumnTree(null, editColumnTreeArgs);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.EditColumTreeArgs> OnQueryColumnNode;

        public event EventHandler<Views.Backstage.EditColumTreeArgs> OnUpdateColumnTree;

        public void ExeBindColumnNode(System.Data.DataTable dtColumnNode, DataTable dtAllDept, DataTable dtDutyDept, DataTable dtHeptDept)
        {
            txt_parent_Column.Text = dtColumnNode.Rows[0]["PARENTNAME"].ToString();
            txt_Column_Nmae.Text = dtColumnNode.Rows[0]["COLUMN_TREE_NAME"].ToString();
            txt_Column_Descript.Text = dtColumnNode.Rows[0]["COLUMN_DESCRIPTION"].ToString();
            txt_Column_No.Text = dtColumnNode.Rows[0]["COLUMN_NO"].ToString();
            ddl_ColumnGreade.SelectedValue = dtColumnNode.Rows[0]["COLUMN_GRADE"].ToString();
            txt_Check_Way.Text = dtColumnNode.Rows[0]["CHECK_WAY"].ToString();
            txt_Score.Text = dtColumnNode.Rows[0]["SCORE"].ToString();
            txt_Score_Standard.Text = dtColumnNode.Rows[0]["SCORE_STANDARD"].ToString();
            ExeBindColumn(tree_Duty_Dept, dtAllDept, dtDutyDept);
            ExeBindColumn(tree_Help_Dept, dtAllDept, dtHeptDept);
        }

        public void ExeReturnUpdateMsg(bool isUpdate)
        {
            if (!isUpdate)
            {
                ExtAspNet.Alert.ShowInTop("修改失败！", MessageBoxIcon.Error);
            }
            else
            {
                Session["IsRefresh"] = "1";
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }
        #endregion

        #region【内部方法】
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
                    node.NodeID = dr["DEPT_ID"].ToString();
                    node.Text = dr["DEPT_NAME"].ToString();
                    foreach (DataRow drf in dtFun.Rows)
                    {
                        if (dr["DEPT_ID"].ToString() == drf["DEPT_ID"].ToString())
                        {
                            node.Checked = true;
                            node.Expanded = true;
                            pnode.Expanded = true;
                        }
                    }
                    node.EnableCheckBox = true;
                    node.AutoPostBack = true;
                    CreateColumnTree(dr["DEPT_ID"].ToString(), node, data, dtFun);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 绑定tree
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="dtColumn"></param>
        /// <param name="dtFun">勾选的</param>
        public void ExeBindColumn(ExtAspNet.Tree tree, System.Data.DataTable dtColumn, DataTable dtFun)
        {
            tree.Nodes.Clear();
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
                        nodeChild.NodeID = dr["DEPT_ID"].ToString();
                        nodeChild.Text = dr["DEPT_NAME"].ToString();
                        //node.IconUrl =
                        nodeChild.EnableCheckBox = true;
                        nodeChild.Expanded = true;
                        nodeChild.AutoPostBack = true;

                        foreach (DataRow drf in dtFun.Rows)
                        {
                            if (dr["DEPT_ID"].ToString() == drf["DEPT_ID"].ToString())
                            {
                                nodeChild.Checked = true;
                                nodeChild.Expanded = true;
                            }
                        }
                        CreateColumnTree(dr["DEPT_ID"].ToString(), nodeChild, dtColumn, dtFun);
                        tree.Nodes.Add(nodeChild);
                    }
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
    }
}