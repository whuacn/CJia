using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class AddDeptUsageTest
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
        /// 实例化添加病区类
        /// </summary>
        CJia.PIVAS.Models.DataManage.AddDeptUsageModel addDeptUsage = new CJia.PIVAS.Models.DataManage.AddDeptUsageModel();

        /// <summary>
        /// 测试查询所有病区
        /// </summary>
        [TestMethod]
        public void QueryDept_查询所有病区_有返回值()
        {
            string sqlQuertDept = @"select count(*) from gm_dept_view";
            int deptCount = int.Parse(CJia.DefaultOleDb.QueryScalar(sqlQuertDept));

            DataTable dtDepe = addDeptUsage.QueryDept();
            Assert.IsTrue(deptCount == dtDepe.Rows.Count, "未能查出所有病区");
        }

        /// <summary>
        /// 测试查询病区未配置的用法
        /// </summary>
        [TestMethod]
        public void QueryUsage_查询病区未配置的用法_有返回值()
        {
            //找出一个病区
            string sqlQueryDept = @"select dept_id from gm_dept_view";
            string deptId = CJia.DefaultOleDb.QueryScalar(sqlQueryDept);

            //找出当前病区未配置的用法
            string sqlQueryUsage = @"select usage_id
                                  from gm_usage_view a
                                 where a.USAGE_ID not in
                                       (select b.usage_id
                                          from sr_pivas_set b
                                         where b.status = '1'
                                           and b.office_id = '"+deptId +"')";
            DataTable dtUsage = CJia.DefaultOleDb.Query(sqlQueryUsage);
            int UsageCount1 = dtUsage.Rows.Count;

            //测试方法的结果
            int UsageCount2 = addDeptUsage.QueryUsage(deptId).Rows.Count;

            Assert.IsTrue(UsageCount1 == UsageCount2, "查询结果有误");
        }

        /// <summary>
        /// 测试添加病区对应用法数据
        /// </summary>
        [TestMethod]
        public void InsertPivas_添加病区对应用法数据_添加成功()
        {
            //找出一个病区
            string sqlQueryDept = @"select dept_id,dept_name from gm_dept_view";
            string deptId = CJia.DefaultOleDb.Query(sqlQueryDept).Rows[0]["DEPT_ID"].ToString();
            string deptName = CJia.DefaultOleDb.Query(sqlQueryDept).Rows[0]["DEPT_NAME"].ToString();

            //找出当前病区未配置的用法
            string sqlQueryUsage = @"select usage_id,usage_name
                                  from gm_usage_view a
                                 where a.USAGE_ID not in
                                       (select b.usage_id
                                          from sr_pivas_set b
                                         where b.status = '1'
                                           and b.office_id = '" + deptId + "')";
            DataTable dtUsage = CJia.DefaultOleDb.Query(sqlQueryUsage);
            long UsageId = long.Parse(dtUsage.Rows[0]["USAGE_ID"].ToString());
            string UsageName = dtUsage.Rows[0]["USAGE_NAME"].ToString();

            //找出待插入的数据的ID 供下面删除 用
            string sqlQueryNextSeq = @"select sr_pivas_set_seq.nextval from dual";
            long NextSeq = long.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryNextSeq))+1;
            try
            {
                //测试方法的添加方法
                bool isInsert = addDeptUsage.InsertPivas(deptId, deptName, UsageId, UsageName,1000000999);

                Assert.IsTrue(isInsert, "插入失败");
            }
            finally
            {
                string sqlDeleteTestData = @"delete sr_pivas_set t where t.pivas_set_id =" + NextSeq;
                int Delete = CJia.DefaultOleDb.Execute(sqlDeleteTestData);

                Assert.IsTrue(Delete == 1, "sr_pivas_set表中新添加的Id为" + NextSeq + "的数据删除失败");
            }
        }

        /// <summary>
        /// 判断是否有重复
        /// </summary>
        [TestMethod]
        public void QueryIsRepeat_判断是否有重复_重复()
        {
            string sqlQuertPivas = @"select * from sr_pivas_set where status='1'";
            DataTable dtPivas = CJia.DefaultOleDb.Query(sqlQuertPivas);
            string officeId=dtPivas.Rows[0]["OFFICE_ID"].ToString();
            long usageId=long.Parse(dtPivas.Rows[0]["USAGE_ID"].ToString());

            //传入两个真的参数测试
            bool isRepeat1 = addDeptUsage.QueryIsRepeat(officeId, usageId);
            Assert.IsTrue(isRepeat1, "有重复数据");

            //传入假参数测试
            bool isRepeat2 = addDeptUsage.QueryIsRepeat("8888888888", 8888888888);
            Assert.IsFalse(isRepeat2, "测试数据测试报错");
        }
    }
}
