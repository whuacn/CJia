using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Models
{
    public class AreaManageModel : CJia.Parking.Tools.Model
    {
        #region 【楼层】
        /// <summary>
        /// 查询库中是否存在相同楼层编号
        /// </summary>
        /// <param name="floorNo"></param>
        /// <returns></returns>
        public DataTable QueryIsExistSameFloorNo(string floorNo)
        {
            object[] sqlParams = new object[] { floorNo };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameFloorNo,sqlParams);
        }

        /// <summary>
        /// 插入楼层表
        /// </summary>
        /// <param name="floorNo">楼层编号</param>
        /// <returns></returns>
        public bool InsertFloor(string floorNo,long userId)
        {
            object[] sqlParams = new object[] { floorNo ,userId};
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertFloor, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询楼层数据表有效数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryFloor()
        {
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectFloor);
        }

        /// <summary>
        /// 删除时楼层时查询区域信息表中是否有存在正在使用的楼层流水号
        /// </summary>
        /// <param name="floorId">索要删除楼层流水号</param>
        /// <returns></returns>
        public DataTable QueryIsExistUsingFloorIdWhenDelete(long floorId)
        {
            object[] sqlParams = new object[] { floorId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistUsingFloorIdWhenDelete,sqlParams);
        }

        /// <summary>
        /// 删除选中楼层
        /// </summary>
        /// <param name="floorId">楼层流水号</param>
        /// <returns></returns>
        public bool DeleteFloor(long userId,long floorId)
        {
            object[] sqlParams = new object[]{ userId,floorId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteFloor,sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改楼层数据表
        /// </summary>
        /// <param name="floorNo"></param>
        /// <param name="floorId"></param>
        /// <returns></returns>
        public bool UpdateFloor(string floorNo,long userId, long floorId)
        {
            object[] sqlParams = new object[] { floorNo, userId,floorId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateFloor,sqlParams) > 0 ? true : false;
        }
        #endregion

        #region【区域】
        /// <summary>
        /// 查询库中是否存在相同区域编号+楼层号
        /// </summary>
        /// <param name="areaNo"></param>
        /// <returns></returns>
        public DataTable QueryIsSameAreaAndFloor(string areaNo, long floorId)
        {
            object[] sqlParams = new object[] { areaNo,floorId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameAreaNo, sqlParams);
        }

        /// <summary>
        /// 插入区域表
        /// </summary>
        /// <param name="areaNo">区域编号</param>
        /// <param name="floorId">楼层编号</param>
        /// <returns></returns>
        public bool InsertArea(string areaNo, long floorId ,long userId)
        {
            object[] sqlParams = new object[] { areaNo, floorId, userId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertArea, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询区域数据表有效数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryArea(long floorId)
        {
            object[] sqlParams = new object[] { floorId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectArea,sqlParams);
        }

        /// <summary>
        /// 删除时区域时查询车位信息表中是否有存在正在使用的区域流水号
        /// </summary>
        /// <param name="areaId">所要删除区域流水号</param>
        /// <returns></returns>
        public DataTable QueryIsExistUsingAreaIdWhenDelete(long areaId)
        {
            object[] sqlParams = new object[] { areaId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistUsingAreaIdWhenDelete, sqlParams);
        }

        /// <summary>
        /// 删除选中区域
        /// </summary>
        /// <param name="floorId">区域流水号</param>
        /// <returns></returns>
        public bool DeleteArea(long userId,long areaId)
        {
            object[] sqlParams = new object[] { userId,areaId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteArea, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改区域数据
        /// </summary>
        /// <param name="areaNo"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public bool UpdateArea(string areaNo,long userId, long areaId)
        {
            object[] sqlParams = new object[] { areaNo, userId,areaId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateArea,sqlParams) > 0 ? true : false;
        }
        #endregion

        #region 【车位】

        /// <summary>
        /// 查询库中是否存在相同车位编号
        /// </summary>
        /// <param name="parkNo"></param>
        /// <returns></returns>
        public DataTable QueryIsSameParkNo(string parkNo)
        {
            object[] sqlParams = new object[] { parkNo };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectIsExistSameParkNo, sqlParams);
        }

        /// <summary>
        /// 插入车位表
        /// </summary>
        /// <param name="parkNo">车位编号</param>
        /// <param name="areaId">区域编号</param>
        /// <param name="cameraNo">摄像机编号</param>
        /// <returns></returns>
        public bool InsertParkInfo(string parkNo, long areaId , string cameraNo,long userId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(parkNo);
            sqlParams.Add(areaId);
            sqlParams.Add(cameraNo);
            sqlParams.Add(userId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlInsertParkInfo, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 查询车位数据表有效数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryParkInfo(long areaId)
        {
            object[] sqlParams = new object[] { areaId };
            return CJia.DefaultPostgre.Query(SqlTools.SqlSelectParkInfo, sqlParams);
        }

        /// <summary>
        /// 删除选中车位
        /// </summary>
        /// <param name="parkId">车位流水号</param>
        /// <returns></returns>
        public bool DeletePark(long userId,long parkId)
        {
            object[] sqlParams = new object[] { userId,parkId };
            return CJia.DefaultPostgre.Execute(SqlTools.SqlDeleteParkInfo, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改区域数据
        /// </summary>
        /// <param name="parkNo"></param>
        /// <param name="cameraNo"></param>
        /// <param name="areaId"></param>
        /// <param name="parkId"></param>
        /// <returns></returns>
        public bool UpdateParkInfo(string parkNo,string cameraNo , long userId , long parkId)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(parkNo);
            sqlParams.Add(cameraNo);
            sqlParams.Add(userId);
            sqlParams.Add(parkId);
            return CJia.DefaultPostgre.Execute(SqlTools.SqlUpdateParkInfo, sqlParams) > 0 ? true : false;
        }
        #endregion
    }
}
