using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class FileQuery : CJia.Evaluation.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitTree(QueryAllDept());
                ExeBindDataType(QueryFileType());
            }
        }

        protected override object CreatePresenter()
        {
            return null;
        }

        public DataTable QueryAllDept()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDept = ad.Query(CJia.Evaluation.Models.SqlToos.SqlQueryAllDept, null);
                return dtDept;
            }
        }

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

        public void ExeBindDataType(System.Data.DataTable dtDataType)
        {
            ddl_Data_Type.DataValueField = "TYPE_ID";
            ddl_Data_Type.DataTextField = "TYPE_VALUE";
            ddl_Data_Type.DataSource = dtDataType;
            ddl_Data_Type.DataBind();
        }

        void ExeBindDataUser(System.Data.DataTable dtDataType)
        {
            ddl_Data_User.DataValueField = "USER_ID";
            ddl_Data_User.DataTextField = "USER_NAME";
            ddl_Data_User.DataSource = dtDataType;
            ddl_Data_User.DataBind();
        }

        public DataTable QueryFileType()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDept = ad.Query(CJia.Evaluation.Models.SqlToos.SqlQueryDataType, null);
                DataRow dr = dtDept.NewRow();
                dr["TYPE_ID"] = "0";
                dr["TYPE_VALUE"] = "<全部>";
                dtDept.Rows.InsertAt(dr, 0);
                return dtDept;
            }
        }

        protected void tree_Main_NodeCommand(object sender, ExtAspNet.TreeCommandEventArgs e)
        {
            string selectedId = tree_Main.SelectedNodeID;
            if (!String.IsNullOrEmpty(selectedId))
            {
                ExeBindDataUser(QueryUserByDeptID(selectedId));
            }
            else
            {
                Alert.ShowInTop("请选择节点！", MessageBoxIcon.Warning);
            }
        }

        DataTable QueryUserByDeptID(string DeptID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { DeptID };
                DataTable dtDept = ad.Query(@"select user_id,user_name from gm_user GU
                                                                         where GU.STATUS = '1'
                                                                           AND Gu.DEPT_ID in (select dept_id
                                                                                                from gm_dept
                                                                                               start with dept_id = ?
                                                                                              connect by prior dept_id = parent_id)", ob);
                DataRow dr = dtDept.NewRow();
                dr["USER_ID"] = "0";
                dr["USER_NAME"] = "<全部>";
                dtDept.Rows.InsertAt(dr, 0);
                return dtDept;
            }
        }

        protected void btn_Query_Click(object sender, EventArgs e)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ddl_Data_Type.SelectedValue, ddl_Data_Type.SelectedValue, ddl_Data_User.SelectedValue, ddl_Data_User.SelectedValue, txt_Subject.Text, txt_Subject.Text, tree_Main.SelectedNodeID };
                DataTable dtFileData = ad.Query(@"select gd.data_id,
                                                                                       gd.data_name,
                                                                                       gd.data_content,
                                                                                       gc.type_value,
                                                                                       gu.user_name,
                                                                                       gd.creater_date,
                                                                                       tree_path
                                                                                  from GM_DATA gd, gm_user gu, gm_type gc, vw_column_tree gct
                                                                                 where gd.status = '1'
                                                                                   and gd.data_type = gc.type_id
                                                                                   and gd.creater_by = gu.user_id
                                                                                   and gd.column_tree_id = gct.column_tree_id
                                                                                   and (gd.data_type = ? or ? = '0')
                                                                                   and (gd.creater_by = ? or ? = '0')
                                                                                   and (gd.data_name like '%'||?||'%' or ? is null)
                                                                                   and  Gu.DEPT_ID in (select dept_id
                                                                                                from gm_dept
                                                                                               start with dept_id = ?
                                                                                              connect by prior dept_id = parent_id)", ob);
                BindGrid(gr_Data, dtFileData);
                Session["PageData"] = dtFileData;
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

        protected void gr_Data_PageIndexChange(object sender, GridPageEventArgs e)
        {
            DataTable dtCheck = Session["PageData"] as DataTable;
            gr_Data.PageIndex = e.NewPageIndex;
            BindGrid(gr_Data, dtCheck);
        }

        protected void gr_Data_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["PageData"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gr_Data.DataSource = view1;
            gr_Data.DataBind();
        }

        protected void gr_Data_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = gr_Data.DataKeys[e.RowIndex];
            if (e.CommandName == "data_Query")
            {
                PageContext.RegisterStartupScript(window1.GetShowReference("EditData.aspx?DataId=" + keys[0].ToString() + "&OperType=Select", "添加资料"));
            }
        }
    }
}