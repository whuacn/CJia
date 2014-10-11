using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IAreaManageView : CJia.Parking.Tools.IView
    {
        #region 【楼层】
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnInit;

        /// <summary>
        /// 保存楼层信息
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnFloorSave;

        /// <summary>
        /// 单击Grid楼层事件
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnGridFloorClick;

        /// <summary>
        /// 删除楼层
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnFloorDelete;

        /// <summary>
        /// 绑定楼层
        /// </summary>
        /// <param name="dtFloor"></param>
        void ExeBindGridFloor(DataTable dtFloor);
        #endregion

        #region 【区域】
        /// <summary>
        /// 保存区域信息
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnAreaSave;

        /// <summary>
        /// 删除区域
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnAreaDelete;

        /// <summary>
        /// 绑定区域
        /// </summary>
        /// <param name="dtFloor"></param>
        void ExeBindGridArea(DataTable dtArea);
        #endregion

        #region 【车位】
        /// <summary>
        /// 保存车位信息
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnParkSave;

        /// <summary>
        /// 删除车位
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnParkDelete;

        /// <summary>
        /// 单击Grid区域事件
        /// </summary>
        event EventHandler<Views.AreaManageArgs> OnGridAreaClick;

        /// <summary>
        /// 帮定的那个车位
        /// </summary>
        /// <param name="dtPark"></param>
        void ExeBindGridPark(DataTable dtPark);
        #endregion
    }

    public class AreaManageArgs : EventArgs
    {
        /// <summary>
        /// 楼层流水号
        /// </summary>
        public long FloorId;

        /// <summary>
        /// 楼层编号
        /// </summary>
        public string FloorNo;

        /// <summary>
        /// 修改或删除前数据库中所存楼层编号（原楼层编号）
        /// </summary>
        public string OldFloorNo;

        /// <summary>
        /// 区域流水号
        /// </summary>
        public long AreaId;

        /// <summary>
        /// 区域编号
        /// </summary>
        public string AreaNo;

        /// <summary>
        ///  修改或删除前数据库中所存区域编号（原区域编号）
        /// </summary>
        public string OldAreaNo;

        /// <summary>
        /// 车位流水号
        /// </summary>
        public long ParkId;
        
        /// <summary>
        /// 车位编号
        /// </summary>
        public string ParkNo;

        /// <summary>
        ///  修改或删除前数据库中所存车位编号（原车位编号）
        /// </summary>
        public string OldParkNo;

        /// <summary>
        /// 摄像头编号
        /// </summary>
        public string CameraNo;


        /// <summary>
        /// 楼层保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string FloorSaveStatus = "add";

        /// <summary>
        /// 区域保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string AreaSaveStatus = "add";

        /// <summary>
        /// 车位保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string ParkSaveStatus = "add";
    }
}
