using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class MemberModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMember()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMember);
        }

        ///// <summary>
        ///// 查询会员类型
        ///// </summary>
        ///// <returns></returns>
        //public DataTable QueryMemType()
        //{
        //    return CJia.DefaultPostgre.Query(SqlTools.SqlSelectMemType);
        //}

        /// <summary>
        /// 是否存在相同会员编号
        /// </summary>
        /// <param name="memNo"></param>
        /// <returns></returns>
        public DataTable QueryIsExistSameMemNo(string memNo)
        {
            object[] sqlParams = new object[] { memNo };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameMemberNo,sqlParams);
        }

        /// <summary>
        /// 是否存在相同车牌号
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        public DataTable QueryIsExistSamePlateNo(string plateNo)
        {
            object[] sqlParams = new object[] { plateNo };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSamePlateNo,sqlParams);
        }

        /// <summary>
        /// 插入会员信息表
        /// </summary>
        /// <param name="memNo">会员编号</param>
        /// <param name="memName">会员名称</param>
        /// <param name="plateNo">车牌号</param>
        /// <param name="checkDate">会员登记日期</param>
        /// <param name="userId">创建人</param>
        /// <returns></returns>
        public bool InsertMember(string memNo,string memName,string plateNo,long userId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(memNo);
            sqlParams.Add(memNo);
            sqlParams.Add(plateNo);
            sqlParams.Add(userId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertMember,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="memNo"></param>
        /// <param name="memName"></param>
        /// <param name="plateNo"></param>
        /// <param name="userId"></param>
        /// <param name="memId"></param>
        /// <returns></returns>
        public bool UpdateMember(string memNo, string memName, string plateNo, long userId, long memId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(memNo);
            sqlParams.Add(memName);
            sqlParams.Add(plateNo);
            sqlParams.Add(userId);
            sqlParams.Add(memId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateMember, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="memId">所要修改的会员ID</param>
        /// <returns></returns>
        public bool DeleteMember(long userId, long memId)
        {
            object[] sqlParams = new object[] { userId,memId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteMember, sqlParams) > 0 ? true : false;
        }
    }
}
