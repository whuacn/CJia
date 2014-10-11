using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class SelectTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询任务信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTask(long OrganID)
        {
            object[] ob = new object[] { OrganID };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryTask,ob);
            return dtResult;
        }
          
        /// <summary>
        /// 根据任务ID查询任务信息
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public DataTable QueryTaskById(long TaskId)
        {
            object[] ob=new object[]{TaskId};
            DataTable dtTask=CJia.DefaultOleDb.Query(SqlTools.SqlQueryTaskByIdForExe,ob);
            if(dtTask!=null&&dtTask.Rows!=null&&dtTask.Rows.Count>0)
            {
                return dtTask;
            }
            else
            {
                return null;
            }
        }
    }
}
