using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Framework.Data
{
    public class User : DataObject
    {
        public User() { }
        public User(params object[] Values)
            : base(Values)
        {
            this.InitFields("ID", "Code", "Password", "Name", "DeptID", "DeptName");
        }
        public Int64 ID { get { return GetInt("ID"); } set { Set("ID", value); } }
        public string Code { get { return Get("Code").ToString(); } set { Set("Code", value); } }
        public string Password { get { return Get("Password").ToString(); } set { Set("Password", value); } }
        public string Name { get { return Get("Name").ToString(); } set { Set("Name", value); } }
        public Int64 DeptID { get { return GetInt("DeptID"); } set { Set("DeptID", value); } }
        public string DeptName { get { return Get("DeptName").ToString(); } set { Set("DeptName", value); } }
    }
}
