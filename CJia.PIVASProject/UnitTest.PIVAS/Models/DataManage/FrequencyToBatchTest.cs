using System;
using System.Data;
using CJia.PIVAS.Models.DataManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    /// <summary>
    /// 测试频率对应批次
    /// </summary>
    [TestClass]
    public class FrequencyToBatchTest
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
        /// 实例化频率对应批次
        /// </summary>
        FrequencyToBatchModel frequencyBatch = new FrequencyToBatchModel();

        /// <summary>
        /// 测试查询频率对应批次
        /// </summary>
        [TestMethod]
        public void QueryFrequencyToBatch_查询频率对应批次_有返回值()
        {
            //查询频率对应批次表中的数据条数
            string sqlFrequencyBatch = @"select count(*) from sr_frequence_batch_set  where status='1'";
            int count = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlFrequencyBatch));

            DataTable dt = frequencyBatch.QueryFrequencyToBatch();
            Assert.IsTrue(count == dt.Rows.Count, "查询结果不正确");
            Assert.IsFalse(dt.Rows.Count == 0, "没有查询到频率对应批次数据");
            Assert.IsFalse(count > dt.Rows.Count, "查询到得频率对应批次数据有缺失");
            Assert.IsFalse(count < dt.Rows.Count, "查询到得频率对应批次数据有增加");
        }

        /// <summary>
        /// 测试查询频率视图中的频率信息
        /// </summary>
        [TestMethod]
        public void QueryFrequency_查询频率视图中的频率信息_有返回值()
        {
            //查询频率视图中的数据条数
            string sqlFrequency = @"select count(*) 
                        from gm_frequency_view 
                        where frequency_id not in(select frequency_id from sr_frequence_batch_set) ";
            int count = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlFrequency));

            DataTable dt = frequencyBatch.QueryFrequency();
            Assert.IsTrue(count == dt.Rows.Count, "查询结果不正确");
            Assert.IsFalse(dt.Rows.Count == 0, "没有查询到频率信息");
            Assert.IsFalse(count > dt.Rows.Count, "查询到得频率数据有丢失");
            Assert.IsFalse(count < dt.Rows.Count, "查询到的频率数据有增加");
        }

        ///// <summary>
        ///// 测试删除频率对应批次信息
        ///// </summary>
        //[TestMethod]
        //public void DeleteFrequencyBatch_删除频率对应批次信息_删除成功()
        //{

        //}
    }
}
