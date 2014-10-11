using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.CheckRegOrder.Views
{
    public interface IClinicChooseView
    {
        /// <summary>
        /// 加载页面时数据绑定事件
        /// </summary>
        event EventHandler OnLoadEvent;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<ClinicArgs> btnOk_ClickEvent;

        /// <summary>
        /// 取消事件
        /// </summary>
        event EventHandler btnCancle_ClickEvent;

        /// <summary>
        /// 绑定诊室名称
        /// </summary>
        /// <param name="dtClinicName"></param>
        void ExeBindClinicName(DataTable dtClinicName);

        /// <summary>
        /// 关闭父窗口
        /// </summary>
        void CloseParentFrm();
    }

    public class ClinicArgs : EventArgs
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatientID = 0;

        /// <summary>
        /// 诊室ID
        /// </summary>
        public int ClinicID = 0;

        /// <summary>
        /// 队列编号
        /// </summary>
        public int QueueNo = 0;

        public DataRow DataRowBySelectedNoQueuePatient = null;
    }
}
