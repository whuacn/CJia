using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IExeTask : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<ExeTaskArgs> OnQueryTouchFiled;
        event EventHandler<ExeTaskArgs> OnQueryInitTaskTitle;
        event EventHandler<ExeTaskArgs> OnQueryChecker;
        event EventHandler<ExeTaskArgs> OnSaveExeTask;
        event EventHandler<ExeTaskArgs> OnInitCheckResult;
        void ExeBindTouchFiled(DataTable dtToucheFiled);
        void ExeBindTaskTitle(DataTable dtTaskTitle);
        void ExeBindChecker(DataTable dtChecker);
        void ExeBindCheckResult(DataTable dtCheckResult);
        void ExeCleanScreen();
    }

    public class ExeTaskArgs : EventArgs
    {
        /// <summary>
        /// 任务的模板ID
        /// </summary>
        public long TemplateId;

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public long UserId;

        /// <summary>
        /// 当前登录用户的组织Id
        /// </summary>
        public long OrganId;

        /// <summary>
        /// 检查单位ID
        /// </summary>
        public long UnitID;

        /// <summary>
        /// 检查单位名称
        /// </summary>
        public string UnitName;
        /// <summary>
        /// 选择的任务ID
        /// </summary>
        public long TaskId;

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName;

        /// <summary>
        /// 是否有证（0代表没有，1代表有）
        /// </summary>
        public char IsLicence;

        /// <summary>
        /// 是否已建档（0代表没有，1代表有）
        /// </summary>
        public char IsFiling;

        /// <summary>
        /// 检查开始时间
        /// </summary>
        public DateTime StartDateTime;

        /// <summary>
        /// 检查结束时间
        /// </summary>
        public DateTime End_DateTime;

        /// <summary>
        /// 检查地点
        /// </summary>
        public string CheckPoint;

        /// <summary>
        /// 是否要整改
        /// </summary>
        public char IsRectification;

        /// <summary>
        /// 复查日期
        /// </summary>
        public DateTime? Review;

        /// <summary>
        /// 此次是否要复查
        /// </summary>
        public char IsReview;

        /// <summary>
        /// 整改情况
        /// </summary>
        public char RectificationResult;

        /// <summary>
        /// 涉及条线
        /// </summary>
        public string TouchFiled;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;

        /// <summary>
        /// 检查结果
        /// </summary>
        public long CheckResult;

        /// <summary>
        /// 检查人1ID
        /// </summary>
        public long CheckOne;

        /// <summary>
        /// 检查人1姓名
        /// </summary>
        public string CheckOneName;

        /// <summary>
        /// 检查人2ID
        /// </summary>
        public long CheckTwo;

        /// <summary>
        /// 检查人2姓名
        /// </summary>
        public string CheckTwoName;

        /// <summary>
        /// 检查笔录
        /// </summary>
        public string CheckNotes;

        /// <summary>
        /// 检查意见
        /// </summary>
        public string CheckOpinion;

        /// <summary>
        /// 执行监督的题目
        /// </summary>
        public List<AnswerTitle> listExeTaskTitle;
    }
}
