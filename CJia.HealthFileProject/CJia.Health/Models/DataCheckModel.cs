using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Models
{
    public class DataCheckModel : CJia.Health.Tools.Model
    {
        public DataTable Sreach(DateTime start, DateTime end, string search)
        {
            string searchStr = "%" + search + "%";
            object[] parames = new object[] { start, end, searchStr, searchStr, searchStr, searchStr };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSearchData, parames);
            return result;
        }

        public DataTable SelectPic(string healthId)
        {
            object[] parames = new object[] { healthId };
            DataTable result = CJia.DefaultOleDb.Query(CJia.Health.Models.SqlTools.SqlSelectPic, parames);
            return result;
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="healthId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ModifCheckStatus(string healthId, string status)
        {
            object[] parames = new object[] { status, healthId };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifCheckStatis, parames);
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        /// <param name="healthId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ModifLockStatus(string healthId, string status)
        {
            object[] parames = new object[] { status, healthId  };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlModifLockStatus, parames);
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public bool GetLockFunction(string userid)
        {
            object[] parames = new object[] { userid };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.Health.Models.SqlTools.SqlQueryLockFunction,parames);
            if(result != "0")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 插入审核
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        public bool InsertCheckReason(string healthId, string checkReason, string originalCheckStatus, string checkStatus, string userID, string userName)
        {
            object[] parames = new object[] { healthId, checkStatus,userID, userName, checkReason, originalCheckStatus };
            int result = CJia.DefaultOleDb.Execute(CJia.Health.Models.SqlTools.SqlInsertCheckReason, parames);
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
