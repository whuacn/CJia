using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.ExeTask
{
    public partial class ExeTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IExeTask
    {
        CJia.HealthInspection.Views.ExeTaskArgs exeTaskArgs = new Views.ExeTaskArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                Session["UnitNameTask"] = null;
                Session["UnitAddressTask"] = null;
                Session["TaskNameExe"] = null;
                Session["IsSelectTask"] = null;
                dp_start.SelectedDate = DateTime.Now;
                dp_end.SelectedDate = DateTime.Now;
                exeTaskArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
                exeTaskArgs.UserId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
                OnQueryChecker(null, exeTaskArgs);
            }
            if (Session["UnitNameTask"] != null && Session["UnitAddressTask"] != null)
            {
                txt_unitName.Text = Session["UnitNameTask"].ToString();
                txt_address.Text = Session["UnitAddressTask"].ToString();
            }
            if (Session["TaskNameExe"] != null)
            {
                txt_Task.Text = Session["TaskNameExe"].ToString();
            }
            if (Session["IsSelectTask"] != null && Session["IsSelectTask"].ToString() == "1")
            {
                if (Convert.ToInt64(Session["TaskTemplateIdExe"]) != 0)
                {
                    exeTaskArgs.TemplateId = Convert.ToInt64(Session["TaskTemplateIdExe"]);
                    OnQueryInitTaskTitle(null, exeTaskArgs);
                    Session["CheckResultTask"] = null;
                    Session["CheckAdviceTask"] = null;
                    Session["IsSelectTask"] = "0";
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            OnQueryTouchFiled(null, null);
            OnInitCheckResult(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ExeTaskPresenter(this);
        }

        protected override bool InitPage()
        {
            this.B_gr_Main = gridCheckTitle;
            //this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        protected void ddl_zhenggai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_zhenggai.SelectedValue == "1")
            {
                //dp_fucha.Enabled = true;
                dp_fucha.Hidden = false;
                dp_fucha.SelectedDate = DateTime.Now.AddDays(1);
            }
            if (ddl_zhenggai.SelectedValue == "0")
            {
                //dp_fucha.Enabled = false;
                dp_fucha.Hidden = true;
                dp_fucha.SelectedDate = null;
                //dp_fucha.Text = "";
                dp_fucha.EmptyText = "( 空 )";
            }
        }

        protected void ddl_fucha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_fucha.SelectedValue == "0")
            {
                //ddl_zhqk.Enabled = false;
                ddl_zhqk.Hidden = true;
            }
            if (ddl_fucha.SelectedValue == "1")
            {
                //ddl_zhqk.Enabled = true;
                ddl_zhqk.Hidden = false;
                ddl_zhqk.SelectedIndex = 0;
            }
        }

        //选择单位
        protected void btn_selectUnit_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/SelectUnit.aspx?WhichPage=Task", "选择单位"));
        }

        //选择任务
        protected void btn_selectTask_Click(object sender, EventArgs e)
        {
            Session["IsSelectTask"] = "1";
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/ExeTask/SelectTask.aspx", "选择任务"));
        }

        #region【接口实现】
        public event EventHandler<Views.ExeTaskArgs> OnQueryTouchFiled;

        public event EventHandler<Views.ExeTaskArgs> OnQueryInitTaskTitle;

        public event EventHandler<Views.ExeTaskArgs> OnQueryChecker;

        public event EventHandler<Views.ExeTaskArgs> OnSaveExeTask;

        public event EventHandler<Views.ExeTaskArgs> OnInitCheckResult;

        public void ExeBindCheckResult(DataTable dtCheckResult)
        {
            ExtAspNet.DropDownList DdcheckResult = new ExtAspNet.DropDownList();
            DdcheckResult.ID = "DdcheckResult1";
            DdcheckResult.AutoPostBack = true;
            DdcheckResult.Label = "检查结果";
            for (int i = 0; i < dtCheckResult.Rows.Count; i++)
            {
                DdcheckResult.Items.Add(new ExtAspNet.ListItem(dtCheckResult.Rows[i]["NAME"].ToString(), dtCheckResult.Rows[i]["CODE"].ToString()));
            }
            row_CheckResult.Items.Add(DdcheckResult);
        }

        public void ExeBindChecker(DataTable dtChecker)
        {
            ddl_Checker.DataSource = dtChecker;
            ddl_Checker.DataTextField = "USER_NAME";
            ddl_Checker.DataValueField = "USER_ID";
            ddl_Checker.DataBind();
            ddl_Checker.Items.Insert(0, new ExtAspNet.ListItem("请选择另外一位执行人...", "0"));
        }

        public void ExeBindTaskTitle(System.Data.DataTable dtTaskTitle)
        {
            Session["ExeTaskTitleList"] = dtTaskTitle;
            List<AnswerTitle> ListAnswerTitle = new List<AnswerTitle>();
            for (int i = 0; i < dtTaskTitle.Rows.Count; i++)
            {
                AnswerTitle answerTitle = new AnswerTitle();
                answerTitle.TitleID = Convert.ToInt64(dtTaskTitle.Rows[i]["CHECK_TITLE_ID"]);
                answerTitle.TitleName = (i + 1) + "、 " + dtTaskTitle.Rows[i]["CHECK_TITLE_NAME"].ToString();
                answerTitle.TitleContent = dtTaskTitle.Rows[i]["CHECK_TITLE_CONTENT"].ToString();
                ListAnswerTitle.Add(answerTitle);
            }
            Session["ExeTaskTitleClassList"] = ListAnswerTitle;
            InitGrid(dtTaskTitle);
        }

        /// <summary>
        /// 绑定涉及条线
        /// </summary>
        /// <param name="dtToucheFiled"></param>
        public void ExeBindTouchFiled(System.Data.DataTable dtToucheFiled)
        {
            if (dtToucheFiled != null)
            {
                ExtAspNet.CheckBoxList touchFiled = new ExtAspNet.CheckBoxList();
                touchFiled.ID = "touchFiled1";
                touchFiled.ColumnNumber = 6;
                touchFiled.AutoPostBack = true;
                touchFiled.Required = true;
                touchFiled.Label = "涉及条线";
                for (int i = 0; i < dtToucheFiled.Rows.Count; i++)
                {
                    touchFiled.Items.Add(new ExtAspNet.CheckItem(dtToucheFiled.Rows[i]["NAME"].ToString(), dtToucheFiled.Rows[i]["CODE"].ToString()));
                }
                row_TouchFiled.Items.Add(touchFiled);
            }
        }

        public void ExeCleanScreen()
        {
            Session["UnitNameTask"] = null;
            Session["UnitAddressTask"] = null;
            Session["TaskNameExe"] = null;
            Session["IsSelectTask"] = null;
            Session["ExeTaskTitleList"] = null;
            Session["ExeTaskTitleClassList"] = null;
            PageContext.Refresh();
            ExtAspNet.Alert.ShowInTop("任务执行成功", ExtAspNet.MessageBoxIcon.Information);
        }
        #endregion

        protected void btn_answer_Click(object sender, EventArgs e)
        {
            List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
            if (ListAnswerTitle != null && ListAnswerTitle.Count > 0)
            {
                //当前答题的Index
                Session["TitleIndexTask"] = 0;
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/Answer.aspx?WhichPage=ExeTask", "答题"));
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("请选择任务", MessageBoxIcon.Information);
            }
        }

        protected void btn_ResultAdvice_Click(object sender, EventArgs e)
        {
            if (Session["UnitNameTask"] != null)
            {
                if (ddl_Checker.SelectedValue != "0")
                {
                    if (Session["ExeTaskTitleClassList"] != null)
                    {
                        List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                        if (ListAnswerTitle != null)
                        {
                            string CheckResult = "{0}卫生监督员【{1},{2}】,对【{3}】进行现场检查。检查人员向【{4}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine;
                            CheckResult = string.Format(CheckResult, (Session["User"] as DataTable).Rows[0]["ORGAN_NAME"].ToString(), (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString(), ddl_Checker.SelectedText, Session["UnitNameTask"].ToString(), Session["UnitNameTask"].ToString());
                            string CheckAdvice = "";
                            int a = 1;
                            int b = 1;
                            //List<AnswerTitle> ListAnswerTitle1 = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                            for (int i = 0; i < ListAnswerTitle.Count; i++)
                            {
                                if (ListAnswerTitle[i].IsAnswered == true)
                                {
                                    if (ListAnswerTitle[i].TitleRusult != "")
                                    {
                                        CheckResult = CheckResult + a.ToString() + "、 " + ListAnswerTitle[i].TitleRusult + "。" + Environment.NewLine;
                                        a++;
                                    }
                                    if (ListAnswerTitle[i].TitleAdvice != "")
                                    {
                                        CheckAdvice = CheckAdvice + b.ToString() + "、 " + ListAnswerTitle[i].TitleAdvice + "。" + Environment.NewLine;
                                        b++;
                                    }
                                }
                            }
                            Session["CheckResultTask"] = CheckResult;
                            Session["CheckAdviceTask"] = CheckAdvice;
                        }
                        else
                        {
                            Session["CheckResultTask"] = null;
                            Session["CheckAdviceTask"] = null;
                        }
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/CheckResultAdvice.aspx?WhichPage=ExeTask", "查看检查笔录和意见书"));
                    }
                    else
                    {
                        Alert.ShowInTop("请先选择模板", MessageBoxIcon.Information);
                    }

                }
                else
                {
                    Alert.ShowInTop("请选择执行人!", MessageBoxIcon.Warning);
                }
            }
            else
            {
                Alert.ShowInTop("请选择单位!", MessageBoxIcon.Warning);
            }
        }

        protected void ddl_Checker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Checker.SelectedValue != "0")
            {
                txt_Checker.Text = (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString() + "," + ddl_Checker.SelectedText;
                exeTaskArgs.CheckTwo = Convert.ToInt64(ddl_Checker.SelectedValue);
                exeTaskArgs.CheckTwoName = ddl_Checker.SelectedText.ToString();
            }
            else
            {
                txt_Checker.Text = null;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
            bool isAnswer = true;
            //List<int> noAnswerIndex = new List<int>();
            string strNoAnswerIndex = "";
            for (int i = 0; i < ListAnswerTitle.Count; i++)
            {
                if (ListAnswerTitle[i].IsAnswered == false)
                {
                    isAnswer = isAnswer && ListAnswerTitle[i].IsAnswered;
                    //noAnswerIndex.Add(i + 1);
                    strNoAnswerIndex = strNoAnswerIndex + (i + 1).ToString() + " ,";
                }
            }
            if (isAnswer == false)
            {
                strNoAnswerIndex = strNoAnswerIndex.Substring(0, strNoAnswerIndex.Length - 2);
                PageContext.RegisterStartupScript(@"if(confirm('还有第" + strNoAnswerIndex + @"题没答,是否放弃答题？'))
                                                    {
                                                        document.getElementById('btn_visualSave').click();
                                                    }
                                                    else 
                                                    {
                                                    }");
            }
            else
            {
                SaveExeTask();
            }
        }

        protected void btn_visualSave_Click(object sender, EventArgs e)
        {
            SaveExeTask();
        }

        private void SaveExeTask()
        {
            exeTaskArgs.UnitID = Convert.ToInt64(Session["UnitIDTask"]);
            exeTaskArgs.UnitName = Session["UnitNameTask"].ToString();
            exeTaskArgs.TaskId = Convert.ToInt64(Session["TaskIdExe"]);
            exeTaskArgs.TaskName = Session["TaskNameExe"].ToString();
            exeTaskArgs.IsLicence = Convert.ToChar(ddl_wuzheng.SelectedValue);
            exeTaskArgs.IsFiling = Convert.ToChar(ddl_jiandang.SelectedValue);
            exeTaskArgs.StartDateTime = Convert.ToDateTime(dp_start.Text);
            exeTaskArgs.End_DateTime = Convert.ToDateTime(dp_end.Text);
            exeTaskArgs.CheckPoint = txt_address.Text;
            exeTaskArgs.IsRectification = Convert.ToChar(ddl_zhenggai.SelectedValue);
            if (ddl_zhenggai.SelectedValue == "1")
            {
                exeTaskArgs.Review = Convert.ToDateTime(dp_fucha.Text);
            }
            else
            {
                exeTaskArgs.Review = Convert.ToDateTime("0001-01-01");
            }
            exeTaskArgs.IsReview = Convert.ToChar(ddl_fucha.SelectedValue);
            if (ddl_fucha.SelectedValue == "1")
            {
                exeTaskArgs.RectificationResult = Convert.ToChar(ddl_zhqk.SelectedValue);
            }
            else
            {
                exeTaskArgs.RectificationResult = ' ';
            }
            ExtAspNet.CheckBoxList checkboxlist = row_TouchFiled.FindControl("touchFiled1") as ExtAspNet.CheckBoxList;
            if (checkboxlist.SelectedIndexArray.Length == 0)
            {
                exeTaskArgs.TouchFiled = "";
            }
            else
            {
                for (int i = 0; i < checkboxlist.SelectedValueArray.Length; i++)
                {
                    exeTaskArgs.TouchFiled = exeTaskArgs.TouchFiled + "|" + checkboxlist.SelectedValueArray[i];
                }
            }
            exeTaskArgs.Remark = txt_remark.Text;
            ExtAspNet.DropDownList dropdownList = row_CheckResult.FindControl("DdcheckResult1") as ExtAspNet.DropDownList;
            exeTaskArgs.CheckResult = Convert.ToInt64(dropdownList.SelectedValue);
            exeTaskArgs.CheckOne = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
            exeTaskArgs.CheckOneName = (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString();
            exeTaskArgs.CheckTwo = Convert.ToInt64(ddl_Checker.SelectedValue);
            exeTaskArgs.CheckTwoName = ddl_Checker.SelectedText.ToString();
            if (Session["ExeTaskTitleClassList"] != null)
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                if (ListAnswerTitle != null)
                {
                    string CheckResult = "{0}卫生监督员【{1},{2}】,对【{3}】进行现场检查。检查人员向【{4}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine;
                    CheckResult = string.Format(CheckResult, (Session["User"] as DataTable).Rows[0]["ORGAN_NAME"].ToString(), (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString(), ddl_Checker.SelectedText, Session["UnitNameTask"].ToString(), Session["UnitNameTask"].ToString());
                    string CheckAdvice = "";
                    int a = 1;
                    int b = 1;
                    //List<AnswerTitle> ListAnswerTitle1 = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                    for (int i = 0; i < ListAnswerTitle.Count; i++)
                    {
                        if (ListAnswerTitle[i].IsAnswered == true)
                        {
                            if (ListAnswerTitle[i].TitleRusult != "")
                            {
                                CheckResult = CheckResult + a.ToString() + "、 " + ListAnswerTitle[i].TitleRusult + "。" + Environment.NewLine;
                                a++;
                            }
                            if (ListAnswerTitle[i].TitleAdvice != "")
                            {
                                CheckAdvice = CheckAdvice + b.ToString() + "、 " + ListAnswerTitle[i].TitleAdvice + "。" + Environment.NewLine;
                                b++;
                            }
                        }
                    }
                    exeTaskArgs.CheckNotes = string.Format(CheckResult, exeTaskArgs.CheckOneName, exeTaskArgs.CheckTwoName, exeTaskArgs.UnitName, exeTaskArgs.UnitName);
                    exeTaskArgs.CheckOpinion = CheckAdvice;
                }
                else
                {
                    exeTaskArgs.CheckNotes = "";
                    exeTaskArgs.CheckOpinion = "";
                }
            }
            else
            {
                exeTaskArgs.CheckNotes = "";
                exeTaskArgs.CheckOpinion = "";
            }
            exeTaskArgs.listExeTaskTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
            exeTaskArgs.UserId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
            exeTaskArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            OnSaveExeTask(null, exeTaskArgs);
        }

        private void CleanScreen()
        {
            //txt_unitName.Text = "";
            //txt_Tmp.Text = "";
            //txt_address.Text = "";
            //ddl_zhenggai.SelectedIndex = 0;
            //ddl_fucha.SelectedIndex = 0;
            //ExtAspNet.CheckBoxList checkboxlist = row_TouchFiled.FindControl("touchFiled1") as ExtAspNet.CheckBoxList;
            //for (int i = 0; i < checkboxlist.Items.Count; i++)
            //{
            //    checkboxlist.Items[i].Selected = false;
            //}
            //txt_remark.Text = "";
            //ddl_Checker.SelectedIndex = 0;

        }



    }
}