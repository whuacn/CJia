using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Data
{
    public class PatientAdvices : DataObject
    {
        public PatientAdvices()
        {
            this.InitFields("PAID", "InhosID", "AdviceID", "PatientIllfield", "PatientOffice", "StandingFlag", "AdviceType", "AdviceName", "CommonName", "AdviceShowName", "ViewGroup", "GroupIndex", "Spec", "Dosage", "UsageName", "Frequence", "Memo", "ListDoctor", "ListDoctorOffice", "ListDate", "PreStartDate", "PreStopDate", "StopDoctor", "StopDate", "AuditNurse", "AuditDate", "StopAuditNurse", "StopAuditDate", "AdviceStatus");
        }
        [PrimaryKey]
        public string PAID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string AdviceID { get { return Get(); } set { Set(value); } }
        public string PatientIllfield { get { return Get(); } set { Set(value); } }
        public string PatientOffice { get { return Get(); } set { Set(value); } }
        public string StandingFlag { get { return Get(); } set { Set(value); } }
        public string AdviceType { get { return Get(); } set { Set(value); } }
        public string AdviceName { get { return Get(); } set { Set(value); } }
        public string CommonName { get { return Get(); } set { Set(value); } }
        public string AdviceShowName { get { return Get(); } set { Set(value); } }
        public string ViewGroup { get { return Get(); } set { Set(value); } }
        public string GroupIndex { get { return Get(); } set { Set(value); } }
        public string Spec { get { return Get(); } set { Set(value); } }
        public string Dosage { get { return Get(); } set { Set(value); } }
        public string UsageName { get { return Get(); } set { Set(value); } }
        public string Frequence { get { return Get(); } set { Set(value); } }
        public string Memo { get { return Get(); } set { Set(value); } }
        public string ListDoctor { get { return Get(); } set { Set(value); } }
        public string ListDoctorOffice { get { return Get(); } set { Set(value); } }
        public string ListDate { get { return Get(); } set { Set(value); } }
        public string PreStartDate { get { return Get(); } set { Set(value); } }
        public string PreStopDate { get { return Get(); } set { Set(value); } }
        public string StopDoctor { get { return Get(); } set { Set(value); } }
        public string StopDate { get { return Get(); } set { Set(value); } }
        public string AuditNurse { get { return Get(); } set { Set(value); } }
        public string AuditDate { get { return Get(); } set { Set(value); } }
        public string StopAuditNurse { get { return Get(); } set { Set(value); } }
        public string StopAuditDate { get { return Get(); } set { Set(value); } }
        public string AdviceStatus { get { return Get(); } set { Set(value); } }
    }
}
