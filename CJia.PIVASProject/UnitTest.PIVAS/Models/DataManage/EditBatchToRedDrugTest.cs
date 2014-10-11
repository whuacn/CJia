using System;
using CJia.PIVAS.Models.DataManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    /// <summary>
    /// 测试修改批次
    /// </summary>
    [TestClass]
    public class EditBatchToRedDrugTest
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
        /// 实例化
        /// </summary>
        EditBatchToRedDrugModel editBatch = new EditBatchToRedDrugModel();

        /// <summary>
        /// 测试修改批次对应冲药
        /// </summary>
        [TestMethod]
        public void UpdateBatchSet_修改批次_修改成功()
        {
            //string sqlQueryNextSeq = @"select sm_batch_set_seq.nextval from dual";
            //long nextSql = long.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryNextSeq));
            try
            {
                //添加一条测试的冲药数据(BatchSet表的外键关联用)
                string sqlInsertCy1 = @"insert into sm_time_set
                                  (time_id, time_name, start_time, over_time, type, status, create_by, create_date, update_by, update_date)
                                values
                                  (1000000999, '测试数据', '23:00', '23:30', '2', '1', 1000000999, sysdate, 1000000999, sysdate)";
                bool isInsertCy1 = CJia.DefaultOleDb.Execute(sqlInsertCy1) > 0 ? true : false;
                Assert.IsTrue(isInsertCy1, "添加冲药数据不成功");

                //添加一条测试的冲药数据(BatchSet表的外键关联用)
                string sqlInsertCy2 = @"insert into sm_time_set
                                  (time_id, time_name, start_time, over_time, type, status, create_by, create_date, update_by, update_date)
                                values
                                  (1000009999, '测试数据', '22:00', '22:30', '2', '1', 1000009999, sysdate, 1000000999, sysdate)";
                bool isInsertCy2 = CJia.DefaultOleDb.Execute(sqlInsertCy2) > 0 ? true : false;
                Assert.IsTrue(isInsertCy2, "添加冲药数据不成功");

                //先添加一条待测试的数据
                string sqlInsertBatch = @"insert into sm_batch_set
                              (batch_id, batch_name, batch_time, time_id, status, create_date, create_by, update_date, update_by)
                            values
                              (1000000999, '测试', '22:00', 1000000999, '1', sysdate, 1000000999, sysdate, 1000000999)";
                bool isInsert = CJia.DefaultOleDb.Execute(sqlInsertBatch) > 0 ? true : false;
                Assert.IsTrue(isInsert, "添加批次测试数据失败");


                bool isUpdate = editBatch.UpdateBatchSet("23:00", 1000009999, 1000000999, 1000000999);
                Assert.IsTrue(isUpdate, "批次对应冲药失败");

            }
            finally
            {
                //删除刚添加的供测试用的批次数据
                string sqlDeleteBatch = "delete sm_batch_set where batch_id= 1000000999 ";
                bool isDeleteBatch = CJia.DefaultOleDb.Execute(sqlDeleteBatch) > 0 ? true : false;
                Assert.IsTrue(isDeleteBatch, "删除添加的供测试用的批次数据失败");

                //删除刚添加的供测试用的冲药数据
                string sqlDeleteCy1 = "delete sm_time_set where time_id= 1000000999 ";
                bool isDeleteCy1 = CJia.DefaultOleDb.Execute(sqlDeleteCy1) > 0 ? true : false;
                Assert.IsTrue(isDeleteCy1, "删除添加的供测试用的冲药数据失败");

                //删除刚添加的供测试用的冲药数据
                string sqlDeleteCy2 = "delete sm_time_set where time_id= 1000009999 ";
                bool isDeleteCy2 = CJia.DefaultOleDb.Execute(sqlDeleteCy2) > 0 ? true : false;
                Assert.IsTrue(isDeleteCy2, "删除添加的供测试用的冲药数据失败");
            }
        }
    }
}
