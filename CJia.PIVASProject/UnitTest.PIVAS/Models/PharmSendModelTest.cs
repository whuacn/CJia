using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTest.PIVAS.Models
{
    [TestClass]
    public class PharmSendModelTest
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
            pharmSendModel = new CJia.PIVAS.Models.PharmSendModel();
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
        /// 冲药Model类
        /// </summary>
        CJia.PIVAS.Models.PharmSendModel pharmSendModel;
        /// <summary>
        /// 测试冲药次数是否一致
        /// </summary>
        [TestMethod]
        public void GetPharmSendTime_检查冲药次数是否一致_一致()
        {
            DataTable data = pharmSendModel.GetPharmSendTime("2");
            int i = data.Rows.Count;
            Assert.AreEqual(2, i, "冲药次数不一致");
        }
        /// <summary>
        /// 测试当天是否有瓶贴
        /// </summary>
        [TestMethod]
        public void GetTodayLable_检查当天是否有瓶贴_一致()
        {
            DataTable data = pharmSendModel.GetTodayLable();
            Assert.IsNull(data, "未查询到数据");
        }
        /// <summary>
        /// 测试当天是否有瓶贴明细
        /// </summary>
        [TestMethod]
        public void GetTodayLableDetail_检查当天是否有瓶贴明细_一致()
        {
            DataTable data = pharmSendModel.GetTodayLableDetail();
            Assert.IsNull(data, "未查询到数据");
        }
        /// <summary>
        /// 测试当天待冲药中有无待审退的瓶贴
        /// </summary>
        [TestMethod]
        public void isExistApply_检查当天是否有审退的瓶贴_一致()
        {
            bool bol = pharmSendModel.isExistApply();
            Assert.IsFalse(bol, "不为false");
        }
        ///// <summary>
        ///// 测试当天配置中心药房库存不足的待冲药是否有数据
        ///// </summary>
        //[TestMethod]
        //public void GetTodayNOPharmStore_检查当天配置中心药房库存不足的待冲药_一致()
        //{
        //    DataTable data = pharmSendModel.GetTodayNOPharmStore();
        //    Assert.IsNotNull(data, "未查询到数据");
        //}
        ///<summary>
        ///测试根据冲药次数修改当天待冲药瓶贴冲药状态
        ///</summary>
        [TestMethod]
        public void ModifyExeStatusByTimeID_检查当天配置中心药房库存不足的待冲药_一致()
        {
            string seq = pharmSendModel.GetPharmSendSeq();
            bool bol = pharmSendModel.ModifyExeStatusByTimeID(seq, 100001, 1000000002," ", 1000000002);
            Assert.IsFalse(bol, "不为False");
        }
    }
}
