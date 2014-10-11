using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class BackHomePageModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 查询用户没有的菜单权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable QueryNoMenuComptence(string UserId)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { UserId };
                DataTable dt = ad.Query(SqlToos.SqlQueryNoMenuComptence, ob);
                return dt;
            }
        }
    }
}
