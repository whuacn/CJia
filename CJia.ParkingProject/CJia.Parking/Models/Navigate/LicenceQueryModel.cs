using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models.Navigate
{
    public class LicenceQueryModel : CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 根据车牌查询车辆信息
        /// </summary>
        /// <param name="lice1"></param>
        /// <param name="lice2"></param>
        /// <param name="lice3"></param>
        /// <param name="lice4"></param>
        /// <param name="lice5"></param>
        /// <param name="pageIndex">查询第几页数据</param>
        /// <returns></returns>
        public DataTable LicenceQuery(string lice1,string lice2,string lice3,string lice4,string lice5,int pageIndex)
        {
            object[] ob = new object[] { "%" + lice1 + "%" + lice2 + "%" + lice3 + "%" + lice4 + "%" + lice5 + "%",pageIndex*6-5,pageIndex*6+1 };
            return CJia.DefaultPostgre.Query(SqlTools.SqlLicenceQuery, ob);
        }
    }
}
