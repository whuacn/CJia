using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models
{
    public class ErrorModel:Tools.Model
    {
        public DataTable QueryError()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryError);
        }
    }
}
