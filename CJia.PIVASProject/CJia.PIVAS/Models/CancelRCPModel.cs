//***************************************************
// 文件名（File Name）:      CancelRCPModel.cs
//
// 表（Tables）:            ST_PIVAS_LABEL_CANCEL_APPLY（配制中心瓶贴撤销申请记录表），
//                          ST_PIVAS_LABEL（配制中心瓶贴表）,
//                          ST_PIVAS_LABEL_DETAIL（配制中心瓶贴明细表）,
//                          ST_PIVAS_LABEL_CANCEL_RCP（配制中心瓶贴撤销单）
//
// 视图（Views）:           CANCEL_APPLY_COMMON_VIEW（退药申请界面公共查询视图）
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.26
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 退药查询数据层
    /// </summary>
    public class CancelRCPModel:Tools.Model
    {
        /// <summary>
        /// 根据瓶贴所选瓶贴状态和日期查询已处理瓶贴
        /// </summary>
        /// <param name="labelStatus">所选瓶贴状态</param>
        /// <param name="checkTime">所选时间条件</param>
        /// <returns></returns>
        public DataTable QueryRCP(int labelStatus , DateTime checkTime)
        {
            object[] sqlParams = new object[] { labelStatus, checkTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectRCP, sqlParams);
        }

        /// <summary>
        /// 查询所选日期去重后所有退药单号（不包括拒绝退药单号）
        /// </summary>
        /// <param name="checkTime"></param>
        /// <returns></returns>
        public DataTable QueryGridDisTinCancelRCPID(DateTime checkTime)
        {
            object[] sqlParams = new object[] { checkTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDisTinCancelRCPID,sqlParams);
        }

        /// <summary>
        /// 退药汇总查询
        /// </summary>
        /// <param name="checkTime">所选时间</param>
        /// <returns></returns>
        public DataTable QueryTotalCancelPharm(DateTime checkTime)
        {
            object[] sqlParams = new object[] { checkTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectAllCancelPharm, sqlParams);
        }

        /// <summary>
        /// 打印退药单查询
        /// </summary>
        /// <param name="checkTime"></param>
        /// <returns></returns>
        public DataTable QueryPrintCancelPharm(DateTime checkTime)
        {
            object[] sqlParams = new object[] { checkTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectPrintCancelPharm, sqlParams);
        }

        /// <summary>
        /// 单击左侧单号后查询退药信息
        /// </summary>
        /// <param name="labelStatus"></param>
        /// <param name="checkTime">所要查询时间</param>
        /// <param name="selectedRCPId">所选择退药单号</param>
        /// <returns></returns>
        public DataTable QueryGridCancelRCPBySelectedId(int labelStatus , DateTime checkTime, string selectedRCPId)
        {
            object[] sqlParams = new object[] { labelStatus, checkTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectRCP + selectedRCPId ,sqlParams);
        }


        /// <summary>
        /// 选择单号后汇总查询退药信息
        /// </summary>
        /// <param name="labelStatus"></param>
        /// <param name="checkTime">所要查询时间</param>
        /// <param name="selectedRCPId">所选择退药单号</param>
        /// <returns></returns>
        public DataTable QueryGridAllCancelRCPBySelectedId(int labelStatus, DateTime checkTime, string selectedRCPId)
        {
            string queryStr = string.Format(SqlTools.SqlSelectAllCancelRCPById,selectedRCPId);
            object[] sqlParams = new object[] { labelStatus, checkTime };
            return CJia.DefaultOleDb.Query(queryStr, sqlParams);
        }
    }
}
