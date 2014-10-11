using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.HIS.Clinic.Register.Models
{
    public class RegisterModel : CJia.HIS.Model
    {
        /// <summary>
        /// ͨ��ƴ���뷵�ط���ģ����ѯ�Ĳ��˿�����datatable
        /// </summary>
        /// <param name="filter">ƴ����</param>
        /// <returns>���˿�����</returns>
        public DataTable GetCartType(string filter)
        {
            filter = filter.ToUpper();
            string par1 = filter;
            string par2 = "'%" + filter + "'%";
            string par3 = "'%";
            foreach(char ch in filter)
            {
                par3 += ch.ToString() + "%";
            }
            par3 += "'";
            object[] parameters = new object[] { par1,par2,par3 };
            DataTable result = CJia.DefaultData.Query(SqlModel.GetCartType, parameters);
            return result;
        }
    }
}

