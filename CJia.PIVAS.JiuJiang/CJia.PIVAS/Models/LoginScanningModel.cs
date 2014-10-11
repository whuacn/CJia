using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace CJia.PIVAS.Models
{
    public class LoginScanningModel : Tools.Model
    {

        /// <summary>
        /// 检查用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable Login(string userId, string password)
        {
            object[] parms = new object[] { userId, password };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlLogin, parms);
            return result;
        }

        /// <summary>
        /// 插入登录扫描
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public void InsertLoginScanning(string userId, string userName,string operation)
        {
            object[] parms = new object[] { userId, userName, operation };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlInsertLoginScanning,parms);
        }



        /// <summary>
        /// 检测该用户是否登录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true为未登录</returns>
        public bool ExamineUser(string userId)
        {
            object[] parms = new object[] { userId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlExamineUser, parms);
            if(result == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测该操作台是否登录
        /// </summary>
        /// <param name="Operation"></param>
        /// <returns>true为未登录</returns>
        public bool ExamineOperation(string Operation)
        {
            object[] parms = new object[] { Operation };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlExamineOperation, parms);
            if(result == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
