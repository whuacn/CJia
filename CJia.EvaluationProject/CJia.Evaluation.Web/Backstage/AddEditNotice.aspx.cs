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
    public partial class AddNotice : CJia.Evaluation.Tools.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OperType"].ToString() == "Select")
            {
                DataBanding();
                txt_Notice_Subject.Readonly = true;
                dt_Notice_Date.Readonly = true;
                ckedit_add.ReadOnly = true;
                btn_Add_Data.Hidden = true;
            }
            else if (Request.QueryString["OperType"].ToString() == "Update")
            {
                DataBanding();
            }
            if (!IsPostBack)
            {
                    //DataBanding();
                    initPage();
            }
        }

        /// <summary>
        /// 公告数据绑定
        /// </summary>
        void DataBanding()
        {
            DataTable dt = SelectNoticeData(Request.QueryString["NoticeID"].ToString());
            txt_Notice_Subject.Text = dt.Rows[0]["NOTICE_SUBJECT"].ToString();
            dt_Notice_Date.SelectedDate = DateTime.Parse(dt.Rows[0]["VALID_DATE"].ToString());
            ckedit_add.Text = dt.Rows[0]["NOTICE_TEXT"].ToString();
        }

        protected override object CreatePresenter()
        {
            return null;
        }

        protected void btn_Add_Data_Click(object sender, EventArgs e)
        {
            if (Sysdate < DateTime.Parse(dt_Notice_Date.Text))
            {
                string strHtml = HttpUtility.UrlDecode(ckedit_add.Text);
                string strReplaceFile = strHtml.Replace(">/ckfinder/userfiles/files/", ">");
                DataTable dt = Session["User"] as DataTable;
                string UserID = dt.Rows[0]["USER_ID"].ToString();
                if (Request.QueryString["OperType"].ToString() == "Insert")
                {
                    bool bol = AddNoticeData(txt_Notice_Subject.Text, strReplaceFile, DateTime.Parse(dt_Notice_Date.Text), UserID);
                    if (bol)
                    {
                        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                    }
                    else
                    {
                        ExtAspNet.Alert.ShowInTop("保存失败！", ExtAspNet.MessageBoxIcon.Error);
                    }
                }

                else if (Request.QueryString["OperType"].ToString() == "Update")
                {
                    bool bol = EditNoticeData(txt_Notice_Subject.Text, strReplaceFile, DateTime.Parse(dt_Notice_Date.Text), UserID, Request.QueryString["NoticeID"].ToString());
                    if (bol)
                    {
                        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                    }
                    else
                    {
                        ExtAspNet.Alert.ShowInTop("保存失败！", ExtAspNet.MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Alert.ShowInTop("截至日期不能小于当前日期！", MessageBoxIcon.Error);
            }
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 初始化人、科室
        /// </summary>
        void initPage()
        {
            DataTable dt = Session["User"] as DataTable;
            txt_Notice_User.Text = dt.Rows[0]["USER_NAME"].ToString();
            txt_Notice_Dept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
            //UserID = dt.Rows[0]["USER_ID"].ToString();
            //DeptID = "0";
        }

        protected bool AddNoticeData(string NoticeSubject, string NoticeText, DateTime NoticeValid, string NoticeUser)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[4] { NoticeSubject, NoticeText, NoticeUser, NoticeValid };
                return ad.Execute(@"insert into tt_notice(notice_id, notice_subject, notice_text, create_by, create_date, valid_date, status)
                                                    values(tt_notice_seq.nextval,?,?,?,sysdate,?,'1')", sqlParams) > 0 ? true : false;
            }
        }

        protected bool EditNoticeData(string NoticeSubject, string NoticeText, DateTime NoticeValid, string NoticeUser, string NoticeID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[5] { NoticeSubject, NoticeText, NoticeValid, NoticeUser, NoticeID };
                return ad.Execute(@"update tt_notice set Notice_subject=?,notice_text=?,valid_date=? ,update_by=?,update_date=sysdate
                                                    where notice_id=?", sqlParams) > 0 ? true : false;
            }
        }

        /// <summary>
        ///查看公告
        /// </summary>
        /// <returns></returns>
        DataTable SelectNoticeData(string NoticeID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[1] { NoticeID };
                return ad.Query(@"select * from tt_notice where notice_id=?", sqlParams);
            }
        }


    }
}