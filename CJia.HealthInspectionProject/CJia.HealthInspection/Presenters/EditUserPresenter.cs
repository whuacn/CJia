using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditUserPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditUserModel,Views.IEditUser>
    {
        public EditUserPresenter(Views.IEditUser view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.EditUserArgs e)
        {
            View.ExeBindControl(Model.QueryUserById(e.UserId));
            View.ExeCheckBoxList(Model.QueryRoleByOrganId(e.LoginUser.Rows[0]["organ_id"].ToString()),Model.QueryUserOwnRoleByUserId(e.UserId));
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditUserArgs e)
        {
            List<object> sqlParams = new List<object>();
            if (Model.QueryIsExistSameUserNoUpdate(e.UserId,e.UserNo))
            {
                View.ExeMessageBox("存在相同用户名，请修改...",false);
                return;
            }

            string loginUserId = e.LoginUser.Rows[0]["user_id"].ToString();
            bool isSuccess = false;
            sqlParams.Add(e.UserNo);
            sqlParams.Add(e.UserName);
            sqlParams.Add(loginUserId);
            sqlParams.Add(e.UserId);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                if (Model.UpdateUser(trans.ID,sqlParams))
                {
                    Model.DeleteUserRoleByUserId(trans.ID, loginUserId,e.UserId);
                    for (int i = 0; i < e.RoleArr.Count; i++)
                    {
                        Model.InsertUserRole(trans.ID, e.UserId, e.RoleArr[i],loginUserId);
                    }

                    View.ExeMessageBox("保存成功！",true);
                    isSuccess = true;
                }
                trans.Complete();
            }
            if (!isSuccess)
            {
                View.ExeMessageBox("保存失败,请联系管理员...",false);
            }
           
        }
    }
}
