using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJia.HISOLAP.Web.UI
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
        /// <summary>
        /// 是否可复用
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}