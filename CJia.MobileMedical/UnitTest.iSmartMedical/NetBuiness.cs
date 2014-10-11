using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.iSmartMedical
{
    [TestClass]
    public class NetBuiness
    {
        [TestMethod]
        public void 测试监听()
        {
            //CJia.Net.Data.DBConfig.Load();
            ////启动监听
            //string ListenID = CJia.Net.Data.DefaultOracle.StartListen("SELECT * FROM CJ_SYNC_DATA");
            ////停止监听
            //CJia.Net.Data.DefaultOracle.StopListen(ListenID);
        }

        [TestMethod]
        public void 测试中间库用户同步_FromHIS()
        {
            //CJia.Net.Data.DBConfig.Load();
            //CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new CJia.Net.Business.MobileMedical.SyncHis2Mid();
            //string Msg = sync.InitMidUserFromHiS();
            //sync.Dispose();
            //Assert.AreEqual(1, 0, Msg);
        }
        [TestMethod]
        public void 测试中间库病人同步_FromHIS()
        {
            //CJia.Net.Data.DBConfig.Load();
            //CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new CJia.Net.Business.MobileMedical.SyncHis2Mid();
            //string Msg = sync.InitMidPatientFromHiS();
            //sync.Dispose();
            //Assert.AreEqual(1, 0, Msg);
        }
        [TestMethod]
        public void 测试中间库病人医嘱同步_FromHIS()
        {
            //CJia.Net.Data.DBConfig.Load();
            //CJia.Net.Business.MobileMedical.SyncHis2Mid sync = new CJia.Net.Business.MobileMedical.SyncHis2Mid();
            //string Msg = sync.InitMidPatientAdviceFromHiS();
            //sync.Dispose();
            //Assert.AreEqual(1, 0, Msg);
        }
    }
}
