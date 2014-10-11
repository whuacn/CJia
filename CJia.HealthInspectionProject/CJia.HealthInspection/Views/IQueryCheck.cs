using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryCheck : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<QueryCheckArgs> OnQueryCheckByKey;
        void ExeBindCheck(DataTable dtCheck);
    }

    public class QueryCheckArgs : EventArgs
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
