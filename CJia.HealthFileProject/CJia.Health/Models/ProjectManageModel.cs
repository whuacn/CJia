using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class ProjectManageModel : CJia.Health.Tools.Model
    {
        /// <summary>
        /// 根据关键字查询项目信息
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public DataTable QueryProject(string keyWord)
        {
            if (keyWord == "" || keyWord == null)
            {
                return CJia.DefaultOleDb.Query(SqlTools.SqlQueryAllProject);
            }
            else
            {
                object[] ob = new object[] { "%" + keyWord + "%", "%" + keyWord + "%", "%" + keyWord + "%" };
                return CJia.DefaultOleDb.Query(Models.SqlTools.SqlQueryProject, ob);
            }
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="ProName">项目名称</param>
        /// <param name="ProNo">项目编号</param>
        /// <param name="ProPinyin">项目拼音查询码</param>
        /// <returns></returns>
        public bool UpdateProject(string ProName, string ProNo, string ProPinyin, string UserID, string ProId, string isPrint, string shortKey, string isLook,string isExport)
        {
            object[] ob = new object[] { ProName, ProNo, ProPinyin, UserID, isPrint, shortKey, isLook,isExport, ProId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateProject, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 插入一条新项目
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="ProNo"></param>
        /// <param name="ProPinyin"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool InsertProject(string ProName, string ProNo, string ProPinyin, string UserId, string isPrint, string shortKey, string isLook,string isExport)
        {
            object[] ob = new object[] { ProName, ProNo, ProPinyin, UserId, isPrint, shortKey, isLook, isExport };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertProject, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条项目信息
        /// </summary>
        /// <param name="ProId"></param>
        /// <returns></returns>
        public bool DeleteProject(string UserId, string ProId)
        {
            object[] ob = new object[] { UserId, ProId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlDelectProject, ob) > 0 ? true : false;
        }

        /// <summary>
        /// 查询项目表里有几条与当前编号一样的数据
        /// </summary>
        /// <param name="ProNo">项目编号</param>
        /// <returns></returns>
        public int CheckProIsRepeat(string ProNo, string ProId)
        {
            object[] ob = new object[] { ProNo, ProId };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlCheckProIsRepeat, ob));
        }
        /// <summary>
        /// 判断是否为合法的快捷键（快捷键不能重复）,返回true表示有重复的
        /// </summary>
        /// <param name="shortKey"></param>
        /// <returns></returns>
        public bool IsShortKey(string shortKey)
        {
            object[] ob = new object[] { shortKey };
            DataTable data = CJia.DefaultOleDb.Query(SqlTools.SqlIsShortKey, ob);
            if (data != null && data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
