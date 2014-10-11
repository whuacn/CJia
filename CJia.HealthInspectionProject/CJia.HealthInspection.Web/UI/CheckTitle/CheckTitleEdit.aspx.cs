using CJia.HealthInspection.Views;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.CheckTitle
{
    public partial class CheckTitleEdit : Tools.Page, Views.ICheckTitleEdit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnInitPage != null)
                {
                    checkTitleEditArgs.CheckTitleID = this.Request["ID"].ToString();
                    OnInitPage(null, checkTitleEditArgs);
                    if (this.Request["isEdit"].ToString() == "0")
                    {
                        btn_Save.Visible = false;
                    }
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.CheckTitleEditPresenter(this);
        }
        CheckTitleEditArgs checkTitleEditArgs = new CheckTitleEditArgs();
        public event EventHandler<CheckTitleEditArgs> OnInitPage;
        public event EventHandler<CheckTitleEditArgs> OnSave;
        public void ExeBindCheckTitle(DataTable data, DataTable dataType)
        {
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dataType.Rows)
            {
                str = str.Append(dr["SMALL_TEMPLATE_NAME"].ToString() + " ");
            }
            txt_Type.Text = str.ToString();
            txt_TitleName.Text = data.Rows[0]["CHECK_TITLE_NAME"].ToString();
            txt_title_content.Text = data.Rows[0]["CHECK_TITLE_CONTENT"].ToString();
            if (data.Rows[0]["IS_CHOICE"].ToString() == "1")
            {
                cb_IsChoice.Checked = true;
            }
            else
            {
                cb_IsChoice.Checked = false;
            }
            int count = 0;
            if (data != null)
            {
                count = data.Rows.Count;
            }
            if (count > 0)
            {
                count = data.Rows.Count;
                txt_answer1.Text = data.Rows[0]["ANSWER_NAME"].ToString();
                txt_result1.Text = data.Rows[0]["CHECK_RESULT"].ToString();
                txt_advice1.Text = data.Rows[0]["ADVICE"].ToString();
            }
            if (count > 1)
            {
                txt_answer2.Text = data.Rows[1]["ANSWER_NAME"].ToString();
                txt_result2.Text = data.Rows[1]["CHECK_RESULT"].ToString();
                txt_advice2.Text = data.Rows[1]["ADVICE"].ToString();
            }
            if (count > 2)
            {
                txt_answer3.Text = data.Rows[2]["ANSWER_NAME"].ToString();
                txt_result3.Text = data.Rows[2]["CHECK_RESULT"].ToString();
                txt_advice3.Text = data.Rows[2]["ADVICE"].ToString();
            }
            if (count > 3)
            {
                txt_answer4.Text = data.Rows[3]["ANSWER_NAME"].ToString();
                txt_result4.Text = data.Rows[3]["CHECK_RESULT"].ToString();
                txt_advice4.Text = data.Rows[3]["ADVICE"].ToString();
            }
            if (count > 4)
            {
                txt_answer5.Text = data.Rows[4]["ANSWER_NAME"].ToString();
                txt_result5.Text = data.Rows[4]["CHECK_RESULT"].ToString();
                txt_advice5.Text = data.Rows[4]["ADVICE"].ToString();
            }
            if (count > 5)
            {
                txt_answer6.Text = data.Rows[5]["ANSWER_NAME"].ToString();
                txt_result6.Text = data.Rows[5]["CHECK_RESULT"].ToString();
                txt_advice6.Text = data.Rows[5]["ADVICE"].ToString();
            }
        }
        public void ExeIsSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("修改成功", "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop("修改失败，请与管理员联系……");
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (OnSave != null)
            {
                checkTitleEditArgs.CheckTitleID = this.Request["ID"].ToString();
                checkTitleEditArgs.AnswersData = CreateAnswerData();
                checkTitleEditArgs.TitleName = txt_TitleName.Text;
                checkTitleEditArgs.TitleContent = txt_title_content.Text;
                checkTitleEditArgs.IsChoice = cb_IsChoice.Checked ? "1" : "0";
                checkTitleEditArgs.User = (DataTable)Session["User"];
                OnSave(null, checkTitleEditArgs);
            }
        }
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
    }
}