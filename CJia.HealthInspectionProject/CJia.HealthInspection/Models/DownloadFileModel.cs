using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class DownloadFileModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 根据任务ID查询所属文件
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public DataTable QueryFilesByTaskId(string taskId)
        {
            object[] sqlParams = new object[] { taskId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryFilesByTaskId, sqlParams);
        }
    }
}
