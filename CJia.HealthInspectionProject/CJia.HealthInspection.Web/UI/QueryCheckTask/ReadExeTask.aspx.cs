using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.QueryCheckTask
{
    public partial class ReadExeTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IReadExeTask
    {
        CJia.HealthInspection.Views.ReadExeTaskArgs readExeTaskArgs = new Views.ReadExeTaskArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                readExeTaskArgs.ExeTaskId = Convert.ToInt64(Request.QueryString["ExeTaskId"]);
                //readExeTaskArgs.TaskId = Convert.ToInt64(Request.QueryString["TaskId"]);
                OnQueryExeTaskById(null, readExeTaskArgs);
                OnInitExeTaskTitle(null, readExeTaskArgs);
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            OnInitTouchFiled(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ReadExeTaskPresenter(this);
        }

        #region【实现接口】
        public event EventHandler<Views.ReadExeTaskArgs> OnQueryExeTaskById;

        public event EventHandler<Views.ReadExeTaskArgs> OnInitTouchFiled;

        public event EventHandler<Views.ReadExeTaskArgs> OnInitExeTaskTitle;

        public void ExeBindTaskTitle(System.Data.DataTable dtTitleAnswer, string TitleID, string TitleName, string TitleContent, long CheckAnswerId, string TitleResult, string TitleAdvice)
        {
            ExtAspNet.AccordionPane accord = new ExtAspNet.AccordionPane();
            accord.ID = TitleID;
            accord.Title = TitleName;
            accord.BodyPadding = "2px 5px";
            accord.ShowBorder = false;
            if (dtTitleAnswer != null)
            {
                ExtAspNet.RadioButtonList radioAnswer = new ExtAspNet.RadioButtonList();
                radioAnswer.ID = (Convert.ToInt64(TitleID) + 1).ToString();
                radioAnswer.ColumnNumber = 1;
                radioAnswer.Label = "选择答案";
                for (int i = 0; i < dtTitleAnswer.Rows.Count; i++)
                {
                    radioAnswer.Items.Add(new ExtAspNet.RadioItem(dtTitleAnswer.Rows[i]["ANSWER_NAME"].ToString(), dtTitleAnswer.Rows[i]["ANSWER_ID"].ToString()));
                    if (Convert.ToInt64(dtTitleAnswer.Rows[i]["ANSWER_ID"]) == CheckAnswerId)
                    {
                        radioAnswer.SelectedIndex = i;
                    }
                }
                accord.Items.Add(radioAnswer);
            }
            ExtAspNet.Label lableResult = new ExtAspNet.Label();
            lableResult.Text = "检查笔录:" + "  " + TitleResult;
            ExtAspNet.Label lableAdvice = new ExtAspNet.Label();
            lableAdvice.Text = "检查意见:   " + TitleAdvice;
            ExtAspNet.Label lable1 = new ExtAspNet.Label();
            ExtAspNet.Label lable2 = new ExtAspNet.Label();
            accord.Items.Add(lable1);
            accord.Items.Add(lableResult);
            accord.Items.Add(lable2);
            accord.Items.Add(lableAdvice);
            Accordion1.Panes.Add(accord);
        }

        public void ExeBindExeTask(System.Data.DataTable dtExeTask)
        {
            txt_unitName.Text = dtExeTask.Rows[0]["UNIT_NAME"].ToString();
            txt_Task.Text = dtExeTask.Rows[0]["Task_NAME"].ToString();
            string a = Request.QueryString["OrganName"].ToString();
            txt_OrganName.Text = a;
            ddl_wuzheng.SelectedValue = dtExeTask.Rows[0]["IS_LICENSE"].ToString();
            ddl_jiandang.SelectedValue = dtExeTask.Rows[0]["IS_FILING"].ToString();
            txt_address.Text = dtExeTask.Rows[0]["CHECK_POINT"].ToString();
            dp_start.SelectedDate = Convert.ToDateTime(dtExeTask.Rows[0]["START_DATETIME"]);
            dp_end.SelectedDate = Convert.ToDateTime(dtExeTask.Rows[0]["END_DATETIME"]);
            ddl_zhenggai.SelectedValue = dtExeTask.Rows[0]["IS_RECTIFICATION"].ToString();
            if (dtExeTask.Rows[0]["IS_RECTIFICATION"].ToString() == "1")
            {
                dp_fucha.Hidden = false;
                dp_fucha.SelectedDate = Convert.ToDateTime(dtExeTask.Rows[0]["REVIEW_DATE"]);
            }
            ddl_fucha.SelectedValue = dtExeTask.Rows[0]["IS_REVIEW"].ToString();
            if (dtExeTask.Rows[0]["IS_REVIEW"].ToString() == "1")
            {
                ddl_zhqk.Hidden = false;
                ddl_zhqk.SelectedValue = dtExeTask.Rows[0]["RECTIFICATION_RESULT_ID"].ToString();
            }
            ExtAspNet.CheckBoxList checkBoxlist = row_TouchFiled.FindControl("touchFiled1") as ExtAspNet.CheckBoxList;
            string[] touchFiled = dtExeTask.Rows[0]["INVOLVE_CONTENT"].ToString().Substring(1).Split('|');
            checkBoxlist.SelectedValueArray = touchFiled;
            txt_remark.Text = dtExeTask.Rows[0]["REMARK"].ToString();
            txt_CheckResult.Text = dtExeTask.Rows[0]["CHECK_RESULT_NAME"].ToString();
            txt_Checker.Text = dtExeTask.Rows[0]["CHECK_ONE_NAME"].ToString() + ", " + dtExeTask.Rows[0]["CHECK_TWO_NAME"].ToString();
            txta_CheckResult.Text = dtExeTask.Rows[0]["CHECK_NOTES"].ToString();
            txta_CheckAdvice.Text = dtExeTask.Rows[0]["CHECK_OPINION"].ToString();
        }

        public void ExeBindTouchFiled(System.Data.DataTable dtTouchFiled)
        {
            ExtAspNet.CheckBoxList touchFiled = new ExtAspNet.CheckBoxList();
            touchFiled.ID = "touchFiled1";
            touchFiled.ColumnNumber = 6;
            touchFiled.Readonly = true;
            touchFiled.Required = true;
            touchFiled.Label = "涉及条线";
            for (int i = 0; i < dtTouchFiled.Rows.Count; i++)
            {
                touchFiled.Items.Add(new ExtAspNet.CheckItem(dtTouchFiled.Rows[i]["NAME"].ToString(), dtTouchFiled.Rows[i]["CODE"].ToString()));
            }
            row_TouchFiled.Items.Add(touchFiled);
        }
        #endregion


        
    }
}