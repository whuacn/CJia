using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface ICheckTitleEdit:Tools.IPage
    {
        event EventHandler<CheckTitleEditArgs> OnInitPage;
        event EventHandler<CheckTitleEditArgs> OnSave;
        void ExeBindCheckTitle(DataTable data,DataTable dataType);
        void ExeIsSuccess(bool bol);
    }
    public class CheckTitleEditArgs : EventArgs
    {
        /// <summary>
        /// 检查题目id
        /// </summary>
        public string CheckTitleID;
        /// <summary>
        /// 检查题目名称
        /// </summary>
        public string TitleName;
        /// <summary>
        /// 检查题目内容
        /// </summary>
        public string TitleContent;
        /// <summary>
        /// 是否选择题
        /// </summary>
        public string IsChoice;
        /// <summary>
        /// 答案内容，检查笔录，意见
        /// </summary>
        public DataTable AnswersData;

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;
    }
}
