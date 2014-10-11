using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class Patient : DataObject
    {
        public Patient()
        {
            this.InitFields("InhosID", "PatientID", "PatientCode", "PatientName", "PatientType", "IDCardNo", "Gender", "Age", "IllcaseNo", "InhosDate", "InhosType", "InhosStatus", "IllfieldID", "IllfieldName", "OfficeID", "OfficeName", "RoomID", "RoomName",
                "BedID", "BedName", "BedDoctor", "BedDoctorName", "GradeName", "FoodName", "IllnessState", "AllergicHistory", "DiagnoseName", "LeaveHosDate", "LeaveHosState", "EMRID", "Prepay", "FeeSum", "IsOweFee");
        }

        [PrimaryKey]
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string PatientID { get { return Get(); } set { Set(value); } }
        public string PatientCode { get { return Get(); } set { Set(value); } }
        public string PatientName { get { return Get(); } set { Set(value); } }
        public string PatientType { get { return Get(); } set { Set(value); } }
        public string IDCardNo { get { return Get(); } set { Set(value); } }
        public string Gender { get { return Get(); } set { Set(value); } }
        public string Age { get { return Get(); } set { Set(value); } }
        public string IllcaseNo { get { return Get(); } set { Set(value); } }
        public string InhosDate { get { return Get(); } set { Set(value); } }
        public string InhosType { get { return Get(); } set { Set(value); } }
        public string InhosStatus { get { return Get(); } set { Set(value); } }
        public string IllfieldID { get { return Get(); } set { Set(value); } }
        public string IllfieldName { get { return Get(); } set { Set(value); } }
        public string OfficeID { get { return Get(); } set { Set(value); } }
        public string OfficeName { get { return Get(); } set { Set(value); } }
        public string RoomID { get { return Get(); } set { Set(value); } }
        public string RoomName { get { return Get(); } set { Set(value); } }
        public string BedID { get { return Get(); } set { Set(value); } }
        public string BedName { get { return Get(); } set { Set(value); } }
        public string BedDoctor { get { return Get(); } set { Set(value); } }
        public string BedDoctorName { get { return Get(); } set { Set(value); } }
        public string GradeName { get { return Get(); } set { Set(value); } }
        public string FoodName { get { return Get(); } set { Set(value); } }
        public string IllnessState { get { return Get(); } set { Set(value); } }
        public string AllergicHistory { get { return Get(); } set { Set(value); } }
        public string DiagnoseName { get { return Get(); } set { Set(value); } }
        public string LeaveHosDate { get { return Get(); } set { Set(value); } }
        public string LeaveHosState { get { return Get(); } set { Set(value); } }
        public string EMRID { get { return Get(); } set { Set(value); } }
        public string Prepay { get { return Get(); } set { Set(value); } }
        public string FeeSum { get { return Get(); } set { Set(value); } }
        public string IsOweFee { get { return Get(); } set { Set(value); } }
    }
}
