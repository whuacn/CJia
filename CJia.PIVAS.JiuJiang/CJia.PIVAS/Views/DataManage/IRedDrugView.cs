using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 时间维护的接口层
    /// </summary>
    public interface IRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        event EventHandler<RedDrugEventArgs> OnLoadData;

        /// <summary>
        /// 删除选中数据
        /// </summary>
        event EventHandler<RedDrugEventArgs> OnDeleteTimeSet;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        void ExeInitData(DataTable dt);

        /// <summary>
        /// 配置载入的是哪个页面  1代表拉单2代表冲药
        /// </summary>
        int WhichPage
        {
            get;
            set;
        }

    }

    /// <summary>
    /// 时间维护的参数类
    /// </summary>
    public class RedDrugEventArgs : EventArgs
    {
        /// <summary>
        /// 载入页面配置
        /// </summary>
        public int Whichpage;   

        /// <summary>
        /// 时间ID
        /// </summary>
        public long TimeId;

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public long UserId;
    }
}