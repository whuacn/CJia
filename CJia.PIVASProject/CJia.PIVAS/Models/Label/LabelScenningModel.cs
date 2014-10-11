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
        public DataTable QueryLabelList(string date,string scenningType,string iffieldID,string bacthID)
        {
            StringBuilder format = new StringBuilder("");
            format.Append(" and gb.gen_time = '" + date + "' ");
            if(scenningType == "0")
            {
                format.Append(" and gb.status in (1000501,1000601,1000602)  ");
            }
            else
            {
                format.Append(" and gb.status in (1000601,1000602)  ");
            }
            if(iffieldID != "0")
            {
                format.Append(" and spl.illfield_id = '" + iffieldID + "' ");
            }
            if(bacthID != "0")
            {
                format.Append(" and spl.batch_id = '" + bacthID + "' ");
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryPrintLableList, format.ToString());
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 根据条形码号 返回瓶贴信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable QueryBarCodeLabel(string barCode)
        {
            object[] paramers = new object[]{barCode};
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarCodeLable,paramers);
            return result;
        }

        /// <summary>
        /// 修改瓶贴状态
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="status"></param>
        public void UpdateBarCodeStatus(string barCode,string status)
        {
            object[] paramers = new object[] { status, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateBarCodeStatus, paramers);
        }

        /// <summary>
        /// 从新打印瓶贴
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable AnewPrintLabel(string barCode,string userid)
        {
            string BarcodeSeq = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarcodeSeq);
            object[] paramers = new object[] { BarcodeSeq, userid, barCode };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlCopeBarCode, paramers);
            this.UpdateBarCodeStatus(barCode, "1000603");
            return this.QueryBarCodeLabel(BarcodeSeq);
        }

    }
}
