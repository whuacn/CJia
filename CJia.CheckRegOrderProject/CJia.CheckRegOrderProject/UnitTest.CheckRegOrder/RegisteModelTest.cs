using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJia.Net.Business;
using CJia.Net.Service;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using CJia.CheckRegOrder.Models;
using CJia.CheckRegOrder;

namespace UnitTest.CheckRegOrder
{
    [TestClass]
    public class RegisteModelTest
    {
        CJia.Net.IServerApplication serverApp;
        CJia.Net.Business.DataAdapter dataAdapter;
        string ServerIP = "127.0.0.1";
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
        /// 测试根据病人卡号查询HIS
        /// </summary>
        [TestMethod]
        public void GetHISPatientByNO_根据参数查询返回结果_有数据()
        {
            string patientNO = "1004";
            RegisteModel regModel = new RegisteModel();
            DataTable result = regModel.GetHISPatientByNO(patientNO);
            Assert.IsNotNull(result, "未查询出数据");
        }
        /// <summary>
        /// 测试根据发票编号查询HIS
        /// </summary>
        [TestMethod]
        public void GetHISPatientByInvoiceNO_根据参数查询返回结果_有数据()
        {
            string invoiceNO = "12";
            RegisteModel regModel = new RegisteModel();
            DataTable result = regModel.GetHISPatientByInvoiceNO(invoiceNO);
            Assert.IsNotNull(result, "未查出出数据");
        }
        /// <summary>
        /// 测试向本系统插入一条门诊病人数据
        /// </summary>
        [TestMethod]
        public void AddClinicPatient_本系统插入一条门诊病人数据_返回bool()
        {
            string patientNO = "1004";
            RegisteModel regModel = new RegisteModel();
            DataTable data = regModel.GetHISPatientByNO(patientNO);
            int registeBy = 1002;
            string admissionsType = "门诊病人";
            bool bol = regModel.AddClinicPatient(data, registeBy, admissionsType);
            Assert.IsTrue(bol, "插入失败");
        }
        /// <summary>
        /// 测试向本系统插入一条检查病人数据
        /// </summary>
        [TestMethod]
        public void AddCheckPatient_本系统插入一条检查病人数据_返回bool()
        {
            string patientNO = "1004";
            RegisteModel regModel = new RegisteModel();
            DataTable data = regModel.GetHISPatientByNO(patientNO);
            int registeBy = 1002;
            string admissionsType = "检查病人";
            PatientHistory ph = new PatientHistory();
            ph.TreatDate = DateTime.Now;
            bool bol = regModel.AddCheckPatient(data, registeBy, admissionsType, ph);
            Assert.IsTrue(bol, "插入失败");
        }
        /// <summary>
        /// 测试根据病人卡号查询待排队与排队队列中数据
        /// </summary>
        [TestMethod]
        public void GetLinePatientByNO_根据参数检查待排队与排队队列中是否有数据_有数据()
        {
            string patientNO = "1004";
            RegisteModel regModel = new RegisteModel();
            DataTable result = regModel.GetLinePatientByNO(patientNO);
            Assert.IsNotNull(result, "未查询出数据");
        }
        /// <summary>
        /// 测试根据发票编号查询登记未排队队列中数据
        /// </summary>
        [TestMethod]
        public void GetNotLinePatientByPatientNO_根据参数检查登记未排队队列中是否有数据_有数据()
        {
            string patientNO = "1006";
            RegisteModel regModel = new RegisteModel();
            DataTable result = regModel.GetNotLinePatientByPatientNO(patientNO);
            Assert.IsNotNull(result, "未查询出数据");
        }
        /// <summary>
        /// 测试根据病人卡号修改病人状态
        /// </summary>
        [TestMethod]
        public void ModifyStateByPatientNO_根据参数修改病人状态_返回bool()
        {
            string patientNO = "1004";
            RegisteModel regModel = new RegisteModel();
            bool bol = regModel.ModifyStateByPatientNO(patientNO);
            Assert.IsTrue(bol, "修改失败");
        }
        /// <summary>
        /// 测试根据字典类型获得字典值
        /// </summary>
        [TestMethod]
        public void GetCodeValueByType_根据字典类型查询字典值_有数据()
        {
            string codeType = "CIN";
            RegisteModel regModel = new RegisteModel();
            DataTable result = regModel.GetCodeValueByType(codeType);
            Assert.IsNotNull(result, "未查询出数据");
        }
    }
}
