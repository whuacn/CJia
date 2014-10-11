using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class DoctorPatients : DataObject
    {
        public DoctorPatients() 
        {
            this.InitFields("DPID", "DoctorID", "InhosID", "DPType", "CreateDate");
        }

        [PrimaryKey]
        public string DPID { get { return Get(); } set { Set(value); } }
        public string DoctorID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string DPType { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
    }
}
