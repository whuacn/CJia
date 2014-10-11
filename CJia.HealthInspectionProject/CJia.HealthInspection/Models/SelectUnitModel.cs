using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class SelectUnitModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据关键字查询单位
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataTable QueryUnitByKew(string keyWord,long organId)
        {
            object[] ob = new object[] {organId, "%" + keyWord + "%", "%" + keyWord + "%", "%" + keyWord + "%", "%" + keyWord + "%", "%" + keyWord + "%" };
            DataTable dtUnit = CJia.DefaultOleDb.Query(SqlTools.SqlQueryUnitByKey,ob);
            return dtUnit;
        }

        /// <summary>
        /// 根据单位ID查询单位信息
        /// </summary>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public DataTable QueryUnitById(long UnitID)
        {
            object[] ob = new object[] { UnitID };
            DataTable dtUnit = CJia.DefaultOleDb.Query(SqlTools.SqlQueryUnitByID, ob);
            if (dtUnit != null && dtUnit.Rows != null && dtUnit.Rows.Count > 0)
            {
                return dtUnit;
            }
            else
            {
                return null;
            }
        }
    }
}
