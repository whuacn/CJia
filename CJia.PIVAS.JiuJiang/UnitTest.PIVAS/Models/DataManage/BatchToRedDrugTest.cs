using System;
using System.Data;
using CJia.PIVAS.Models.DataManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    /// <summary>
    /// 测试批次对应冲药页面的model层
    /// </summary>
    [TestClass]
    public class BatchToRedDrugTest
    {
        [TestInitialize()]
        public void InitTest()
        {
            CJia.ClientConfig.ServerIP = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Host");
            CJia.ClientConfig.ServerPort = int.Parse(CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("Port"));
            CJia.ClientConfig.ClientNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("ClientNo");
            CJia.ClientConfig.SystemNo = CJia.PIVAS.Tools.ConfigHelper.GetAppStrings("SystemNo");
        }

        /// <summary>
        /// 结束测试
        /// </summary>
        [TestCleanup()]
        public void EndTest()
        {
            //serverApp.Stop();
        }

        /// <summary>
        /// 实例化批次Model
        /// </summary>
        BatchToRedDrugModel batchToRedDrug = new BatchToRedDrugModel();

        /// <summary>
        /// 测试查询批次对应冲药数据
        /// </summary>
        [TestMethod]
        public void QueeryBatchSet_查询批次对应冲药数据_有数据返回()
        {
            //先查询出批次表中有多少条有效数据
            string sqlQueryCount = @"select count(*) from sm_batch_set where status='1'";
            int count = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryCount));

            //测试查询结果
            DataTable dtBatch = batchToRedDrug.QueryBatchSet();
            Assert.IsTrue(count == dtBatch.Rows.Count, "查询结果不正确");
            //Assert.IsTrue(dtBatch.Rows.Count == 0, "没有查询到批次数据");
            //Assert.IsTrue(count > dtBatch.Rows.Count, "批次数据查询有丢失");
            //Assert.IsTrue(count < dtBatch.Rows.Count, "查询到得批次数据比数据库里的多");
        }
    }
}
