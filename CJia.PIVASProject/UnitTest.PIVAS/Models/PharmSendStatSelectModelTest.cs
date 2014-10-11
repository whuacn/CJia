using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.PIVAS.Models
{
    [TestClass]
    public class PharmSendStatSelectModelTest
    {
        /// <summary>
        /// 定义发药统计Model类
        /// </summary>
        CJia.PIVAS.Models.PharmSendStatSelectModel pharmSendStatSelectModel;
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
            pharmSendStatSelectModel = new CJia.PIVAS.Models.PharmSendStatSelectModel();
        }
        /// <summary>
        /// 结束测试
        /// </summary>
        [TestCleanup()]
        public void EndTest()
        {
            //serverApp.Stop();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
