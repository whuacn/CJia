using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class MemberPresenter : CJia.Parking.Tools.Presenter<Models.MemberModel,Views.IMemberView>
    {
        public MemberPresenter(Views.IMemberView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
            view.OnDelete += view_OnDelete;
        }
               
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.MemberArgs e)
        {
            BindGridMember();
        }

        /// <summary>
        /// 绑定会员Grid信息
        /// </summary>
        void BindGridMember()
        {
            View.ExeGridMember(Model.QueryMember());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.MemberArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtSameMem = Model.QueryIsExistSameMemNo(e.MemNo);
            if (dtSameMem != null && dtSameMem.Rows.Count > 0)
            {
                if ((long)dtSameMem.Rows[0]["mem_id"] != e.MemId)
                {
                    Message.Show("存在相同会员编号，请修改！");
                    return;
                }
            }

            dtSameMem = Model.QueryIsExistSamePlateNo(e.PlateNo);
            if (dtSameMem != null && dtSameMem.Rows.Count > 0)
            {
                if ((long)dtSameMem.Rows[0]["mem_id"] != e.MemId)
                {
                    Message.Show("存在相同车牌号，请修改！");
                    return;
                }
            }

            if (e.MemSaveStatus == "add")
            {
                if (Message.ShowQuery("确定要保存【" + e.MemName + "】+【" + e.PlateNo + "】？") == Message.Result.Ok)
                {
                    Model.InsertMember(e.MemNo,e.MemName,e.PlateNo,userId);
                }
            }
            if (e.MemSaveStatus == "update")
            {
                if (Message.ShowQuery("确定要修改【" + e.OldMemName + "】+【" + e.OldPlateNo + "】？") == Message.Result.Ok)
                {
                    Model.UpdateMember(e.MemNo,e.MemName,e.PlateNo,userId,e.MemId);
                }
            }
            BindGridMember();
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDelete(object sender, Views.MemberArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            if (Message.ShowQuery("确定删除【" + e.OldMemName + "】") == Message.Result.Ok)
            {
                Model.DeleteMember(userId,e.MemId);
                BindGridMember();
            }
        }
    }
}
