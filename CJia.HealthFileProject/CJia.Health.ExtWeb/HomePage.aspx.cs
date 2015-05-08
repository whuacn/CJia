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
                    string userID = useData.Rows[0]["USER_ID"].ToString();
                    InitPage(userID);
                }
            }
        }
        public void InitPage(string userID)
        {
            DataTable data = GetMyfavourite(userID);
            if (data != null && data.Rows.Count > 0)
            {
                tree_MCenter.Nodes.Clear();
                foreach (DataRow dr in data.Rows)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.NodeID = dr["FAVORITES_ID"].ToString();
                    node.Text = dr["FAVORITES_NAME"].ToString();
                    node.IconUrl = "~/Icons/package.png";
                    node.NavigateUrl = "UI/MyFavorite.aspx?id=" + dr["FAVORITES_ID"].ToString();
                    tree_MCenter.Nodes.Add(node);
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
                DataTable useData = Session["User"] as DataTable;
                string userID = useData.Rows[0]["USER_ID"].ToString();
                InitPage(userID);
            }
        }

        protected void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_ChangePassword.GetShowReference("ChangePassword.aspx", "修改密码"));
        }
    }
}