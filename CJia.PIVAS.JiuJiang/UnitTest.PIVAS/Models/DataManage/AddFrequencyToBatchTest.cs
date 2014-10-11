using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class AddFrequencyToBatchTest
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

        //实例化所测试的类
        CJia.PIVAS.Models.DataManage.AddFrequencyToBatchModel addfrequency = new CJia.PIVAS.Models.DataManage.AddFrequencyToBatchModel();

        /// <summary>
        /// 测试从频率视图中查询未配置批次的频率信息
        /// </summary>
        [TestMethod]
        public void QueryFrequency_从频率视图中查询未配置批次的频率信息_有返回值()
        {
            //查询未配置批次的频率
            string sqlFrequency = @"select count(*) 
                        from gm_frequency_view 
                        where frequency_id not in(select frequency_id from sr_frequence_batch_set) ";
            try
            {
                //从视图中找出一条频率数据
                string SqlQueryFrequency = @"select * from gm_frequency_view";
                DataTable dt = CJia.DefaultOleDb.Query(SqlQueryFrequency);

                //或得未添加频率对应批次时有多少条频率
                int frequencyCountBegin = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlFrequency));

                //往频率对应批次表中插入一条频率对应批次数据
                string SqlInsertFrequencyToBatch = @"insert into sr_frequence_batch_set
                                                  (frequency_batch_id, frequency_id, frequency_name, frequency_filter, batchs_name, status, create_by, create_date)
                                                values
                                                  (1000000999, '" + dt.Rows[0]["frequency_id"].ToString() + "','" + dt.Rows[0]["frequency_name"] + "','" + dt.Rows[0]["filter"] + "','1-3-','1', 1000000999, sysdate)";
                bool IsInsert = CJia.DefaultOleDb.Execute(SqlInsertFrequencyToBatch) > 0 ? true : false;
                Assert.IsTrue(IsInsert, "插入测试数据失败");

                //判断是否往频率对应批次表中插入一条频率对应批次信息 且频率Id=上面从频率视图中查出来的频率ID
                string SqlQueryFrequencyBatch = @"select *
                                           from sr_frequence_batch_set t
                                          where status = '1'
                                            and t.frequency_batch_id = 1000000999";
                DataRow dr = CJia.DefaultOleDb.Query(SqlQueryFrequencyBatch).Rows[0];
                string frequency_id = dr["frequency_id"].ToString();
                Assert.IsTrue(dt.Rows[0]["frequency_id"].ToString() == frequency_id, "未能往频率对应批次表中插入一条频率对应批次信息");

                //或得已添加一条频率对应批次时有多少条频率
                int frequencyCountEnd = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlFrequency));
                Assert.IsTrue(frequencyCountBegin == frequencyCountEnd + 1, "添加失败");
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


        /// <summary>
        /// 测试插入频率对应批次
        /// </summary>
        [TestMethod]
        public void InsertFrquencyBatch_插入频率对应批次_插入成功()
        {
            string SqlQueryFrequencyBatchId = @"select sr_frequency_batch_set_seq.nextval from dual";
            long FrequencyBatchId = long.Parse(CJia.DefaultOleDb.QueryScalar(SqlQueryFrequencyBatchId).ToString())+1;
            try
            {
                bool IsInsert = addfrequency.InsertFrquencyBatch(1000000999, "test", "test", "1-3", 1000000999);
                Assert.IsTrue(IsInsert, "插入失败");
            }
            finally
            {
                //删除插入的测试数据
                string SqlDelete = @"delete sr_frequence_batch_set
                                where status='1' and frequency_batch_id = " + FrequencyBatchId;
                bool IsDelete = CJia.DefaultOleDb.Execute(SqlDelete) > 0 ? true : false;
                Assert.IsTrue(IsDelete, "频率对应批次表中插入的Id为1000000999的测试数据未能删除成功");
            }
            }
    }
}
