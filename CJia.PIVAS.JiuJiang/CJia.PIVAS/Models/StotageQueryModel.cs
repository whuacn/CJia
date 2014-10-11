using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class StotageQueryModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询药品库存
        /// </summary>
        /// <param name="DrugName"></param>
        /// <param name="BatchNo"></param>
        /// <param name="DrugFirm"></param>
        /// <param name="FilterZero"></param>
        /// <returns></returns>
        public DataTable QueryStorage(string DrugName,string DrugSpec, string BatchNo, string DrugFirm, bool FilterZero)
        {
            object[] ob = new object[] { "%" + DrugName + "%", "%" + DrugName.ToUpper() + "%", "%" + DrugSpec + "%", "%" + BatchNo + "%", "%" + DrugFirm + "%" };
            string sql = "";
            if (FilterZero)
            {
                sql = string.Format(SqlTools.SqlStorageQuery, " and quantity != 0 ");
            }
            else
            {
                sql = string.Format(SqlTools.SqlStorageQuery, "");
            }
            return CJia.DefaultOleDb.Query(sql, ob);
        }
    }
}
