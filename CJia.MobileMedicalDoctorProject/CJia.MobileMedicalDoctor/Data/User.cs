using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class User : DataObject
    {
        public User() 
        {
            this.InitFields("ID", "Code", "Password", "Name", "DeptID", "DeptName", "Status");
        }

        
        //[CJia.MobileMedicalDoctor.Entity.KyeName("ID")]
        [PrimaryKey]
        public string ID { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("Code")]
        public string Code { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("Password")]
        public string Password { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("Name")]
        public string Name { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("DeptID")]
        public string DeptID { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("DeptName")]
        public string DeptName { get { return Get(); } set { Set(value); } }

        //[CJia.MobileMedicalDoctor.Entity.KyeName("Status")]
        public string Status { get { return Get(); } set { Set(value); } }
    }
}
