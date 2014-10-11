using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Evaluation.Tools
{
    public interface IPage
    {
        /// <summary>
        /// 页面Show之后执行
        /// </summary>
        event EventHandler Load;
        /// <summary>
        /// 界面抛出提示信息
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
        /// <summary>
        /// 跳转到某一页
        /// </summary>
        /// <param name="page"></param>
        void GoToPage(string page);
    }
}
