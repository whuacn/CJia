using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Parking.Presenters
{
    public class AreaManagePresenter : CJia.Parking.Tools.Presenter<Models.AreaManageModel,Views.IAreaManageView>
    {
        public AreaManagePresenter(Views.IAreaManageView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnFloorSave += view_OnFloorSave;
            view.OnFloorDelete += view_OnFloorDelete;
            view.OnGridFloorClick += view_OnGridFloorClick;
            view.OnAreaSave += view_OnAreaSave;
            view.OnAreaDelete += view_OnAreaDelete;

            view.OnGridAreaClick += view_OnGridAreaClick;
            view.OnParkSave += view_OnParkSave;
            view.OnParkDelete += view_OnParkDelete;

        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.AreaManageArgs e)
        {
            BindGridFloor();
        }

        #region 【楼层】

        /// <summary>
        /// 绑定界面楼层Grid
        /// </summary>
        void BindGridFloor()
        {
            View.ExeBindGridFloor(Model.QueryFloor());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnFloorSave(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsSameFloorNo = Model.QueryIsExistSameFloorNo(e.FloorNo);
            if (dtIsSameFloorNo != null && dtIsSameFloorNo.Rows.Count > 0)
            {
                if (Convert.ToInt64(dtIsSameFloorNo.Rows[0]["floor_id"]) != e.FloorId)
                {
                    Message.Show("存在相同【楼层编号】！");
                    return;
                }
            }
            // 如果是新增
            if (e.FloorSaveStatus == "add")
            {
                if (Message.ShowQuery("确定要保存【" + e.FloorNo + "】？") == Message.Result.Ok)
                {
                    Model.InsertFloor(e.FloorNo,userId);
                }
            }
            if (e.FloorSaveStatus == "update")
            {
                if (Message.ShowQuery("确定要修改【" + e.OldFloorNo + "】？") == Message.Result.Ok)
                {
                    Model.UpdateFloor(e.FloorNo,userId, e.FloorId);
                }
            }
            BindGridFloor();
        }

        void view_OnFloorDelete(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsExistFloor = Model.QueryIsExistUsingFloorIdWhenDelete(e.FloorId);
            if (dtIsExistFloor != null && dtIsExistFloor.Rows.Count > 0)
            {
                Message.Show("请先删除【" + e.OldFloorNo + "】中所有区域！");
                return;
            }
            else
            {
                if (Message.ShowQuery("确定删除【" + e.OldFloorNo + "】") == Message.Result.Ok)
                {
                    Model.DeleteFloor(userId, e.FloorId);
                    BindGridFloor();
                }
            }
        }

        void view_OnGridFloorClick(object sender, Views.AreaManageArgs e)
        {
            BindGridArea(e);
            BindGridPark(e);
        }
        #endregion

        #region【区域】
      
        /// <summary>
        /// 绑定界面Grid区域
        /// </summary>
        void BindGridArea(Views.AreaManageArgs e)
        {
            View.ExeBindGridArea(Model.QueryArea(e.FloorId));
        }

        void view_OnAreaSave(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsSameAreaAndFloor = Model.QueryIsSameAreaAndFloor(e.AreaNo, e.FloorId);
            if (dtIsSameAreaAndFloor != null && dtIsSameAreaAndFloor.Rows.Count > 0)
            {
                if (Convert.ToInt64(dtIsSameAreaAndFloor.Rows[0]["area_id"]) != e.AreaId && Convert.ToInt64(dtIsSameAreaAndFloor.Rows[0]["floor_id"]) != e.FloorId)
                {
                    Message.Show("存在相同【区域编号】+【楼层编号】！");
                    return;
                }
            }
            if (e.AreaSaveStatus == "add")
            {
                if (Message.ShowQuery("确定要保存【" + e.AreaNo + "】+【" + e.OldFloorNo + "】？") == Message.Result.Ok)
                {
                    Model.InsertArea(e.AreaNo, e.FloorId,userId);
                }
            }
            if(e.AreaSaveStatus == "update")
            {
                if (Message.ShowQuery("确定要修改【" + e.OldAreaNo + "】+【" + e.OldFloorNo + "】？") == Message.Result.Ok)
                {
                    Model.UpdateArea(e.AreaNo,userId, e.AreaId);
                }
            }
            BindGridArea(e);
        }

        void view_OnAreaDelete(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsExistArea = Model.QueryIsExistUsingAreaIdWhenDelete(e.AreaId);
            if (dtIsExistArea != null && dtIsExistArea.Rows.Count > 0)
            {
                Message.Show("请先删除【" + e.OldAreaNo + "】+【" + e.OldFloorNo + "】中所有车位");
                return;
            }
            else
            {
                if (Message.ShowQuery("确定要删除【" + e.OldAreaNo + "】+【" + e.OldFloorNo + "】？") == Message.Result.Ok)
                {
                    Model.DeleteArea(userId, e.AreaId);
                    BindGridArea(e);
                }
            }           
        }
        #endregion

        #region 【车位】
        void BindGridPark(Views.AreaManageArgs e)
        {
            View.ExeBindGridPark(Model.QueryParkInfo(e.AreaId));
        }

        /// <summary>
        /// 单击Grid区域，查询绑定车位Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnGridAreaClick(object sender, Views.AreaManageArgs e)
        {
            BindGridPark(e);
        }

        /// <summary>
        /// 保存车位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnParkSave(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtIsExistSameParkNo = Model.QueryIsSameParkNo(e.ParkNo);
            if (dtIsExistSameParkNo != null && dtIsExistSameParkNo.Rows.Count > 0)
            {
                if (Convert.ToInt64(dtIsExistSameParkNo.Rows[0]["park_id"]) != e.ParkId)
                {
                    Message.Show("存在相同【车位编号】！");
                    return;
                }
            }
            if (e.ParkSaveStatus == "add")
            {
                if (Message.ShowQuery("确定要保存【" + e.ParkNo + "】？") == Message.Result.Ok)
                {
                    Model.InsertParkInfo(e.ParkNo,e.AreaId,e.CameraNo,userId);
                }
            }
            if (e.ParkSaveStatus == "update")
            {
                if (Message.ShowQuery("确定要修改【" + e.OldParkNo + "】？") == Message.Result.Ok)
                {
                    Model.UpdateParkInfo(e.ParkNo,e.CameraNo,userId,e.ParkId);
                }
            }
            BindGridPark(e);
        }
       
        /// <summary>
        /// 删除车位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnParkDelete(object sender, Views.AreaManageArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            if (Message.ShowQuery("确定要删除【" + e.OldParkNo + "】？") == Message.Result.Ok)
            {
                Model.DeletePark(userId,e.ParkId);
            }
            BindGridPark(e);
        }
        #endregion
    }
}
