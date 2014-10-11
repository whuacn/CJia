using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// 修改时间数据的M层
    /// </summary>
    public class EditTimeSetModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// 判断修改时间是否有重叠 返回true表示有重叠 true表示没有重叠
        /// </summary>
        /// <param name="type">1代表拉单 2代表冲药</param>
        /// <param name="timeId"></param>
        /// <param name="startTime">开始时间</param>
        /// <param name="overTime">截止时间</param>
        /// <returns></returns>
        public bool IsUpdateRepeat(string type, long timeId, string startTime, string overTime)
        {
            object[] ob = new object[] { type, type, type, timeId, startTime, overTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsUpdateRepeat,ob) == "1" ? false : true;
        }

        /// <summary>
        /// 添加时间时 判断要修改的时间段与其他的时间段是否重叠  返回true表示有重叠 true表示没有重叠
        /// </summary>
        /// <param name="type">1代表拉单 2代表冲药</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="overTime">截止时间</param>
        /// <returns></returns>
        public bool isInsertRepeat(string type, string startTime, string overTime)
        {
            object[] ob = new object[] { type, startTime, startTime, overTime, overTime, startTime, overTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsInsertRepeat, ob) == "1" ? true : false;
        }

        /// <summary>
        /// 修改TimeSet表 true表示修改成功
        /// </summary>
        /// <param name="timeName">时间名称</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="overTime">截止时间</param>
        /// <param name="userId">当前登录用户Id</param>
        /// <param name="timeId">时间ID</param>
        /// <returns></returns>
        public bool UpdateTimeSet( string timeName, string startTime, string overTime, long userId, long timeId)
        {
            //if (overTime == null) overTime = "23:59";
            object[] ob = new object[] { timeName, startTime, overTime, userId, timeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateTimeSet, ob) > 0 ? true : false;
        }


        /// <summary>
        /// 添加TimeSet表
        /// </summary>
        /// <param name="timeName">时间名称</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="overTime">截止时间</param>
        /// <param name="whichpage">哪个页面 1代表拉单 2代表冲药</param>
        /// <param name="updateBy">修改人</param>
        /// <returns></returns>
        public bool InsertTimeSet(string timeName, string startTime, string overTime, int whichpage, long updateBy )
        {
            object[] ob = new object[] { timeName, startTime, overTime, whichpage, updateBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertTimeSet, ob) > 0 ? true : false;
        }
    }
}