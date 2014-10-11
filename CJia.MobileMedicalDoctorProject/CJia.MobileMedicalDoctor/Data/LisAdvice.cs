using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class LisAdvice : DataObject
    {
        public LisAdvice()
        {
            this.InitFields("IllcaseNo", "AdviceID", "AdviceName", "Diagnose", "Doctor", "ApplyDate", "Office", "Reporter", "ReportDate", "SampleNo","TestDate");
        }

        [PrimaryKey]
        public string IllcaseNo { get { return Get(); } set { Set(value); } }
        public string AdviceID { get { return Get(); } set { Set(value); } }
        public string AdviceName { get { return Get(); } set { Set(value); } }
        public string Diagnose { get { return Get(); } set { Set(value); } }
        public string Doctor { get { return Get(); } set { Set(value); } }
        public string ApplyDate { get { return Get(); } set { Set(value); } }
        public string Office { get { return Get(); } set { Set(value); } }
        public string Reporter { get { return Get(); } set { Set(value); } }
        public string ReportDate { get { return Get(); } set { Set(value); } }
        public string SampleNo { get { return Get(); } set { Set(value); } }
        public string TestDate { get { return Get(); } set { Set(value); } }
    }
}
