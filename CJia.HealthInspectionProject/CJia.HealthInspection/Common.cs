using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection
{
    /// <summary>
    /// 公共类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 检查题目选择对应小分类提示
        /// </summary>
        public static string AddCheckTitelTooltip;
        /// <summary>
        /// 小分类ID
        /// </summary>
        public static List<string> SmallTemplateTypeIDList = new List<string>();
        /// <summary>
        /// 模板中检查题目数据源
        /// </summary>
        public static DataTable CheckTitleToTempData;

        #region【任务管理】
        /// <summary>
        /// 执行监督选择的模板ID
        /// </summary>
        public static long ExeCheckTemplateID;

        /// <summary>
        /// 执行监督选择的模板名称
        /// </summary>
        public static string ExeCheckTemplatenName;

        #endregion

        /// <summary>
        /// 法律法规文件路径
        /// </summary>
        //public static string WordFilepaht;


        /// <summary>
        /// 单位ID
        /// </summary>
        public static long UnitId;

        /// <summary>
        /// 单位名称
        /// </summary>
        public static string UnitName;

        /// <summary>
        /// 单位地址
        /// </summary>
        public static string UnitAddress;
       
    }

    /// <summary>
    /// 答题的题目
    /// </summary>
    public class AnswerTitle
    {
        /// <summary>
        /// 题目ID
        /// </summary>
        public long TitleID;
        /// <summary>
        /// 题目名称
        /// </summary>
        public string TitleName;

        /// <summary>
        /// 题目内容
        /// </summary>
        public string TitleContent;

        /// <summary>
        /// 题目答案
        /// </summary>
        public DataTable dtAnswer;

        /// <summary>
        /// 被选中的答案ID
        /// </summary>
        public long CheckedId;

        /// <summary>
        /// 被选中的RadioButtonList的Index说
        /// </summary>
        public int CheckedIndex;

        /// <summary>
        /// 题目笔录
        /// </summary>
        public string TitleRusult;

        /// <summary>
        /// 题目建议
        /// </summary>
        public string TitleAdvice;

        /// <summary>
        /// 此题是否已答
        /// </summary>
        public bool IsAnswered;
    }
}
