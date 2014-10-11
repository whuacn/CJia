using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Models
{
    public class AdminHandleModel : CJia.PEIS.Tools.Model
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="createBy">创建人</param>
        /// <returns></returns>
        public bool AddUser(Views.AdminHandleEventArgs args, int createBy)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(args.UserNo);
            sqlParams.Add(args.UserName);
            sqlParams.Add(args.UserGender);
            if (args.UserPhone.Length == 0) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserPhone); }
            if (args.UserWorkUnit.Length == 0) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserWorkUnit); }
            sqlParams.Add(createBy);
            if (args.UserImage == null) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserImage); }
            if (args.UserSignImage == null) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserSignImage); }
            sqlParams.Add(args.UserStatus);
            sqlParams.Add(args.UserNameSpell);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertUser, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="args"></param>
        /// <param name="updataBy"></param>
        /// <returns></returns>
        public bool ModifyUser(Views.AdminHandleEventArgs args, int updataBy)
        {
            List<object> sqlParams = new List<object>();
            StringBuilder str = new StringBuilder("");
            sqlParams.Add(args.UserNo);
            sqlParams.Add(args.UserName);
            sqlParams.Add(args.UserGender);
            if (args.UserPhone.Length == 0) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserPhone); }
            if (args.UserWorkUnit.Length == 0) { sqlParams.Add(DBNull.Value); }
            else { sqlParams.Add(args.UserWorkUnit); }
            sqlParams.Add(args.UserStatus);
            sqlParams.Add(args.UserNameSpell);
            sqlParams.Add(updataBy);
            sqlParams.Add(args.UserID);
            if (args.UserImage != null)
            {
                str.Append("user_image=:10,");
                sqlParams.Add(args.UserImage);
            }
            else
            {
                sqlParams.Add(DBNull.Value);
            }
            if (args.UserSignImage != null)
            {
                str.Append("user_sign=:11,");
                sqlParams.Add(args.UserSignImage);
            }
            else
            {
                sqlParams.Add(DBNull.Value);
            }
            string sql = string.Format(SqlTools.SqlUpdataUserByUserID, str.ToString());
            return CJia.DefaultPostgre.Execute(sql, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 获得性别
        /// </summary>
        /// <returns></returns>
        public DataTable GetGender()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectGender);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得用户状态
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserStatus()
        {
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectUserStatus);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <param name="bol">是否显示停用</param>
        /// <returns></returns>
        public DataTable GetAllUsers(bool bol)
        {
            if (bol)
            {
                DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectAllUser);
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return null;
            }
            else
            {
                string sql = SqlTools.SqlSelectAllUser + " and b.status=9";
                DataTable dtResult = CJia.DefaultPostgre.Query(sql);
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return null;
            }
        }
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="bol">是否显示停用</param>
        /// <param name="keys">关键字</param>
        /// <returns></returns>
        public DataTable GetUsersByKeys(bool bol, string keys)
        {
            string str = " AND (b.user_no LIKE '%" + keys + "%' or b.user_name LIKE '%" + keys + "%' or b.user_name_spell LIKE '%" + keys.ToUpper() + "%')";
            if (bol)
            {
                string sql = SqlTools.SqlSelectAllUser + str;
                DataTable dtResult = CJia.DefaultPostgre.Query(sql);
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return null;
            }
            else
            {
                string sql = SqlTools.SqlSelectAllUser + " and b.status=9" + str;   //不显示停用
                DataTable dtResult = CJia.DefaultPostgre.Query(sql);
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return null;
            }
        }
        /// <summary>
        /// 根据用户id获得其所有信息
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public DataTable GetUserByUserID(int userID)
        {
            object[] sqlParam = new object[] { userID };
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectUserByUserID, sqlParam);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户id删除用户
        /// </summary>
        /// <param name="updateID">修改人id</param>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public bool DeleteUserByUserID(int updateID, int userID)
        {
            object[] sqlParam = new object[] { updateID, userID };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteUserByUserID, sqlParam) > 0 ? true : false;
        }
        /// <summary>
        /// 重置用户密码(密码为8888)
        /// </summary>
        /// <param name="updateID">修改人id</param>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public bool ResetPasswordByUserID(int updateID, int userID)
        {
            object[] sqlParam = new object[] { updateID, userID };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlResetPasswordByUserID, sqlParam) > 0 ? true : false;
        }
        /// <summary>
        /// 根据用户编号查询用户
        /// </summary>
        /// <param name="userNO">用户编号</param>
        /// <returns></returns>
        public DataTable GetUserByUserNO(string userNO)
        {
            object[] sqlParam = new object[] { userNO };
            DataTable dtResult = CJia.DefaultPostgre.Query(SqlTools.SqlSelectUserByUserNO, sqlParam);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

    }
}
