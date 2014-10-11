using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    /// <summary>
    /// 查询法律法规树状结构数据源
    /// </summary>
    public class LowModel : Tools.Model
    {
        /// <summary>
        /// 查询所有法律文件树状结构
        /// </summary>
        /// <returns></returns>
        public DataTable GetLowTreeData()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryLowFather);
        }

        /// <summary>
        /// 根据Id查询法律法规文件
        /// </summary>
        /// <param name="LowId"></param>
        /// <returns></returns>
        public DataTable SelectLowFileById(long LowId)
        { 
            object[] ob=new object[]{LowId};
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectLowByID, ob);
        }
    }
}
