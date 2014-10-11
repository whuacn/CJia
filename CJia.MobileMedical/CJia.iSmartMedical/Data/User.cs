using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class User : DataObject
    {
        public User() 
        {
            this.InitFields("ID", "Code", "Password", "Name", "DeptID", "DeptName", "UserType", "Status");
        }

        [PrimaryKey]
        public string ID { get { return Get(); } set { Set(value); } }
        public string Code { get { return Get(); } set { Set(value); } }
        public string Password { get { return Get(); } set { Set(value); } }
        public string Name { get { return Get(); } set { Set(value); } }
        public string DeptID { get { return Get(); } set { Set(value); } }
        public string DeptName { get { return Get(); } set { Set(value); } }
        public string UserType { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
    }
}
