using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia
{
    /// <summary>
    /// Presenter基类
    /// </summary>
    /// <typeparam name="IView"></typeparam>
    public class Presenter<IView>
    {
        /// <summary>
        /// View接口
        /// </summary>
        public IView View { get; private set; }
        /// <summary>
        /// Presenter基类
        /// </summary>
        public Presenter(IView view)
        {
            this.View = view;
            this.OnViewSet();
        }
        /// <summary>
        /// Presenter基类
        /// </summary>
        protected virtual void OnViewSet()
        { }
    }
}
