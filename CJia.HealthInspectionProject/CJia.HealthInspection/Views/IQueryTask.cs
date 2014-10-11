using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IQueryTask : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.QueryTaskArgs> OnInit;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.QueryTaskArgs> OnSearch;

        /// <summary>
        /// 删除任务事件
        /// </summary>
        event EventHandler<Views.QueryTaskArgs> OnDeleteTaskId;

        /// <summary>
        /// 删除所选任务组
        /// </summary>
        event EventHandler<Views.QueryTaskArgs> OnDeletedTaskArr;

        /// <summary>
        /// 绑定界面任务Grid
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeGridTask(DataTable dtTask);

        /// <summary>
        /// 绑定任务类型下拉框
        /// </summary>
        /// <param name="dtTaskType"></param>
        void ExeDropTaskType(DataTable dtTaskType);
    }

    public class QueryTaskArgs : EventArgs
    {
        /// <summary>
        /// 所选任务类型
        /// </summary>
        public string SelectedTaskTypeId;

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWord;

        /// <summary>
        /// 所要删除任务ID
        /// </summary>
        public string DeleteTaskId;

        /// <summary>
        /// 所要删除任务组
        /// </summary>
        public List<object> DeletedTaskArr = new List<object>();

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;
    }
}
