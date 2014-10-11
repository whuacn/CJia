using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Presenters
{
    public class CheckTitleEditPresenter : Tools.PresenterPage<Models.CheckTitleEditModel, Views.ICheckTitleEdit>
    {
        public CheckTitleEditPresenter(Views.ICheckTitleEdit view)
            : base(view)
        {
            view.OnInitPage += view_OnInitPage;
            view.OnSave += view_OnSave;
        }

        void view_OnSave(object sender, Views.CheckTitleEditArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                bool bol1 = Model.ModifyCheckTitle(trans.ID, e.TitleName, e.TitleContent, e.IsChoice, e.User.Rows[0]["USER_ID"].ToString(), e.CheckTitleID);
                bool bol2 = true;
                //if (e.IsChoice == "1")//是选择题
                //{
                //删除原来的答案
                Model.DeleteCheckTitleAnswer(trans.ID, e.CheckTitleID, e.User.Rows[0]["USER_ID"].ToString());
                if (e.AnswersData != null && e.AnswersData.Rows.Count != 0)
                {
                    foreach (DataRow dr in e.AnswersData.Rows)
                    {
                        //新增答案
                        bol2 = Model.AddCheckTitleAnswer(trans.ID, dr["AnswerName"].ToString(), e.CheckTitleID, e.User.Rows[0]["USER_ID"].ToString(), dr["Result"].ToString(), dr["Advice"].ToString());
                        if (!bol2)
                        {
                            break;
                        }
                    }
                }
                //}
                if (bol1 && bol2)
                {
                    isSuccess = true;
                }
                View.ExeIsSuccess(isSuccess);
                trans.Complete();
            }
        }

        void view_OnInitPage(object sender, Views.CheckTitleEditArgs e)
        {
            DataTable checkTitleData = Model.GetCheckTitleByID(e.CheckTitleID);
            DataTable checkTitleTypeData = Model.GetCheckTitleTypeByID(e.CheckTitleID);
            View.ExeBindCheckTitle(checkTitleData, checkTitleTypeData);
        }
    }
}
