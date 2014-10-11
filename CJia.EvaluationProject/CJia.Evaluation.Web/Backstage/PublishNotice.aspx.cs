using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Data;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class SendNotice : CJia.Evaluation.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshTemplate();
            }
        }

        protected override object CreatePresenter()
        {
            return null;
        }
        protected void win_Edit_Close(object sender, WindowCloseEventArgs e)
        {
            RefreshTemplate();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshTemplate()
        {
            //string nodeID = tree_Main.SelectedNodeID;
            DataTable data = GetData();
            //gr_Main.RecordCount = data.Rows.Count;
            //gr_Main.DataSource = data.DefaultView;
            //gr_Main.DataBind();
            BindGrid(gr_Main, data);
        }

        /// <summary>
        /// 获得公告列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable data = ad.Query(@"select notice_id,
                                                                            notice_subject,
                                                                            gu.user_name create_USER,
                                                                            tn.create_date,
                                                                            valid_date, 
                                                                            dept_name create_dept
                                                                    from tt_notice TN,GM_USER GU,GM_DEPT GD
                                                                    where TN.CREATE_BY=GU.USER_ID
                                                                    AND GU.DEPT_ID=GD.DEPT_ID(+)
                                                                    AND TN.STATUS='1'
                                                                    and tn.valid_date>=sysdate
                                                                    order by tn.create_date desc", null);
                Session["PageNotice"] = data;
                return data;
            }
        }

        protected void btn_Delete_Notice_Click(object sender, EventArgs e)
        {
            int[] selectIndex = gr_Main.SelectedRowIndexArray;
            if (selectIndex.Length > 0)
            {
                object[] ob = gr_Main.DataKeys[selectIndex[0]];
                string NoticeID = ob[0].ToString();
                if (NoticeCreateBy(NoticeID))
                {
                    if (DelNoticeData(NoticeID))
                    {
                        ExtAspNet.Alert.ShowInTop("删除成功！", ExtAspNet.MessageBoxIcon.Information);
                        RefreshTemplate();
                    }
                    else
                    {
                        ExtAspNet.Alert.ShowInTop("删除失败！", ExtAspNet.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Alert.ShowInTop("当前操作员不是该公告的发布人，没有删除该公告的权限!", MessageBoxIcon.Warning);
                }
            }
            else
            {
                Alert.ShowInTop("请选择需要删除的类型!", MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <returns></returns>
        bool DelNoticeData(string NoticeID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[1] { NoticeID };
                return ad.Execute(@"update tt_notice set status='0' where notice_id=?", sqlParams) > 0 ? true : false;
            }
        }
        /// <summary>
        /// 该公告是否有当前用户创建
        /// </summary>
        /// <param name="NoticeID"></param>
        /// <returns></returns>
        bool NoticeCreateBy(string NoticeID)
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dt = Session["User"] as DataTable;
                string UserID = dt.Rows[0]["USER_ID"].ToString();
                object[] sqlParams = new object[2] { NoticeID, UserID };
                DataTable data = ad.Query(@"select * from tt_notice where notice_id=? and create_by=?", sqlParams);
                return data.Rows.Count > 0 ? true : false;
            }
        }


        protected void btn_Add_Notice_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddEditNotice.aspx?OperType=Insert", "发布公告"));
        }

        protected void gr_Main_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = gr_Main.DataKeys[e.RowIndex];
            if (e.CommandName == "Notice_Text")
            {
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddEditNotice.aspx?OperType=Select&NoticeID=" + keys[0].ToString(), "查看公告"));
            }
        }
        /// <summary>
        /// 编辑公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Edit_Notice_Click(object sender, EventArgs e)
        {
            int[] selectIndex = gr_Main.SelectedRowIndexArray;
            if (selectIndex.Length > 0)
            {
                object[] ob = gr_Main.DataKeys[selectIndex[0]];
                string NoticeID = ob[0].ToString();
                if (NoticeCreateBy(NoticeID))
                {
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("AddEditNotice.aspx?OperType=Update&NoticeID=" + NoticeID, "编辑公告"));
                }
                else
                {
                    Alert.ShowInTop("当前操作员不是该公告的发布人，没有编辑该公告的权限!", MessageBoxIcon.Warning);
                }
            }
            else
            {
                Alert.ShowInTop("请选择需要编辑的公告!", MessageBoxIcon.Warning);
            }
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            DataTable dtCheck = Session["PageNotice"] as DataTable;
            gr_Main.PageIndex = e.NewPageIndex;
            BindGrid(gr_Main, dtCheck);
        }

        protected void gr_Main_Sort(object sender, GridSortEventArgs e)
        {
            DataTable table = Session["PageData"] as DataTable;
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", e.SortField, e.SortDirection);
            gr_Main.DataSource = view1;
            gr_Main.DataBind();
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


    }
}