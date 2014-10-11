using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class PatientEmrDoc : DataObject
    {
        public PatientEmrDoc()
        {
            this.InitFields("InhosID", "SectionNo", "DocTypeID", "DocTypeName", "Title", "DocContent", "Creator", "CreateDate", "CreateTime", "Status", "Checker", "CheckDate", "LastSaveDate");
        }

        [PrimaryKey]
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string SectionNo { get { return Get(); } set { Set(value); } }
        public string DocTypeID { get { return Get(); } set { Set(value); } }
        public string DocTypeName { get { return Get(); } set { Set(value); } }
        public string Title { get { return Get(); } set { Set(value); } }
        public string DocContent { get { return Get(); } set { Set(value); } }
        public string Creator { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
        public string CreateTime { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
        public string Checker { get { return Get(); } set { Set(value); } }
        public string CheckDate { get { return Get(); } set { Set(value); } }
        public string LastSaveDate { get { return Get(); } set { Set(value); } }
    }
}
