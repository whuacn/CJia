using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IQueueView
    {
        /// <summary>
        /// 加载页面时数据绑定事件
        /// </summary>
        event EventHandler OnLoadEvent;

        /// <summary>
        /// 取消排队
        /// </summary>
        event EventHandler<QueueArgs> OnCancleQueueEvent;

        /// <summary>
        /// 取消等待
        /// </summary>
        event EventHandler<QueueArgs> OnCancleWaitEvent;

        /// <summary>
        /// radioGroup筛选诊室
        /// </summary>
        event EventHandler<QueueArgs> OnFliterClinicEvent;

        /// <summary>
        /// 分配诊室事件
        /// </summary>
        event EventHandler OnAllocateClinicEvent;

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        event EventHandler OnFreshEvent;

        /// <summary>
        /// 绑定登记未排队病人列表
        /// </summary>
        /// <param name="dtNotExistQueue"></param>
        void ExeBindNotExistQueue(DataTable dtNotExistQueue);

        /// <summary>
        /// 绑定正在排队病人列表
        /// </summary>
        /// <param name="dtExistQueue"></param>
        void ExeBindExistQueue(DataTable dtExistQueue);



        ///// <summary>
        ///// 绑定诊室名称
        ///// </summary>
        ///// <param name="dtClinicName"></param>
        void ExeBindClinicName(DataTable dtClinicName);

        

    }


    public class QueueArgs : EventArgs
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatientID = 0;

        /// <summary>
        /// 诊室ID
        /// </summary>
        public int ClinicID = 0;
    }
}
