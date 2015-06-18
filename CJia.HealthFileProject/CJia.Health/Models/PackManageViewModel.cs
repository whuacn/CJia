using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class PackManageViewModel : Models.PackViewModel
    {
        public DataTable GetPatient(string packCode, string packName)
        {
            object[] parames = new object[] { packCode, packName };
            DataTable result = CJia.DefaultOleDb.Query(SqlTools.SqlQueryPackByNameAndCode, parames);
            return result;
        }
        public bool DeletePackDetailOne(string packID, string healthID, string updateBy)
        {
            object[] sqlParams = new object[] { updateBy, packID, healthID };
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
        public DataTable GetPack(DateTime start, DateTime end, string address, string patCode, string patName, string packCode, string packName)
        {
            StringBuilder str = new StringBuilder();
            List<object> parames = new List<object>();
            if (start != DateTime.MinValue && end != DateTime.MinValue)
            {
                start = DateTime.Parse(start.ToShortDateString() + " 00:00:00");
                end = DateTime.Parse(end.ToShortDateString() + " 23:59:59");
                parames.Add(start);
                parames.Add(end);
                str.Append(" and t.create_date between ? and ?");
            }
            if (address.Length > 0)
            {
                parames.Add(address);
                str.Append(" and t.pack_address=?");
            }
            if (patCode.Length > 0)
            {
                parames.Add(patCode);
                str.Append(" and ttt.patient_code=?");
            }
            if (patName.Length > 0)
            {
                parames.Add(patName);
                str.Append(" and ttt.patient_name=?");
            }
            if (packCode.Length > 0)
            {
                parames.Add(packCode);
                str.Append(" and t.pack_code = ?");
            }
            if (packName.Length > 0)
            {
                parames.Add(packName);
                str.Append(" and t.pack_name = ?");
            }
            if (str.Length == 0)
                str.Append(" and 1=2");
            string sql = string.Format(SqlTools.SqlQueryPack, str);
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            return result;
        }
    }
}
