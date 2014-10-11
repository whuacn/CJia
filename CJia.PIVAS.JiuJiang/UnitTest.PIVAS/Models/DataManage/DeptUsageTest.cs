using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class DeptUsageTest
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

        CJia.PIVAS.Models.DataManage.DeptUsageModel deptUsage = new CJia.PIVAS.Models.DataManage.DeptUsageModel();

        /// <summary>
        /// 查询所有病区对应用法
        /// </summary>
        [TestMethod]
        public void QueryDeptUsage_查询所有病区对应用法_有返回值()
        {
            string sqlQueryDeptUsageCount = @"select count(*) from sr_pivas_set where status = '1'";
            int deptCount = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryDeptUsageCount));

            DataTable dtDeptUsage =  deptUsage.QueryDeptUsage();
            Assert.IsTrue(deptCount == dtDeptUsage.Rows.Count, "未能查询出所有病区对应用法");
        }

        [TestMethod]
        public void DeleteDeptUsage_删除病区对应用法_删除成功()
        {
            //先插入一条病区对应用法的测试数据
            string sqlInsertDeptUsage = @"insert into sr_pivas_set
                                          (pivas_set_id, office_id, office_name, usage_id, usage_name, status, create_by, create_date, update_by, update_date)
                                        values
                                          (1000000999, 1000000999, '测试病区', '1000000999', '测试用法', '1', 1000000999, sysdate, 1000000999, sysdate)";
            bool isInsert = CJia.DefaultOleDb.Execute(sqlInsertDeptUsage) > 0 ? true : false;
            Assert.IsTrue(isInsert, "插入测试数据失败");

            //测试删除
            bool isDelete = deptUsage.DeleteDeptUsage(1000000999, 1000000999);
            
            string sqlDelete = @"delete sr_pivas_set 
                                where pivas_set_id=1000000999";
            CJia.DefaultOleDb.Execute(sqlDelete);
            
            Assert.IsTrue(isDelete, "删除失败");
        }
    }
}
