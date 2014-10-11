using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 时间维护的M层
    /// </summary>
    public class RedDrugModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 查询时间数据详情（冲药，拉单）
        /// </summary>
        /// <param name="whichpage">要配置的页面 1代表拉单 2代表冲药</param>
        /// <returns></returns>
        public DataTable GetRedDrug(string whichpage)
        {
            object[] ob = new object[] { whichpage };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryTimeSet, ob);
        }


        /// <summary>
        /// 删除TimeSet选中的数据 true为删除成功
        /// </summary>
        /// <param name="updateBy">修改人</param>
        /// <param name="timeId">TimeId</param>
        /// <returns></returns>
        public bool DeleteTimeSet(long updateBy,long timeId)
        {
            object[] ob = new object[] { updateBy,timeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDeleteTimeSet, ob) > 0 ? true : false;
        }
    
    }
}