using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class BackHomePage : CJia.Evaluation.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                    MenuOperate();
            }
        }
        protected override object CreatePresenter()
        {
            return null;
        }

        private void MenuOperate()
        {
            CJia.Evaluation.Models.Backstage.BackHomePageModel model = new Models.Backstage.BackHomePageModel();
            DataTable dtUser = Session["User"] as DataTable;
            string UserId = dtUser.Rows[0]["USER_ID"].ToString();
            DataTable dt = model.QueryNoMenuComptence(UserId);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["MENU_ID"].ToString())
                    {
                        case "1000000000":
                            ap_MBasic.Visible = false;
                            break;
                        case "1000000001":
                            tree_MBasic.Nodes.Remove(tree_MBasic.FindNode("node_DeptUser"));
                            break;
                        case "1000000002":
                            tree_MBasic.Nodes.Remove(tree_MBasic.FindNode("node_ColumnManage"));
                            break;
                        case "1000000003":
                            tree_MBasic.Nodes.Remove(tree_MBasic.FindNode("node_TypeEdit"));
                            break;
                        case "1000000004":
                            tree_MBasic.Nodes.Remove(tree_MBasic.FindNode("node_NoticeManage"));
                            break;
                        case "1000000005":
                            ap_MBusiness.Visible = false;
                            break;
                        case "1000000006":
                            tree_MBusiness.Nodes.Remove(tree_MBusiness.FindNode("node_DataInput"));
                            break;
                        case "1000000007":
                            tree_MBusiness.Nodes.Remove(tree_MBusiness.FindNode("node_DataQuery"));
                            break;
                        case "1000000008":
                            ap_MArticle.Visible = false;
                            break;
                        case "1000000009":
                            tree_MArticle.Nodes.Remove(tree_MArticle.FindNode("node_DataDeclare"));
                            break;
                        case "1000000010":
                            tree_MArticle.Nodes.Remove(tree_MArticle.FindNode("node_DataReview"));
                            break;
                        case "1000000011":
                            tree_MArticle.Nodes.Remove(tree_MArticle.FindNode("node_ReviewQuery"));
                            break;
                        case "1000000012":
                            tree_MArticle.Nodes.Remove(tree_MArticle.FindNode("node_ReviewStats"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}