using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 过滤瓶贴Model层
    /// </summary>
    public class LabelAgainPrintModel : CJia.PIVAS.Tools.Model
    {

        /// <summary>
        /// 查询要打印的瓶贴
        /// </summary>
        /// <param name="LabelList"></param>
        /// <returns></returns>
        public DataTable SelectPrintInfo(List<string> LabelList)
        {
            if(LabelList != null && LabelList.Count > 0)
            {
                StringBuilder sql = new StringBuilder("(");
                foreach(string labelBarId in LabelList)
                {
                    sql.Append(labelBarId);
                    sql.Append(",");
                }
                if(sql.Length > 1)
                {
                    sql.Remove(sql.Length - 1, 1);
                }
                sql.Append(")");
                string newSql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlSelectLabelInfo, sql.ToString());
                return CJia.DefaultOleDb.Query(newSql);
            }
            else
            {
                return null;
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
        /// 通过时间查瓶贴
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public System.Data.DataTable Select(DateTime startDateTime, DateTime endDateTime, string illfieldId, string batchId, string startBarId, string endBarId)
        {
            object[] parmes = new object[] { startDateTime, endDateTime, startBarId, endBarId };
            string addSql = "";
            if(illfieldId != "0")
            {
                addSql += " and spl.illfield_id = '" + illfieldId + "'";
            }
            if(batchId != "0")
            {
                addSql += " and spl.batch_id = '" + batchId + "' ";
            }
            string newSql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlSelectLabel, addSql);
            return CJia.DefaultOleDb.Query(newSql, parmes);
        }

        ///// <summary>
        ///// 通过瓶贴号查瓶贴
        ///// </summary>
        ///// <param name="start"></param>
        ///// <param name="end"></param>
        ///// <returns></returns>
        //public System.Data.DataTable Select(string start, string end)
        //{
        //    object[] parmes = new object[] { start, end };
        //    return CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlSelectLabelByBarId, parmes);
        //}

        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }
    }
}
