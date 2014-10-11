using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.HIS.App.Models
{
    public class MainContainerModel : CJia.HIS.Model
    {
        public DataTable GetMenu(string userId, string systemId)
        {
            object[] parameters = new object[] { systemId, userId };
            DataTable result = CJia.DefaultData.Query(SqlModel.GetMenu, parameters);
            return result;
        }

        public DataTable GetTool(string userId, string systemId)
        {
            object[] parameters = new object[] { systemId, userId };
            DataTable result = CJia.DefaultData.Query(SqlModel.GetTool, parameters);
            return result;
        }

        public DataTable GetModule(string moduleId)
        {
            object[] parameters = new object[] { moduleId };
            DataTable result = CJia.DefaultData.Query(SqlModel.GetMoudle, parameters);
            return result;
        } 
    }
}

