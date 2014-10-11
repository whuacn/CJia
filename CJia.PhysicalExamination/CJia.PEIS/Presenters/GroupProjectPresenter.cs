using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Presenters
{
    public class GroupProjectPresenter:CJia.PEIS.Tools.Presenter<Models.GroupProjectModel,Views.IGroupProjectView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public GroupProjectPresenter(Views.IGroupProjectView view)
            : base(view)
        {

        }
       
    }
}
