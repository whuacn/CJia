//***************************************************
// 文件名（File Name）:      CancelApplyModelTest.cs
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
    public class CancelApplyModelTest
    {
        CJia.PIVAS.Models.CancelApplyModel cancelApplyModel;

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
            cancelApplyModel = new CJia.PIVAS.Models.CancelApplyModel();
        }


        /// <summary>
        /// 查询申请退药列表信息
        /// </summary>
        [TestMethod]
        public void QueryGridByCancelApply_查询数据是否为空()
        {
            // 查询日期条件
            string queryDate = "BETWEEN  to_date('01-01-2020 00:00:00', 'dd-mm-yyyy hh24:mi:ss') AND  to_date('02-01-2020 23:59:59', 'dd-mm-yyyy hh24:mi:ss')";
            // 查询瓶贴状态
            string queryExeStatus = "0";
            // 查询病区
            string queryIllFieldId = "1000000673";
            string labelStatus = "1000302";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            DataTable dtGrid = cancelApplyModel.QueryGridByCancelApply(queryDate, queryExeStatus, queryIllFieldId);
            Assert.IsNotNull(dtGrid, "未查询到数据");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
        }

        /// <summary>
        /// 病区查询，绑定病区筛选条件
        /// </summary>
        [TestMethod]
        public void QueryOfficeName_查询数据是否为空()
        {
            if (CJia.DefaultData.Execute(SqlTools.sqlInsertPIVAS_Set) > 0)
            {
                DataTable dtOfficeName = cancelApplyModel.QueryOfficeName();
                Assert.IsNotNull(dtOfficeName, "未查询到数据");
                CJia.DefaultData.Execute(SqlTools.sqlDeletePIVAS_Set);
            }
            
        }

        /// <summary>
        /// 取得退药表下一个Sequence
        /// </summary>
        [TestMethod]
        public void QueryNextCancelRCPId_查询退药表下一个Sequence()
        {
            long nextCancelRCPId = cancelApplyModel.QueryNextCancelRCPId();
            Assert.AreNotEqual(0, nextCancelRCPId, "未获得正确退药单号");
        }

        /// <summary>
        /// 插入退药表
        /// </summary>
        [TestMethod]
        public void InsertCancelRCP_数据是否插入成功()
        {
            bool isSuccess = false;
            isSuccess = cancelApplyModel.InsertCancelRCP(202002250001, 1000000001, "huyang", "胡洋", "1000000062", "配置中心药房");
            Assert.IsTrue(isSuccess,"数据插入失败");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
        }

        /// <summary>
        /// 修改瓶贴表瓶贴状态
        /// </summary>
        [TestMethod]
        public void UpdatePivasLabelStatus_数据是否修改成功()
        {
            bool isSuccess = false;
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            isSuccess = cancelApplyModel.UpdatePivasLabelStatus(1000000001, "9000000000");
            Assert.IsTrue(isSuccess, "数据修改失败");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
        }

        /// <summary>
        /// 修改退药申请表瓶贴状态、瓶贴单号
        /// </summary>
        [TestMethod]
        public void UpdateCancelApplyByAgree_数据是否修改成功()
        {
            bool isSuccess = false;
            string labelStatus = "1000302";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            isSuccess = cancelApplyModel.UpdateCancelApplyByAgree(202002250001, 1000000001, "9000000000");
            Assert.IsTrue(isSuccess, "数据修改失败");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
        }

        /// <summary>
        /// 拒绝退药时根据界面所选group_index修改退药表
        /// </summary>
        [TestMethod]
        public void UpdateCancelApplyByRefuse_数据是否修改成功()
        {
            bool isSuccess = false;
            string labelStatus = "1000302";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            isSuccess = cancelApplyModel.UpdateCancelApplyByRefuse(202002250001, 1000000001, "9000000000");
            Assert.IsTrue(isSuccess, "数据修改失败");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
        }

        /// <summary>
        ///  打印所勾选的瓶贴药品
        /// </summary>
        [TestMethod]
        public void QueryPrintApplyCancelPharm_打印是否成功()
        {
            string labelStatus = "1000303";
            string sqlFormatInsertCancelApply = string.Format(SqlTools.sqlInsertCancelApply, labelStatus);
            CJia.DefaultData.Execute(SqlTools.sqlInsertRCP);
            CJia.DefaultData.Execute(sqlFormatInsertCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlInsertLabel);
            DataTable dtPrint = cancelApplyModel.QueryPrintApplyCancelPharm("1000000001");
            Assert.IsNotNull(dtPrint,"打印成功");
            CJia.DefaultData.Execute(SqlTools.sqlDeleteCancelApply);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteRCP);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabelDetail);
            CJia.DefaultData.Execute(SqlTools.sqlDeleteLabel);
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
