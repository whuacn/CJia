using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 冲药View层
    /// </summary>
    public interface IPharmSendView : Tools.IView
    {
        /// <summary>
        /// 预览瓶贴
        /// </summary>
        event EventHandler OnPreviewLable;
        /// <summary>
        /// 查看明细
        /// </summary>
        event EventHandler OnDetail;
        /// <summary>
        /// 冲药事件
        /// </summary>
        event EventHandler<PharmSendArgs> OnPharmSend;
        /// <summary>
        /// 获得冲药次数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void ExeGetPharmSendTime(DataTable data);
        /// <summary>
        /// 绑定今天要冲的药
        /// </summary>
        /// <param name="data"></param>
        void ExeBindTodayLable(DataTable data);
        /// <summary>
        /// 绑定瓶贴明细
        /// </summary>
        /// <param name="data"></param>
        void ExeBindTodayLableDetail(DataTable data);
        /// <summary>
        /// 绑定库存不足提示界面
        /// </summary>
        /// <param name="data"></param>
        void ExeBindTodayNoPharmStore(DataTable data,int timeID);
        /// <summary>
        /// 判断是否在冲药时间范围内
        /// </summary>
        /// <param name="data"></param>
        bool ExeIsPharmSend(DataTable data);
    }
    /// <summary>
    /// 冲药参数类
    /// </summary>
    public class PharmSendArgs : EventArgs
    {
        /// <summary>
        /// 第N次冲药id
        /// </summary>
        public int timeID;
    }
}
