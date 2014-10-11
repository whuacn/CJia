//***************************************************
// 文件名（File Name）:      CancelRCPModelTest.cs
//
// 表（Tables）:            nothing
//
// 视图（Views）:           nothing
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.2.18
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTest.PIVAS.Models
{
    [TestClass]
    public class CancelRCPModelTest
    {
        CJia.PIVAS.Models.CancelRCPModel cancelRCPModel;

        /// <summary>
        /// 初始化测试参数
        /// </summary>
        [TestInitialize()]
        public void InitTest()
        {
            CJia.ClientConfig.ServerIP = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Host");
            CJia.ClientConfig.ServerPort = int.Parse(CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Port"));
            CJia.ClientConfig.ClientNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("ClientNo");
            CJia.ClientConfig.SystemNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("SystemNo");
            cancelRCPModel = new CJia.PIVAS.Models.CancelRCPModel();
        }

        /// <summary>
        /// 根据瓶贴所选瓶贴状态和日期查询已处理瓶贴
        /// </summary>
        [TestMethod]
        public void QueryRCP_查询数据是否为空()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DateTime checkDate = DateTime.Parse("2020/01/01");
            DataTable dtQueryData = cancelRCPModel.QueryRCP(1000303,checkDate);
            Assert.IsNotNull(dtQueryData, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }
        
        /// <summary>
        /// 查询所选日期去重后所有退药单号（不包括拒绝退药单号）
        /// </summary>
        [TestMethod]
        public void QueryGridDisTinCancelRCPID_查询数据是否为空()
        {
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            DateTime checkDate = DateTime.Parse("2020/01/01");
            DataTable dtRCPId = cancelRCPModel.QueryGridDisTinCancelRCPID(checkDate);
            Assert.IsNotNull(dtRCPId, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

        /// <summary>
        /// 退药汇总查询
        /// </summary>
        [TestMethod]
        public void QueryTotalCancelPharm_查询数据是否为空()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DateTime checkDate = DateTime.Parse(DateTime.Now.ToString("2020/01/01"));
            DataTable dtCancelPharm = cancelRCPModel.QueryTotalCancelPharm(checkDate);
            Assert.IsNotNull(dtCancelPharm, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

       
        /// <summary>
        /// 打印退药单查询
        /// </summary>
        [TestMethod]
        public void QueryPrintCancelPharm_查询数据是否为空()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DateTime checkDate = DateTime.Parse(DateTime.Now.ToString("2020/01/01"));
            DataTable dtPrintCancelPharm = cancelRCPModel.QueryPrintCancelPharm(checkDate);
            Assert.IsNotNull(dtPrintCancelPharm, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

        /// <summary>
        /// 单击左侧单号后查询退药信息
        /// </summary>
        [TestMethod]
        public void QueryGridCancelRCPBySelectedId_查询数据是否为空()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DateTime checkDate = DateTime.Parse(DateTime.Now.ToString("2020/01/01"));
            DataTable dtSelectedId = cancelRCPModel.QueryGridCancelRCPBySelectedId(1000303, checkDate, "202002250001");
            Assert.IsNotNull(dtSelectedId, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

        /// <summary>
        /// 选择单号后汇总查询退药信息
        /// </summary>
        [TestMethod]
        public void QueryGridAllCancelRCPBySelectedId_查询数据是否为空()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DateTime checkDate = DateTime.Parse(DateTime.Now.ToString("2020/01/01"));
            DataTable dtSelectedId = cancelRCPModel.QueryGridAllCancelRCPBySelectedId(1000303, checkDate, "202002250001");
            Assert.IsNotNull(dtSelectedId, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

        /// <summary>
        /// 结束测试
        /// </summary>
        [TestCleanup()]
        public void EndTest()
        {
            
        }
    }
}
