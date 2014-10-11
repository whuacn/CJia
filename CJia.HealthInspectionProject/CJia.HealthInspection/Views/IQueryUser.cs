using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryUser : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QueryUserArgs> OnSearch;

        /// <summary>
        /// 删除单个任务事件
        /// </summary>
        event EventHandler<Views.QueryUserArgs> OnDeleteUserId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        event EventHandler<Views.QueryUserArgs> OnDeletedUserArr;

        /// <summary>
        /// 绑定界面人员Grid
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeGridUser(DataTable dtUser);
    }

    public class QueryUserArgs : EventArgs
    {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWords;

        /// <summary>
        /// 所要删除用户Id
        /// </summary>
        public string DeletedUserId;

        /// <summary>
        /// 删除所选用户
        /// </summary>
        public List<object> DeletedUserArr = new List<object>();

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;
    }
}
