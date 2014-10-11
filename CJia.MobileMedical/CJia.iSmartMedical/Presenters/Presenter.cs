using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Presenters
{
    /// <summary>
    /// Presenter基类
    /// </summary>
    /// <typeparam name="M">数据模型</typeparam>
    /// <typeparam name="V">视图模型</typeparam>
    public class Presenter<M, V>
        where M : Models.IModel, new()
        where V : Views.IView
    {
        /// <summary>
        /// 使用单例模式，取数据模型
        /// </summary>
        public static M Model
        {
            get
            {
                return SingletonCreator.instance;
            }
        }

        /// <summary>
        /// 构造函数，初始化视图
        /// </summary>
        /// <param name="view">The view.</param>
        public Presenter(V view)
        {
            View = view;
            OnInitView();
        }
        /// <summary>
        /// 初始化View
        /// </summary>
        protected virtual void OnInitView()
        { }
        /// <summary>
        /// 视图
        /// </summary>
        protected V View { get; private set; }

        protected class SingletonCreator
        {
            static SingletonCreator()
            {

            }
            internal static readonly M instance = new M();
        }
    }
}
