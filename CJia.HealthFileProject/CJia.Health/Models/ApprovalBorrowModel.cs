using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class ApprovalBorrowModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询所有借阅申请
        /// </summary>
        /// <returns></returns>
        public DataTable QuertBorrow()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBorrow);
        }

        /// <summary>
        /// 查询申请单
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBorrowList(DateTime beginDate,DateTime endDate,string deptId,string borrowState)
        {
            object[] ob = new object[] { "%"+deptId+"%", beginDate, endDate, borrowState };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBorrowList, ob);
        }

        /// <summary>
        /// 查询病案号
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRecord(DateTime beginDate,DateTime endDate,string deptId,string borrowState)
        {
            object[] ob = new object[] { "%" + deptId + "%", beginDate, endDate, borrowState };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryRecord, ob);
        }


        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllDept);
        }

        /// <summary>
        /// 查询借阅状态
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBorrowState()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBorrowState);
        }

        /// <summary>
        /// 通过借阅
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="listBorrow"></param>
        /// <param name="agreeId"></param>
        /// <param name="agreeName"></param>
        /// <returns></returns>
        public bool PassBorrow(string transID, string listBorrow, string agreeId, string agreeName)
        {
            object[] ob = new object[] { agreeId, agreeName, agreeId, listBorrow, listBorrow };
            return  CJia.DefaultOleDb.Execute(transID, SqlTools.SqlPassBorrow, ob) > 0 ? true : false;
        }
        public bool PassBorrowFromEndDate(string transID, string listBorrow,DateTime endDate, string agreeId, string agreeName)
        {
            object[] ob = new object[] { agreeId, agreeName, agreeId, endDate, listBorrow };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlPassBorrowFromEndDate, ob) > 0 ? true : false;
        }
        /// <summary>
        /// 拒绝借阅
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="listBorrow"></param>
        /// <param name="agreeId"></param>
        /// <param name="agreeName"></param>
        /// <returns></returns>
        public bool RefuseBorrow(string transID, string listBorrow, string agreeId, string agreeName)
        {
            object[] ob = new object[] { agreeId, agreeName, agreeId, listBorrow };
            return CJia.DefaultOleDb.Execute(transID, SqlTools.SqlRefuseBorrow, ob) > 0 ? true : false;
        }

    }
}
