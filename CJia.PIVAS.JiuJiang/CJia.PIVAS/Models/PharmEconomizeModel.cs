using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    public class PharmEconomizeModel : CJia.PIVAS.Tools.Model
    {

        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 获取赛选药品信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectFilterPharm(string illfieldId)
        {
            string str = " where  1 = 0 ";
            if (illfieldId != "0")
            {
                str = " where nhifp.illfield_id = '" + illfieldId + "' ";
            }
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectFilterPharm, str);
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 查询节约用药信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="illfield"></param>
        /// <param name="pharmIds"></param>
        /// <returns></returns>
        public DataTable SelectPharmEconomize(DateTime startDate, DateTime endDate, string illfield, List<string> pharmIds)
        {
            StringBuilder pharmIdStr = new StringBuilder("");
            if (pharmIds != null && pharmIds.Count > 0)
            {
                //pharmIdStr.Append(" and  gpv.pharm_id in (");
                pharmIdStr.Append(" and  pharm_id in (");// by dh
                foreach (string pharmId in pharmIds)
                {
                    pharmIdStr.Append("'");
                    pharmIdStr.Append(pharmId);
                    pharmIdStr.Append("',");
                }
                pharmIdStr.Remove(pharmIdStr.Length - 1, 1);
                pharmIdStr.Append(") ");
            }
            //StringBuilder illifeldStr = new StringBuilder("");
            //if(illfield != "0")
            //{
            //    //illifeldStr.Append(" and  spl.illfield_id = ");
            //    illifeldStr.Append(" and  illfield_id = ");
            //    illifeldStr.Append("'");
            //    illifeldStr.Append(illfield);
            //    illifeldStr.Append("' ");
            //}
            //else
            //{
            //    illifeldStr.Append(" and 1 = 1 ");
            //}
            //string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectPharmEconomize, pharmIdStr.ToString(), illifeldStr.ToString());
            //object[] parames = new object[] { startDate, endDate };
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectPharmEconomize2, pharmIdStr.ToString());
            object[] parames = new object[] { illfield, startDate, endDate, illfield, illfield, illfield, illfield };
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            //DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        public DataTable SelectPharmEconomizeInput( DateTime endDate, string illfield, List<string> pharmIds)
        {
            StringBuilder pharmIdStr = new StringBuilder("");
            if (pharmIds != null && pharmIds.Count > 0)
            {
                //pharmIdStr.Append(" and  gpv.pharm_id in (");
                pharmIdStr.Append(" and  pharm_id in (");// by dh
                foreach (string pharmId in pharmIds)
                {
                    pharmIdStr.Append("'");
                    pharmIdStr.Append(pharmId);
                    pharmIdStr.Append("',");
                }
                pharmIdStr.Remove(pharmIdStr.Length - 1, 1);
                pharmIdStr.Append(") ");
            }
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectPharmEconomizeInput, pharmIdStr.ToString());
            object[] parames = new object[] { illfield, illfield, endDate, illfield, illfield, illfield, illfield };
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            //DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 药品节约
        /// </summary>
        /// <param name="pharmData"></param>
        /// <param name="selectIllfield"></param>
        /// <returns></returns>
        public bool AddPharm(DataTable pharmData, string selectIllfield)
        {
            if (pharmData != null && pharmData.Rows != null && pharmData.Rows.Count > 0)
            {
                using (CJia.Transaction tran = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    string pharmEconomizeId = CJia.DefaultOleDb.QueryScalar(tran.ID, CJia.PIVAS.Models.SqlTools.QueryPharmEconomizeId);
                    object[] parames = new object[] { pharmEconomizeId, CJia.PIVAS.User.UserId, CJia.PIVAS.User.UserName, selectIllfield };
                    bool result1 = CJia.DefaultOleDb.Execute(tran.ID, CJia.PIVAS.Models.SqlTools.InsertPharmEconomize, parames) > 0 ? true : false;
                    if (!result1)
                    {
                        return false;
                    }
                    foreach (DataRow row in pharmData.Rows)
                    {
                        parames = new object[] { row["PHARM_ID"].ToString(), row["ADD_PHARM_COUNT"].ToString(), pharmEconomizeId, row["PHARM_UNIT"].ToString() };
                        bool result2 = CJia.DefaultOleDb.Execute(tran.ID, CJia.PIVAS.Models.SqlTools.InsertPharmEconomizeDetail, parames) > 0 ? true : false;
                        if (!result2)
                        {
                            return false;
                        }

                        parames = new object[] { row["PHARM_ID"].ToString(), row["PHARM_UNIT"].ToString(), selectIllfield };
                        bool result3 = CJia.DefaultOleDb.Execute(tran.ID, CJia.PIVAS.Models.SqlTools.UpdatePharmEconomizeLastDate, parames) > 0 ? true : false;
                        if (!result3)
                        {
                            parames = new object[] { row["PHARM_ID"].ToString(), row["PHARM_UNIT"].ToString(), selectIllfield };
                            bool result4 = CJia.DefaultOleDb.Execute(tran.ID, CJia.PIVAS.Models.SqlTools.InsertPharmEconomizeLastDate, parames) > 0 ? true : false;
                            if (!result4)
                            {
                                return false;
                            }
                        }
                    }
                    if (!this.AddPharmHis(tran.ID, pharmEconomizeId))
                    {
                        return false;
                    }
                    tran.Complete();
                }
            }
            return true;
        }

        /// <summary>
        /// 调用插入摆药信息的存储过程
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="pharmEconomizeId"></param>
        /// <returns></returns>
        public bool AddPharmHis(string transID, string pharmEconomizeId)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("I_PHARM_ECONOMIZE_ID", pharmEconomizeId);
            parms.Add("O_FLAG", "");
            CJia.DefaultOleDb.ExecuteProcedure(transID, "ADD_PHARM_ECONOMIZE", ref parms);
            string result = parms["O_FLAG"].ToString();
            if (result == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAddPharm(DateTime startDate, DateTime endDate, string illfield, List<string> pharmIds)
        {
            StringBuilder pharmIdStr = new StringBuilder("");
            if (pharmIds != null && pharmIds.Count > 0)
            {
                pharmIdStr.Append(" and  gpv.pharm_id in (");
                foreach (string pharmId in pharmIds)
                {
                    pharmIdStr.Append("'");
                    pharmIdStr.Append(pharmId);
                    pharmIdStr.Append("',");
                }
                pharmIdStr.Remove(pharmIdStr.Length - 1, 1);
                pharmIdStr.Append(") ");
            }
            //StringBuilder illifeldStr = new StringBuilder("");
            //if (illfield != "0")
            //{
            //    illifeldStr.Append(" and    spe.economize_illfield = ");
            //    illifeldStr.Append("'");
            //    illifeldStr.Append(illfield);
            //    illifeldStr.Append("' ");
            //}
            //string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectAddPharm, pharmIdStr.ToString(), illifeldStr.ToString());
            //object[] parames = new object[] { startDate, endDate };
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectAddPharm2, pharmIdStr.ToString());
            object[] parames = new object[] { startDate, endDate, illfield, illfield };
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            return result;
        }


        public DataTable SelectAddPharmDetail(DateTime startDate, DateTime endDate, string illfield, List<string> pharmIds)
        {
            StringBuilder pharmIdStr = new StringBuilder("");
            if (pharmIds != null && pharmIds.Count > 0)
            {
                pharmIdStr.Append(" and  gpv.pharm_id in (");
                foreach (string pharmId in pharmIds)
                {
                    pharmIdStr.Append("'");
                    pharmIdStr.Append(pharmId);
                    pharmIdStr.Append("',");
                }
                pharmIdStr.Remove(pharmIdStr.Length - 1, 1);
                pharmIdStr.Append(") ");
            }
            //StringBuilder illifeldStr = new StringBuilder("");
            //if(illfield != "0")
            //{
            //    illifeldStr.Append(" and    spe.economize_illfield = ");
            //    illifeldStr.Append("'");
            //    illifeldStr.Append(illfield);
            //    illifeldStr.Append("' ");
            //}
            //else
            //{
            //    illifeldStr.Append(" and 1 = 1 ");
            //}
            //string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectAddPharmDetail, pharmIdStr.ToString(), illifeldStr.ToString());
            //object[] parames = new object[] { startDate, endDate };
            string sql = string.Format(CJia.PIVAS.Models.SqlTools.SqlSelectAddPharmDetail2, pharmIdStr.ToString());
            object[] parames = new object[] { startDate, endDate, illfield, illfield };
            DataTable result = CJia.DefaultOleDb.Query(sql, parames);
            return result;
        }

        public void AddFilterPharm(string illfieldId, string pharmId)
        {
            object[] parames = new object[] { pharmId, illfieldId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlAddFilterPharm, parames);
        }

        public void DeleteFilterPharm(string illfieldId, string pharmId)
        {
            object[] parames = new object[] { illfieldId, pharmId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.SqlTools.SqlDeleteFilterPharm, parames);
        }
    }
}
