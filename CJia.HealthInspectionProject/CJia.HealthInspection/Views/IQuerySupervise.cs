using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQuerySupervise : CJia.HealthInspection.Tools.IPage
    {
        ///// <summary>
        ///// 初始化事件
        ///// </summary>
        //event EventHandler<Views.QuerySuperviseArgs> OnInit;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QuerySuperviseArgs> OnSearch;

        /// <summary>
        /// 删除单个任务事件
        /// </summary>
        event EventHandler<Views.QuerySuperviseArgs> OnDeleteUserId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        event EventHandler<Views.QuerySuperviseArgs> OnDeletedUserArr;

        /// <summary>
        /// 绑定界面人员Grid
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeGridUser(DataTable dtUser);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        void ExeMessageBox(string message);
    }

    public class QuerySuperviseArgs : EventArgs
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
