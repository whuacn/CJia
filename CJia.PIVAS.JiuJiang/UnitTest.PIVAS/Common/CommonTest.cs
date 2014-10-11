using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Common
{
    [TestClass]
    public class CommonTest
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
        /// 测试加、解密
        /// </summary>
        [TestMethod]
        public void PwdHandel()
        {
            //测试密码为test的加解密
            string pwdTest1="test";
            string EncryptPwd1 = CJia.PIVAS.Common.EncryptString(pwdTest1);
            string DecryptPwd1 = CJia.PIVAS.Common.DecryptString(EncryptPwd1);
            Assert.IsTrue(pwdTest1 == DecryptPwd1, "机密解密正确");

            //测试密码为huyang的加解密
            string pwdTest2 = "huyang";
            string EncryptPwd2 = CJia.PIVAS.Common.EncryptString(pwdTest2);
            string DecryptPwd2 = CJia.PIVAS.Common.DecryptString(EncryptPwd1);
            Assert.IsTrue(pwdTest1 == DecryptPwd1, "机密解密正确");
        }

        /// <summary>
        /// 测试批次处理 如把1-3转换成1和3的list
        /// </summary>
        [TestMethod]
        public void BatchHandle_批次处理_有返回值()
        {
            string batchsName1 = "1-4-";
            List<int> ListBatch1 = CJia.PIVAS.Common.BatchHandle(batchsName1);
            Assert.IsTrue(ListBatch1[0] == 1, "批次处理失败");
            Assert.IsTrue(ListBatch1[1] == 4, "批次处理失败");
           

            string batchsName2 = "1-3-4-";
            List<int> ListBatch2 = CJia.PIVAS.Common.BatchHandle(batchsName2);
            Assert.IsTrue(ListBatch2[0] == 1, "批次处理失败");
            Assert.IsTrue(ListBatch2[1] == 3, "批次处理失败");
            Assert.IsTrue(ListBatch2[2] == 4, "批次处理失败");
        }
         
    }
}
