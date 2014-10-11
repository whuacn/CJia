using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.Views.Label
{
    /// <summary>
    /// 赛选瓶贴用户控件接口
    /// </summary>
    public interface IFilterLabelView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<FilterLabelEventArgs> OnInit;

        /// <summary>
        /// 修改保存赛选条件
        /// </summary>
        event EventHandler<FilterLabelEventArgs> OnModifFilter;

        /// <summary>
        /// 药品类型绑定方法回调函数
        /// </summary>
        /// <param name="pharmTypes">药品类型</param>
        void ExeBindingPharmTypes(object pharmTypes);

        /// <summary>
        /// 批次绑定方法回调函数
        /// </summary>
        /// <param name="bacths">批次</param>
        void ExeBindingBacths(object bacths);

        /// <summary>
        /// 病区病床绑定方法回调函数
        /// </summary>
        /// <param name="IffieldBens"></param>
        void ExeBindingIffieldBens(object IffieldBens);

        /// <summary>
        /// 使用的排序方式绑定方法回调函数
        /// </summary>
        /// <param name="UseOrderBy">使用的排序方式</param>
        void ExeBindingUseOrderBy(object UseOrderBy);

        /// <summary>
        /// 未使用的排序方式绑定方法回调函数
        /// </summary>
        /// <param name="NoUseOrderBy"></param>
        void ExeBindingNoUseOrderBy(object NoUseOrderBy);

    }

    /// <summary>
    /// 时间参数类
    /// </summary>
    public class FilterLabelEventArgs : EventArgs
    {
        /// <summary>
        /// 药品类型
        /// </summary>
        public CheckedListBoxControl PharmType;

        /// <summary>
        /// 批次信息
        /// </summary>
        public CheckedListBoxControl LabelBatch;

        /// <summary>
        /// 病床信息
        /// </summary>
        public CheckedListBoxControl Bed;

        /// <summary>
        /// 使用的排序方式
        /// </summary>
        public ListBoxControl UserOrderBy;

        /// <summary>
        /// 未使用的排序方式
        /// </summary>
        public ListBoxControl NoUserOrderBy;
    }
}
