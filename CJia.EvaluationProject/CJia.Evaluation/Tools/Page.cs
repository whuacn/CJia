using ExtAspNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Tools
{
    public class Page : System.Web.UI.Page
    {
        private object _presenter;

        /// <summary>
        /// 用户控件UI层父类构造函数
        /// </summary>
        public Page()
        {
            _presenter = this.CreatePresenter();
        }

        /// <summary>
        /// 常见Presenter虚方法
        /// </summary>
        /// <returns></returns>
        protected virtual object CreatePresenter()
        {
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} 必须重载 CreatePresenter 方法.", this.GetType().FullName));
            }
        }
        /// <summary>
        /// 显示弹框信息
        /// </summary>
        /// <param name="message">要显示的内容</param>
        public void ShowMessage(string message)
        {
            //Response.Write("  <script type='text/javascript'>alert('" + message + "'); </script>");
            //ClientScript.RegisterClientScriptBlock(typeof(Page), new Guid().ToString(), "alert('" + message + "');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Ok", "alert('" + message + "');", true);
        }
        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        public DateTime Sysdate
        {
            get
            {
                using (Adapter ad = new Adapter())
                {
                    return DateTime.Parse(ad.QueryScalar("select sysdate from dual", null));
                }
            }
        }
        /// <summary>
        /// 跳转到某一页
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(string page)
        {
            Response.Redirect(page);
        }
        
        protected override void OnPreLoad(EventArgs e)
        {
            //base.OnPreLoad(e);
            if (Session["User"] == null)
            {
                //Response.Redirect("~/LoginView.aspx");
                Response.Write("  <script type='text/javascript'>top.location='../../LoginView.aspx'</script>");
            }
        }
        /// <summary>
        /// 初始化Page
        /// </summary>
        protected virtual bool InitPage()
        {
            return true;
        }
        /// <summary>
        /// 重新绑定Grid数据
        /// </summary>
        public void InitGrid(DataTable data)
        {
            //Tools.ExtGridBase.DataSource = data;
            Session["DataSource"] = new DataTable();
            Session["DataSource"] = data;
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = data.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = B_gr_Main.PageSize; //显示的数量
            ps.CurrentPageIndex = B_gr_Main.PageIndex; //取得当前页的页码
            B_gr_Main.RecordCount = data.Rows.Count; 
            B_gr_Main.DataSource = ps;
            B_gr_Main.DataBind();
        }
        /// <summary>
        /// 表格控件
        /// </summary>
        protected Grid B_gr_Main;
        /// <summary>
        /// 页数下拉框
        /// </summary>
        protected ExtAspNet.DropDownList B_ddl_PageSize;
        protected void btn_Search_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["DataSource"] != null)
            {
                this.B_gr_Main.PageIndex = 0;
                this.B_gr_Main.PageSize = int.Parse(this.B_ddl_PageSize.SelectedValue);
                DataTable data = Session["DataSource"] as DataTable;
                this.InitGrid(data);
            }
        }

        protected void gr_Main_Sort(object sender, GridSortEventArgs e)
        {
            if (Session["DataSource"] != null)
            {
                this.ViewState["SortExpression"] = e.SortField;
                this.ViewState["SortDirection"] = e.SortDirection;
                DataTable dt = Session["DataSource"] as DataTable;
                dt.DefaultView.Sort = e.SortField + " " + e.SortDirection;
                //this.InitGrid(Tools.ExtGridBase.DataSource);
                this.InitGrid(dt);
            }
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["DataSource"] != null)
            {
                this.B_gr_Main.PageIndex = e.NewPageIndex;
                DataTable dt = Session["DataSource"] as DataTable;
                this.InitGrid(dt);
            }
        }
        #region【树绑定】
        /// <summary>
        /// 树绑定
        /// </summary>
        protected ExtAspNet.Tree B_Tree;

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="parent">父编码</param>
        /// <param name="pnode">节点</param>
        /// <param name="featList">数据</param>
        public void CreateTree(string parent, ExtAspNet.TreeNode pnode, DataTable data, string mainField, string parentField, string textField)
        {
            foreach (DataRow dr in data.Rows)
            {
                if (dr[parentField].ToString() == parent)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr[mainField].ToString();
                    node.Text = dr[textField].ToString();
                    node.EnableCheckBox = true;
                    node.AutoPostBack = true;
                    CreateTree(dr[mainField].ToString(), node, data, mainField, parentField, textField);
                    pnode.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        public void InitTree(DataTable dtTree, string mainField, string parentField, string textField)
        {
            B_Tree.Nodes.Clear();
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
                    if (dr[parentField].ToString() == string.Empty)
                    {
                        ExtAspNet.TreeNode nodeChild = new ExtAspNet.TreeNode();
                        nodeChild.NodeID = dr[mainField].ToString();
                        nodeChild.Text = dr[textField].ToString();
                        //node.IconUrl =
                        nodeChild.EnableCheckBox = true;
                        nodeChild.Expanded = true;
                        nodeChild.AutoPostBack = true;
                        CreateTree(dr[mainField].ToString(), nodeChild, dtTree, mainField, parentField, textField);
                        node.Nodes.Add(nodeChild);
                    }
                }
            }
            B_Tree.Nodes.Add(node);
        }
        #endregion
    }
}
