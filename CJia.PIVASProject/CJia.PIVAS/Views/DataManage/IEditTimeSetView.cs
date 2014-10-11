using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 修改时间数据的接口层
    /// </summary>
    public interface IEditTimeSetView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 修改TimeSet数据
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnUpdateTimeSet;

        /// <summary>
        /// 插入TimeSer数据
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnInserttimeSet;

        /// <summary>
        /// 判断判断修改时间是否有重叠 返回true表示有重叠 true表示没有重叠
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnIsUpdateRepeat;

        /// <summary>
        /// 判断判断添加时间是否有重叠 返回true表示有重叠 true表示没有重叠
        /// </summary>
        event EventHandler<EditTimeSetEventArgs> OnIsInsertRepeat;

        /// <summary>
        /// 传回时间段是否有重叠的值回UI
        /// </summary>
        /// <param name="isRepeat"></param>
        void ExeIsRepeat(bool isRepeat);

    }

    /// <summary>
    /// 修改时间的参数类
    /// </summary>
    public class EditTimeSetEventArgs : EventArgs
    {
        /// <summary>
        /// 配置当前是哪个页面 1代表拉单 2代表冲药
        /// </summary>
        public int Whichpage;

        /// <summary>
        /// 配置是哪个操作  1代表添加 2代表修改
        /// </summary>
        public int WhichHandle;

        /// <summary>
        /// 时间名字
        /// </summary>
        public string TimeName;     

        /// <summary>
        /// 其实时间
        /// </summary>
        public string StartTime;    

        /// <summary>
        /// 结束时间
        /// </summary>
        public string OverTime;

        /// <summary>
        /// 当结束时间为00:00时为当天的最后一个 用于进行时间重叠判断的字段 
        /// </summary>
        public string EndTime;

        /// <summary>
        /// 当前登录用的ID
        /// </summary>
        public long UserId;         

        /// <summary>
        /// TimeID 主键
        /// </summary>
        public long TimeId;         
    }
}