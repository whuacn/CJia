using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class DoctorCheckLog : DataObject, INotifyPropertyChanged
    {
        public DoctorCheckLog()
        {
            this.InitFields("DCLID", "DeviceID", "InhosID", "DoctorID", "DoctorName", "LogType", "CheckDate", "CheckTime", "CheckLog", "Photo", "MedicalLog", "LastSaveDate");
        }

        [PrimaryKey]
        public string DCLID { get { return Get(); } set { Set(value); } }
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string DoctorID { get { return Get(); } set { Set(value); } }
        public string DoctorName { get { return Get(); } set { Set(value); } }
        public string LogType { get { return Get(); } set { Set(value); } }
        public string CheckDate { get { return Get(); } set { Set(value); } }
        public string CheckTime { get { return Get(); } set { Set(value); } }
        public string CheckLog { get { return Get(); } set { Set(value); } }
        public byte[] Photo { get { return GetBytes(); } set { Set(value); } }
        public byte[] MedicalLog 
        { 
            get { return GetBytes(); } 
            set { 
                Set(value);
                OnPropertyChanged("MedicalLog");
            } 
        }
        public string LastSaveDate { get { return Get(); } set { Set(value); } }
    }
}
