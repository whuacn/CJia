using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class LisResult : DataObject
    {
        public LisResult()
        {
            this.InitFields("SampleNo", "TestDate", "PatientID", "IllcaseNo", "AdviceInfo", "ApplyDate", "ReportDate", "ItemCode", "ItemName", "TestResult", "TestUnit", "NormalRange", "TestNote", "CRISISValue");
        }

        [PrimaryKey]
        public string SampleNo { get { return Get(); } set { Set(value); } }
        public string TestDate { get { return Get(); } set { Set(value); } }
        public string PatientID { get { return Get(); } set { Set(value); } }
        public string IllcaseNo { get { return Get(); } set { Set(value); } }
        public string AdviceInfo { get { return Get(); } set { Set(value); } }
        public string ApplyDate { get { return Get(); } set { Set(value); } }
        public string ReportDate { get { return Get(); } set { Set(value); } }
        public string ItemCode { get { return Get(); } set { Set(value); } }
        public string ItemName { get { return Get(); } set { Set(value); } }
        public string TestResult { get { return Get(); } set { Set(value); } }
        public string TestUnit { get { return Get(); } set { Set(value); } }
        public string NormalRange { get { return Get(); } set { Set(value); } }
        public string TestNote { get { return Get(); } set { Set(value); } }
        public string CRISISValue { get { return Get(); } set { Set(value); } }
    }
}
