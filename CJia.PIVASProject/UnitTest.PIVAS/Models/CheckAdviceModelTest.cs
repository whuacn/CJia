//***************************************************
// 文件名（File Name）:      CheckAdviceModelTest.cs（审方Model层测试类）
//
// 数据表（Tables）:         sr_pivas_set,st_check_detail,st_check
// 视图(Views)               advice_view ,hm_patient_view,patient_history_view 
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UnitTest.PIVAS.Models
{
    /// <summary>
    /// 审方Model层测试类
    /// </summary>
    [TestClass]
    public class CheckAdviceModelTest
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
            checkAdviceModel = new CJia.PIVAS.Models.CheckAdviceModel();
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
        /// 审方Model类
        /// </summary>
        CJia.PIVAS.Models.CheckAdviceModel checkAdviceModel;

        /// <summary>
        /// 测试可进配置中心的病区
        /// </summary>
        [TestMethod]
        public void GetOffice_检查可进配置中心的病区_一致()
        {
            if (CJia.DefaultData.Execute(SqlTools.sqlInsertPIVAS_Set) > 0)
            {
                DataTable data = checkAdviceModel.GetOffice();
                Assert.IsNotNull(data, "未查询到数据");
                CJia.DefaultData.Execute(SqlTools.sqlDeletePIVAS_Set);
            }          
        }

        /// <summary>
        /// 测试可进配置中心的病区
        /// </summary>
        [TestMethod]
        public void GetAdviceData_检查医嘱_一致()
        {
            DateTime beginListDate = CJia.PIVAS.Models.PIVASModel.QuerySysdate();
            DateTime endListDate = CJia.PIVAS.Models.PIVASModel.QuerySysdate();
            DataTable data = checkAdviceModel.GetAdviceData(beginListDate, endListDate, "0", false, true, false, false, true, true, true, true, 1000101);
            Assert.IsNotNull(data, "未查询到数据");
        }

    }
}
