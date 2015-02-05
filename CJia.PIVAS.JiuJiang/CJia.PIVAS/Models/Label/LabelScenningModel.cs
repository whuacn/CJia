using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 瓶贴预览Model层
    /// </summary>
    public class LabelScenningModel : CJia.PIVAS.Tools.Model
    {

        /// <summary>
        /// 查询瓶贴的扣费次数
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public string QueryLabelTimes(string labelId)
        {
            object[] paramers = new object[] { labelId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlLabelTimes, paramers);
            if(string.IsNullOrEmpty(result))
            {
                result = "0";
            }
            return result;
        }

        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }

        /// <summary>
        /// 查询瓶贴列表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryLabelList(string grOrDr,string date, string scenningType, string iffieldID, string bacthID, string labelType, string longTemporary)
        {
            StringBuilder format = new StringBuilder("");
            format.Append(" and spl.pharm_time between to_date('" + date + "','yyyy/mm/dd') and to_date('" + date + "','yyyy/mm/dd') + 1");
            if(grOrDr == "0")
            {
                format.Append(" and spl.list_doctor_date between to_date('" + date + "','yyyy/mm/dd') and to_date('" + date + "','yyyy/mm/dd') + 1 ");
            }
            else
            {
                format.Append(" and spl.list_doctor_date < to_date('" + date + "','yyyy/mm/dd') ");
            }
            if(scenningType == "1000601")
            {
                format.Append(" and gb.status in (1000501,1000601,1000602,1000605)  ");
            }
            else if(scenningType == "1000602")
            {
                format.Append(" and gb.status in (1000601,1000602,1000605)  ");
            }
            else if(scenningType == "1000605")
            {
                format.Append(" and gb.status in (1000602,1000605)  ");
            }
            
                format.Append(" and spl.illfield_id in (" + iffieldID + ") ");
           
                format.Append(" and spl.batch_id in (" + bacthID + ") ");
            
            string labelTypeStr = "";
            if(labelType == "10")
            {
                labelTypeStr = " and  1 = 1 ";
            }
            else
            {
                labelTypeStr = "    and fn_is_group(spl.group_index) =  '" + labelType + "'";
            }
            object[] parms = new object[] { scenningType, longTemporary };
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryPrintLableList, format.ToString(), labelTypeStr);
            DataTable result = CJia.DefaultOleDb.Query(sql, parms);
            return result;
        }

        /// <summary>
        /// 根据条形码号 返回瓶贴信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable QueryBarCodeLabel(string barCode)
        {
            object[] paramers = new object[] { barCode };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarCodeLable, paramers);
            return result;
        }

        /// <summary>
        /// 修改瓶贴状态
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="status"></param>
        public void UpdateBarCodeStatus(string barCode, string status, string userId, DateTime updateTime)
        {
            object[] paramers = new object[] { status, userId, updateTime, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateBarCodeStatus, paramers);
            if(status != "1000603")
            {
                paramers = new object[] { status, updateTime, userId, CJia.PIVAS.User.UserName, barCode };
                CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateBarCodeScanning, paramers);
            }
        }

        /// <summary>
        /// 从新打印瓶贴
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable AnewPrintLabel(string barCode, string userid)
        {
            string BarcodeSeq = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarcodeSeq);
            object[] paramers = new object[] { BarcodeSeq, userid, CJia.PIVAS.Tools.Helper.Sysdate, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlCopeBarCode, paramers);
            this.UpdateBarCodeStatus(barCode, "1000603", userid, CJia.PIVAS.Tools.Helper.Sysdate);
            paramers = new object[] { BarcodeSeq, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateScanningBarID, paramers);
            return this.QueryBarCodeLabel(BarcodeSeq);
        }

        /// <summary>
        /// 确定瓶贴对应医嘱的有效状态
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool QueryLabelGroupIndex(string barCode)
        {
            object[] paramers = new object[] { barCode };
            if(CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelGroupIndex, paramers) == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 拼贴作废
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="userid"></param>
        public void DelectPrintedLabel(string barCode, string userid)
        {
            object[] paramers = new object[] { userid, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDelectPrintedLabelByDarCode, paramers);
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDelectLabelByDarCode, paramers);
        }

        /// <summary>
        /// 打印瓶贴明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable QueryPrintLabelDetail(DateTime date, string labelType, string longTemporary,string grOrDr, string illfieldId, string bacthID)
        {
            string longTemporaryStr = "";
            if(longTemporary == "10")
            {
                longTemporaryStr = " and  1 = 1 ";
            }
            else
            {
                longTemporaryStr = " and spl.LONG_TIME_STATUS =  '" + longTemporary + "'";
            }

            string labelTypeStr = "";
            if(labelType == "10")
            {
                labelTypeStr = " and  1 = 1 ";
            }
            else
            {
                labelTypeStr = "    and fn_is_group(spl.group_index) =  '" + labelType + "'";
            }

            string batchStr = "";
            if(bacthID != "0")
            {
                batchStr = " and spl.batch_id = '" + bacthID + "' ";
            }
            else
            {
                batchStr = " and 1 = 1 ";
            }

            string strDrGr = "";
            if(grOrDr == "0")
            {
                strDrGr = " and spl.list_doctor_date between to_date('" + date.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') and to_date('" + date.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') + 1 ";
            }
            else
            {
                strDrGr = " and spl.list_doctor_date < to_date('" + date.ToString("yyyy/MM/dd") + "','yyyy/mm/dd') ";
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.QueryPrintLabelDetail, longTemporaryStr, labelTypeStr, batchStr, strDrGr);
            object[] parames = new object[] { date, date.AddDays(1), illfieldId };
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            return result;
        }
    }
}
