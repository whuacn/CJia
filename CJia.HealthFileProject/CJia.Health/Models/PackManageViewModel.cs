using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class PackManageViewModel : Models.PackViewModel
    {
        public DataTable GetPatient(string packCode,string packName)
        {
            object[] parames = new object[] { packCode, packName };
            DataTable result = CJia.DefaultOleDb.Query(SqlTools.SqlQueryPackByNameAndCode, parames);
            return result;
        }
        public bool DeletePackDetail(string detailID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, detailID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDelteDetail, sqlParams) > 0 ? true : false;
        }
        public bool DeletePackDetail(string transID, string packID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, packID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDeltePackDetail, sqlParams) > 0 ? true : false;
        }
        public bool DeletePack(string transID, string packID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, packID };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlDeltePack, sqlParams) > 0 ? true : false;
        }
    }
}
