using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class UserTest
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
        /// 实例化待测试类
        /// </summary>
        CJia.PIVAS.Models.DataManage.UserModel userModel = new CJia.PIVAS.Models.DataManage.UserModel();

        /// <summary>
        /// 测试查询配置中心所有用户
        /// </summary>
        [TestMethod]
        public void QueryAllUser_查询配置中心所有用户_有返回值()
        {
            //通过Sql语句查出有多少条用户数据
            string sqlQueryAllUser = @"select * from sm_user where status='1'";
            int UserCount = CJia.DefaultOleDb.Query(sqlQueryAllUser).Rows.Count;

            //通过调用测试方法查询有多少条用户数据
            int UsetCountTest = userModel.QueryAllUser().Rows.Count;
            Assert.IsTrue(UserCount == UsetCountTest, "查询结果有误");
        }

        /// <summary>
        /// 测试删除用户
        /// </summary>
        [TestMethod]
        public void DeleteUser_删除用户_删除成功()
        {
            string sqlQueryNextSeq = @"select sm_user_seq.nextval from dual";
            long NextSeq = long.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryNextSeq));

            try
            {
                string sqlInsertTest = @"insert into sm_user
                                      (user_id, user_no, user_name, user_password, status, create_by, create_date, update_by, update_date, filter, dept_id, dept_name)
                                    values
                                      (" + NextSeq + ", 'test', '测试', '123456', '1', 1000000999, sysdate, 1000000999, sysdate, 'test', 1000000999, 'test')";

                bool isInset = CJia.DefaultOleDb.Execute(sqlInsertTest) == 1 ? true : false;
                Assert.IsTrue(isInset, "插入测试数据失败");

                bool isDelete = userModel.DeleteUser(1000000999, NextSeq);
                Assert.IsTrue(isDelete, "删除失败");
            }
            finally
            {
                //最后删除添加的测试数据 以防万一
                string sqlDeleteTest = @"delete sm_user where user_id=" + NextSeq;
                CJia.DefaultOleDb.Execute(sqlDeleteTest);
            }
                                    
        }
    }
}
