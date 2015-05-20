using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb
{
    public partial class HomePage : CJia.Health.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    DataTable useData = Session["User"] as DataTable;
                    tbt_Clock.Text = DateTime.Now.ToString();
                    tbt_Info.Text = "欢迎【" + useData.Rows[0]["dept_name"].ToString() + "    " + useData.Rows[0]["USER_NAME"].ToString() + "】";
                    InitCNode();
                    int width = int.Parse(Request["winW"].ToString());
                    int height = int.Parse(Request["winH"].ToString());
                    tree_MArticle.Nodes[0].NavigateUrl = "UI/ReceiptFavorite.aspx?w=" + width + "&h=" + height;
                    tree_MArticle.Nodes[1].NavigateUrl = "UI/MyBorrow.aspx?w=" + width + "&h=" + height;
                }
            }
        }
        protected void InitCNode()
        {
            if (Session["User"] != null)
            {
                DataTable useData = Session["User"] as DataTable;
                string userID = useData.Rows[0]["USER_ID"].ToString();
                DataTable data = GetMyfavourite(userID);
                if (data != null && data.Rows.Count > 0)
                {
                    int width = int.Parse(Request["winW"].ToString());
                    int height = int.Parse(Request["winH"].ToString());
                    tree_MCenter.Nodes.Clear();
                    foreach (DataRow dr in data.Rows)
                    {
                        ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                        node.NodeID = dr["FAVORITES_ID"].ToString();
                        node.Text = dr["FAVORITES_NAME"].ToString();
                        node.IconUrl = "~/Icons/package.png";
                        node.NavigateUrl = "UI/MyFavorite.aspx?id=" + dr["FAVORITES_ID"].ToString() + "&w=" + width + "&h=" + height;
                        tree_MCenter.Nodes.Add(node);
                    }
                }
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }

        protected void btnRefulse_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                InitCNode();
            }
        }

        protected void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_ChangePassword.GetShowReference("ChangePassword.aspx", "修改密码"));
        }

        protected void tree_MCenter_NodeExpand(object sender, TreeExpandEventArgs e)
        {

        }

        protected void tree_MCenter_NodeCheck(object sender, TreeCheckEventArgs e)
        {

        }
    }
}