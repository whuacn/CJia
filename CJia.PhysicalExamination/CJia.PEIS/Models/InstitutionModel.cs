using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Models
{
    public class InstitutionModel:CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 查询上级单位
        /// </summary>
        /// <returns></returns>
        public DataTable QueryHigherIns()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectHigherIns);
        }

        /// <summary>
        /// 查询单位性质
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInsType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectInsType);
        }

        /// <summary>
        /// 插入单位表
        /// </summary>
        /// <param name="sqlParams">表字段</param>
        /// <returns></returns>
        public bool InsertInstitution(List<object> sqlParams)
        {
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertInstitution, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询单位详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInsInfo()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectInstitutionBindGrid);
        }

        /// <summary>
        /// 修改单位表
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool UpdateInstitutionById(List<object> sqlParams)
        {
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateInstitutionById, sqlParams) > 0 ? true : false; 
        }
    }
}
