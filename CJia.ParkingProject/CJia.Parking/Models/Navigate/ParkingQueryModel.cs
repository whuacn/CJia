using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models.Navigate
{
    public class ParkingQueryModel : CJia.Parking.Tools.Model
    {
        public DataTable ParkQuery(string park1, string park2, string park3, string park4, int pageIndex)
        {
            object[] ob = new object[] { "%" + park1 + "%" + park2 + "%" + park3 + "%" + park4 + "%", pageIndex * 6 - 5, pageIndex * 6 + 1 };
            return CJia.DefaultPostgre.Query(SqlTools.SqlParkQuery, ob);
        }

        /// <summary>
        /// 图片插入数据库（初始数据）
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="pariInfoId"></param>
        /// <param name="bt"></param>
        /// <returns></returns>
        public int insertPic(string plateNo,int pariInfoId,byte[] bt)
        {
            string sql = "insert into pt_collect_picture(plate_no,park_info_id,in_park_pic,create_date) VALUES (:1,:2,:3,now())";
            object[] ob = new object[] { plateNo, pariInfoId, bt };
            return  CJia.DefaultPostgre.Execute(sql, ob);
        }
    }
}
