using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.Models
{
    public class CheckScriptModel : Tools.Model
    {
        /// <summary>
        /// 获得审核脚本
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllScript()
        {
            string sql = string.Format(SqlTools.SqlQueryCheckScript, "");
            DataTable dtResult = CJia.DefaultOleDb.Query(sql);
            return dtResult;
        }
        /// <summary>
        /// 根据编号获得审核脚本
        /// </summary>
        /// <param name="NO"></param>
        /// <returns></returns>
        public DataTable GetScriptByNO(string NO)
        {
            object[] sqlParams = new object[] { NO };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckScriptByNO, sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 根据关键字搜索审核脚本
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetScriptByKey(string key)
        {
            object[] sqlParams = new object[] { "%" + key + "%", "%" + key + "%", "%" + key + "%", "%" + key + "%", "%" + key + "%", "%" + key + "%" };
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckScriptByKey, sqlParams);
            return dtResult;
        }
        /// <summary>
        /// 新增审核脚本
        /// </summary>
        /// <param name="NO"></param>
        /// <param name="test"></param>
        /// <param name="error"></param>
        /// <param name="checkID"></param>
        /// <param name="level"></param>
        /// <param name="classify"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddCheckScript(string NO, string test, string error, string checkID, string level, string classify, string userID)
        {
            object[] sqlParams = new object[] { NO, test, error, checkID, level, classify, userID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlAddCheckScript, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 修改审核脚本
        /// </summary>
        /// <param name="NO"></param>
        /// <param name="test"></param>
        /// <param name="error"></param>
        /// <param name="checkID"></param>
        /// <param name="level"></param>
        /// <param name="classify"></param>
        /// <param name="userID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool ModifyCheckScript(string NO, string test, string error, string checkID, string level, string classify, string status, string userID, string ID)
        {
            object[] sqlParams = new object[] { NO, test, error, checkID, level, classify, status, userID, ID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlModifyCheckScript, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 删除审核脚本
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteCheckScript(string ID, string userID)
        {
            object[] sqlParams = new object[] { userID, ID };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteCheckScript, sqlParams) > 0 ? true : false;
        }
        /// <summary>
        /// 获得审核类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckType()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(SqlTools.SqlQueryCheckType);
            return dtResult;
        }
    }
}
