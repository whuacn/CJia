using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Tools.Models
{
    public class SyetemConfigModel
    {
        public Dictionary<string, List<string>> QueryDBConfig()
        {
            return CJia.DefaultData.QueryDBConfig();
        }

        public void Execute(string dbName, string sqlStr)
        {
            using(CJia.DataAdapter ada = new DataAdapter(dbName))
            {
                ada.Execute(sqlStr);
            }
        }
    }
}
