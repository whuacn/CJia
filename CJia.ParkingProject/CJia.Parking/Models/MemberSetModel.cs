using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Models
{
    public class MemberSetModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 查询会员类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMemType()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMemType);
        }

        /// <summary>
        /// 查询是否存在相同会员类型
        /// </summary>
        /// <param name="memType"></param>
        /// <returns></returns>
        public DataTable QueryIsExistSameMemType(string memType)
        {
            object[] sqlParams = new object[]{ memType };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameMemType,sqlParams);
        }

        /// <summary>
        /// 插入会员类型表
        /// </summary>
        /// <param name="memType"></param>
        /// <param name="price"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool InsertMemType(string memType,int price,long userId)
        {
            object[] sqlParams = new object[] { memType,price,userId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertMemType,sqlParams) > 0 ?true : false;
        }

        /// <summary>
        /// 修改会员类型表
        /// </summary>
        /// <param name="memType"></param>
        /// <param name="price"></param>
        /// <param name="userId"></param>
        /// <param name="memTypeId"></param>
        /// <returns></returns>
        public bool UpdateMemType(string memType, int price, long userId,long memTypeId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(memType);
            sqlParams.Add(price);
            sqlParams.Add(userId);
            sqlParams.Add(memTypeId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateMemType, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除会员类型表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="memTypeId"></param>
        /// <returns></returns>
         public bool DeleteMemType(long userId,long memTypeId)
         {
             object[] sqlParams = new object[] { userId,memTypeId };
             return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteMemType, sqlParams) > 0 ? true : false;
         }
         
         
    }
}
