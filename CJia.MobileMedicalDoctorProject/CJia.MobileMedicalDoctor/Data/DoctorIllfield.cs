using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class DoctorIllfield : DataObject
    {
        public DoctorIllfield() 
        {
            this.InitFields("DIID", "DoctorID", "IllfeildID", "IllfieldName");
        }

        [PrimaryKey]
        public string DIID { get { return Get(); } set { Set(value); } }
        public string DoctorID { get { return Get(); } set { Set(value); } }
        public string IllfeildID { get { return Get(); } set { Set(value); } }
        public string IllfieldName { get { return Get(); } set { Set(value); } }
    }
}
