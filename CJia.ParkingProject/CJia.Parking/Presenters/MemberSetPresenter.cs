using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters
{
    public class MemberSetPresenter : CJia.Parking.Tools.Presenter<Models.MemberSetModel,Views.IMemberSetView>
    {
        public MemberSetPresenter(Views.IMemberSetView view)
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
        void view_OnInit(object sender, Views.MemSetArgs e)
        {
            BindGridMemType();
        }

        /// <summary>
        /// 绑定Grid会员类型
        /// </summary>
        void BindGridMemType()
        {
            View.ExeGridMemType(Model.QueryMemType());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.MemSetArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            DataTable dtSameMemType = Model.QueryIsExistSameMemType(e.MemType);
            if (dtSameMemType != null && dtSameMemType.Rows.Count > 0)
            {
                if ((long)dtSameMemType.Rows[0]["mem_type_id"] != e.MemTypeId)
                {
                    Message.Show("存在相同类型，请修改！");
                    return;
                }
            }
            if (e.MemTypeSaveStatus == "add")
            {
                if (Message.ShowQuery("确定要保存【" + e.MemType + "】?") == Message.Result.Ok)
                {
                    Model.InsertMemType(e.MemType,e.Price,userId);
                }
            }
            if (e.MemTypeSaveStatus == "update")
            {
                if (Message.ShowQuery("确定要修改【" + e.OldMemType + "】？") == Message.Result.Ok)
                {
                    Model.UpdateMemType(e.MemType,e.Price,userId,e.MemTypeId);
                }
            }
            BindGridMemType();
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDelete(object sender, Views.MemSetArgs e)
        {
            long userId = (long)User.UserData.Rows[0]["user_id"];
            if (Message.ShowQuery("确定要删除【" + e.OldMemType + "】") == Message.Result.Ok)
            {
                Model.DeleteMemType(userId,e.MemTypeId);
                BindGridMemType();
            }
        }
    }
}
