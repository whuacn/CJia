using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class MainFromModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询是否有未审核医嘱
        /// </summary>
        /// <returns></returns>
        public bool QueryNoCheckAdvice()
        {
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryNoCheckAdvice);
            if(result == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查询异常瓶贴
        /// </summary>
        /// <returns></returns>
        public DataTable QueryExpetionLabel()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryExcpitionLabel);
            return result;
        }

        /// <summary>
        /// 查询库存不足药物
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStorage()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryStorage);
            return result;
        }

        /// <summary>
        /// 查询未打印瓶贴
        /// </summary>
        /// <returns></returns>
        public int QueryNoPrintLabel()
        {
            return int.Parse(CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryNoPrintLabel));
        }
    }
}

