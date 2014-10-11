using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class PadAdvice : DataObject
    {
        public PadAdvice()
        {
            this.InitFields("PAID", "DeviceID", "InhosID", "PatientName", "DoctorID", "DoctorName", "AdviceTypeCode", "AdviceTypeName", "StandingTypeCode", "StandingTypeName", "AdviceID", "HiSAdviceID", "AdviceName", "AdviceShowName", "CommonName", "Spec", "GroupIndex", "Dosage", "DosageUnit", "Amount", "AmountUnit", "UsageID", "UsageName", "FrequenceID", "FrequenceName", "PreStartDate", "PreStopDate", "Notes", "CreateDate", "Status", "SyncStatus", "SyncDate");
        }

        [PrimaryKey]
        public string PAID { get { return Get(); } set { Set(value); } }
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string PatientName { get { return Get(); } set { Set(value); } }
        public string DoctorID { get { return Get(); } set { Set(value); } }
        public string DoctorName { get { return Get(); } set { Set(value); } }
        public string AdviceTypeCode { get { return Get(); } set { Set(value); } }
        public string AdviceTypeName { get { return Get(); } set { Set(value); } }
        public string StandingTypeCode { get { return Get(); } set { Set(value); } }
        public string StandingTypeName { get { return Get(); } set { Set(value); } }
        public string AdviceID { get { return Get(); } set { Set(value); } }
        public string HiSAdviceID { get { return Get(); } set { Set(value); } }
        public string AdviceName { get { return Get(); } set { Set(value); } }
        public string AdviceShowName { get { return Get(); } set { Set(value); } }
        public string CommonName { get { return Get(); } set { Set(value); } }
        public string Spec { get { return Get(); } set { Set(value); } }
        public string GroupIndex { get { return Get(); } set { Set(value); } }
        public string Dosage { get { return Get(); } set { Set(value); } }
        public string DosageUnit { get { return Get(); } set { Set(value); } }
        public string Amount { get { return Get(); } set { Set(value); } }
        public string AmountUnit { get { return Get(); } set { Set(value); } }
        public string UsageID { get { return Get(); } set { Set(value); } }
        public string UsageName { get { return Get(); } set { Set(value); } }
        public string FrequenceID { get { return Get(); } set { Set(value); } }
        public string FrequenceName { get { return Get(); } set { Set(value); } }
        public string PreStartDate { get { return Get(); } set { Set(value); } }
        public string PreStopDate { get { return Get(); } set { Set(value); } }
        public string Notes { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
        public string SyncStatus { get { return Get(); } set { Set(value); } }
        public string SyncDate { get { return Get(); } set { Set(value); } }
    }
}
