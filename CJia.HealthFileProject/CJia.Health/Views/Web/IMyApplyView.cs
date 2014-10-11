using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IMyApplyView:CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 初始化
        /// </summary>
        event EventHandler<MyApplyArgs> OnLoadMyApply;
        /// <summary>
        /// 撤销申请事件
        /// </summary>
        event EventHandler<MyApplyArgs> OnUndo;
        /// <summary>
        /// 详细信息事件
        /// </summary>
        event EventHandler<MyApplyArgs> OnDetail;
        /// <summary>
        /// 绑定详情
        /// </summary>
        /// <param name="data"></param>
        void ExeBindApplyDetail(DataTable data);
        /// <summary>
        /// 绑定申请单
        /// </summary>
        /// <param name="data"></param>
        void ExeBindInit(DataTable data);
    }
    public class MyApplyArgs : EventArgs
    {
        /// <summary>
        /// 申请单id
        /// </summary>
        public string ListID;
        public DataTable UserData;
    }
}
