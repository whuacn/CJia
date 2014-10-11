using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HIS.Clinic.Register.Models
{
    public static class SqlModel
    {
        public static string GetCartType
        {
            get
            {
                return @"select code_name TEXT, code VALUE from gm_code where status = '1' and code_type = 'PATIENT_CARD_TYPE' and (filter = :1 or filter like :1 or filter like :2)";
            }
        }

    }
}
