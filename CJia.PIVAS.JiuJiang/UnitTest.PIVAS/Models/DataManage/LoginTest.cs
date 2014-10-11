using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models.DataManage
{
    [TestClass]
    public class LoginTest
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
        /// 实例化登录类
        /// </summary>
        CJia.PIVAS.Models.LoginModel login = new CJia.PIVAS.Models.LoginModel();

        /// <summary>
        /// 测试查询当前登录用户的信息
        /// </summary>
        [TestMethod]
        public void SelectUser_查询当前登录用户的信息_有返回值()
        {
            string sqlQueryNextSeq = @"select sm_user_seq.nextval from dual";
            long nextSeq = long.Parse(CJia.DefaultOleDb.QueryScalar(sqlQueryNextSeq));
            try
            {
                string sqlInsert = @"insert into sm_user
                              (user_id, user_no, user_name, user_password, status, create_by, create_date, update_by, update_date, filter, dept_id, dept_name)
                            values
                              (" + nextSeq + ", 'test', '测试', '123456', '1', 1000000999, sysdate, 1000000999, sysdate, 'test', 1000000999, 'test')";

                bool isinsert = CJia.DefaultOleDb.Execute(sqlInsert) > 0 ? true : false;

                //测试真参数
                DataTable dtUsertrue = login.SelectUser("test", "123456");
                Assert.IsTrue(dtUsertrue.Rows.Count == 1, "没有查出正确结果");
                Assert.IsTrue(dtUsertrue.Rows[0]["USER_NAME"].ToString() == "测试", "查询出的结果有误");

                //测试假参数
                DataTable dtUserFalse = login.SelectUser("testFalse3838", "test");
                Assert.IsFalse(dtUserFalse.Rows.Count == 1, "错误数据也能查出  此方法有误");
            }
            finally
            {
                string SqlDelete = @"delete sm_user where user_id=" + nextSeq;
                bool isDelete = CJia.DefaultOleDb.Execute(SqlDelete) == 1 ? true : false;
                Assert.IsTrue(isDelete, "删除测试数据Id为" + nextSeq + "失败,请删除");
            }

        }
    }
}
