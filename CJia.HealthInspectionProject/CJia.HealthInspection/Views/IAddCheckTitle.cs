using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface IAddCheckTitle : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<AddCheckTitleArgs> OnInit;
        event EventHandler<AddCheckTitleArgs> OnBigTempChange;
        event EventHandler<AddCheckTitleArgs> OnMidTempChange;
        event EventHandler<AddCheckTitleArgs> OnSave;
        void ExeIsSuccess(bool bol);
        void ExeBindBigTemp(DataTable data, bool bol);
        void ExeBindMidTemp(DataTable data, bool bol);
        void ExeBindSmallTemp(DataTable data, bool bol);
    }
    public class AddCheckTitleArgs : EventArgs
    {
        /// <summary>
        /// 大分类类型ID
        /// </summary>
        public string BigTemplateID;
        /// <summary>
        /// 中分类类型ID
        /// </summary>
        public string MiddleTemplateID;
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
        /// 题目分类
        /// </summary>
        public List<string> SmallTemplateTypeIDList;
        public bool isFirst = false;
        /// <summary>
        /// 模板id
        /// </summary>
        public string TemplateID;

        /// <summary>
        /// 执行监督的ID
        /// </summary>
        public long CheckID;

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public long UserID;

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public DataTable User;
    }
}
