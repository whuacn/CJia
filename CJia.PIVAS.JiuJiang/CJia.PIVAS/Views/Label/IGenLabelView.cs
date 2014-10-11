using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// 生成瓶贴接口
    /// </summary>
    public interface IGenLabelView : CJia.PIVAS.Tools.IView
    {

        /// <summary>
        /// 预览瓶贴事件
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnPreviewLabelEven;

        /// <summary>
        /// 生成瓶贴事件
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnGenLabelEven;

        /// <summary>
        /// 查询病区
        /// </summary>
        event EventHandler<GenLabelEventArgs> OnQueryIffield;

        /// <summary>
        /// 绑定预览瓶贴汇总回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingCollect(DataTable result);

        /// <summary>
        /// 绑定预览瓶贴详情回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingInfo(DataTable result);

        /// <summary>
        /// 绑定病区回调方法
        /// </summary>
        /// <param name="result"></param>
        void ExeBindingIffield(DataTable result);

        /// <summary>
        /// 生成病区回调方法
        /// </summary>
        /// <param name="result">生成的瓶贴</param>
        void ExeGenLabel(DataTable result);

        /// <summary>
        /// 出事话进度条回调方法
        /// </summary>
        /// <param name="max"></param>
        void ExeInitSchedule(int max);

        /// <summary>
        /// 进度条走到下一步回调方法
        /// </summary>
        void ExeNextSchedule();
        
    }

    /// <summary>
    /// 生成瓶贴事件参数
    /// </summary>
    public class GenLabelEventArgs : EventArgs
    {

        /// <summary>
        /// 选着的病区
        /// </summary>
        public List< DataRow> Illfieldids;


    }
}