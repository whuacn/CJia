using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class EditFrequencyToBatchTest
    {
        /// <summary>
        /// 初始化
        /// </summary>
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
        /// 实例化所测页面
        /// </summary>
        CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel editFrequencyToBatch = new CJia.PIVAS.Models.DataManage.EditFrequencyToBatchModel();

        /// <summary>
        /// 测试查询批次
        /// </summary>
        [TestMethod]
        public void QueryBatch_查询批次_有返回值()
        {
            //查询出批次表中有几条批次数据
            string SqlQueryBatchCount = "select count(*) from sm_batch_set";
            int BatchCount = int.Parse(CJia.DefaultOleDb.QueryScalar(SqlQueryBatchCount));

            int QueryBatchCount = editFrequencyToBatch.QueryBatch().Rows.Count;
            Assert.IsTrue(BatchCount == QueryBatchCount, "查询结果不正确");
            Assert.IsFalse(QueryBatchCount == 0, "批次表中没有数据");
            Assert.IsFalse(BatchCount > QueryBatchCount, "查询出的批次数据数量有缺失");
            Assert.IsFalse(BatchCount < QueryBatchCount, "查询出的批次数据数量有增加");
        }

        /// <summary>
        /// 测试修改频率对应批次
        /// </summary>
        [TestMethod]
        public void UpdataFrequencyBatch_修改频率对应批次_修改成功()
        {
            try
            {
                //从视图中找出一条频率数据
                string SqlQueryFrequency = @"select * from gm_frequency_view";
                DataRow dr = CJia.DefaultOleDb.Query(SqlQueryFrequency).Rows[0];

                //往频率对应批次表中插入一条频率对应批次数据
                string SqlInsertFrequencyToBatch = @"insert into sr_frequence_batch_set
                                                  (frequency_batch_id, frequency_id, frequency_name, frequency_filter, batchs_name, status, create_by, create_date)
                                                values
                                                  (1000000999, '" + dr["frequency_id"].ToString() + "','" + dr["frequency_name"] + "','" + dr["filter"] + "','1-3-','1', 1000000999, sysdate)";
                bool IsInsert = CJia.DefaultOleDb.Execute(SqlInsertFrequencyToBatch) > 0 ? true : false;
                Assert.IsTrue(IsInsert, "插入测试数据失败");

                //判断是否插入成功
                bool IsUpdate = editFrequencyToBatch.UpdataFrequencyBatch("1-4", 1000000999, 1000000999);
                Assert.IsTrue(IsUpdate, "修改失败");

                //判断修改后的批次名称是否正确
                string QueryFrequencybatch = @"select batchs_name from sr_frequence_batch_set t where t.frequency_batch_id=1000000999";
                string batchsName = CJia.DefaultOleDb.QueryScalar(QueryFrequencybatch).ToString();
                Assert.IsTrue(batchsName == "1-4", "批次修改失败");
            }
            finally
            {
                //删除插入的测试数据
                string SqlDelete = @"delete sr_frequence_batch_set
                                where frequency_batch_id = 1000000999";
                bool IsDelete = CJia.DefaultOleDb.Execute(SqlDelete) > 0 ? true : false;
                Assert.IsTrue(IsDelete, "频率对应批次表中插入的Id为1000000999的测试数据未能删除成功");
            }
        }

    }
}
