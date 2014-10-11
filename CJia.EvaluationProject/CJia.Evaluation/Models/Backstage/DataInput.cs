using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class DataInput :CJia.Evaluation.Tools.Model
    {
        public DataTable QueryUser()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable data = ad.Query(CJia.Evaluation.Models.SqlToos.SqlQueryUser,null);
                return data;
            }
        }
    }
}
