using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 查询瓶贴Model层
    /// </summary>
    public class QueryLabelModel : CJia.PIVAS.Tools.Model
    {

        /// <summary>
        /// 获取某天的摆药单汇总
        /// </summary>
        /// <param name="dayDate">每天时间</param>
        /// <returns>摆药单汇总</returns>
        public DataTable QueryArrangeCollect(DateTime dayDate)
        {
            object[] paramers = new object[] { dayDate };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryArrangeCollect, paramers);
            return result;
        }

        /// <summary>
        /// 获取该这些摆药单下的所有瓶贴
        /// </summary>
        /// <param name="ArrangeIds"></param>
        /// <returns></returns>
        public DataTable QuseryIffieldBed(List<object> ArrangeIds)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = new StringBuilder("1 = 1");
            StringBuilder bacths = new StringBuilder("1 = 1");
            StringBuilder bens = new StringBuilder("1 = 1");
            StringBuilder orderBy = new StringBuilder("");

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return CJia.DefaultOleDb.Query(sql);
        }

        /// <summary>
        /// 根据摆药单获取摆药单下的瓶贴详情
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴详情</returns>
        public DataTable QueryLabelDetailByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 根据摆药单获取摆药单下的瓶贴详情
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴详情</returns>
        public DataTable QueryLabelDetailInfoByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql = this.CreateQueryLabelDetailInfoSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 查询所有病房所有批次的瓶贴汇总信息
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴汇总信息</returns>
        public DataTable QueryAllIllfieldBacthLabelCollectByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql1 = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            string sql2 = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllIllfieldBacthLabelCollect, sql1);
            DataTable result = CJia.DefaultOleDb.Query(sql2);
            return result;
        }

        /// <summary>
        /// 查询药品汇总信息
        /// </summary>
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>药品汇总信息</returns>
        public DataTable QueryPharmCollect(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql1 = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            string sql2 = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryPharmCollect, sql1);
            DataTable result = CJia.DefaultOleDb.Query(sql2);
            return result;
        }

        /// <summary>
        /// 根据摆药单获取白药单下的瓶贴汇总信息
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <returns>瓶贴汇总信息</returns>
        public DataTable QueryLabelCollectByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelCollectByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString());
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 查询所有的药品类型
        /// </summary>
        /// <returns>药品类型</returns>
        public DataTable QueryAllPharmType()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllPharmType);
            return result;
        }

        /// <summary>
        /// 查询所有的批次
        /// </summary>
        /// <returns>批次</returns>
        public DataTable QueryAllBacth()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllBacth);
            return result;
        }

        #region 补助方法

        /// <summary>
        /// 生成过滤用sql语句
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>sql语句</returns>
        private string CreateQueryLabelDetailSql(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);
            StringBuilder orderBy = this.GetOrderByStr(OrderBy);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return sql;
        }

        /// <summary>
        /// 生成过滤用sql语句
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>sql语句</returns>
        private string CreateQueryLabelDetailInfoSql(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);
            StringBuilder orderBy = this.GetOrderByStr(OrderBy);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailInfoByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return sql;
        }

        /// <summary>
        /// 根据摆药单id返回摆药单过滤条件sql语句
        /// </summary>
        /// <param name="ArrangeIds"></param>
        /// <returns></returns>
        public StringBuilder GetArrangeIdsStr(List<object> ArrangeIds)
        {
            StringBuilder arrangeIds = new StringBuilder(" spa.arrange_id in (");
            if(ArrangeIds != null && ArrangeIds.Count > 0)
            {
                foreach(string id in ArrangeIds.ToArray())
                {
                    arrangeIds.Append(id.ToString() + ",");
                }
                arrangeIds.Remove(arrangeIds.Length - 1, 1);
                arrangeIds.Append(") ");
            }
            else
            {
                arrangeIds = new StringBuilder(" 1 = 0 ");
            }
            return arrangeIds;
        }

        /// <summary>
        /// 根据药品类型返回药品类型过滤条件sql语句
        /// </summary>
        /// <param name="PharmTypes"></param>
        /// <returns></returns>
        public StringBuilder GetPharmTypesStr(List<object> PharmTypes)
        {
            StringBuilder pharmTypes = new StringBuilder(" spl.pivas_pharm_type  in (");
            if(PharmTypes != null && PharmTypes.Count > 0)
            {
                foreach(string id in PharmTypes)
                {
                    pharmTypes.Append(id + ",");
                }
                pharmTypes.Remove(pharmTypes.Length - 1, 1);
                pharmTypes.Append(") ");
            }
            else
            {
                pharmTypes = new StringBuilder(" 1 = 0 ");
            }
            return pharmTypes;
        }

        /// <summary>
        /// 根据批次返回批次过滤条件sql语句
        /// </summary>
        /// <param name="Bacths"></param>
        /// <returns></returns>
        public StringBuilder GetBacthsStr(List<object> Bacths)
        {
            StringBuilder bacths = new StringBuilder(" spl.batch_id  in (");
            if(Bacths != null && Bacths.Count > 0)
            {
                foreach(string id in Bacths)
                {
                    bacths.Append(id + ",");
                }
                bacths.Remove(bacths.Length - 1, 1);
                bacths.Append(") ");
            }
            else
            {
                bacths = new StringBuilder(" 1 = 0 ");
            }
            return bacths;
        }

        /// <summary>
        /// 根据病床返回病床过滤条件sql语句
        /// </summary>
        /// <param name="Bens"></param>
        /// <returns></returns>
        public StringBuilder GetBensStr(List<object> Bens)
        {
            StringBuilder bens = new StringBuilder(" (spl.illfield_id,spl.bed_id)  in (");
            if(Bens != null && Bens.Count > 0)
            {
                foreach(string id in Bens)
                {
                    bens.Append("(" + id + "),");
                }
                bens.Remove(bens.Length - 1, 1);
                bens.Append(") ");
            }
            else
            {
                bens = new StringBuilder(" 1 = 0 ");
            }
            return bens;
        }

        /// <summary>
        /// 根据排序方式返回排序方式sql语句
        /// </summary>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        public StringBuilder GetOrderByStr(List<object> OrderBy)
        {
            StringBuilder orderBy = new StringBuilder(" order by  ");
            if(OrderBy != null && OrderBy.Count > 0)
            {
                foreach(string id in OrderBy)
                {
                    orderBy.Append(id + ",");
                }
                orderBy.Remove(orderBy.Length - 1, 1);
            }
            else
            {
                orderBy = new StringBuilder("");
            }
            return orderBy;
        }


        /// <summary>
        /// 把瓶贴条形码信息插入条形码表中 并返回条形码id
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="labelPageNo"></param>
        /// <param name="labelAllPageNo"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public object GetLabelBarcode(object labelID,object labelPageNo,object labelAllPageNo,long userid)
        {
            string BarcodeSeq = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarcodeSeq);
            object[] paramers = new object[] { BarcodeSeq, labelPageNo, labelAllPageNo, userid, labelID };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabelBarcode, paramers);
            object[] paramers1 = new object[] { BarcodeSeq};
            DataTable result =  CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarCode, paramers1);
            return result;
        }

        /// <summary>
        /// 修改瓶贴打印状态
        /// </summary>
        public void UpdateLabelPrintStatus(object labelId)
        {
            object[] paramers = new object[] { labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateLabelPrintStatus, paramers);
        }

        #endregion

    }
}