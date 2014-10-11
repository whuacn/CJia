using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Models
{
    public class QueryTaskModel : CJia.HealthInspection.Tools.Model
    {
        /// <summary>
        /// 查询所有任务类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTaskType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllTaskType);
        }

        /// <summary>
        /// 根据组织查询任务
        /// </summary>
        /// <param name="organId">组织流水号</param>
        /// <returns></returns>
        public DataTable QueryTaskByOrganId(string organId)
        {
            object[] sqlParams = new object[] { organId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTaskByOrganId,sqlParams);
        }

        /// <summary>
        /// 根据所选条件查询任务
        /// </summary>
        /// <param name="taskTypeId">所选任务类型</param>
        /// <param name="searchKeyWord">查询关键词</param>
        /// <returns></returns>
        public DataTable QueryTaskBySearch(string taskTypeId,string searchKeyWord,string organId)
        {
            object[] sqlParams = new object[] { organId };
            string sql = "";
            if (taskTypeId == "0")
            {
                sql = SqlTools.SqlQueryTaskBySearch;
            }
            else
            {
                sql = SqlTools.SqlQueryTaskBySearch + " and gt.task_type_id="+ taskTypeId +"";
            }
            if (searchKeyWord != "")
            {
                sql += "and (gt.task_name like '%" + searchKeyWord + "%' or gt.organ_name like '%" + searchKeyWord + "%' or gg.template_name like '%" + searchKeyWord + "%' or gt.check_scode like '%" + searchKeyWord + "%' or gt.remark like '%" + searchKeyWord + "%' or gu.user_name like '%" + searchKeyWord + "%' or gd.dept_name like '%" + searchKeyWord + "%')";
            }
            DataTable dt = CJia.DefaultOleDb.Query(sql, sqlParams);
            return CJia.DefaultOleDb.Query(sql,sqlParams);
        }

        /// <summary>
        /// 根据任务ID删除任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteTaskById(string updateBy,string taskId)
        {
            object[] sqlParams = new object[]{ updateBy,taskId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteTaskById,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据任务ID删除任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteTaskById(string transID, string updateBy, string taskId)
        {
            object[] sqlParams = new object[] { updateBy, taskId };
            return CJia.DefaultOleDb.Execute(transID,SqlTools.SqlDeleteTaskById, sqlParams) > 0 ? true : false;
        }
    }
}
