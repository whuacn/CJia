using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJia.Net.Business;
using CJia.Net.Service;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using CJia.CheckRegOrder.App.UI;

namespace UnitTest.CheckRegOrder
{
    [TestClass]
    public class RegisteViewTest
    {
        CJia.Net.IServerApplication serverApp;
        CJia.Net.Business.DataAdapter dataAdapter;
        string ServerIP = "192.168.1.204";//"127.0.0.1";
        int Port = 10929;
        /// <summary>
        /// 初始化测试参数
        /// </summary>
        [TestInitialize()]
        public void InitTest()
        {
            CJia.Net.CJiaEndPoint netEP = new CJia.Net.CJiaEndPoint(Port);
            serverApp = CJia.Net.CJiaServerBuilder.CreateServerApplication(netEP);
            dataAdapter = new CJia.Net.Business.DataAdapter();
            //dataAdapter.LoadDatabaseConfig();
            CJia.Net.Data.DBConfig.Load();
            serverApp.AddService<CJia.Net.Service.IDataAdapter, CJia.Net.Business.DataAdapter>(dataAdapter);
            serverApp.Start();

            CJia.ClientConfig.ServerPort = Port;
            CJia.ClientConfig.ServerIP = ServerIP;
        }
        /// <summary>
        /// 结束测试
        /// </summary>
        [TestCleanup()]
        public void EndTest()
        {
            serverApp.Stop();
        }
        /// <summary>
        /// 测试根据病人发票HIS查询
        /// </summary>
        [TestMethod]
        public void DoSelectHISByPatientNOEvent_检查是否根据参数有返回结果_有数据()
        {
            string patientNO = "1004";
            RegisteView regView = new RegisteView();
            regView.PatientNO = patientNO;
            regView.DoSelectHISByPatientNOEvent();
            DataTable result = regView.PatientData;
            Assert.IsNotNull(result, "未查询出数据");
        }
        /// <summary>
        /// 测试根据发票编号HIS查询
        /// </summary>
        [TestMethod]
        public void DoSelectHISByInvoiceNOEvent_检查是否根据参数返回结果_有数据()
        {
            string invoiceNO = "16";
            RegisteView regView = new RegisteView();
            regView.InvoiceNO = invoiceNO;
            regView.DoSelectHISByInvoiceNOEvent();
            DataTable result = regView.PatientData;
            Assert.IsNotNull(result, "未查询出数据");
        }
        /// <summary>
        /// 测试根据发票号和病人卡号HIS查询
        /// </summary>
        [TestMethod]
        public void DoSelectHISEvent_检查是否根据参数返回结果_无数据()
        {
            string patientNO = "1006";
            string invoiceNO = "23";
            RegisteView regView = new RegisteView();
            regView.PatientNO = patientNO;
            regView.InvoiceNO = invoiceNO;
            regView.DoSelectHISEvent();
            DataTable result = regView.PatientData;
            Assert.IsNotNull(result,"未查询出数据");
        }
       
    }
}
