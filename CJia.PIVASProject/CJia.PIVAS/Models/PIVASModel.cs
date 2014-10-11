using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models
{
    public static class PIVASModel
    {
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime QuerySysdate()
        {
            return DateTime.Parse( CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
        }
    }
}
