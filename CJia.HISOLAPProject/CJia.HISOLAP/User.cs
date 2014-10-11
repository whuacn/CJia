using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP
{
    public class User
    {
        private static string userID;
        public static string UserID
        {
            get
            {
                return "1000000001";
            }
            set
            {
                userID = value;
            }
        }

        private static string userName;
        public static string UserName
        {
            get
            {
                return "管理员";
            }
            set
            {
                userName = value;
            }
        }
    }
}
