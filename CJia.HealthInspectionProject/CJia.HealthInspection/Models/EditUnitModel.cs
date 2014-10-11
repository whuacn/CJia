using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class EditUnitModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据代码类型查询下拉数据
        /// </summary>
        /// <param name="codeType">代码类型</param>
        /// <returns></returns>
        public DataTable QueryDownType(string codeType)
        {
            object[] sqlParams = new object[] { codeType };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTypeFromCode,sqlParams);
        }

        /// <summary>
        /// 根据单位Id查询单位信息
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public DataTable QueryUnitInfoByUnitId(string unitId)
        {
            object[] sqlParams = new object[] { unitId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryUnitInfoByUnitId, sqlParams);
        }

        /// <summary>
        /// 修改单位信息表
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool UpdateUnitByUnitId(List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateUnitByUnitId,sqlParams) > 0 ? true : false;
        }
    }
}
