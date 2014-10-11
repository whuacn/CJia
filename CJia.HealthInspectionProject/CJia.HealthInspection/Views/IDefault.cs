using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IDefault : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 查询登录用户所拥有功能
        /// </summary>
        event EventHandler<Views.DefaultArgs> OnQueryFunctionByUserId;
    }

    public class DefaultArgs : EventArgs
    {
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string LoginUserId;

        /// <summary>
        /// 登录用户不存在的功能
        /// </summary>
        public DataTable UserFunction;
    }
}
