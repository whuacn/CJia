using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 添加用户P层
    /// </summary>
    public class AddUserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddUserModel,CJia.PIVAS.Views.DataManage.IAddUserView>
    {
        public AddUserPresenter(Views.DataManage.IAddUserView view)
            : base(view)
        {
            this.View.OnLeave += View_OnLeave;
            this.View.OnaddUser += View_OnaddUser;
        }

        /// <summary>
        /// 工号输入框失去焦点 判断这个工号在配置中心是否有重复和判断在His中是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLeave(object sender, Views.DataManage.addUsereventArgs e)
        {
            bool isUserRepeat=this.Model.IsUserRepeat(e.UserNo);
            if (isUserRepeat)
            {
                this.View.ExeGetFocus();
            }
            
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnaddUser(object sender, Views.DataManage.addUsereventArgs e)
        {
            bool IsInsert = this.Model.InsertUser(e.UserNo, e.UserName, e.Pwd,e.DeptId, e.DeptName, e.UserId);
            if (IsInsert)
            {
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("添加失败");
                this.View.ExeGetFocus();
            }
        }

        protected override void OnInitView()
        {

        }

    }
}