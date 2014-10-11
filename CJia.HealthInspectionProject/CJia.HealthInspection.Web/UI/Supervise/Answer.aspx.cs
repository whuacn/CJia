using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    public partial class Answer : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IAnswer
    {
        CJia.HealthInspection.Views.AnswerArgs answerArgs = new Views.AnswerArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                if (ListAnswerTitle.Count > 0)
                {
                    if (Convert.ToInt32(Session["TitleIndex"]) == 0)
                    {
                        btn_LastTitle.Enabled = false;
                    }
                    if (Convert.ToInt32(Session["TitleIndex"]) < ListAnswerTitle.Count)
                    {
                        //OnQueryAnswerByTitleID(null, answerArgs);
                        txtCheckTitleName.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleName;
                        areaCheckTitleContent.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleContent;
                        DataTable dtAnswer = new DataTable();
                        int a = Convert.ToInt32(Session["TitleIndex"]);
                        if (ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].CheckedId == 0)
                        {
                            answerArgs.CheckTitleID = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleID;
                            CJia.HealthInspection.Models.AnswerModel answerModel = new Models.AnswerModel();
                            dtAnswer = answerModel.QuyerAnswerByTitleID(answerArgs.CheckTitleID);
                            if (dtAnswer != null && dtAnswer.Rows != null && dtAnswer.Rows.Count > 0)
                            {
                                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].dtAnswer = dtAnswer;
                                ExtAspNet.RadioButtonList radioAnswer = new ExtAspNet.RadioButtonList();
                                radioAnswer.ID = "radioAnswer1";
                                radioAnswer.AutoPostBack = true;
                                radioAnswer.Required = true;
                                radioAnswer.SelectedIndexChanged += new EventHandler(radioAnswer_SelectedIndexChanged);
                                radioAnswer.Label = "选择答案";
                                for (int i = 0; i < dtAnswer.Rows.Count; i++)
                                {
                                    radioAnswer.Items.Add(new RadioItem(dtAnswer.Rows[i]["ANSWER_NAME"].ToString(), dtAnswer.Rows[i]["ANSWER_ID"].ToString()));
                                }
                                //radioAnswer.DataTextField = "ANSWER_NAME";
                                //radioAnswer.DataValueField = "ANSWER_ID";
                                //radioAnswer.DataSource = dtAnswer;
                                //radioAnswer.DataBind();
                                radioRow.Items.Add(radioAnswer);
                                Session["RadioButtonList"] = radioAnswer;
                                texCheckRusult.Readonly = true;
                                txtCheckAdvice.Readonly = true;
                            }
                            else
                            {
                                texCheckRusult.Readonly = false;
                                txtCheckAdvice.Readonly = false;
                                //texCheckRusult.Height = 116;
                                //txtCheckAdvice.Height = 116;
                                texCheckRusult.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult;
                                txtCheckAdvice.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice;
                                //ExtAspNet.Alert.Show("此题没有答案");
                            }
                        }
                        else
                        {
                            dtAnswer = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].dtAnswer;
                            if (dtAnswer != null && dtAnswer.Rows != null && dtAnswer.Rows.Count > 0)
                            {
                                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].dtAnswer = dtAnswer;
                                ExtAspNet.RadioButtonList radioAnswer = new ExtAspNet.RadioButtonList();
                                radioAnswer.ID = "radioAnswer1";
                                radioAnswer.AutoPostBack = true;
                                radioAnswer.Required = true;
                                radioAnswer.SelectedIndexChanged += new EventHandler(radioAnswer_SelectedIndexChanged);
                                radioAnswer.Label = "选择答案";
                                for (int i = 0; i < dtAnswer.Rows.Count; i++)
                                {
                                    radioAnswer.Items.Add(new RadioItem(dtAnswer.Rows[i]["ANSWER_NAME"].ToString(), dtAnswer.Rows[i]["ANSWER_ID"].ToString()));
                                }
                                radioAnswer.Items[ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].CheckedIndex].Selected = true;
                                texCheckRusult.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult;
                                txtCheckAdvice.Text = ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice;
                                radioRow.Items.Add(radioAnswer);
                                Session["RadioButtonList"] = radioAnswer;
                                texCheckRusult.Readonly = true;
                                txtCheckAdvice.Readonly = true;
                            }
                            //else
                            //{
                            //    ExtAspNet.Alert.Show("此题没有答案");
                            //}
                        }
                        Session["IsAnswer"] = "1";
                    }
                    else
                    {
                        //Session["ExeCheckTitleClassList"] = ListAnswerTitle;
                        //if (Session["ExeCheckTitleClassList"] != null)
                        //{
                        //    string CheckResult = "XX市XX区卫生监督所卫生监督员【{0},{1}】,对【{2}】进行现场检查。检查人员向【{3}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine; ;
                        //    string CheckAdvice = "";
                        //    int a = 1;
                        //    int b = 1;
                        //    //List<AnswerTitle> ListAnswerTitle1 = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                        //    for (int i = 0; i < ListAnswerTitle.Count; i++)
                        //    {
                        //        if (ListAnswerTitle[i].TitleRusult != "")
                        //        {
                        //            CheckResult = CheckResult + a.ToString() + "、 " + ListAnswerTitle[i].TitleRusult + "。" + Environment.NewLine;
                        //            a++;
                        //        }
                        //        if (ListAnswerTitle[i].TitleAdvice != "")
                        //        {
                        //            CheckAdvice = CheckAdvice + b.ToString() + "、 " + ListAnswerTitle[i].TitleAdvice + "。" + Environment.NewLine;
                        //            b++;
                        //        }
                        //    }
                        //    Session["CheckResult"] = CheckResult;
                        //    Session["CheckAdvice"] = CheckAdvice;
                        //}

                        Alert.ShowInTop("题目已答完", MessageBoxIcon.Information);
                        Session["IsAnswer"] = "0";
                        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                    }
                }
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                List<AnswerTitle> ListAnswerTaskTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                if (ListAnswerTaskTitle.Count > 0)
                {
                    if (Convert.ToInt32(Session["TitleIndexTask"]) == 0)
                    {
                        btn_LastTitle.Enabled = false;
                    }
                    if (Convert.ToInt32(Session["TitleIndexTask"]) < ListAnswerTaskTitle.Count)
                    {
                        //OnQueryAnswerByTitleID(null, answerArgs);
                        txtCheckTitleName.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleName;
                        areaCheckTitleContent.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleContent;
                        DataTable dtAnswer = new DataTable();
                        int a = Convert.ToInt32(Session["TitleIndexTask"]);
                        if (ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].CheckedId == 0)
                        {
                            answerArgs.CheckTitleID = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleID;
                            CJia.HealthInspection.Models.AnswerModel answerModel = new Models.AnswerModel();
                            dtAnswer = answerModel.QuyerAnswerByTitleID(answerArgs.CheckTitleID);
                            if (dtAnswer != null && dtAnswer.Rows != null && dtAnswer.Rows.Count > 0)
                            {
                                ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].dtAnswer = dtAnswer;
                                ExtAspNet.RadioButtonList radioAnswer = new ExtAspNet.RadioButtonList();
                                radioAnswer.ID = "radioAnswer1";
                                radioAnswer.AutoPostBack = true;
                                radioAnswer.Required = true;
                                radioAnswer.SelectedIndexChanged += new EventHandler(radioAnswer_SelectedIndexChanged);
                                radioAnswer.Label = "选择答案";
                                for (int i = 0; i < dtAnswer.Rows.Count; i++)
                                {
                                    radioAnswer.Items.Add(new RadioItem(dtAnswer.Rows[i]["ANSWER_NAME"].ToString(), dtAnswer.Rows[i]["ANSWER_ID"].ToString()));
                                }
                                //radioAnswer.DataTextField = "ANSWER_NAME";
                                //radioAnswer.DataValueField = "ANSWER_ID";
                                //radioAnswer.DataSource = dtAnswer;
                                //radioAnswer.DataBind();
                                radioRow.Items.Add(radioAnswer);
                                Session["RadioButtonList"] = radioAnswer;
                                texCheckRusult.Readonly = true;
                                txtCheckAdvice.Readonly = true;
                            }
                            else
                            {
                                texCheckRusult.Readonly = false;
                                txtCheckAdvice.Readonly = false;
                                texCheckRusult.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult;
                                txtCheckAdvice.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice;
                                //ExtAspNet.Alert.Show("此题没有答案");
                            }
                        }
                        else
                        {
                            dtAnswer = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].dtAnswer;
                            if (dtAnswer != null && dtAnswer.Rows != null && dtAnswer.Rows.Count > 0)
                            {
                                ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].dtAnswer = dtAnswer;
                                ExtAspNet.RadioButtonList radioAnswer = new ExtAspNet.RadioButtonList();
                                radioAnswer.ID = "radioAnswer1";
                                radioAnswer.AutoPostBack = true;
                                radioAnswer.Required = true;
                                radioAnswer.SelectedIndexChanged += new EventHandler(radioAnswer_SelectedIndexChanged);
                                radioAnswer.Label = "选择答案";
                                for (int i = 0; i < dtAnswer.Rows.Count; i++)
                                {
                                    radioAnswer.Items.Add(new RadioItem(dtAnswer.Rows[i]["ANSWER_NAME"].ToString(), dtAnswer.Rows[i]["ANSWER_ID"].ToString()));
                                }
                                radioAnswer.Items[ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].CheckedIndex].Selected = true;
                                texCheckRusult.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult;
                                txtCheckAdvice.Text = ListAnswerTaskTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice;
                                radioRow.Items.Add(radioAnswer);
                                Session["RadioButtonList"] = radioAnswer;
                                texCheckRusult.Readonly = true;
                                txtCheckAdvice.Readonly = true;
                            }
                            //else
                            //{
                            //    ExtAspNet.Alert.Show("此题没有答案");
                            //}
                        }
                        Session["IsAnswer"] = "1";
                    }
                    else
                    {
                        //Session["ExeTaskTitleClassList"] = ListAnswerTaskTitle;
                        //if (Session["ExeTaskTitleClassList"] != null)
                        //{
                        //    string CheckResult = "XX市XX区卫生监督所卫生监督员【{0},{1}】,对【{2}】进行现场检查。检查人员向【{3}】负责人出示执法证并了解相关情况,经检查发现:" + Environment.NewLine; ;
                        //    string CheckAdvice = "";
                        //    int a = 1;
                        //    int b = 1;
                        //    //List<AnswerTitle> ListAnswerTitle1 = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                        //    for (int i = 0; i < ListAnswerTaskTitle.Count; i++)
                        //    {
                        //        if (ListAnswerTaskTitle[i].TitleRusult != "")
                        //        {
                        //            CheckResult = CheckResult + a.ToString() + "、 " + ListAnswerTaskTitle[i].TitleRusult + "。" + Environment.NewLine;
                        //            a++;
                        //        }
                        //        if (ListAnswerTaskTitle[i].TitleAdvice != "")
                        //        {
                        //            CheckAdvice = CheckAdvice + b.ToString() + "、 " + ListAnswerTaskTitle[i].TitleAdvice + "。" + Environment.NewLine;
                        //            b++;
                        //        }
                        //    }
                        //    Session["CheckResultTask"] = CheckResult;
                        //    Session["CheckAdviceTask"] = CheckAdvice;
                        //}

                        Alert.ShowInTop("题目已答完", MessageBoxIcon.Information);
                        Session["IsAnswer"] = "0";
                        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                    }
                }
            }

        }

        protected void radioAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                ExtAspNet.RadioButtonList radioButtonList = radioRow.FindControl("radioAnswer1") as ExtAspNet.RadioButtonList;
                List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].CheckedIndex = radioButtonList.SelectedIndex;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].CheckedId = Convert.ToInt64(radioButtonList.SelectedItem.Value);
                long answerID = Convert.ToInt64(radioButtonList.SelectedItem.Value);
                answerArgs.AnswerID = answerID;
                OnQueryAnswerResultByID(null, answerArgs);
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                ExtAspNet.RadioButtonList radioButtonList = radioRow.FindControl("radioAnswer1") as ExtAspNet.RadioButtonList;
                List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].CheckedIndex = radioButtonList.SelectedIndex;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].CheckedId = Convert.ToInt64(radioButtonList.SelectedItem.Value);
                long answerID = Convert.ToInt64(radioButtonList.SelectedItem.Value);
                answerArgs.AnswerID = answerID;
                OnQueryAnswerResultByID(null, answerArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AnswerPresenter(this);
        }

        protected void btn_LastTitle_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                Session["TitleIndex"] = Convert.ToInt32(Session["TitleIndex"]) - 1;
                PageContext.Refresh();
                //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                Session["TitleIndexTask"] = Convert.ToInt32(Session["TitleIndexTask"]) - 1;
                PageContext.Refresh();
            }
        }

        protected void btn_NextTitle_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                ExtAspNet.RadioButtonList radioButtonList = radioRow.FindControl("radioAnswer1") as ExtAspNet.RadioButtonList;
                if (radioButtonList != null)
                {
                    if (IsSelectedAnsert(radioButtonList) == false)
                    {
                        //ExtAspNet.Alert.Show("此题没有做完,是否放弃此题进入下一题", "12", "if(confirm('此题没有做完,是否放弃此题进入下一题？')){}else {document.getElementById('btn_visualNext').click();}");
                        PageContext.RegisterStartupScript(@"if(confirm('此题没有做完,是否放弃此题进入下一题？'))
                                                    {
                                                        document.getElementById('btn_visualNext').click();
                                                    }
                                                    else 
                                                    {
                                                    }");
                    }
                    else
                    {
                        List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].IsAnswered = true;
                        Session["ExeCheckTitleClassList"] = ListAnswerTitle;
                        Session["TitleIndex"] = Convert.ToInt32(Session["TitleIndex"]) + 1;
                        PageContext.Refresh();
                    }
                }
                else
                {
                    if (texCheckRusult.Text == "" && txtCheckAdvice.Text == "")
                    {
                        PageContext.RegisterStartupScript(@"if(confirm('此题没有做完,是否放弃此题进入下一题？'))
                                                    {
                                                        document.getElementById('btn_visualNext').click();
                                                    }
                                                    else 
                                                    {
                                                    }");
                    }
                    else
                    {
                        List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].IsAnswered = true;
                        Session["ExeCheckTitleClassList"] = ListAnswerTitle;
                        Session["TitleIndex"] = Convert.ToInt32(Session["TitleIndex"]) + 1;
                        PageContext.Refresh();
                    }
                }
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                ExtAspNet.RadioButtonList radioButtonList = radioRow.FindControl("radioAnswer1") as ExtAspNet.RadioButtonList;
                if (radioButtonList != null)
                {
                    if (IsSelectedAnsert(radioButtonList) == false)
                    {
                        //ExtAspNet.Alert.Show("此题没有做完,是否放弃此题进入下一题", "12", "if(confirm('此题没有做完,是否放弃此题进入下一题？')){}else {document.getElementById('btn_visualNext').click();}");
                        PageContext.RegisterStartupScript(@"if(confirm('此题没有做完,是否放弃此题进入下一题？'))
                                                    {
                                                        document.getElementById('btn_visualNext').click();
                                                    }
                                                    else 
                                                    {
                                                    }");
                    }
                    else
                    {
                        List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].IsAnswered = true;
                        Session["ExeTaskTitleClassList"] = ListAnswerTitle;
                        Session["TitleIndexTask"] = Convert.ToInt32(Session["TitleIndexTask"]) + 1;
                        PageContext.Refresh();
                    }
                }
                else
                {
                    if (texCheckRusult.Text == "" && txtCheckAdvice.Text == "")
                    {
                        PageContext.RegisterStartupScript(@"if(confirm('此题没有做完,是否放弃此题进入下一题？'))
                                                    {
                                                        document.getElementById('btn_visualNext').click();
                                                    }
                                                    else 
                                                    {
                                                    }");
                    }
                    else
                    {
                        List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                        ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].IsAnswered = true;
                        Session["ExeTaskTitleClassList"] = ListAnswerTitle;
                        Session["TitleIndexTask"] = Convert.ToInt32(Session["TitleIndexTask"]) + 1;
                        PageContext.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否选择了答案（此题是否已经被答完）
        /// </summary>
        /// <returns></returns>
        private bool IsSelectedAnsert(ExtAspNet.RadioButtonList radioAnswer)
        {
            if (radioAnswer == null)
                return true;
            bool IsSelected = false;
            for (int i = 0; i < radioAnswer.Items.Count; i++)
            {
                IsSelected = IsSelected || radioAnswer.Items[i].Selected;
            }
            return IsSelected;
        }

        #region【实现接口】
        public event EventHandler<Views.AnswerArgs> OnQueryAnswerByTitleID;

        public event EventHandler<Views.AnswerArgs> OnQueryAnswerResultByID;

        /// <summary>
        /// 答题时把
        /// </summary>
        /// <param name="dtRusult"></param>
        public void ExeBindAnswerResult(DataTable dtRusult)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                if (dtRusult != null)
                {
                    List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                    texCheckRusult.Text = dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                    txtCheckAdvice.Text = dtRusult.Rows[0]["ADVICE"].ToString();
                    ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                    ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                }
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                if (dtRusult != null)
                {
                    List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                    texCheckRusult.Text = dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                    txtCheckAdvice.Text = dtRusult.Rows[0]["ADVICE"].ToString();
                    ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                    ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                }
            }
        }

        /// <summary>
        /// 显示当前这道题目的答案
        /// </summary>
        /// <param name="dtAnswer"></param>
        public void ExeBindAnswer(DataTable dtAnswer)
        {
            //if (dtAnswer != null)
            //{
            //    //Session["TitleAnswer"] = dtAnswer;
            //    //radioAnswer.Items.Clear();
            //    for (int i = 0; i < dtAnswer.Rows.Count; i++)
            //    {
            //        //ExtAspNet.RadioItem radioItem = new ExtAspNet.RadioItem();
            //        //radioItem.Text = dtAnswer.Rows[i]["ANSWER_NAME"].ToString();
            //        //radioItem.Value = dtAnswer.Rows[i]["ANSWER_ID"].ToString();
            //        //radioAnswer.Items.Add(radioItem);
                    
            //        radioAnswer.DataTextField = "ANSWER_NAME";
            //        radioAnswer.DataValueField = "ANSWER_ID";
            //        radioAnswer.DataSource = dtAnswer;
            //        radioAnswer.DataBind();
	
            //    }
            //}
            //else
            //{
            //    ExtAspNet.Alert.Show("此题目没有答案");
            //}
        }
        #endregion


        protected void btn_visualNext_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndex"])].IsAnswered = false;
                Session["ExeCheckTitleClassList"] = ListAnswerTitle;
                Session["TitleIndex"] = Convert.ToInt32(Session["TitleIndex"]) + 1;
                PageContext.Refresh();
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                List<AnswerTitle> ListAnswerTitle = Session["ExeTaskTitleClassList"] as List<AnswerTitle>;
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleRusult = texCheckRusult.Text; //dtRusult.Rows[0]["CHECK_RESULT"].ToString();
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].TitleAdvice = txtCheckAdvice.Text; //dtRusult.Rows[0]["ADVICE"].ToString();
                ListAnswerTitle[Convert.ToInt32(Session["TitleIndexTask"])].IsAnswered = false;
                Session["ExeTaskTitleClassList"] = ListAnswerTitle;
                Session["TitleIndexTask"] = Convert.ToInt32(Session["TitleIndexTask"]) + 1;
                PageContext.Refresh();
            }
        }

        //protected void TextBox1_TextChanged(object sender, EventArgs e)
        //{
        //    labResult.Text = TextBox1.Text;
        //}

        

        


        
    }
}