using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace CJia.PIVAS.Models
{
    public static class PIVASModel
    {
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime QuerySysdate()
        {
            return DateTime.Parse(CJia.DefaultOleDb.QueryScalar("select sysdate from dual"));
        }

        /// <summary>
        /// 获取扣费时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool QueryFeeTime(string time)
        {
            string value = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryFeeTime);
            if(value == time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否该退该瓶贴
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public static bool QueryCancelFeeTime(string labelId)
        {
            object[] param = new object[] { labelId };
            string value = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryCancelFeeTime, param);
            if(value != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否该退该瓶贴
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public static bool QueryCancelFeeTimeLabelId(string labelId)
        {
            object[] param = new object[] { labelId };
            string value = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.SqlTools.SqlQueryCancelFeeTimeLabelId, param);
            if(value != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据医嘱组号在his中扣费用
        /// </summary>
        /// <param name="groupIndex">医嘱ID</param>
        /// <param name="userid">操作员ID</param>
        /// <param name="data">操作日期</param>
        /// <param name="count">计费频次</param>
        /// <param name="iflag">计费；0；退费：1；</param>
        public static string ExecuteGroupIndexFee(string groupIndex, string userid, DateTime data, int count, int iflag)
        {
            string flag = "";
            object[] paramers = new object[] { groupIndex };
            DataTable adviceids = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAdviceIdByGroupIndex, paramers);
            if(adviceids != null && adviceids.Rows != null && adviceids.Rows.Count != 0)
            {
                bool isSuccessed = false;
                using(CJia.Transaction tran = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    foreach(DataRow row in adviceids.Rows)
                    {
                        string adviceId = row["ADVICE_ID"].ToString();
                        string result = ExecuteAdviceIdFee(tran.ID, adviceId, userid, data, count, iflag);
                        if(result != "Successed")
                        {
                            flag += row["PHARM_NAME"].ToString() + " " + result;
                        }
                    }
                    if(flag == "")
                    {
                        tran.Complete();
                        flag = "Successed";
                        isSuccessed = true;
                    }
                }
                if(!isSuccessed)
                {
                    flag = "";
                    using(CJia.Transaction tran = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                    {
                        foreach(DataRow row in adviceids.Rows)
                        {
                            string adviceId = row["ADVICE_ID"].ToString();
                            string result = ExecuteAdviceIdFee(tran.ID, adviceId, userid, data.AddSeconds(1), count, iflag);
                            if(result != "Successed")
                            {
                                flag += row["PHARM_NAME"].ToString() + " " + result;
                            }
                        }
                        if(flag == "")
                        {
                            tran.Complete();
                            flag = "Successed";
                            isSuccessed = true;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 根据医嘱组号在his中扣费用
        /// </summary>
        /// <param name="transID">事务id</param>
        /// <param name="groupIndex">医嘱ID</param>
        /// <param name="userid">操作员ID</param>
        /// <param name="data">操作日期</param>
        /// <param name="count">计费频次</param>
        /// <param name="iflag">计费；0；退费：1；</param>
        public static string ExecuteGroupIndexFee(string transID, string groupIndex, string userid, DateTime data, int count, int Iflag)
        {
            throw new Exception("此方法是已废除的计费方法");
            //string flag = "";
            //object[] paramers = new object[] { groupIndex };
            //DataTable adviceids = CJia.DefaultOleDb.Query(transID, CJia.PIVAS.Models.SqlTools.SqlQueryAdviceIdByGroupIndex, paramers);
            //if(adviceids != null && adviceids.Rows != null && adviceids.Rows.Count != 0)
            //{
            //    foreach(DataRow row in adviceids.Rows)
            //    {
            //        string adviceId = row["ADVICE_ID"].ToString();
            //        string result = ExecuteAdviceIdFee(transID, adviceId, userid, data, count, Iflag);
            //        flag = result;
            //    }
            //}
            //return flag;
        }

        /// <summary>
        /// 根据医嘱id扣费扣库存
        /// </summary>
        /// <param name="adviceId">医嘱ID</param>
        /// <param name="userid">操作员ID</param>
        /// <param name="data">操作日期</param>
        /// <param name="count">计费频次</param>
        /// <param name="flag">计费；0；退费：1；</param>
        /// <returns></returns>
        public static string ExecuteAdviceIdFee(string adviceId, string userid, DateTime data, int count, int flag)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("I_ADVICE_ID", adviceId);
            parms.Add("I_USER_ID", userid);//现阶段使用默认的用户
            parms.Add("I_OPERDATE", data);
            parms.Add("I_TIMES", count);
            parms.Add("I_FLAG", flag);
            parms.Add("O_FLAG", "");
            CJia.DefaultOleDb.ExecuteProcedure("SP_PHARM_FEE_TEMP", ref parms);
            string result = parms["O_FLAG"].ToString();
            return result;
        }

        /// <summary>
        /// 根据医嘱id扣费扣库存
        /// <param name="transID">事务id</param>
        /// <param name="adviceId">医嘱ID</param>
        /// <param name="userid">操作员ID</param>
        /// <param name="data">操作日期</param>
        /// <param name="count">计费频次</param>
        /// <param name="flag">计费；0；退费：1；</param>
        /// <returns></returns>
        public static string ExecuteAdviceIdFee(string transID, string adviceId, string userid, DateTime data, int count, int flag)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("I_ADVICE_ID", adviceId);
            parms.Add("I_USER_ID", userid);//现阶段使用默认的用户
            parms.Add("I_OPERDATE", data);
            parms.Add("I_TIMES", count);
            parms.Add("I_FLAG", flag);
            parms.Add("O_FLAG", "");
            CJia.DefaultOleDb.ExecuteProcedure(transID, "SP_PHARM_FEE_TEMP", ref parms);
            string result = parms["O_FLAG"].ToString();
            return result;
        }

        /// <summary>
        /// 修改瓶贴状态为已冲药
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="labelId"></param>
        public static void ExecuteLabelFee(string transID, string labelId)
        {
            object[] parmas = new object[] { CJia.PIVAS.User.UserId, CJia.PIVAS.User.UserName, labelId };
            CJia.DefaultOleDb.Execute(transID, CJia.PIVAS.Models.SqlTools.SqlUpdateLabel);
        }

        /// <summary>
        /// 修改瓶贴状态为已冲药
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="labelId"></param>
        public static void ExecuteLabelFee(string labelId)
        {
            object[] parmas = new object[] { CJia.PIVAS.User.UserId, CJia.PIVAS.User.UserName, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlUpdateLabel, parmas);
        }
        /// <summary>
        /// 根据组号获得配伍禁忌数据
        /// </summary>
        /// <param name="groupIndex"></param>
        /// <returns>0：表示审方不通过；1：表示正常</returns>
        public static string[] GetPWJJByGroupIndex(string groupIndex)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("I_GROUP_INDEX", groupIndex);
            parms.Add("O_PWJJ_INFO", "");
            parms.Add("O_FLAG", "");
            CJia.DefaultOleDb.ExecuteProcedure("SP_GET_PWJJ", ref parms);
            string info = parms["O_PWJJ_INFO"].ToString();
            string flag = parms["O_FLAG"].ToString();
            string[] result = new string[2];
            result[0] = flag;
            result[1] = info;
            return result;
        }

        /// <summary>
        /// 根据code返回配置文件表中的value
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetParameters(string code)
        {
            object[] parms = new object[] { code };
            return CJia.DefaultOleDb.QueryScalar("select gp.value from gm_parameters gp where gp.code = ?", parms);
        }


        public static string ipStr = "";
        public static string IpStr
        {
            get
            {
                if(ipStr == "")
                {
                    IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
                    foreach(IPAddress ip in ips)
                    {
                        if(!ip.IsIPv6LinkLocal && !ip.IsIPv6Multicast && !ip.IsIPv6SiteLocal && !ip.IsIPv6Teredo)
                        {
                            ipStr += ip.ToString() + " ";
                        }
                    }
                }
                return ipStr;
            }
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logValue"></param>
        public static void WriteLog(string logValue)
        {
            try
            {
                object[] parms = new object[] { logValue, CJia.PIVAS.User.UserId, CJia.PIVAS.User.UserName, IpStr };
                CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlWriteLog, parms);
            }
            catch
            {
            }
        }

    }
}
