using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Models
{
    public class TemporaryFeeSetModel :CJia.Parking.Tools.Model
    {
        /// <summary>
        /// 查询停车收费表数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTemporaryCharge()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlQueryTemporaryCharge);
        }

        /// <summary>
        ///  插入临时停车收费表数据
        /// </summary>
        /// <param name="freeHour"></param>
        /// <param name="hourSet"></param>
        /// <param name="hourSetFee"></param>
        /// <param name="upperHour"></param>
        /// <param name="upperHourSet"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool InsertTemporaryCharge(string freeHour,string hourSet,string hourSetFee,string upperHour,string upperHourSet,long userId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(freeHour);
            sqlParams.Add(hourSet);
            sqlParams.Add(hourSetFee);
            sqlParams.Add(upperHour);
            sqlParams.Add(upperHourSet);
            sqlParams.Add(userId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertTemporaryCharge, sqlParams) > 0 ? true : false ;
        }

        /// <summary>
        /// 修改临时停车收费表数据
        /// </summary>
        /// <param name="freeHour"></param>
        /// <param name="hourSet"></param>
        /// <param name="hourSetFee"></param>
        /// <param name="upperHour"></param>
        /// <param name="upperHourSet"></param>
        /// <returns></returns>
        public bool UpdateTemporaryCharge(string freeHour, string hourSet, string hourSetFee, string upperHour, string upperHourSet)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(freeHour);
            sqlParams.Add(hourSet);
            sqlParams.Add(hourSetFee);
            sqlParams.Add(upperHour);
            sqlParams.Add(upperHourSet);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateTemporaryCharge, sqlParams) > 0 ? true : false;
        }
    }
}
