using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.HealthInspection.Web.UI.Supervise
{
    public partial class CheckResultAdvice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                if (Session["CheckResult"] != null)
                {
                    txtCheckRusult.Text = Session["CheckResult"].ToString();
                }
                if (Session["CheckAdvice"] != null)
                {
                    txtCheckAdvice.Text = Session["CheckAdvice"].ToString();
                }
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                if (Session["CheckResultTask"] != null)
                {
                    txtCheckRusult.Text = Session["CheckResultTask"].ToString();
                }
                if (Session["CheckAdviceTask"] != null)
                {
                    txtCheckAdvice.Text = Session["CheckAdviceTask"].ToString();
                }
            }
            //if (Session["ExeCheckTitleClassList"] != null)
            //{
            //    string CheckResult = "XX市XX区卫生监督所卫生监督员【监督员1,监督员2】,在【XXX】陪同下,对【XXX】进行现场检查。检查人员向【】出示执法证并了解相关情况,经检查发现:" + Environment.NewLine; ;
            //    string CheckAdvice = "";
            //    int a = 1;
            //    int b = 1;
            //    List<AnswerTitle> ListAnswerTitle = Session["ExeCheckTitleClassList"] as List<AnswerTitle>;
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
            //    txtCheckRusult.Text = CheckResult;
            //    txtCheckAdvice.Text = CheckAdvice;
            //    Session["CheckResult"] = CheckResult;
            //    Session["CheckAdvice"] = CheckAdvice;
            //}
            //else
            //{
            //    Alert.ShowInTop("请先答题。", MessageBoxIcon.Information);
            //}
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["WhichPage"].ToString() == "ExeCheck")
            {
                Session["CheckResult"] = txtCheckRusult.Text;
                Session["CheckAdvice"] = txtCheckAdvice.Text;
            }
            if (Request.QueryString["WhichPage"].ToString() == "ExeTask")
            {
                Session["CheckResultTask"] = txtCheckRusult.Text;
                Session["CheckAdviceTask"] = txtCheckAdvice.Text;
            }
        }
    }
}