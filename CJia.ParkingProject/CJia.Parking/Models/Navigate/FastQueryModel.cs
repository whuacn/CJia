using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models.Navigate
{
    public class FastQueryModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="fast1"></param>
        /// <param name="fast2"></param>
        /// <param name="fast3"></param>
        /// <param name="fast4"></param>
        /// <param name="fast5"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable FastQuery(string fast1,string fast2,string fast3,string fast4,string fast5,int pageIndex)
        {
            string par1=fast1+fast2+fast3+fast4+fast5;
            string par2=par1;
            string par3="%"+fast1+fast2+fast3+fast4+fast5+"%";
            string par4=par3;
            string par5="%" + fast1 + "%" + fast2 + "%" + fast3 + "%" + fast4 + "%" + fast5 + "%";
            string par6=par5;
            string par7 = "%" + fast1 + "%";
            string par8 = "%" + fast2 + "%";
            string par9 = "%" + fast3 + "%";
            string par10 = "%" + fast4 + "%";
            string par11 = "%" + fast5 + "%";
            string par12 = "%" + fast1 + "%";
            string par13 = "%" + fast2 + "%";
            string par14 = "%" + fast3 + "%";
            string par15 = "%" + fast4 + "%";
            string par16 = "%" + fast5 + "%";
            int par17=pageIndex * 6 - 5;
            int par18=pageIndex * 6 + 1;
            object[] ob = new object[] { par1, par2, par3, par4, par5, par6, par7, par8, par9, par10, par11, par12, par13, par14, par15, par16, par17, par18 };
            return CJia.DefaultPostgre.Query(SqlTools.SqlFastQuery, ob);
        }
    }
}
