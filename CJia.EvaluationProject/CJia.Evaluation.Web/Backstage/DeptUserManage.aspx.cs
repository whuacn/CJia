using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage.UI
{
    public partial class DeptUserManage : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IDeptUserManager
    {
        CJia.Evaluation.Views.Backstage.DeptUserManagerArgs args = new Views.Backstage.DeptUserManagerArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsDeptUpdate"] != null && Session["IsDeptUpdate"].ToString() == "1")
            {
                Session["IsDeptUpdate"] = "0";
                OnInitDept(null, null);
            }
            if (Session["AddUserDeptId"] != null)
            {
                args.DeptId = Session["AddUserDeptId"].ToString();
                OnQueryUserByDeptId(null, args);
                Session["AddUserDeptId"] = null;
            }
            if (!IsPostBack)
            {
                OnInitDept(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.DeptUserManagerPresenter(this);
        }

        #region【内部方法】
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
                        node.NodeID = dr["DEPT_ID"].ToString();
                        node.Text = dr["DEPT_NAME"].ToString();
                        //node.IconUrl = "~/Icons/group.png";
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        CreateTree(dr["DEPT_ID"].ToString(), node, data);
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
                    node.NodeID = dr["DEPT_ID"].ToString();
                    node.Text = dr["DEPT_NAME"].ToString();
                    //node.IconUrl = "~/Icons/group.png";
                    node.EnablePostBack = true;
                    CreateTree(dr["DEPT_ID"].ToString(), node, data);
                    pnode.Nodes.Add(node);
                }
            }
        }

        private void BindGrid(ExtAspNet.Grid grid, DataTable dtResult)
        {
            // 1.设置总项数
            grid.RecordCount = dtResult.Rows.Count;

            // 2.获取当前分页数据
            DataTable paged = dtResult.Clone();

            int rowbegin = grid.PageIndex * grid.PageSize;
            int rowend = (grid.PageIndex + 1) * grid.PageSize;
            if (rowend > dtResult.Rows.Count)
            {
                rowend = dtResult.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(dtResult.Rows[i]);
            }

            // 3.绑定到Grid
            grid.DataSource = paged;
            grid.DataBind();
        }
        #endregion

        #region【页面事件】
        protected void tree_Main_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                args.DeptId = selectedId;
                OnQueryUserByDeptId(null, args);
            }
            else
            {
                Alert.ShowInTop("请选择节点！", MessageBoxIcon.Warning);
            }
        }


        protected void gr_Main_RowCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Edit":
                    PageContext.RegisterStartupScript(Window1.GetShowReference("EditUser.aspx?userID=" + keys[0].ToString()+"&userCode="+keys[1].ToString()+"&userName="+keys[2].ToString()+"&userDept="+keys[3].ToString(), "编辑"));
                    break;
                case "Delete":
                    args.userId = keys[0].ToString();
                    args.UserID = dtUser.Rows[0]["USER_ID"].ToString();
                    args.DeptId = keys[3].ToString();
                    OnDeleteUser(null, args);
                    break;
                case "Competence":
                    PageContext.RegisterStartupScript(Window2.GetShowReference("Competence.aspx?userID=" + keys[0], "权限编辑"));
                    break;
            }
        }

        protected void btn_Add_Dept_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddDept.aspx", "新增科室"));
        }

        protected void btn_Edit_Dept_Click(object sender, EventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("EditDept.aspx?DeptId=" + selectedId , "修改科室"));
            }
            else
            {
                Alert.ShowInTop("请选择科室节点！", MessageBoxIcon.Warning);
            }
        }

        protected void btn_Delete_Delt_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                args.UserID = dtUser.Rows[0]["USER_ID"].ToString();
                args.DeptId = selectedId;
                OnDeleteDept(null, args);
            }
            else
            {
                Alert.ShowInTop("请选择科室节点！", MessageBoxIcon.Warning);
            }
        }

        protected void btn_Add_User_Click(object sender, EventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                args.DeptId = selectedId;
                Session["AddUserDeptID"] = selectedId;
                Session["AddUserDeptName"] = tree_Main.FindNode(selectedId).Text;
                //OnIsHaveChildDept(null, args); //判断当前科室是否可以添加用户
                PageContext.RegisterStartupScript(Window1.GetShowReference("AddUser.aspx?DeptId=" + Session["AddUserDeptID"].ToString() + "&DeptName=" + Session["AddUserDeptName"].ToString(), "添加用户"));
            }
            else
            {
                Alert.ShowInTop("请选择科室节点！", MessageBoxIcon.Warning);
            }
        }

        protected void gr_Main_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["DeptUser"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gr_Main.DataSource = view1;
            gr_Main.DataBind();
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            DataTable dtCheck = Session["DeptUser"] as DataTable;
            gr_Main.PageIndex = e.NewPageIndex;
            BindGrid(gr_Main, dtCheck);
        }
#endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.DeptUserManagerArgs> OnInitDept;

        public event EventHandler<Views.Backstage.DeptUserManagerArgs> OnQueryUserByDeptId;

        public event EventHandler<Views.Backstage.DeptUserManagerArgs> OnDeleteDept;

        public event EventHandler<Views.Backstage.DeptUserManagerArgs> OnIsHaveChildDept;

        public event EventHandler<Views.Backstage.DeptUserManagerArgs> OnDeleteUser;

        public void ExeReturnDeleteUserMsg(bool isDelete)
        {
            if (!isDelete)
            {
                Alert.ShowInTop("删除失败!请重试.", MessageBoxIcon.Error);
            }
            else
            {
                OnQueryUserByDeptId(null, args);
            }
        }

        public void ExeInsertUser(bool isHaveChildDept)
        {
            if (isHaveChildDept)
            {
                Alert.ShowInTop("该科室不能添加用户，在其子科室添加！", MessageBoxIcon.Error);
            }
            else
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference("AddUser.aspx?DeptId=" + Session["AddUserDeptID"].ToString()+"&DeptName="+Session["AddUserDeptName"].ToString(), "添加用户"));
            }
        }

        public void ExeReturnDeleteMsg(bool isDelete)
        {
            if (isDelete)
            {
                OnInitDept(null, null);
            }
            else
            {
                Alert.ShowInTop("删除失败！", MessageBoxIcon.Error);
            }
        }

        public void ExeBindUser(DataTable dtUser)
        {
            Session["DeptUser"] = dtUser;
            BindGrid(gr_Main, dtUser);
        }

        public void ExeBindDept(DataTable dtDept)
        {
            InitTree(dtDept);
        }
        #endregion

        










        
    }
}