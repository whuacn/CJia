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
    public partial class DataInput : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IDataInput
    {
        CJia.Evaluation.Views.Backstage.DataInputArgs dataInputArgs = new Views.Backstage.DataInputArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsRefhData"] != null && Session["IsRefhData"].ToString() == "1")
            {
                dataInputArgs.ColumnID = Session["RefhColumnID"].ToString();
                OnQueryDataByColumnId(null, dataInputArgs);
                Session["IsRefhData"] = null;
            }
            if (!IsPostBack)
            {
                DataTable dtUser = Session["User"] as DataTable;
                dataInputArgs.UserId = dtUser.Rows[0]["USER_ID"].ToString();
                OnInitColumnTree(null, dataInputArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.DataInputPresenter(this);
        }

        #region【页面方法】
        /// <summary>
        /// 为Grid绑定数据
        /// </summary>
        /// <param name="data"></param>
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
                        node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                        node.Text = dr["COLUMN_TREE_NAME"].ToString();
                        //node.IconUrl = "~/Icons/group.png";
                        node.Expanded = true;
                        node.EnablePostBack = true;
                        CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
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
                    node.NodeID = dr["COLUMN_TREE_ID"].ToString();
                    node.Text = dr["COLUMN_TREE_NAME"].ToString();
                    if (dr["ISHAVECOMPENTENCE"].ToString()=="0")
                    {
                        node.Enabled = false;
                    }
                    //node.IconUrl = "~/Icons/group.png";
                    node.EnablePostBack = true;
                    CreateTree(dr["COLUMN_TREE_ID"].ToString(), node, data);
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

        #region【接口实现】
        public event EventHandler<Views.Backstage.DataInputArgs> OnInitColumnTree;

        public event EventHandler<Views.Backstage.DataInputArgs> OnQueryDataByColumnId;

        public event EventHandler<Views.Backstage.DataInputArgs> OnDeleteData;

        public void ExeReturnDeleteMsg(bool isDeleteData)
        {
            if (!isDeleteData)
            {
                Alert.ShowInTop("删除失败", MessageBoxIcon.Error);
            }
            else
            {
                dataInputArgs.ColumnID = Session["ColumnId"].ToString();
                OnQueryDataByColumnId(null, dataInputArgs);
            }
        }

        public void ExeBindData(DataTable dtData)
        {
            Session["Data"] = dtData;
            BindGrid(gr_Data, dtData);
        }

        public void ExeBindColumnTree(System.Data.DataTable dtColumnTree)
        {
            InitTree(dtColumnTree);
        }
        #endregion


        #region【事件】
        protected void tree_Main_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                Session["ColumnId"] = selectedId;
                dataInputArgs.ColumnID = selectedId;
                OnQueryDataByColumnId(null, dataInputArgs);
            }
            else
            {
                Alert.ShowInTop("请选择节点！", MessageBoxIcon.Warning);
            }
        }

        protected void gr_Data_PageIndexChange(object sender, GridPageEventArgs e)
        {
            DataTable dtCheck = Session["Data"] as DataTable;
            gr_Data.PageIndex = e.NewPageIndex;
            BindGrid(gr_Data, dtCheck);
        }

        protected void gr_Data_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["Data"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gr_Data.DataSource = view1;
            gr_Data.DataBind();
        }

        protected void btnAddData_Click(object sender, EventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                CJia.Evaluation.Models.Backstage.DataInputModel model = new Models.Backstage.DataInputModel();
                int ColumnLevel = model.QueryColumnLevel(Convert.ToInt64(selectedId));
                if (ColumnLevel == 7)
                {
                    PageContext.RegisterStartupScript(window1.GetShowReference("AddData.aspx?ColumnTreeId=" + selectedId, "添加资料"));
                }
                else
                {
                    Alert.ShowInTop("当前栏目不能添加资料，请选择子级栏目！", MessageBoxIcon.Warning);
                }
            }
            else
            {
                Alert.ShowInTop("请选择节点！");
            }
            
        }

        protected void btnEditData_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(window1.GetShowReference("EditData.aspx", "添加资料"));
        }
        #endregion

        protected void gr_Data_RowCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            object[] keys = gr_Data.DataKeys[e.RowIndex];
            if (e.CommandName == "data_Edit")
            {
                PageContext.RegisterStartupScript(window1.GetShowReference("EditData.aspx?DataId="+ keys[0].ToString(), "添加资料"));
            }
            else if (e.CommandName == "Delete")
            {
                dataInputArgs.DataID = keys[0].ToString();
                dataInputArgs.UserId = dtUser.Rows[0]["USER_ID"].ToString();
                OnDeleteData(null, dataInputArgs);
            }
        }


        
    }
}