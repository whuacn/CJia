using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryExeTask : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<QueryExeTaskArgs> OnQueryExeTaskByKeyWord;
        void ExeBindExeTask(DataTable dtExeTask);
    }

    public class QueryExeTaskArgs : EventArgs
    {
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string keyWord;

        /// <summary>
        /// 当前登录用户的组织Id
        /// </summary>
        public long OrganId;
    }
}
