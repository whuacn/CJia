using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class ExeTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.ExeTaskModel,Views.IExeTask>
    {
        public ExeTaskPresenter(Views.IExeTask view)
            : base(view)
        {
            view.OnQueryTouchFiled += view_OnQueryTouchFiled;
            view.OnQueryInitTaskTitle += view_OnQueryInitTaskTitle;
            view.OnQueryChecker += view_OnQueryChecker;
            view.OnInitCheckResult += view_OnInitCheckResult;
            view.OnSaveExeTask += view_OnSaveExeTask;
        }

        void view_OnSaveExeTask(object sender, Views.ExeTaskArgs e)
        {
            long ExeTaskSeq = Model.QueryExeTaskSeq();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool IsSuccess = true;
                bool IsSave = Model.SaveExeTask(trans.ID, ExeTaskSeq, e.UnitID, e.UnitName, e.TaskId, e.TaskName, e.IsLicence, e.IsFiling, e.StartDateTime, e.End_DateTime, e.CheckPoint, e.IsRectification, e.Review, e.IsReview, e.RectificationResult, e.TouchFiled, e.Remark, e.CheckResult, e.CheckOne, e.CheckOneName, e.CheckTwo, e.CheckTwoName, e.CheckNotes, e.CheckOpinion, e.UserId, e.OrganId);
                IsSuccess = IsSuccess && IsSave;
                for (int i = 0; i < e.listExeTaskTitle.Count; i++)
                {
                    if (e.listExeTaskTitle[i].TitleRusult == null)
                    {
                        e.listExeTaskTitle[i].TitleRusult = "";
                    }
                    if (e.listExeTaskTitle[i].TitleAdvice == null)
                    {
                        e.listExeTaskTitle[i].TitleAdvice = "";
                    }
                    bool IsInsertcheckTitle = Model.InsertExeTaskTitle(trans.ID, ExeTaskSeq, e.listExeTaskTitle[i].TitleID, e.UserId, e.listExeTaskTitle[i].CheckedId, e.listExeTaskTitle[i].TitleRusult, e.listExeTaskTitle[i].TitleAdvice);
                    IsSuccess = IsSuccess && IsInsertcheckTitle;
                }
                trans.Complete();
                if (IsSuccess)
                {
                    View.ExeCleanScreen();
                }
                else
                {
                    ExtAspNet.Alert.ShowInTop("任务执行失败", ExtAspNet.MessageBoxIcon.Warning);
                }
            }
        }

        void view_OnInitCheckResult(object sender, Views.ExeTaskArgs e)
        {
            DataTable dtCheckResult = Model.QueryCheckRueult();
            if (dtCheckResult != null)
            {
                View.ExeBindCheckResult(dtCheckResult);
            }
        }

        void view_OnQueryChecker(object sender, Views.ExeTaskArgs e)
        {
            DataTable dtChecker = Model.QueryChecker(e.OrganId, e.UserId);
            if (dtChecker != null)
            {
                View.ExeBindChecker(dtChecker);
            }
        }

        void view_OnQueryInitTaskTitle(object sender, Views.ExeTaskArgs e)
        {
            DataTable dtTaskTitle = Model.QueryTaskTitle(e.TemplateId);
            if (dtTaskTitle != null)
            {
                View.ExeBindTaskTitle(dtTaskTitle);
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("此任务没有题目", ExtAspNet.MessageBoxIcon.Information);
            }
        }

        void view_OnQueryTouchFiled(object sender, Views.ExeTaskArgs e)
        {
            View.ExeBindTouchFiled(Model.QueryTouchFiled());
        }
    }
}
