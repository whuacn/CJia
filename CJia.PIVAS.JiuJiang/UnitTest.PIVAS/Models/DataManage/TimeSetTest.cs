using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJia.PIVAS.Models.DataManage;
using System.Data;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class TimeSetTest
    {
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
        /// 实例化redDrugModel类
        /// </summary>
        RedDrugModel redDrugModel = new RedDrugModel();

        /// <summary>
        /// 实例化EditTimeSetModel
        /// </summary>
        EditTimeSetModel editTimeSetModel = new EditTimeSetModel();

        /// <summary>
        /// 测试是否查询到了冲药和拉单的时间详情
        /// </summary>
        [TestMethod]
        public void GetRedDrug_查询时间数据详情_有数据返回()
        {
//            //先添加一条拉单测试数据
//            string sqlInsertLd = @"insert into sm_time_set
//                                  (time_id, time_name, start_time, over_time, type, status, create_by, create_date, update_by, update_date)
//                                values
//                                  (1000000999, '拉单测试数据', '23:00', '23:30', '1', '1', 1000000999, sysdate, 1000000999, sysdate)";
//            bool isInsert = CJia.DefaultOleDb.Execute(sqlInsertLd) > 0 ? true : false;
//            Assert.IsTrue(isInsert, "添加拉单数据不成功");

//            //插入一条冲药数据
//            string sqlInsertCy = @"insert into sm_time_set
//                                  (time_id, time_name, start_time, over_time, type, status, create_by, create_date, update_by, update_date)
//                                values
//                                  (1000009999, '冲药测试数据', '23:00', '23:30', '0', '1', 1000000999, sysdate, 1000000999, sysdate)";
//            bool isInsertCy = CJia.DefaultOleDb.Execute(sqlInsertCy) > 0 ? true : false;
//            Assert.IsTrue(isInsertCy, "添加冲药数据不成功");

            //查询出表中有几条拉单数据
            string sqlQueryCountLd = @"select count(*) from sm_time_set where status='1' and type='1'";
            int countLd = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryCountLd));

            //查询出表中有几条冲药数据
            string sqlQueryCountCy = @"select count(*) from sm_time_set where status='1' and type='2'";
            int countCy = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryCountCy));

            //测试传入无效参数"0"
            DataTable dtNull = redDrugModel.GetRedDrug("0");
            Assert.IsTrue(dtNull.Rows.Count==0, "此参数是无效参数，应该不能有返回值");

            //测试查询拉单详情
            DataTable dtLd = redDrugModel.GetRedDrug("1");
            Assert.IsTrue(dtLd.Rows.Count == countLd, "拉单数据查询错误");

            //测试查询冲药详情
            DataTable dtCy = redDrugModel.GetRedDrug("2");
            Assert.IsTrue(dtCy.Rows.Count == countCy, "冲药数据查询错误");
        }

        

        /// <summary>
        /// 测试时间数据（拉单和冲药）删除是否成功
        /// </summary>
        [TestMethod]
        public void DeleteTimeSet_删除冲药或者拉单数据_删除成功()
        {
            string sqlSelectNextSeq = @"select sm_time_set_seq.nextval from dual";
            long timeId = long.Parse(CJia.DefaultOleDb.QueryScalar(sqlSelectNextSeq).ToString())+1;
           
            try
            {
              
                bool isInsertLd = editTimeSetModel.InsertTimeSet("第十次拉单sdgdrhgsrfgsdfsg", "22:00", "23:00", 1, 1000000001);
                Assert.IsTrue(isInsertLd, "添加测试的拉单数据不成功");
            }
            finally
            {
                string sqlDelete = @"delete sm_time_set where time_id=" + timeId;
                bool isDelete = CJia.DefaultOleDb.Execute(sqlDelete) >0? true : false;
                Assert.IsTrue(isDelete, "删除添加的Id为"+timeId+"的测试数据失败，请手动删除");
            }
        }
    }
}
