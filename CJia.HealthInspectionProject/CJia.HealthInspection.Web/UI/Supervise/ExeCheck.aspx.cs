using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    public partial class ExeCheck : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IExeCheck
    {
        Views.ExeCheckArgs exeCheckArgs = new Views.ExeCheckArgs();
        long TempID;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                Session["UnitName"] = null;
                Session["UnitAddress"] = null;
                Session["SelectedTemplateNameExeCheck"] = null;
                Session["ExeCheckTitleList"] = null;
                //Session["IsSelectTemp"] = "0";
                dp_start.SelectedDate = DateTime.Now;
                dp_end.SelectedDate = DateTime.Now;
                //OnInitAddCheckID(null, null);
                exeCheckArgs.organ_id = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
                exeCheckArgs.UserId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
                OnQueryChecker(null, exeCheckArgs);
            }

            if (Session["UnitName"] != null && Session["UnitAddress"] != null)
            {
                txt_unitName.Text = Session["UnitName"].ToString();
                txt_address.Text = Session["UnitAddress"].ToString();
            }
            if (Session["SelectedTemplateNameExeCheck"] != null)
            {
                txt_Tmp.Text = Session["SelectedTemplateNameExeCheck"].ToString();
            }
            if (Convert.ToInt32(Session["IsSelectTemp"]) == 1)
            {
                TempID = Convert.ToInt64(Session["ExeTempID"]);
                exeCheckArgs.TempID = Convert.ToInt64(Session["ExeTempID"]);
                OnIninCheckTitle(null, exeCheckArgs);
                Session["CheckResult"] = null;
                Session["CheckAdvice"] = null;
                Session["IsSelectTemp"] = "0";
            }
            if (Convert.ToInt32(Session["IsSelectTemp"]) == 2)
            {
                DataTable dtCheck = Session["ExeCheckTitleList"] as DataTable;
                ExeBindCheckTitle(dtCheck);
                Session["CheckResult"] = null;
                Session["CheckAdvice"] = null;
                Session["IsSelectTemp"] = "0";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            OnInitTouchFiled(null, null);
            OnInieCheckResult(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ExeCheckPresenter(this);
        }

        protected override bool InitPage()
        {
            this.B_gr_Main = gridCheckTitle;
            //this.B_ddl_PageSize = dropPageSize;
            return true;
        }

        //选择模板
        protected void btn_selectTemp_Click(object sender, EventArgs e)
        {
            //"UI/Task/SelectTemplate.aspx?isAdd=1"
            Session["IsSelectTemp"] = 1;
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Task/SelectTemplate.aspx?status=3", "选择模版"));
        }

        //选择单位
        protected void btn_selectUnit_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/SelectUnit.aspx?WhichPage=Check", "选择单位"));
        }

        protected void abc_TextChanged(object sender, EventArgs e)
        {

        }

        //答题
        protected void btn_answer_Click(object sender, EventArgs e)
        {
            List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
            if (ListAnswerTitle != null && ListAnswerTitle.Count > 0)
            {
                //当前答题的Index
                Session["TitleIndex"] = 0;
                PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/Answer.aspx?WhichPage=ExeCheck", "答题"));
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("请先选择模板或者添加题目", MessageBoxIcon.Warning);
            }
        }

        //增加零星题
        protected void btn_AddTitel_Click(object sender, EventArgs e)
        {
            Session["IsSelectTemp"] = 2;
            PageContext.RegisterStartupScript(Window1.GetShowReference("~/UI/Supervise/EditCheckTitle.aspx", "增加零星题"));
        }

        //查看检查笔录和意见书
        protected void btn_ResultAdvice_Click(object sender, EventArgs e)
        {
            if (Session["ExeCheckTitleClassList"] != null)
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                if (ListAnswerTitle != null)
                {
                    string CheckResult = "{0}卫生监督员【{1},{2}】,对【{3}】进行现场检查。检查人员向【{4}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine;
                    CheckResult = string.Format(CheckResult, (Session["User"] as DataTable).Rows[0]["ORGAN_NAME"].ToString(), (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString(), ddl_Checker.SelectedText, Session["UnitName"].ToString(), Session["UnitName"].ToString());
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
                    Session["CheckResult"] = CheckResult;
                    Session["CheckAdvice"] = CheckAdvice;
                    PageContext.RegisterStartupScript(win_Edit.GetShowReference("~/UI/Supervise/CheckResultAdvice.aspx?WhichPage=ExeCheck", "查看检查笔录和意见书"));
                }
            }
            else
            {
                Alert.ShowInTop("请先选择模板", MessageBoxIcon.Information);
            }
        }

        #region【实现接口】
        public event EventHandler<Views.ExeCheckArgs> OnIninCheckTitle;

        public event EventHandler<Views.ExeCheckArgs> OnInitAddCheckID;

        public event EventHandler<Views.ExeCheckArgs> OnInitTouchFiled;

        public event EventHandler<Views.ExeCheckArgs> OnInieCheckResult;

        public event EventHandler<Views.ExeCheckArgs> OnExeCheck;

        public event EventHandler<Views.ExeCheckArgs> OnQueryChecker;

        public void ExeBindChecker(DataTable dtChecker)
        {
            ddl_Checker.DataSource = dtChecker;
            ddl_Checker.DataTextField = "USER_NAME";
            ddl_Checker.DataValueField = "USER_ID";
            ddl_Checker.DataBind();
            ddl_Checker.Items.Insert(0, new ExtAspNet.ListItem("请选择另外一位执行人...", "0"));

        }

        public void ExeBindCheckResult(DataTable dtCheckResult)
        {
            if (dtCheckResult != null && dtCheckResult.Rows != null && dtCheckResult.Rows.Count > 0)
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
        }

        /// <summary>
        /// 绑定涉及条线
        /// </summary>
        /// <param name="dtTouchFiled"></param>
        public void ExeBindTouchFiled(DataTable dtTouchFiled)
        {
            if (dtTouchFiled != null && dtTouchFiled.Rows != null && dtTouchFiled.Rows.Count > 0)
            {
                ExtAspNet.CheckBoxList touchFiled = new ExtAspNet.CheckBoxList();
                touchFiled.ID = "touchFiled1";
                touchFiled.ColumnNumber = 6;
                touchFiled.AutoPostBack = true;
                touchFiled.Required = true;
                touchFiled.Label = "涉及条线";
                for (int i = 0; i < dtTouchFiled.Rows.Count; i++)
                {
                    touchFiled.Items.Add(new ExtAspNet.CheckItem(dtTouchFiled.Rows[i]["NAME"].ToString(), dtTouchFiled.Rows[i]["CODE"].ToString()));
                }
                row_TouchFiled.Items.Add(touchFiled);
            }
        }

        //绑定题目Grid
        public void ExeBindCheckTitle(System.Data.DataTable dtCheckTitle)
        {
            //CJia.HealthInspection.Tools.ExtGridBase.UnitData = dtCheckTitle;
            List<AnswerTitle> ListAnswerTitle = new List<AnswerTitle>();
            if (dtCheckTitle == null)
            {
                dtCheckTitle = new DataTable();
                dtCheckTitle.Columns.Add(new DataColumn("CHECK_TITLE_ID"));
                dtCheckTitle.Columns.Add(new DataColumn("CHECK_TITLE_NAME"));
                dtCheckTitle.Columns.Add(new DataColumn("CHECK_TITLE_CONTENT"));
            }
            Session["ExeCheckTitleList"] = dtCheckTitle;
            if (dtCheckTitle != null && dtCheckTitle.Rows != null && dtCheckTitle.Rows.Count > 0)
            {
                for (int i = 0; i < dtCheckTitle.Rows.Count; i++)
                {
                    AnswerTitle answerTitle = new AnswerTitle();
                    answerTitle.TitleID = Convert.ToInt64(dtCheckTitle.Rows[i]["CHECK_TITLE_ID"]);
                    answerTitle.TitleName = (i + 1) + "、 " + dtCheckTitle.Rows[i]["CHECK_TITLE_NAME"].ToString();
                    answerTitle.TitleContent = dtCheckTitle.Rows[i]["CHECK_TITLE_CONTENT"].ToString();
                    ListAnswerTitle.Add(answerTitle);
                }
            }
            Session["ExeCheckTitleClassList"] = ListAnswerTitle;
            InitGrid(dtCheckTitle);
        }

        public void ExeCleanScreen()
        {
            Session["UnitName"] = null;
            Session["UnitAddress"] = null;
            Session["SelectedTemplateNameExeCheck"] = null;
            Session["IsSelectTemp"] = "0";
            Session["ExeCheckTitleList"] = null;
            Session["ExeCheckTitleClassList"] = null;
            PageContext.Refresh();
            ExtAspNet.Alert.ShowInTop("监督执行完成", ExtAspNet.MessageBoxIcon.Information);
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
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
                SaveCheck();
            }
        }

        protected void btn_visualSave_Click(object sender, EventArgs e)
        {
            SaveCheck();
        }

        private void SaveCheck()
        {
            exeCheckArgs.UnitID = Convert.ToInt64(Session["UnitID"]);
            exeCheckArgs.UnitName = Session["UnitName"].ToString();
            exeCheckArgs.TempID = Convert.ToInt64(Session["ExeTempID"]);
            exeCheckArgs.TempName = txt_Tmp.Text; //Session["SelectedTemplateNameExeCheck"].ToString();
            exeCheckArgs.IsLicence = Convert.ToChar(ddl_wuzheng.SelectedValue);
            exeCheckArgs.IsFiling = Convert.ToChar(ddl_jiandang.SelectedValue);
            exeCheckArgs.StartDateTime = Convert.ToDateTime(dp_start.Text);
            exeCheckArgs.End_DateTime = Convert.ToDateTime(dp_end.Text);
            exeCheckArgs.CheckPoint = txt_address.Text;
            exeCheckArgs.IsRectification = Convert.ToChar(ddl_zhenggai.SelectedValue);
            if (ddl_zhenggai.SelectedValue == "1")
            {
                exeCheckArgs.Review = Convert.ToDateTime(dp_fucha.Text);
            }
            else
            {
                exeCheckArgs.Review = Convert.ToDateTime("0001-01-01");
            }
            exeCheckArgs.IsReview = Convert.ToChar(ddl_fucha.SelectedValue);
            if (ddl_fucha.SelectedValue == "1")
            {
                exeCheckArgs.RectificationResult = Convert.ToChar(ddl_zhqk.SelectedValue);
            }
            else
            {
                exeCheckArgs.RectificationResult = ' ';
            }
            ExtAspNet.CheckBoxList checkboxlist = row_TouchFiled.FindControl("touchFiled1") as ExtAspNet.CheckBoxList;
            if (checkboxlist.SelectedIndexArray.Length == 0)
            {
                exeCheckArgs.TouchFiled = "";
            }
            else
            {
                for (int i = 0; i < checkboxlist.SelectedValueArray.Length; i++)
                {
                    exeCheckArgs.TouchFiled = exeCheckArgs.TouchFiled + "|" + checkboxlist.SelectedValueArray[i];
                }
            }
            exeCheckArgs.Remark = txt_remark.Text;
            ExtAspNet.DropDownList dropdownList = row_CheckResult.FindControl("DdcheckResult1") as ExtAspNet.DropDownList;
            exeCheckArgs.CheckResult = Convert.ToInt64(dropdownList.SelectedValue);
            exeCheckArgs.CheckOne = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
            exeCheckArgs.CheckOneName = (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString();
            exeCheckArgs.CheckTwo = Convert.ToInt64(ddl_Checker.SelectedValue);
            exeCheckArgs.CheckTwoName = ddl_Checker.SelectedText.ToString();
            if (Session["ExeCheckTitleClassList"] != null)
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                if (ListAnswerTitle != null)
                {
                    string CheckResult = "{0}卫生监督员【{1},{2}】,对【{3}】进行现场检查。检查人员向【{4}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine;
                    CheckResult = string.Format(CheckResult, (Session["User"] as DataTable).Rows[0]["ORGAN_NAME"].ToString(), (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString(), ddl_Checker.SelectedText, Session["UnitName"].ToString(), Session["UnitName"].ToString());
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
                    exeCheckArgs.CheckNotes = string.Format(CheckResult, exeCheckArgs.CheckOneName, exeCheckArgs.CheckTwoName, exeCheckArgs.UnitName, exeCheckArgs.UnitName);
                    exeCheckArgs.CheckOpinion = CheckAdvice;
                }
                else
                {
                    exeCheckArgs.CheckNotes = "";
                    exeCheckArgs.CheckOpinion = "";
                }
            }
            else
            {
                exeCheckArgs.CheckNotes = "";
                exeCheckArgs.CheckOpinion = "";
            }
            exeCheckArgs.listCheckTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
            exeCheckArgs.organ_id = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            exeCheckArgs.UserId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["USER_ID"]);
            OnExeCheck(null, exeCheckArgs);
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

        protected void ddl_Checker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Checker.SelectedValue != "0")
            {
                txt_Checker.Text = (Session["User"] as DataTable).Rows[0]["USER_NAME"].ToString() + "," + ddl_Checker.SelectedText;
                exeCheckArgs.CheckTwo = Convert.ToInt64(ddl_Checker.SelectedValue);
                exeCheckArgs.CheckTwoName = ddl_Checker.SelectedText.ToString();
            }
            else
            {
                txt_Checker.Text = null;
            }
        }

        //private void CleanScreen()
        //{
        //    //txt_unitName.Text = "";
        //    //txt_Tmp.Text = "";
        //    //txt_address.Text = "";
        //    //ddl_zhenggai.SelectedIndex = 0;
        //    //ddl_fucha.SelectedIndex = 0;
        //    //ExtAspNet.CheckBoxList checkboxlist = row_TouchFiled.FindControl("touchFiled1") as ExtAspNet.CheckBoxList;
        //    //for (int i = 0; i < checkboxlist.Items.Count; i++)
        //    //{
        //    //    checkboxlist.Items[i].Selected = false;
        //    //}
        //    //txt_remark.Text = "";
        //    //ddl_Checker.SelectedIndex = 0;

        //}








    }
}