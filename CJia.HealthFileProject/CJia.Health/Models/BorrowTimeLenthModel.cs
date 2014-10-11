using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class BorrowTimeLenthModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 查询借阅时间
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBorrowTime()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryBorrowTime);
        }

        /// <summary>
        /// 查询医生职称
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDocDescript()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryDocDes);
        }

        public int CheckDesRepeat(string DocDesId,string BorrowTimeId)
        { 
            object[] ob=new object[]{DocDesId,BorrowTimeId};
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckDesRepeat, ob));
        }

        /// <summary>
        /// 添加一条借阅时间数据
        /// </summary>
        /// <param name="DocDes"></param>
        /// <param name="TimeLenth"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool InsertBorrowTime(string DocDes,int TimeLenth,string UserID )
        {
            object[] ob = new object[] { DocDes, TimeLenth, UserID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertBorrowTime, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 修改借阅时间
        /// </summary>
        /// <param name="TimeLenth"></param>
        /// <param name="UserId"></param>
        /// <param name="BorrowTimeId"></param>
        /// <returns></returns>
        public bool UpdateBorrowTime(int TimeLenth, string UserId, string BorrowTimeId)
        {
            object[] ob = new object[] { TimeLenth, UserId, BorrowTimeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateBorrowTime, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 删除借阅时间
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BorrowTimeId"></param>
        /// <returns></returns>
        public bool DeleteBorrowTime(string UserId, string BorrowTimeId)
        {
            object[] ob = new object[] { UserId, BorrowTimeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteBorrowTime, ob) > 0 ? true : false;
        }
    }
}
