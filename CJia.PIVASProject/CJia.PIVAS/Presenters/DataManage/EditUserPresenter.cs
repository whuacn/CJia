using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// 修改用户信息P层
    /// </summary>
    public class EditUserPresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.EditUserModel,CJia.PIVAS.Views.DataManage.IEditUserView>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="view"></param>
        public EditUserPresenter(Views.DataManage.IEditUserView view)
            : base(view)
        {
            this.View.OnUpdateUser += View_OnUpdateUser;
            this.View.OnCheckPwd += View_OnCheckPwd;
        }

        /// <summary>
        /// 判断旧密码是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCheckPwd(object sender, Views.DataManage.EditUsereventArgs e)
        {
            bool isOldPwdOk = this.Model.CheckOldPwd(e.OldPwd,e.UserId);
            this.View.ExeIsPwdOk(isOldPwdOk);
        }

        /// <summary>
        /// 修改个人细细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateUser(object sender, Views.DataManage.EditUsereventArgs e)
        {
            bool isUpdate = this.Model.UpdateUser(e.NewPwd,e.UserId);
            if (isUpdate)
            {
                //this.View.ShowMessage("修改成功");
                this.View.CloseWindow();
            }
            else
            {
                this.View.ShowMessage("修改失败");
            }
        }

        protected override void OnInitView()
        {

        }

    }
}