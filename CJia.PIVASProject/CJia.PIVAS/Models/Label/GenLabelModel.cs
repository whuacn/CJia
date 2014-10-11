using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 生成瓶贴Model
    /// </summary>
    public class GenLabelModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询出摆药次数
        /// </summary>
        /// <returns>摆药数据</returns>
        public DataTable QueryListCount()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryListCount);
            return result;
        }

        /// <summary>
        /// 查询出该摆药的摆药表信息
        /// </summary>
        /// <param name="timeId">SM_TIME_SET  id  返回该次摆药的信息</param>
        /// <returns>该次摆药的信息</returns>
        public DataTable QueryListTime(string timeId)
        {
            object[] paramars = new object[]{timeId};
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryListTime, paramars);
            return result;
        }

        /// <summary>
        /// 查询病区以及该病区下生成的摆药单
        /// </summary>
        /// <returns>病区以及其摆药单信息</returns>
        public DataTable QueryIffield()
        {
            DataTable count = this.QueryListCount() ;
            if(count != null && count.Rows != null)
            {
                int countInt = count.Rows.Count;
                StringBuilder str = new StringBuilder("");
                for(int i = 1; i <= countInt; i++)
                {
                    str.Append(",decode(spa.arr_type,'" + i + "',spa.arrange_id,'') CREATE_ARRANGE_" + i);
                }
                string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryIffield, str.ToString());
                DataTable result = CJia.DefaultOleDb.Query(sql);
                return result;
            }
            return null;
        }

        /// <summary>
        /// 删除临时瓶贴表该用户的数据
        /// </summary>
        /// <param name="userid">用户id</param>
        public void DeleteTempLabel(long userid)
        {
            object[] paramars = new object[] { userid };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeleteTempLabel,paramars);
        }

        /// <summary>
        /// 插入临时表瓶贴数据
        /// </summary>
        /// <param name="iffieldId">选着的病区</param>
        /// <param name="userid">用户id</param>
        public void InsertTempLabel(List<string> iffieldId, long userid)
        {
            StringBuilder str = new StringBuilder("");
            if(iffieldId != null && iffieldId.Count > 0)
            {
                str.Append(" where illfield_id in (");
                foreach(string i in iffieldId)
                {
                    str.Append('\'');
                    str.Append(i.ToString());
                    str.Append('\'');
                    str.Append(",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(") ");
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlInsertTempLabel, str);
            object[] paramars = new object[] { userid ,userid};
            CJia.DefaultOleDb.Execute(sql, paramars);
        }

        /// <summary>
        /// 查询临时表瓶贴汇总
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>临时表瓶贴汇总</returns>
        public DataTable QueryTempLabelCollect(long userid)
        {
            object[] paramars = new object[] { userid };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelCollect, paramars);
            return result;
        }

        /// <summary>
        /// 查询临时表瓶贴详情
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>临时表瓶贴详情</returns>
        public DataTable QueryTempLabelDetail(long userid)
        {
            object[] paramars = new object[] { userid };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelDetail, paramars);
            return result;
        }

        /// <summary>
        /// 返回瓶贴表的seq
        /// </summary>
        /// <returns>摆药单id</returns>
        public int QueryArrangeSeq()
        {
            return int.Parse( CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryArrangeSeq).ToString());
        }
        
        /// <summary>
        /// 插入摆药单表
        /// </summary>
        /// <param name="ArrangeId">摆药单id</param>
        /// <param name="userid">用户id</param>
        /// <param name="illfieldId">病区id</param>
        /// <param name="illfieldName">病区名称</param>
        /// <param name="timeid">摆药id</param>
        public void InsertArrange(string tranid,long ArrangeId, long userid, string illfieldId,string illfieldName,string timeid)
        {
            object[] paramars = new object[] { ArrangeId, userid, illfieldId, illfieldName, userid, timeid };
            CJia.DefaultOleDb.Execute(tranid,CJia.PIVAS.Models.Label.SqlTools.SqlInsertArrange, paramars);
        }

        /// <summary>
        /// 插入瓶贴信息
        /// </summary>
        /// <param name="ArrangeId">瓶贴id</param>
        /// <param name="userid">用户id</param>
        /// <param name="illfieldId">病区id</param>
        public void InsertLabel(string tranid, long ArrangeId, long userid, string illfieldId)
        {
            object[] paramars = new object[] { ArrangeId, userid, illfieldId, userid };
            CJia.DefaultOleDb.Execute(tranid,CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabel, paramars);
        }

        /// <summary>
        /// 判断今天该批次是否已经生成摆药单
        /// </summary>
        /// <param name="timeid">摆药id</param>
        /// <param name="iffieldid">病区id</param>
        /// <returns>是否生成摆药单</returns>
        public bool QueryToDayIsGenLabel(string timeid,string iffieldid)
        {
            object[] paramars = new object[] { timeid, iffieldid };
            string str = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryIsGenArrange, paramars);
            if(str == "1")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据摆药单号查询出刚生成的瓶贴
        /// </summary>
        /// <param name="arrangeIds">摆药单id list</param>
        /// <returns>瓶贴</returns>
        public DataTable QueryGenLabel(List<long> arrangeIds)
        {
            StringBuilder str = new StringBuilder("");
            if(arrangeIds == null || arrangeIds.Count == 0)
            {
                str.Append("and 1 = 0");
            }
            else
            {
                str.Append("and spa.arrange_id in (");
                foreach(long lo in arrangeIds)
                {
                    str.Append(lo.ToString() + ",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(") ");
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryGenLabel, str.ToString());
            return  CJia.DefaultOleDb.Query(sql);
        }

    }
}