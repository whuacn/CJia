using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class UnitSelectModel : CJia.HealthInspection.Tools.Model
    {
        ///// <summary>
        ///// 查询所有单位
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetAllUnit(string organId)
        //{
        //    object[] sqlParams = new object[] { organId };
        //    DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryUnit,sqlParams);
        //    return dtResult;
        //}

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public DataTable QueryUnitBySearch(string keyWords, string organId)
        {
            object[] sqlParams = new object[] { organId };
            string sql = "";
            if (keyWords != "")
            {
                sql = SqlTools.SqlQueryUnitBySearch + " and (unit_name like '%" + keyWords + "%' or unit_address like '%" + keyWords + "%')";
            }
            else
            {
                sql = SqlTools.SqlQueryUnitBySearch;
            }
            return CJia.DefaultOleDb.Query(sql, sqlParams);
        }

        /// <summary>
        /// 根据单位ID删除单位
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteUnitById(string updateBy, string unitId)
        {
            object[] sqlParams = new object[] { updateBy, unitId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteUnitById, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据单位ID删除单位（事务）
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public bool DeleteUnitById(string transID, string updateBy, string unitId)
        {
            object[] sqlParams = new object[] { updateBy, unitId };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDeleteUnitById, sqlParams) > 0 ? true : false;
        }
               
    }
}
