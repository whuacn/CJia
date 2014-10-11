using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Tools
{
    public class Presenter<M,V>
        where M : Model , new()
        where V : IView
    {

        /// <summary>
        /// View视图
        /// </summary>
        public V View{get; protected set;}

        /// <summary>
        /// 构造函数 初始化View
        /// </summary>
        /// <param name="view"></param>
        public Presenter(V view)
        {
            this.View = view;
            this.OnInitView();
        }

        /// <summary>
        /// 初始化View 用户初始化View中事件等
        /// </summary>
        protected virtual void OnInitView()
        {
            
        }

        /// <summary>
        /// 使用单例模式去数据模型
        /// </summary>
        public M Model
        {
            get
            {
                return SingletonCreator.instance;
            }
        }

        
        protected static class SingletonCreator
        {
            static SingletonCreator()
            {

            }
            internal static readonly M instance = new M();
        }

    }
}
