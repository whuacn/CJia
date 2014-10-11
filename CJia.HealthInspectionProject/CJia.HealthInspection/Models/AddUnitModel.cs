using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Models
{
    public class AddUnitModel : Tools.Model
    {
        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetTypeValue(string type)
        {
            object[] sqlParams = new object[] { type };
            DataTable dtResult = CJia.DefaultOleDb.Query(CJia.HealthInspection.Models.SqlTools.SqlQueryType, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                DataRow dr = dtResult.NewRow();
                dr["CODE"] = "";
                dr["NAME"] = "不指定";
                dtResult.Rows.InsertAt(dr, 0);
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 新增单位（相对人）
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool AddUnit(string userID)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(Unit.UnitName);
            sqlParams.Add(Unit.Address);
            sqlParams.Add(Unit.DaiMa);
            sqlParams.Add(Unit.FaRen);
            sqlParams.Add(Unit.FaRenNO);
            sqlParams.Add(Unit.FaRenType);
            sqlParams.Add(Unit.FuZeRen);
            sqlParams.Add(Unit.FuZeRenType);
            sqlParams.Add(Unit.FuZeRenNO);
            sqlParams.Add(userID);
            sqlParams.Add(Unit.XukeZhenhao);
            sqlParams.Add(Unit.UnitType);
            sqlParams.Add(Unit.IsHuYuan);
            sqlParams.Add(Unit.HuTpye);
            sqlParams.Add(Unit.QuXianNO);
            sqlParams.Add(Unit.ZhuCeAddress);
            sqlParams.Add(Unit.JingjiType);
            sqlParams.Add(Unit.LianxiRen);
            sqlParams.Add(Unit.LianxiTelePhone);
            sqlParams.Add(Unit.YouBian);
            sqlParams.Add(Unit.FaZhenName);
            sqlParams.Add(Unit.ShenQingType);
            if (Unit.XuKeData != null)
                sqlParams.Add(Unit.XuKeData);
            else
                sqlParams.Add(DBNull.Value);
            if (Unit.StartData != null)
                sqlParams.Add(Unit.StartData);
            else
                sqlParams.Add(DBNull.Value);
            if (Unit.EndData != null)
                sqlParams.Add(Unit.EndData);
            else
                sqlParams.Add(DBNull.Value);
            sqlParams.Add(Unit.OrganId);
            return CJia.DefaultOleDb.Execute(SqlTools.SqlAddUnit, sqlParams) > 0 ? true : false;
        }
    }
}
