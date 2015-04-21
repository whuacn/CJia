using CJia.PIVAS.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Presenters
{
    public class PharmEconomizeUIP
    {
        private IPharmEconomizeVw _View;
        public PharmEconomizeUIP(IPharmEconomizeVw view)
        {
            _View = view;
        }

        public void PharmEconomizeQuery()
        {
            string sqlFilterPharm = "";
            string sqlFilterDept = "";
            string sqlFilterPharm1 = "";
            string sqlFilterDept1 = "";
            DataTable dtFilterPharm = _View.FilterPharm;
            string filterPharm = "";
            for (int i = 0; i < dtFilterPharm.Rows.Count; i++)
            {
                filterPharm +="'"+ dtFilterPharm.Rows[i]["PHARM_ID"].ToString()+"',";
            }
            if (filterPharm == "")
            {
                sqlFilterPharm = " AND 1=0 ";
                sqlFilterPharm1 = " AND 1=0 ";
            }
            else
            {
                filterPharm = filterPharm.Substring(0, filterPharm.Length - 1);
                sqlFilterPharm = " AND PHARM_ID IN (" + filterPharm + ") ";
                sqlFilterPharm1 = " AND GPV.PHARM_ID IN (" + filterPharm + ") ";
            }

            string filterDept = _View.FilterDept;
            if (filterDept == "0")
            {
                sqlFilterDept = " AND 1=1 ";
                sqlFilterDept1 = " AND 1=1 ";
            }
            else
            {
                sqlFilterDept = " AND ILLFIELD_ID = '" + filterDept + "'";
                sqlFilterDept1 = " AND spe.economize_illfield  = '" + filterDept + "'";
            }

            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectPharmEconomize, sqlFilterPharm, sqlFilterDept);
            object[] parames = new object[] { _View.BeginDate, _View.EndDate };
            _View.DtWaitingImport = CJia.DefaultOleDb.Query(sql, parames);



            string sql1 = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectAddPharmDetail, sqlFilterPharm1, sqlFilterDept1);
            object[] parames1 = new object[] { _View.BeginDate, _View.EndDate };
            _View.DtImportRecord = CJia.DefaultOleDb.Query(sql1, parames1);
        }

        public void GetDetpData()
        {
            DataTable result = Common.GetIllfield();
            DataTable dt = result.Copy();
            DataRow dr = dt.NewRow();
            dr["OFFICE_NAME"] = "< 全部 >";
            dr["OFFICE_ID"] = 0;
            dt.Rows.InsertAt(dr, 0);
            _View.DtDept = dt;
        }

        public void GetPharmData()
        {
            string illfieldId = _View.FilterDept;
            string str = " where  1 = 0 ";
            if (illfieldId != "0")
            {
                str = " where nhifp.illfield_id = '" + illfieldId + "' ";
            }
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectFilterPharm, str);
            _View.DtPharm = CJia.DefaultOleDb.Query(sql);
        }

        //public DataTable SelectFilterPharm(string illfieldId)
        //{
        //    string str = " where  1 = 0 ";
        //    if (illfieldId != "0")
        //    {
        //        str = " where nhifp.illfield_id = '" + illfieldId + "' ";
        //    }
        //    string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectFilterPharm, str);
        //    DataTable result = CJia.DefaultOleDb.Query(sql);
        //    return result;
        //}

    }
}
