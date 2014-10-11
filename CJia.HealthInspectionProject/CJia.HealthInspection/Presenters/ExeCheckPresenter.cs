using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class ExeCheckPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.ExeCheckModel, Views.IExeCheck>
    {
        public ExeCheckPresenter(Views.IExeCheck view)
            : base(view)
        {
            View.OnIninCheckTitle += View_OnIninCheckTitle;
            view.OnInitTouchFiled += view_OnInitTouchFiled;
            view.OnInieCheckResult += view_OnInieCheckResult;
            view.OnExeCheck += view_OnExeCheck;
            view.OnQueryChecker += view_OnQueryChecker;
        }

        void view_OnQueryChecker(object sender, Views.ExeCheckArgs e)
        {
            DataTable dtChecker = Model.QueryChecker(e.organ_id, e.UserId);
            if (dtChecker != null)
            {
                View.ExeBindChecker(dtChecker);
            }
        }

        void view_OnExeCheck(object sender, Views.ExeCheckArgs e)
        {
            long ExeCheckSeq = Model.QueryCheckSeq();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool IsSuccess = true;
                bool IsInsertCheck = Model.AddCheck(trans.ID, ExeCheckSeq, e.UnitID, e.UnitName, e.TempID, e.TempName, e.IsLicence, e.IsFiling, e.StartDateTime, e.End_DateTime, e.CheckPoint, e.IsRectification, e.Review, e.IsReview, e.RectificationResult, e.TouchFiled, e.Remark, e.CheckResult, e.CheckOne, e.CheckOneName, e.CheckTwo, e.CheckTwoName, e.CheckNotes, e.CheckOpinion, e.UserId, e.organ_id);
                //bool IsInsertcheckTitle=Model.InsertCheckTitle(trans.ID,ExeCheckSeq,e
                IsSuccess = IsSuccess && IsInsertCheck;
                for (int i = 0; i < e.listCheckTitle.Count; i++)
                {
                    if (e.listCheckTitle[i].TitleRusult == null)
                    {
                        e.listCheckTitle[i].TitleRusult = "";
                    }
                    if (e.listCheckTitle[i].TitleAdvice == null)
                    {
                        e.listCheckTitle[i].TitleAdvice = "";
                    }
                    bool IsInsertcheckTitle = Model.InsertCheckTitle(trans.ID, ExeCheckSeq, e.listCheckTitle[i].TitleID, e.UserId, e.listCheckTitle[i].CheckedId, e.listCheckTitle[i].TitleRusult, e.listCheckTitle[i].TitleAdvice);
                    IsSuccess = IsSuccess && IsInsertcheckTitle;
                }
                trans.Complete();
                if (!IsSuccess)
                {
                    ExtAspNet.Alert.ShowInTop("页面错误，请重新执行", ExtAspNet.MessageBoxIcon.Error);
                }
                else
                {
                    View.ExeCleanScreen();
                }
            }
        }

        void view_OnInieCheckResult(object sender, Views.ExeCheckArgs e)
        {
            View.ExeBindCheckResult(Model.QueryCheckRueult());
        }

        void view_OnInitTouchFiled(object sender, Views.ExeCheckArgs e)
        {
            View.ExeBindTouchFiled(Model.QueryTouchFiled());
        }

        void View_OnIninCheckTitle(object sender, Views.ExeCheckArgs e)
        {
            if (e.TempID != 0)
            {
                DataTable dtCheckTitle = Model.QueryCheckTitleByTempID(e.TempID);
                View.ExeBindCheckTitle(dtCheckTitle);
            }
        }
    }
}
