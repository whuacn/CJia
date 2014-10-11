using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class CheckApply : DataObject
    {
        public CheckApply()
        {
            this.InitFields("InhosID", "IllcaseNo", "PatientName", "PatientClass", "ApplyNo", "TechSystem", "ReportType",
                "ReportName", "ReportDate", "SubmissionDate", "TechNo", "TechMothod", "isNew");
        }

        [PrimaryKey]
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string IllcaseNo { get { return Get(); } set { Set(value); } }
        public string PatientName { get { return Get(); } set { Set(value); } }
        public string PatientClass { get { return Get(); } set { Set(value); } }
        public string ApplyNo { get { return Get(); } set { Set(value); } }
        public string TechSystem { get { return Get(); } set { Set(value); } }
        public string ReportType { get { return Get(); } set { Set(value); } }
        public string ReportName { get { return Get(); } set { Set(value); } }
        public string ReportDate { get { return Get(); } set { Set(value); } }
        public string SubmissionDate { get { return Get(); } set { Set(value); } }
        public string TechNo { get { return Get(); } set { Set(value); } }
        public string TechMothod { get { return Get(); } set { Set(value); } }
        public string isNew { get { return Get(); } set { Set(value); } }
    }
}
