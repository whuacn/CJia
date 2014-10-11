using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTest.PIVAS.Models
{
    [TestClass]
    public class PharmSendSelectModelTest
    {
        /// <summary>
        /// 定义冲药查询Model类
        /// </summary>
        CJia.PIVAS.Models.PharmSendSelectModel pharmSendSelectModel;
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
            pharmSendSelectModel = new CJia.PIVAS.Models.PharmSendSelectModel();
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
        /// 测试当天有无冲药单号
        /// </summary>
        [TestMethod]
        public void GetPharmSendNOByTime_检查跟据时间查询出冲药单号_一致()
        {
            DataTable data = pharmSendSelectModel.GetPharmSendNOByTime(DateTime.Now);
            Assert.IsNull(data, "有数据");
        }
        /// <summary>
        /// 测试根据发药单号得到瓶贴明细
        /// </summary>
        [TestMethod]
        public void GetLableDetailByPharmSendNO_检查根据发药单号得到瓶贴明细_一致()
        {
            DataTable data = pharmSendSelectModel.GetLableDetailByPharmSendNO("10002");
            Assert.IsNull(data, "有数据");
        }
        /// <summary>
        /// 测试根据发药单号得到汇总药品统计
        /// </summary>
        [TestMethod]
        public void GetLableStatByPharmSendNO_检查根据发药单号得到汇总药品统计_一致()
        {
            DataTable data = pharmSendSelectModel.GetLableStatByPharmSendNO("10002");
            Assert.IsNull(data, "有数据");
        }
        /// <summary>
        /// 测试根据发药时间查询瓶贴信息及审核人信息
        /// </summary>
        [TestMethod]
        public void GetLabelAndCheckByPharmTime_检查根据发药时间查询瓶贴信息及审核人信息_一致()
        {
            DataTable data = pharmSendSelectModel.GetLabelAndCheckByPharmTime(DateTime.Now);
            Assert.IsNull(data, "有数据");
        }
        /// <summary>
        /// 测试根据发药时间查询汇总药品统计
        /// </summary>
        [TestMethod]
        public void GetLabelCollectByPharmTime_检查根据发药时间查询汇总药品统计_一致()
        {
            DataTable data = pharmSendSelectModel.GetLabelCollectByPharmTime(DateTime.Now);
            Assert.IsNull(data, "有数据");
        }
    }
}
