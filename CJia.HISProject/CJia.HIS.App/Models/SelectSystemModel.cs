using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.HIS.App.Models
{
    public class SelectSystemModel : CJia.HIS.Model
    {
        public DataTable GetSystem(string userId)
        {
            object[] parameters = new object[]{userId};
            DataTable result = CJia.DefaultData.Query(SqlModel.GetSystem,parameters);
            return result;
        }
    }
}

