using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class AddUsetTest
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
        CJia.PIVAS.Models.DataManage.AddUserModel addUser = new CJia.PIVAS.Models.DataManage.AddUserModel();

        /// <summary>
        /// 测试判断当前工号在用户表中是否有重复
        /// </summary>
        [TestMethod]
        public void IsUserRepeat_判断当前工号在用户表中是否有重复_重复()
        {
            //从用户表中找出一个工号用作测试参数
            string sqlQueryUser = @"select user_no from sm_user where status='1'";
            string userNo = CJia.DefaultOleDb.QueryScalar(sqlQueryUser);

            bool isRepeat1 = addUser.IsUserRepeat(userNo);
            Assert.IsTrue(isRepeat1, "方法出错，不能检测出重复");

            bool isRepeat2 = addUser.IsUserRepeat("test09kejkk");
            Assert.IsFalse(isRepeat2, "方法出错，不能检测出重复");
        }

        /// <summary>
        /// 测试添加新用户
        /// </summary>
        [TestMethod]
        public void InsertUser_添加新用户_添加成功()
        {
            //查询出seq
            string sqlQuertNextSeq = @"select sm_user_seq.nextval from dual";
            long userId=long.Parse(CJia.DefaultOleDb.QueryScalar(sqlQuertNextSeq))+1;
            try
            {
                bool isInsert = addUser.InsertUser("insertTest", "测试", "123456", "100000", "静脉药物配置中心", 1000000999);
                Assert.IsTrue(isInsert, "添加用户失败");
            }
            finally
            {
                //删除测试的添加用户
                string sqlDeleteTestData = @"delete sm_user where user_id=" + userId;
                bool IsDelete = CJia.DefaultOleDb.Execute(sqlDeleteTestData) > 0 ? true : false;
                Assert.IsTrue(IsDelete, "删除测试数据失败");
            }
        }
    }
}
