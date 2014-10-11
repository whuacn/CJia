using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface ICheckSubmit : CJia.Evaluation.Tools.IPage
    {
        event EventHandler OnInitPage;
        event EventHandler<CheckSubmit> OnIndexChange;
        event EventHandler<CheckSubmit> OnSubmit;
        event EventHandler<CheckSubmit> OnReadDetail;
        event EventHandler<CheckSubmit> OnSaveCheck;
        void ExeBindIsSuccessCheck(bool bol);
        void ExeBindCheckDetail(DataTable data);
        void ExeBindPage(DataTable stateData,DataTable resultData);
        void ExeBindCheckData(DataTable data);
        void ExeBindIsSuccessSubmit(bool bol);
    }
    public class CheckSubmit : EventArgs
    {
        /// <summary>
        /// 评审状态id
        /// </summary>
        public string CheckStateID;
        /// <summary>
        /// 条款id
        /// </summary>
        public string[] TreeIDs;
        /// <summary>
        /// 条款id
        /// </summary>
        public string CheckID;
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserID;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName;
        /// <summary>
        /// 评审结果id
        /// </summary>
        public string CheckResultID;
        /// <summary>
        /// 评审意见
        /// </summary>
        public string CheckAdvice;
        /// <summary>
        /// 整改意见
        /// </summary>
        public string ZhengGaiAdvice;
        /// <summary>
        /// 整改截止日期
        /// </summary>
        public string EndDate;
        /// <summary>
        /// 评审日期
        /// </summary>
        public string CheckDate;
    }
}
