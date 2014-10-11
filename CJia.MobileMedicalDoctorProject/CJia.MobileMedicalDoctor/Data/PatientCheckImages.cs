using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Data
{
    public class PatientCheckImages:DataObject
    {
        public PatientCheckImages()
        {
            this.InitFields("PCID", "InhosID", "PatientName", "BedName", "DoctorID", "DoctorName", "CheckImage", "ThumbImage", "CheckDate", "LastSaveDate");
        }

        [PrimaryKey]
        public string PCID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string PatientName { get { return Get(); } set { Set(value); } }
        public string BedName { get { return Get(); } set { Set(value); } }
        public string DoctorID { get { return Get(); } set { Set(value); } }
        public string DoctorName { get { return Get(); } set { Set(value); } }
        public byte[] CheckImage { get { return GetBytes(); } set { Set(value); } }
        public byte[] ThumbImage { get { return GetBytes(); } set { Set(value); } }
        public string CheckDate { get { return Get(); } set { Set(value); } }
        public string LastSaveDate { get { return Get(); } set { Set(value); } }
    }
}
