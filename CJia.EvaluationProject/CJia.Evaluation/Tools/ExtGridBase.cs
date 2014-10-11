using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Evaluation.Tools
{
    /// <summary>
    /// 记录ExeGrid数据
    /// </summary>
    public static class ExtGridBase
    {
        public static int PageIndex = 0;
        public static int PageSize = 0;
        /// <summary>
        /// 数据源
        /// </summary>
        public static DataTable DataSource;
        /// <summary>
        /// 单位数据源
        /// </summary>
        public static DataTable UnitData;
        /// <summary>
        /// 检查题目数据源
        /// </summary>
        public static DataTable CheckTitleData;
        /// <summary>
        /// 添加检查题到模板中
        /// </summary>
        public static DataTable TemplateCheckTitleData;
        /// <summary>
        /// 模板数据源
        /// </summary>
        public static DataTable TemplateData;
    }
}
