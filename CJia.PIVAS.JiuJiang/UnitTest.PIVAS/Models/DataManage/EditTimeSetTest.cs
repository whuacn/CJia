using System;
using CJia.PIVAS.Models.DataManage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class EditTimeSetTest
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
        /// 实例化EditTimeSetModel
        /// </summary>
        EditTimeSetModel editTimeSetModel = new EditTimeSetModel();

        /// <summary>
        /// 测试添加拉单或者冲药数据是否成功
        /// </summary>
        [TestMethod]
        public void InsertTimeSet_添加拉单或者冲药数据_添加成功()
        {
            //添加一条拉单数据
            long timeId1 = long.Parse(CJia.DefaultOleDb.QueryScalar("select sm_time_set_seq.nextval from dual").ToString())+1;
            try
            {
                bool isInsertLd = editTimeSetModel.InsertTimeSet("测试第十次拉单sdgdrhgsrfgsdfsg", "22:00", "23:00", 1, 1000000001);
                Assert.IsTrue(isInsertLd, "添加拉单数据不成功");
            }
            finally
            {
                bool isDelete1 = CJia.DefaultOleDb.Execute("delete sm_time_set where time_id = " + timeId1) > 0 ? true : false;
                Assert.IsTrue(isDelete1, "添加的测试数据没有被删除");
            }

            //添加一条冲药数据
            long timeId2 = long.Parse(CJia.DefaultOleDb.QueryScalar("select sm_time_set_seq.nextval from dual").ToString())+1;
            try
            {
                bool isInsertCy = editTimeSetModel.InsertTimeSet("测试第十次冲药", "22:00", "23:00", 2, 1000000001);
                Assert.IsTrue(isInsertCy, "添加冲药数据不成功");
            }
            finally
            {
                bool isDelete2 = CJia.DefaultOleDb.Execute("delete sm_time_set where time_id = " + timeId2.ToString()) > 0 ? true : false;
                Assert.IsTrue(isDelete2, "添加的测试数据没有被删除");
            }
        }


        /// <summary>
        /// 测试修改时间数据
        /// </summary>
        [TestMethod]
        public void UpdateTimeSet_修改时间数据_修改成功()
        {
            //string timeName = "测试数据";
            //string startTime = "23:00";
            //string overTime = "23:30";
            //long userId = 1000000999;
            try
            {
                //先添加一条测试数据
                string sqlInsert = @"insert into sm_time_set
                                  (time_id, time_name, start_time, over_time, type, status, create_by, create_date, update_by, update_date)
                                values
                                  (1000000999, '测试数据', '23:00', '23:30', '1', '1', 1000000999, sysdate, 1000000999, sysdate)";
                bool isInsert = CJia.DefaultOleDb.Execute(sqlInsert) > 0 ? true : false;
                Assert.IsTrue(isInsert, "添加拉单数据不成功");

                //测试修改
                bool isUpdate = editTimeSetModel.UpdateTimeSet("测试数据1", "22:00", "22:30", 1000000999, 1000000999);
                Assert.IsTrue(isUpdate, "修改不成功");
            }
            finally
            {
                //删除添加的测试数据
                string sqlDelete = @"delete sm_time_set
                                where time_id = 1000000999";
                bool isDelete = CJia.DefaultOleDb.Execute(sqlDelete) > 0 ? true : false;
                Assert.IsTrue(isDelete, "未能删除刚刚添加的测试数据");
            }
        }
    }
}
