using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.FrontStage
{
    public class HomePageModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 获得树形结构
        /// </summary>
        /// <returns></returns>
        public DataTable GetTreeList()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryTreeList, null);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
