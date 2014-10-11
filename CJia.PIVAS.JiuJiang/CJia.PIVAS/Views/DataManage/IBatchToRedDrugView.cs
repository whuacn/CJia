using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 添加频率对应批次的接口层
    /// </summary>
    public interface IBatchToRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化载入数据
        /// </summary>
        event EventHandler<BatchToRedDrugEventArgs> OnLoadData;

        /// <summary>
        /// 初始化修改页面
        /// </summary>
        event EventHandler<BatchToRedDrugEventArgs> OnInitEdit;

        /// <summary>
        /// 初始化gridcontrol数据
        /// </summary>
        /// <param name="dt">频率对饮批次的数据源</param>
        void ExeinitData(DataTable dt);    

        /// <summary>
        /// 初始化编辑数据
        /// </summary>
        /// <param name="dt">冲药数据源</param>
        void ExeinitEditData(DataTable dt); 
    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class BatchToRedDrugEventArgs : EventArgs
    {
        /// <summary>
        /// 时间类型  冲药、拉单
        /// </summary>
        public string TimeType;     
    }
}