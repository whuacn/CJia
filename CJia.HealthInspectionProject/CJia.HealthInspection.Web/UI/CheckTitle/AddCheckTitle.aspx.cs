using CJia.HealthInspection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI
{
    public partial class AddCheckTitle : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IAddCheckTitle
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnInit != null)
                {
                    OnInit(null, null);
                    ddl_Big_SelectedIndexChanged(null, null);
                    ddl_Middle_SelectedIndexChanged(null, null);
                    Session["AddCheckTitelTooltip"] = txt_Small.Text;
                    //CJia.HealthInspection.Common.AddCheckTitelTooltip = txt_Small.Text;
                    //Common.SmallTemplateTypeIDList.Clear();
                    Session["SmallTemplateTypeIDList"] = new List<string>();
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.AddCheckTitlePresenter(this);
        }
        AddCheckTitleArgs addCheckTitleArgs = new AddCheckTitleArgs();

        #region IAddCheckTitle成员
        public event EventHandler<AddCheckTitleArgs> OnInit;
        public event EventHandler<AddCheckTitleArgs> OnBigTempChange;
        public event EventHandler<AddCheckTitleArgs> OnMidTempChange;
        public event EventHandler<AddCheckTitleArgs> OnSave;
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("添加成功！", "提示对话框", "location.href=location.href;");
            }
            else
            {
                Alert.ShowInTop("添加失败，请与管理员联系……！", "提示对话框");
            }
        }
        public void ExeBindBigTemp(DataTable data, bool bol)
        {
            ddl_Big.DataSource = data;
            ddl_Big.DataTextField = "BIG_TEMPLATE_NAME";
            ddl_Big.DataValueField = "BIG_TEMPLATE_ID";
            ddl_Big.DataBind();
        }
        public void ExeBindMidTemp(DataTable data, bool bol)
        {
            ddl_Middle.DataSource = data;
            ddl_Middle.DataTextField = "MIDDLE_TEMPLATE_NAME";
            ddl_Middle.DataValueField = "MIDDLE_TEMPLATE_ID";
            ddl_Middle.DataBind();
        }
        public void ExeBindSmallTemp(DataTable data, bool bol)
        {
            ddl_Small.DataSource = data;
            ddl_Small.DataTextField = "SMALL_TEMPLATE_NAME";
            ddl_Small.DataValueField = "SMALL_TEMPLATE_ID";
            ddl_Small.DataBind();
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 创建答案 结果 意见DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable CreateAnswerData()
        {
            DataTable answerData = new DataTable();
            answerData.Columns.Add("AnswerName", typeof(String));
            answerData.Columns.Add("Result", typeof(String));
            answerData.Columns.Add("Advice", typeof(String));
            if (txt_answer1.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer1.Text;
                dr["Result"] = txt_result1.Text;
                dr["Advice"] = txt_advice1.Text;
                answerData.Rows.Add(dr);
            }
            if (txt_answer2.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer2.Text;
                dr["Result"] = txt_result2.Text;
                dr["Advice"] = txt_advice2.Text;
                answerData.Rows.Add(dr);
            }
            if (txt_answer3.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer3.Text;
                dr["Result"] = txt_result3.Text;
                dr["Advice"] = txt_advice3.Text;
                answerData.Rows.Add(dr);
            }
            if (txt_answer4.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer4.Text;
                dr["Result"] = txt_result4.Text;
                dr["Advice"] = txt_advice4.Text;
                answerData.Rows.Add(dr);
            }
            if (txt_answer5.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer5.Text;
                dr["Result"] = txt_result5.Text;
                dr["Advice"] = txt_advice5.Text;
                answerData.Rows.Add(dr);
            }
            if (txt_answer6.Text.Length != 0)
            {
                DataRow dr = answerData.NewRow();
                dr["AnswerName"] = txt_answer6.Text;
                dr["Result"] = txt_result6.Text;
                dr["Advice"] = txt_advice6.Text;
                answerData.Rows.Add(dr);
            }
            return answerData;
        }
        #endregion

        protected void ddl_Big_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnBigTempChange != null)
            {
                addCheckTitleArgs.BigTemplateID = ddl_Big.SelectedValue;
                OnBigTempChange(null, addCheckTitleArgs);
                ddl_Middle_SelectedIndexChanged(null, null);
            }
        }

        protected void ddl_Middle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnMidTempChange != null)
            {
                addCheckTitleArgs.MiddleTemplateID = ddl_Middle.SelectedValue;
                OnMidTempChange(null, addCheckTitleArgs);
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (Session["AddCheckTitelTooltip"] != null)
            {
                if (txt_Small.Text == Session["AddCheckTitelTooltip"].ToString())
                {
                    txt_Small.Text = ddl_Small.SelectedText;
                    (Session["SmallTemplateTypeIDList"] as List<string>).Add(ddl_Small.SelectedValue);
                    //Common.SmallTemplateTypeIDList.Add(ddl_Small.SelectedValue);
                }
            }
            if (txt_Small.Text.Length == 0)
            {
                txt_Small.Text = ddl_Small.SelectedText;
                //Common.SmallTemplateTypeIDList.Add(ddl_Small.SelectedValue);
                (Session["SmallTemplateTypeIDList"] as List<string>).Add(ddl_Small.SelectedValue);
            }
            else
            {
                if (!txt_Small.Text.Contains(ddl_Small.SelectedText))
                {
                    txt_Small.Text = txt_Small.Text + "," + ddl_Small.SelectedText;
                    //Common.SmallTemplateTypeIDList.Add(ddl_Small.SelectedValue);
                    (Session["SmallTemplateTypeIDList"] as List<string>).Add(ddl_Small.SelectedValue);
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if ((Session["SmallTemplateTypeIDList"] as List<string>).Count > 0)
            {
                addCheckTitleArgs.TitleName = txt_TitleName.Text;
                addCheckTitleArgs.TitleContent = txt_title_content.Text;
                addCheckTitleArgs.IsChoice = cb_IsChoice.Checked ? "1" : "0";
                addCheckTitleArgs.SmallTemplateTypeIDList = Session["SmallTemplateTypeIDList"] as List<string>;
                addCheckTitleArgs.User = (DataTable)Session["User"];
                if (cb_IsChoice.Checked)
                {
                    DataTable answerData = CreateAnswerData();
                    addCheckTitleArgs.AnswersData = answerData;
                }
                if (OnSave != null)
                {
                    OnSave(sender, addCheckTitleArgs);
                }
                //if (Request.QueryString["PageType"] == "1")
                //{
                //    addCheckTitleArgs.UserID = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
                //    addCheckTitleArgs.CheckID = Convert.ToInt64(Request.QueryString["CheckID"]);
                //    OnSaveSingleTitle(null, addCheckTitleArgs);
                //}
                //else
                //{
                //    if (OnSave != null)
                //    {
                //        OnSave(sender, addCheckTitleArgs);
                //    }
                //}
            }
            else
            {
                Alert.ShowInTop("请选择题目分类！", "提示对话框");
                ddl_Big.Focus(true);
            }
        }


        
    }
}