using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 用户维护的P层
    /// </summary>
    public class UserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.UserModel,CJia.PIVAS.Views.DataManage.IUserView>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="view"></param>
        public UserPresenter(Views.DataManage.IUserView view)
            : base(view)
        {
            this.View.OnLoadData += View_OnLoadData;
            this.View.OnDeleteUser += View_OnDeleteUser;
        }

        //初始化gridcontrol数据
        void View_OnLoadData(object sender, Views.DataManage.UserEventArgs e)
        {
            DataTable dtAllUser = this.Model.QueryAllUser();
            this.View.ExeDataBind(dtAllUser);
        }

        //删除用户  把状态给我0
        void View_OnDeleteUser(object sender, Views.DataManage.UserEventArgs e)
        {
            bool IsDelete = this.Model.DeleteUser(e.CreateBy, e.UserId);
            if (IsDelete)
            {
                //this.View.ShowMessage("删除成功");
            }
            else
            {
                this.View.ShowMessage("删除失败");
            }
        }

        //初始化View层
        protected override void OnInitView()
        {

        }

    }
}